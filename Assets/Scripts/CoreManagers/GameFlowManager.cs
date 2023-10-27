using System;
using UnityCustomUtils.SceneManagerUtils;
using UnityEngine;
using Utils.GenericSingletons;

/*
*
* Responsible for switching between scenes and invoking the appropriate callbacks
*
* 
*/
public class GameFlowManager : MonoBehaviourSingleton<GameFlowManager>
{

    private GameFlowScene _currentScene;


    public void SwitchToScene<T>() where T : GameFlowScene, new()
    {
#if UNITY_EDITOR
        Debug.Log($"Switching to scene of type: {typeof(T).Name}");
#endif

#if UNITY_EDITOR
        bool switchingToSameScene = _currentScene != null && _currentScene.GetType().Name == typeof(T).Name;
        if (switchingToSameScene)
        {
            Debug.LogError("Tring to Switch to same scene, doing nothing");
            return;
        }
#endif

        System.Type type = typeof(T);
        string sceneName = type.Name;

        if (_currentScene != null)
        {
            _currentScene.OnExit();
        }

        SceneManagerUtil.SwitchScene(sceneName, () =>
        {
            _currentScene = new T();
            _currentScene.OnEnter();
        });
    }


    public void SwitchToSceneWithNoGameFlow(string sceneName)
    {
#if UNITY_EDITOR
        Debug.Log($"Switching to scene with no game flow: {sceneName}");
#endif


        if (_currentScene != null)
        {
            _currentScene.OnExit();
        }

        SceneManagerUtil.SwitchScene(sceneName, () =>
        {
            _currentScene = null;
        });
    }

    public void ForceRestartCurrentScene()
    {
#if UNITY_EDITOR
        if (_currentScene == null)
        {
            Debug.LogError("Current scene is null, doing nothing");
            return;
        }
#endif


        SceneManagerUtil.SwitchScene(SceneManagerUtil.GetCurrentLoadedSceneName(), () =>
        {
            _currentScene.OnEnter();
        });
    }
}


public abstract class GameFlowScene
{
    public abstract void OnEnter();
    public abstract void OnExit();
}



