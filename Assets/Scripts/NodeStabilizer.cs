using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NodeStabilizer is a component that can be used to activate or deactivate gameobjects onAwake of the game.<br/>
/// 
/// How to use:<br/>
/// 1. Add this component to a gameobject prefarably in the root of the gameobject.<br/>
/// 2. Add the gameobjects that should be activated or deactivated in the inspector.<br/>
/// </summary>
public class NodeStabilizer : MonoBehaviour
{

    public List<GameObject> SetActiveAtLoad = new List<GameObject>();
    public List<GameObject> SetInactiveAtLoad = new List<GameObject>();

    void Awake()
    {
        ToggleGameobjects(SetActiveAtLoad, true);
        ToggleGameobjects(SetInactiveAtLoad, false);

        Destroy(this);
    }

    private void ToggleGameobjects(List<GameObject> go, bool state)
    {
        foreach (GameObject item in SetInactiveAtLoad)
        {

#if UNITY_EDITOR
            if (item == null)
            {
                Debug.LogWarning("NodeStabilizer Warning: There is null object in list");
            }
#endif

            if (item != null) item.SetActive(state);
        }
    }


}