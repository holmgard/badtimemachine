using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindablesManager : MonoBehaviour
{
    public GameObject RewindableObjectParent;

    private Dictionary<int, BadTimeMachine> rewindableObjects = new Dictionary<int, BadTimeMachine>();

    private void Start()
    {
        var components = RewindableObjectParent.GetComponentsInChildren<BadTimeMachine>();
        foreach(var component in components)
        {
            int id = component.gameObject.GetInstanceID();
            rewindableObjects.Add(id, component);
        }
    }

    public BadTimeMachine GetBadTimeMachine(int gameObjectID)
    {
        return rewindableObjects[gameObjectID];
    }

    public bool IsRewindable(int gameObjectID)
    {
        if (rewindableObjects.ContainsKey(gameObjectID))
        {
            return true;
        }
        return false;
    }
}
