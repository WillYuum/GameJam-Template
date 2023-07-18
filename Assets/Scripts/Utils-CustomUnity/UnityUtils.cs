using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace UnityCustomUtils.SceneManagerUtils
{
    public static class SceneManagerUtil
    {
        public static void SwitchScene(string sceneName, Action cb = null)
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


        public static string GetCurrentLoadedSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}
