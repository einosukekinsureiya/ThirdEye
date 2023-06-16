using System.Linq;
using System.Reflection;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace ThirdEye.Util
{
    public class ZNetSceneGrabber
    {
        private static Transform _visualEffect = null!;
        private static GameObject _audioEffect = null!;
        private static GameObject WhistleGlobal;


        //Used to get the shockwave effect.
        public static Transform GetVisualEffect()
        {
            if (_visualEffect == null)
            {
                Color maxColor = new();
                GameObject fetch = ZNetScene.instance.GetPrefab("vfx_sledge_hit");
                Transform fetch2 = fetch.transform.Find("waves");
                _visualEffect = Object.Instantiate(fetch2);
                MainModule mainModule = _visualEffect.GetComponent<ParticleSystem>().main;
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
            MainModule main = _visualEffect.GetComponent<ParticleSystem>().main;
            main.startSizeMultiplier = EnemyHud.instance.m_maxShowDistance * 2F;
            return _visualEffect;
        }

        //Used to get the sound effect.
        
        
        /*
        internal static AssetBundle? LoadAssetBundle(string bundleName)
        {
            var resource = typeof(ThirdEye.ThirdEyePlugin).Assembly.GetManifestResourceNames().Single
                (s => s.EndsWith(bundleName));
            using var stream = typeof(ThirdEye.ThirdEyePlugin).Assembly.GetManifestResourceStream(resource);
            return AssetBundle.LoadFromStream(stream);
        }

        internal static void LoadAssets(AssetBundle? bundle, ZNetScene zNetScene)
        {
            var tmp = bundle?.LoadAllAssets();
            if (zNetScene.m_prefabs.Count <= 0) return;
            if (tmp == null) return;
            foreach (var o in tmp)
            {
                var obj = (GameObject)o;
                zNetScene.m_prefabs.Add(obj);
                var hashcode = obj.GetHashCode();
                zNetScene.m_namedPrefabs.Add(hashcode, obj);
            }
        }

        */
        private static AssetBundle GetAssetBundleFromResources(string filename)
        {
            var execAssembly = Assembly.GetExecutingAssembly();
            var resourceName = execAssembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(filename));

            using (var stream = execAssembly.GetManifestResourceStream(resourceName))
            {
                return AssetBundle.LoadFromStream(stream);
            }
        }
        
        public static void LoadAssets()
        {
            var assetBundle = GetAssetBundleFromResources("whistle");
            WhistleGlobal = assetBundle.LoadAsset<GameObject>("Whistle");
            assetBundle?.Unload(false);
        }


        public static GameObject GetAudioEffect()
        {

           /* if (_audioEffect != null) return _audioEffect;
            GameObject fetch = ZNetScene.instance.GetPrefab("sfx_lootspawn");
            _audioEffect = Object.Instantiate(fetch);
            ZSFX audioModule = _audioEffect.GetComponent<ZSFX>();*/

            if (_audioEffect != null) return _audioEffect;
            /*GameObject fetch*/_ = ZNetScene.instance.GetPrefab("Whistle");
            _audioEffect = Object.Instantiate(WhistleGlobal);
            ZSFX audioModule = _audioEffect.GetComponent<ZSFX>();

            //Adjusting the audio settings to give it some cool reverb.
            audioModule.m_minPitch = 0.8F;
            audioModule.m_maxPitch = 0.85F;
            audioModule.m_distanceReverb = true;
            audioModule.m_vol = 1F;
            audioModule.m_useCustomReverbDistance = true;
            audioModule.m_customReverbDistance = 10F;
            audioModule.m_delay = 1;
            audioModule.m_time = 1;

            return _audioEffect;
        }
    }
}