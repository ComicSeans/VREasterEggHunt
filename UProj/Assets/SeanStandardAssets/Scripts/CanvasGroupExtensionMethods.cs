using UnityEngine;
using System.Collections;

namespace SeanStandardScript
{
    public static class CanvasGroupExtensionMethods
    {
        public static void Hide(this CanvasGroup cg)
        {
            cg.alpha = 0f; //this makes everything transparent
            cg.blocksRaycasts = false; //this prevents the UI element to receive input events
        }

        public static void Show(this CanvasGroup cg)
        {
            cg.alpha = 1f; //this makes everything transparent
            cg.blocksRaycasts = true; //this prevents the UI element to receive input events
        }
    }
}