using UnityEngine;
using UniRx;

namespace ProgressiveTexture
{
    public class ProgressiveTextureUpdate : MonoBehaviour
    {
#region Singleton
        private static ProgressiveTextureUpdate _instance;

        public static ProgressiveTextureUpdate Instance
        {
            get
            {
                if (_instance == null)
                    CreateInstance();
                return _instance;
            }
        }

        private static void CreateInstance()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/ProgressiveTextureUpdate");

            GameObject go = Instantiate(prefab);
            _instance = go.GetComponent<ProgressiveTextureUpdate>();
            DontDestroyOnLoad(go);
        }

        public void Run()
        {

        }
#endregion

#region  Unity Callbacks

        internal bool IsAvailable
        {
            private set;
            get;
        }

        private void Awake()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                TextureEnqueued.Update();
                // Log messages
                GL.IssuePluginEvent(Wrappers.GetRenderEventFunc(), 2);
                // Worker messages
                GL.IssuePluginEvent(Wrappers.GetRenderEventFunc(), 1);
            }).AddTo(this);

            Wrappers.LogLevel(4);
            Wrappers.LogRegisterCallback(Wrappers.OnLogCallback);
            Wrappers.TextureCreatedCallback(Wrappers.OnTextureCreated);

            string version = Wrappers.Version().IntPtrToString();
            Utils.Log("Version: " + version, "green");

            string buildType = Wrappers.BuildType().IntPtrToString();
            Utils.Log("Build type: " + buildType, "green");

            string supportedContext = Wrappers.SupportedContext().IntPtrToString(true);
            Utils.Log("Supported Context: " + supportedContext, "green");

            string instanciatedContext = Wrappers.InstanciatedContext().IntPtrToString(true);
            Utils.Log("Instanciated Context: " + instanciatedContext, "green");

            IsAvailable = Wrappers.IsAvailableContext();
            Utils.Log("Context is available : " + IsAvailable, IsAvailable ? "green" : "red");
        }
#endregion
    }
}