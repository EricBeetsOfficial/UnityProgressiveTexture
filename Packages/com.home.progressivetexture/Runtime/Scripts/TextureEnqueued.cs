using System;
using System.Collections.Generic;

namespace ProgressiveTexture
{
    internal static class TextureEnqueued
    {
        private static readonly Queue<(Action<IntPtr, string>, IntPtr, string)> _queue = new();
        private static readonly object _obj = new();

        public static void Enqueue(Action<IntPtr, string> callback, IntPtr value, string guid)
        {
            lock (_obj)
            {
                _queue.Enqueue((callback, value, guid));
            }
        }

        public static void Update()
        {
            lock (_obj)
            {
                while (_queue.Count > 0)
                {
                    var (callback, value, guid) = _queue.Dequeue();
                    callback?.Invoke(value, guid);
                }
            }
        }
    }
}