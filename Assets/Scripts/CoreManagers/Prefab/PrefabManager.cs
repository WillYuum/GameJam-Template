using UnityEngine;
using PrefabManager.Configs;
using Utils.GenericSingletons;

namespace PrefabManager
{

    public class PrefabManager : MonoBehaviourSingleton<PrefabManager>
    {
        [SerializeField] private PrefabConfig _enemyPrefab;
    }
}