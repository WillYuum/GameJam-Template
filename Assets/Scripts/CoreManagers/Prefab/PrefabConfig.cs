using UnityEngine;

namespace PrefabManager.Configs
{
    [System.Serializable]
    public class PrefabConfig
    {
        [SerializeField] private GameObject _prefab;

        public GameObject CreateGameObject(Vector3 position, Quaternion rotation)
        {
            return GameObject.Instantiate(_prefab, position, rotation);
        }

        public GameObject CreateGameObject(Vector3 position, Quaternion rotation, Transform parent)
        {
            return GameObject.Instantiate(_prefab, position, rotation, parent);
        }

        public GameObject GetPrefabConfig()
        {
            return _prefab;
        }
    }
}