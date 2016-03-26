using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace SeanStandardScript
{
    public class FPSCounter : MonoBehaviour
    {
        [Header("Where to log FPS")]
        public bool DumpToDebugLog;
        public bool UseDebugHUD;
        public bool SetUIText;
        public Text UiText;

        [Header("FPS Logging Settings")] public int TimesToUpdateFPSPerSecond;
        public bool SmoothFPS;

        [Header("FPS")] public string FPS;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(UpdateFPS());
        }

        private IEnumerator UpdateFPS()
        {
            while (true)
            {
                FPS = string.Format("FPS:{0}", (int) (1.0f/(SmoothFPS ? Time.smoothDeltaTime : Time.deltaTime)));
                if (DumpToDebugLog)
                {
                    Debug.Log(FPS);
                }
                if (UseDebugHUD)
                {
                    DebugHUD.Instance.Log(FPS, 0);
                }
                if (SetUIText)
                {
                    UiText.text = FPS;
                }
                yield return new WaitForSeconds(1f/TimesToUpdateFPSPerSecond);
            }
        }
    }
}