using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EntryPointType {
    None,
}

public class EntryPoint : MonoBehaviour
{


    public EntryPointType entryPointType;
    public Entry currentEntryPoint;

    private void Awake()
    {
        switch (entryPointType)
        {
            default:
                break;
        }
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

}




public class InstanceOfEntry : Entry
{
    public override void UseEntry()
    {

    }
}


public class Entry
{
    public virtual void UseEntry()
    {

    }
}
