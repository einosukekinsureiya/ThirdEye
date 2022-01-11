using System;
using HarmonyLib;

namespace ThirdEye.Patches

{
    [HarmonyPatch(typeof(EnemyHud), nameof(EnemyHud.TestShow))]
    public static class TestShowPatch
    {
        public static void Prefix(EnemyHud __instance, Character c)
        {
            //Sets the enemy detection range to the game's default, multiplied by the config value.
            __instance.m_maxShowDistance = ThirdEyePlugin.BaseRange.Value;
            //Gets the player's ThirdEye skill level and adds it to the default max distance you can be away from creatures to be able to view their health bar.
            if (Player.m_localPlayer == null || !Player.m_localPlayer.GetSkills().m_skillData
                    .ContainsKey((Skills.SkillType)Math.Abs("ThirdEye".GetStableHashCode()))) return;
            Player.m_localPlayer.GetSkills().m_skillData
                .TryGetValue((Skills.SkillType)Math.Abs("ThirdEye".GetStableHashCode()), out Skills.Skill value);
            if (value != null)
            {
                //The game's base value is 30f, this mod makes it scale up to 60f at max Third Eye skill.
                __instance.m_maxShowDistance +=
                    (value.m_level * 0.01F) * 30F * ThirdEyePlugin.SkillMultiplier.Value;
            }
        }
    }
}