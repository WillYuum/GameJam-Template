using UnityEngine;
using SpawnManagerMod.Configs;
using Utils.GenericSingletons;

namespace SpawnManagerMod
{

    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        //Example of how to use the SpawnManager
        [SerializeField] private PrefabConfig _enemyPrefab;

        public GameObject Spawn(Vector3 position, Quaternion rotation) => _enemyPrefab.CreateGameObject(position, rotation);
    }
}