using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace ThirdEye.Util
{
    public class ZNetSceneGrabber
    {
        private static Transform visualEffect;
        private static GameObject audioEffect;

        //Used to get the shockwave effect.
        public static Transform GetVisualEffect()
        {
            if (visualEffect == null)
            {
                Color maxColor = new();
                GameObject fetch = ZNetScene.instance.GetPrefab("vfx_sledge_hit");
                Transform fetch2 = fetch.transform.Find("waves");
                visualEffect = Object.Instantiate(fetch2);
                MainModule mainModule = visualEffect.GetComponent<ParticleSystem>().main;
                mainModule.simulationSpeed = 0.2F;
                mainModule.startSize = 0.1F;
                if (ColorUtility.TryParseHtmlString(ThirdEyePlugin.VisualEffectColor.Value, out Color color))
                {
                    maxColor = color;
                }

                mainModule.startColor = new MinMaxGradient
                    { colorMax = maxColor, color = maxColor, colorMin = color };
            }

            //Resize the effect every time to match your Third Eye skill.
            MainModule main = visualEffect.GetComponent<ParticleSystem>().main;
            main.startSizeMultiplier = EnemyHud.instance.m_maxShowDistance * 2F;
            return visualEffect;
        }

        //Used to get the sound effect.
        public static GameObject GetAudioEffect()
        {
            if (audioEffect != null) return audioEffect;
            GameObject fetch = ZNetScene.instance.GetPrefab("sfx_lootspawn");
            audioEffect = Object.Instantiate(fetch);
            ZSFX audioModule = audioEffect.GetComponent<ZSFX>();

            //Adjusting the audio settings to give it some cool reverb.
            audioModule.m_minPitch = 0.8F;
            audioModule.m_maxPitch = 0.85F;
            audioModule.m_distanceReverb = true;
            audioModule.m_vol = 1F;
            audioModule.m_useCustomReverbDistance = true;
            audioModule.m_customReverbDistance = 10F;
            audioModule.m_delay = 1;
            audioModule.m_time = 1;

            return audioEffect;
        }
    }
}