using UnityEngine;
using System.Collections;
using UnityEngine.VR;

namespace SeanStandardScript
{
    public class VRRenderScaleSettings : MonoBehaviour
    {
        [SerializeField]
        private float m_RenderScale = 1f;              //The render scale. Higher numbers = better quality, but trades performance

        protected void Awake()
        {
            VRSettings.renderScale = m_RenderScale;
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                m_RenderScale += 0.1f;
                VRSettings.renderScale = m_RenderScale;
                DebugHUD.Instance.Log("RenderScale="+m_RenderScale, 3);
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                m_RenderScale -= 0.1f;
                VRSettings.renderScale = m_RenderScale;
                DebugHUD.Instance.Log("RenderScale=" + m_RenderScale, 3);
            }
        }
    }
}