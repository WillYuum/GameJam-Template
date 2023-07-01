using System.Collections;
using System.Collections.Generic;
using Utils.GenericSingletons;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using GameloopCore;

/*
*
* This class is responsible for managing the game flow meaning moving from one scene to another
* and loading the UI of that scene and whatever else is needed.
* 
*/
public class GameFlowManager : MonoBehaviourSingleton<GameFlowManager>
{
    private bool _gameFlowLoaded = false;

    public void Load()
    {
        if (_gameFlowLoaded == true)
        {
            Debug.LogError("GameFlowManager already loaded");
            return;
        }

        Debug.Log("Loading GameFlowManager");

        _gameFlowLoaded = true;


#if UNITY_EDITOR
        string currentActiveScene = SceneManager.GetActiveScene().name;
        if (currentActiveScene == "GameScene")
        {
            LoadGameScene();
        }
#else
            LoadGameFromStart();
#endif
    }



    private void LoadGameFromStart()
    {
        string sceneNameToStartWith = "GameScene"; //Change this to the scene you want to start with
        SwitchToScene(sceneNameToStartWith, () =>
        {
            //Do whatever you need to do after the scene is loaded
        });
    }



    private void LoadGameScene()
    {
        SwitchToScene("GameScene", () =>
        {
            //Do whatever you need to do after the scene is loaded
            GameloopBehavior gameSceneloop = GameloopBehavior.Create<GameSceneLoop>("gameSceneLoop");
            gameSceneloop.Play();
        });

    }



    private void SwitchToScene(string sceneName, Action cb = null)
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