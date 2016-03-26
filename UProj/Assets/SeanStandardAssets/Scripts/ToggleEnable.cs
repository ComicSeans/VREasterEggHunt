using UnityEngine;
using System.Collections;

namespace SeanStandardScript
{
    public class ToggleEnable : MonoBehaviour
    {
        [SerializeField]
        private MonoBehaviour target;
        [SerializeField]
        private KeyCode toggleKey;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(toggleKey))
            {
                target.enabled = !target.enabled;
            }
        }
    }
}