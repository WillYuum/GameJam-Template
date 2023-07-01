using UnityEngine;
using SpawnManagerMod.Configs;
using Utils.GenericSingletons;

namespace SpawnManagerMod
{

    public class PrefabManager : MonoBehaviourSingleton<PrefabManager>
    {
        [SerializeField] private PrefabConfig _enemyPrefab;
    }
}