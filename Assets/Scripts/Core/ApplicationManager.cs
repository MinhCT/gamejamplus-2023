using System;
using UnityEngine;

namespace Core
{
    public class ApplicationManager: MonoBehaviour
    {
        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        // private static void RuntimeInit()
        // {
        //     if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Main") return;
        //     var app = new GameObject { name = "[ApplicationManager]" };
        //     app.AddComponent<ApplicationManager>();
        // }

        private void Awake()
        {
            Events.ApplicationStarted += OnApplicationStarted;
        }

        private void OnDestroy()
        {
            Events.ApplicationStarted -= OnApplicationStarted;
        }

        private void Start()
        {
            Invoke("ApplicationStarted", 1.0f);
        }

        private void ApplicationStarted()
        {
            Events.OnApplicationStarted();
        }
        
        private void OnApplicationStarted()
        {
            StatesManager.ChangeState(StatesManager.State.Menu);
            // Destroy(this);
        }
    }
}