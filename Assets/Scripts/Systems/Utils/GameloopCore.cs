using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameloopCore
{
    /*
    *
    * A base class for any class that needs to handle an instance of a gameloop.
    *
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
            OnLoopUpdate();
        }

        protected override void OnPlay()
        {
            print("Started gameloop " + _gameloopName);
        }

        protected override void OnLoopUpdate()
        {

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
            if (IsActive == true)
            {
                Debug.LogError("Gameloop already loaded with name: " + _gameloopName);
                return;
            }
#endif

            OnPlay();
            SetLoopActive(true);
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

            OnEnd();
            SetLoopActive(false);
        }

        public void Toggle(bool toActive)
        {
#if UNITY_EDITOR
            if (IsActive == toActive)
            {
                Debug.LogError("Gameloop already " + (toActive ? "active" : "inactive"));
                return;
            }
#endif

            OnToggle(toActive);
            SetLoopActive(toActive);
        }
    }



    public abstract class GameLoopCoreBehavior : MonoBehaviour
    {
        protected string _gameloopName;
        protected bool _gameloopLoaded = false;
        protected bool IsActive { get; private set; }

        protected abstract void OnPlay();
        protected virtual void OnLoopUpdate() { }
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


        protected void SetLoopActive(bool toActive)
        {
            IsActive = toActive;
            enabled = toActive;
        }
    }

}