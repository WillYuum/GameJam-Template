using System;
using UnityEngine;

namespace CustomDelayer
{
    public class DelayMonoBehaviour : MonoBehaviour
    {
        private float _delay;
        private Action _callback;

        public static DelayMonoBehaviour CreateInstance(string name = "DelayMonoBehaviour")
        {
            GameObject go = new GameObject(name);
            return go.AddComponent<DelayMonoBehaviour>();
        }

        public void InvokeAfter(Action callback, float delay)
        {
            _delay = delay;
            _callback = callback;
        }

        void Update()
        {
            _delay -= Time.deltaTime;

            if (_delay < 0)
            {
                _callback();
                disposeDelayer();
            }
        }

        private void disposeDelayer()
        {
            _callback = null;
            Destroy(this.gameObject);
        }
    }
}