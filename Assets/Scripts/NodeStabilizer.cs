using System.Collections.Generic;
using UnityEngine;

/* 
* NodeStabilizer is a component that can be used to activate or deactivate gameobjects onAwake of the game.<br/>
* 
* How to use:<br/>
* 1. Add this component to a gameobject prefarably in the root of the gameobject.<br/>
* 2. Add the gameobjects that should be activated or deactivated in the inspector.<br/>
*
* Note: This component will be removed onAwake of the gameobject.
* Note: This component will remove null objects from the list of gameobjects to activate or deactivate and will warn you in the console.
*/
public class NodeStabilizer : MonoBehaviour
{

    public List<GameObject> SetActiveAtLoad = new List<GameObject>();
    public List<GameObject> SetInactiveAtLoad = new List<GameObject>();

    void Awake()
    {
#if UNITY_EDITOR
        CheckAndRemoveNullObjects();
#endif

        ToggleGameobjects(SetActiveAtLoad, true);
        ToggleGameobjects(SetInactiveAtLoad, false);

        Destroy(this);
    }

    private void ToggleGameobjects(List<GameObject> go, bool state)
    {

        foreach (GameObject item in SetInactiveAtLoad)
        {
            if (item != null && state == item.activeSelf)
            {
                item.SetActive(!state);
            }
            else if (item != null && state != item.activeSelf)
            {
                item.SetActive(state);
            }
        }
    }



#if UNITY_EDITOR
    private void CheckAndRemoveNullObjects()
    {
        bool hasNull = false;

        foreach (GameObject item in SetActiveAtLoad)
        {
            if (item == null)
            {
                hasNull = true;
                break;
            }
        }

        if (hasNull)
        {
            SetActiveAtLoad.RemoveAll(item => item == null);
            Debug.LogWarning("NodeStabilizer: Removed null objects from SetActiveAtLoad, remove the null objects from the inspector to avoid this warning.");
        }
    }
#endif
}
