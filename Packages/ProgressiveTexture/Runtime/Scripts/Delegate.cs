using System;
using System.Runtime.InteropServices;

namespace ProgressiveTexture.Delegates
{
    internal delegate void DelegateLogCallback(IntPtr msg, IntPtr color);
    internal delegate void DelegateCreatedTexture(ref TextureParameter textureCreated);

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct TextureParameter
    {
        public IntPtr texturePtr;
        public IntPtr texId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string guid;
        public bool yFlip;
    }
}