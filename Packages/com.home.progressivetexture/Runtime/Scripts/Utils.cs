using UnityEngine;

namespace ProgressiveTexture
{
    internal class Utils
    {
        public static void Log(string message, string color = "#E0E0E0")
        {
#if UNITY_EDITOR
            string str = $"<color={color}>{message}</color>";
#else
            string str = message;
#endif
            Debug.Log(str);
        }
    }
}