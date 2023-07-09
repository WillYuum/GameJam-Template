using System.Collections;
using System.Collections.Generic;
using Utils.GenericSingletons;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using GameloopCore;

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
        print($"Switching to scene of type: {typeof(T).Name}");
#endif

        if (_currentScene != null)
        {
            _currentScene.OnExit();
        }

        _currentScene = new T();
        _currentScene.OnEnter();
    }
}


public abstract class GameFlowScene
{
    public abstract void OnEnter();
    public abstract void OnExit();
}

