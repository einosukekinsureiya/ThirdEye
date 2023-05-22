using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using static ThirdEye.ThirdEyePlugin;
using SkillManager;
using UnityEngine;

namespace ThirdEye.Patches
{
    [HarmonyPatch(typeof(Minimap), nameof(Minimap.UpdateMap))]
    static class Minimap_UpdateMap_Patch
    {
        static void Prefix(Minimap __instance)
        {
            //Allow additional map zoom if set in the config.
            if (AllowAdditionalZoom.Value == Toggle.On)
            {
                __instance.m_minZoom = MiniMapZoomLevel.Value;
            }
        }
    }

    [HarmonyPatch]
    static class EnvManOnStartEndDayPatch
    {
        [HarmonyPatch(typeof(EnvMan), nameof(EnvMan.OnMorning))]
        [HarmonyPatch(typeof(EnvMan), nameof(EnvMan.OnEvening))]
        static void Postfix(EnvMan __instance)
        {
            // Reward the player for staying in the game to see a new day or night. Level up ThirdEye
            Player.m_localPlayer.RaiseSkill("ThirdEye");
        }
    }


    [HarmonyPatch(typeof(Minimap), nameof(Minimap.UpdateEventPin))]
    public static class UpdateEventPinPatch
    {
        public static void Postfix(Minimap __instance)
        {
            //Skip this entirely if disabled in the config.
            if (ShowMinimapIcons.Value == Toggle.Off) return;
            //Populate the list of current HUD characters.
            List<Character> guysList = (from hud in EnemyHud.instance.m_huds.Values
                where hud.m_character != null && hud.m_hoverTimer < EnemyHud.instance.m_hoverShowDuration
                select hud.m_character).ToList();
            //Add minimap pins if they haven't been added already.
            foreach (Character character in from character in guysList
                     where character is not Player
                     let flag = __instance.m_pins.Any(pin =>
                         pin.m_name.Equals(
                             character.GetHoverName() + " [Health: " + character.GetHealth() + "] \nUID: " +
                             character.GetZDOID()))
                     where !flag
                     select character)
            {
                __instance.AddPin(character.GetCenterPoint(), Minimap.PinType.RandomEvent,
                    character.GetHoverName() + " [Health: " + character.GetHealth() + "] \nUID: " +
                    character.GetZDOID(), false, false);
            }

            //Remove minimap pins which are not needed anymore.
            List<Minimap.PinData> removePins = new();

            foreach (Minimap.PinData pin in __instance.m_pins)
            {
                if (pin.m_type != Minimap.PinType.RandomEvent) continue;
                bool flag = false;
                foreach (Character character in guysList.Where(character =>
                             pin.m_name.Equals(character.GetHoverName() + " [Health: " + character.GetHealth() +
                                               "] \nUID: " + character.GetZDOID())))
                {
                    pin.m_pos.x = character.GetCenterPoint().x;
                    pin.m_pos.y = character.GetCenterPoint().y;
                    pin.m_pos.z = character.GetCenterPoint().z;
                    flag = true;
                    break;
                }

                if (!flag)
                {
                    removePins.Add(pin);
                }
            }

            foreach (Minimap.PinData pin in removePins)
            {
                __instance.RemovePin(pin);
                ThirdEyeLogger.LogDebug("removing pin for " + pin.m_name);
            }
        }
    }
}