﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindablesManager : MonoBehaviour
{
    private static RewindablesManager _instance;
    public static RewindablesManager Instance {
        get {
            return _instance;
        }
    }

    public GameObject RewindableObjectParent;

    private Dictionary<int, BadTimeMachine> rewindableObjects = new Dictionary<int, BadTimeMachine>();

    void Awake() {
        _instance = this;
    }

    private void Start()
    {
        foreach(Transform child in RewindableObjectParent.transform)
        {
            BadTimeMachine badTimeMachine = child.gameObject.GetComponent<BadTimeMachine>();
            if(badTimeMachine != null)
            {
                rewindableObjects.Add(child.gameObject.GetInstanceID(), badTimeMachine);
            }
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
