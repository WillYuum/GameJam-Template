using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace CustomUnityUtils
{
    public static class UnityUtils
    {
        public static void SwitchToScene(string sceneName, Action cb = null)
        {
#if UNITY_EDITOR
            Scene scene = SceneManager.GetSceneByName(sceneName);
            if (scene.IsValid() == false)
            {
                Debug.LogError("Scene " + sceneName + " is not valid");
                return;
            }
#endif

            void onSceneLoaded(Scene loadedScene, LoadSceneMode mode)
            {
                if (loadedScene.name == sceneName)
                {
                    if (cb != null) cb.Invoke();
                }

                SceneManager.sceneLoaded -= onSceneLoaded;
            }

            SceneManager.sceneLoaded += onSceneLoaded;

            SceneManager.LoadScene(sceneName);
        }
    }
}
