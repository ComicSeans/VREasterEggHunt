using UnityEngine;
using System.Collections;

namespace SeanStandardScript
{
    public class CursorCapture : MonoBehaviour
    {
        [SerializeField] private bool CursorVisible = true;
        [SerializeField] private CursorLockMode CursorLockMode;
        [SerializeField] private KeyCode MouseEscapeKey;

        private void Awake()
        {
            Cursor.visible = CursorVisible;
            Cursor.lockState = CursorLockMode;
#if !UNITY_EDITOR
        Destroy(this);
#endif
        }

        private void Update()
        {
            if (Input.GetKeyDown(MouseEscapeKey))
            {
                CursorVisible = true;
                CursorLockMode = CursorLockMode.None;
            }
            Cursor.visible = CursorVisible;
            Cursor.lockState = CursorLockMode;
        }

    }
}