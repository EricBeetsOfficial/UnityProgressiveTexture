using System;
using System.Runtime.InteropServices;

namespace ProgressiveTexture
{
    internal static class InteropServices
    {
        internal static string IntPtrToString(this IntPtr ptr, bool release = false)
        {
            string str = Marshal.PtrToStringAnsi(ptr);
            if (release)
                Wrappers.ReleaseChar(ptr);
            return str;
        }

        internal static IntPtr CreateHandle(this object value)
        {
            return (IntPtr)GCHandle.Alloc(value);
        }

        internal static T GetHandle<T>(this IntPtr ptr) where T : class
        {
            return ((GCHandle)ptr).Target as T;
        }

        internal static void ReleaseHandle(this IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                ((GCHandle)ptr).Free();
            }
        }
    }
}