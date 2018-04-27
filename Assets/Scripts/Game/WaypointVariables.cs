using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointVariables : MonoBehaviour
{

    [Range(0, 5)] public float WaypointDispertion;
    [Range(0, 2)] public float BrakeSensitivity;

    public static WaypointVariables instance;

    // The singleton instance is set no needed yet
    private void Awake()
    {
        instance = this;
    }

    // Singleton instance to be able to access data from LapComplete
    public static WaypointVariables Instance
    {
        get
        {
            return instance;
        }
    }
}
