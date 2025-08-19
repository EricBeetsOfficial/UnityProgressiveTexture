using System;
using System.Runtime.InteropServices;

namespace ProgressiveTexture.Delegates
{
    internal delegate void DelegateLogCallback(IntPtr msg, IntPtr color);
    internal delegate void DelegateCreatedTexture(ref TextureParameter textureCreated);

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct TextureParameter
    {
        internal IntPtr texturePtr;
        internal IntPtr texId;
        internal IntPtr dxPtr;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        internal string guid;
        public bool yFlip;
    }
}