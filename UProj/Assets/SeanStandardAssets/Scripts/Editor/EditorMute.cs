using UnityEngine;
using System.Collections;
using UnityEditor;

namespace SeanStandardScript
{
    public class EditorMute
    {
        private static float _savedVolume;

        [MenuItem("Editor Volume/Mute")]
        private static void Mute()
        {
            _savedVolume = AudioListener.volume;
            AudioListener.volume = 0.0f;
        }

        [MenuItem("Editor Volume/Unmute")]
        private static void UnMute()
        {
            AudioListener.volume = _savedVolume;
        }
    }
}