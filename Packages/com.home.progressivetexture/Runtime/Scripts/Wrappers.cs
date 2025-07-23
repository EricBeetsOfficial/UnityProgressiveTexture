using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ProgressiveTexture
{
    internal static class Wrappers
    {
#region Imported functions
        [DllImport("UnityPlugin")]
        internal static extern void LogTest();

        [DllImport("UnityPlugin")]
        internal static extern void LogLevel(int level);

        [DllImport("UnityPlugin")]
        internal static extern IntPtr Version();

        [DllImport("UnityPlugin")]
        internal static extern IntPtr BuildType();

        [DllImport("UnityPlugin")]
        internal static extern IntPtr SupportedContext();

        [DllImport("UnityPlugin")]
        internal static extern IntPtr InstanciatedContext();

        [DllImport("UnityPlugin")]
        internal static extern void ReleaseChar(IntPtr ptr);

        [DllImport("UnityPlugin")]
        internal static extern void LoadTexture(string filePath, ref Delegates.TextureParameter textureParameters);

        [DllImport("UnityPlugin")]
        internal static extern IntPtr GetRenderEventFunc();
#endregion

#region Delegates
        [DllImport("UnityPlugin")]
        internal static extern void LogRegisterCallback(Delegates.DelegateLogCallback callback);

        [DllImport("UnityPlugin")]
        internal static extern void LogUnregisterCallback();

        [DllImport("UnityPlugin")]
        internal static extern void TextureCreatedCallback(Delegates.DelegateCreatedTexture callback);
#endregion

#region Callbacks
        [AOT.MonoPInvokeCallback(typeof(Delegates.DelegateCreatedTexture))]
        internal static void OnTextureCreated(ref Delegates.TextureParameter textureCreated)
        {
            Debug.Log($"Texture created {textureCreated.texId} {textureCreated.guid}  !");
            Texture texture = textureCreated.texturePtr.GetHandle<Texture>();
            TextureEnqueued.Enqueue(texture.ReplaceTexture, textureCreated.texId, textureCreated.guid);
            textureCreated.texturePtr.ReleaseHandle();
        }

        [AOT.MonoPInvokeCallback(typeof(Delegates.DelegateLogCallback))]
        internal static void OnLogCallback(IntPtr message, IntPtr color)
        {
            Utils.Log(message.IntPtrToString(), color.IntPtrToString());
        }
#endregion
    }
}