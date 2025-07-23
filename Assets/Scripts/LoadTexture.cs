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
        _renderer.material.SetTexture("_BaseMap", texture.Load("C:/Users/eric_/Programming/Git/ProgressiveTexture/Test/images/pilat.jpg", _renderer.material, "_BaseMap"));
    }
}
