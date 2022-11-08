using UnityEngine;
using SpawnManagerMod.Configs;
using Utils.GenericSingletons;

namespace SpawnManagerMod
{

    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        [SerializeField] private PrefabConfig _enemyPrefab;
    }
}