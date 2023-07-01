using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameloopCore
{
    /*
    *
    * This is the base class for any class that needs to handle an instance of a gameloop.
    * Example: Add gameloop to a level, add gameloop to multiple scenes
    * When creating an instance of a gameloop, you need to create a class that inherits from this class
    * and implement the abstract methods. 
    *
    */
    public abstract class GameloopBehavior : GameLoopPublicActions
    {

        public static T Create<T>(string gameloopName) where T : GameloopBehavior
        {
            GameObject gameloopGameObject = new GameObject(gameloopName);
            T gameloop = gameloopGameObject.AddComponent<T>();
            gameloop.Init(gameloopName, gameloopGameObject);
            return gameloop;
        }

        void Update()
        {
            if (_isActive == false) return;


            onUpdate();
        }

        protected override void OnPlay()
        {
            print("Started gameloop " + _gameloopName);
        }

        protected override void onUpdate()
        {
            // print("yil3an ayer");
        }

        protected override void OnToggle(bool toActive)
        {
            print("Toggled gameloop " + _gameloopName + " to " + toActive);

        }

        protected override void OnEnd()
        {
            print("Ended gameloop " + _gameloopName);

        }
    }








    public abstract class GameLoopPublicActions : GameLoopCoreBehavior
    {
        public void Play()
        {
#if UNITY_EDITOR
            if (_isActive == true)
            {
                Debug.LogError("Gameloop already loaded with name: " + _gameloopName);
                return;
            }
#endif

            _isActive = true;
            OnPlay();
        }


        public void End()
        {
#if UNITY_EDITOR

            if (_gameloopLoaded == false)
            {
                Debug.LogError("Gameloop not loaded with name: " + _gameloopName);
                return;
            }
#endif

            _isActive = false;
            OnEnd();
        }

        public void Toggle(bool toActive)
        {
#if UNITY_EDITOR
            if (_isActive == toActive)
            {
                Debug.LogError("Gameloop already " + (toActive ? "active" : "inactive"));
                return;
            }
#endif

            _isActive = toActive;
            enabled = toActive;
            OnToggle(toActive);
        }
    }



    public abstract class GameLoopCoreBehavior : MonoBehaviour
    {
        protected string _gameloopName;
        protected bool _gameloopLoaded = false;
        protected bool _isActive = false;

        protected abstract void OnPlay();
        protected virtual void onUpdate() { }
        protected abstract void OnEnd();
        protected abstract void OnToggle(bool toActive);

        private GameObject _gameloopGameObject;



        protected void Init(string gameloopName, GameObject gameloopGameObject)
        {
#if UNITY_EDITOR
            if (_gameloopLoaded == true)
            {
                Debug.LogError("Gameloop already loaded");
                return;
            }
#endif

            _gameloopLoaded = true;
            _gameloopName = gameloopName;
            _gameloopGameObject = gameloopGameObject;
        }
    }

}