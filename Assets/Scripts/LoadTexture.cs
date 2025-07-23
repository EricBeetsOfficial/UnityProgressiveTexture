using UnityEngine;
using UniRx;

public class LoadTexture : MonoBehaviour
{
    private Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void PushMe()
    {
        var texture = new ProgressiveTexture.Texture();
        texture.OnCompleted.Subscribe(message =>
        {
            Debug.Log($" DONE {message}!!!");
        }).AddTo(this);

        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "cat.jpg");

        _renderer.material.SetTexture("_BaseMap", texture.Load(filePath, _renderer.material, "_BaseMap"));
    }
}
