using System;
using ProgressiveTexture.Delegates;
using UnityEngine;
using UniRx;

namespace ProgressiveTexture
{
    public class Texture
    {
        private readonly Subject<string> _onCreated = new Subject<string>();
        public IObservable<string> OnCompleted => _onCreated.AsObservable();

        private Material _material;
        private string _materialName;

        public Texture2D Load(string filePath, Material material, string materialName)
        {
            ProgressiveTextureUpdate.Instance.Run();

            _material = material;
            _materialName = materialName;

            Texture2D texture = new Texture2D(1, 1);
            texture.name = Guid.NewGuid().ToString();
            texture.SetPixel(0, 0, Color.red);
            texture.Apply();

            TextureParameter textureParameter = new TextureParameter()
            {
                texturePtr = this.CreateHandle(),
                texId = IntPtr.Zero,
                guid = texture.name
            };
            Wrappers.LoadTexture(filePath, ref textureParameter);

            return texture;
        }

        public void ReplaceTexture(IntPtr texId, string guid)
        {
            _onCreated.OnNext(guid);
            Texture2D texture = Texture2D.CreateExternalTexture(512, 512, TextureFormat.RGB24, true, true, texId);
            texture.filterMode = FilterMode.Bilinear;
            texture.wrapMode = TextureWrapMode.Repeat;
            _material.SetTexture(_materialName, texture);
        }
    }
}