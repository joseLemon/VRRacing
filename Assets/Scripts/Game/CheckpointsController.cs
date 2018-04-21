using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsController : MonoBehaviour {
    public static List<Transform> checkpoints = new List<Transform>();

    // Use this for initialization
    void Start() {
        int iteration = 0;
        foreach(Transform checkpoint in gameObject.transform)
        {
            // if first checkpoint, set active
            if (iteration == 0)
                checkpoint.gameObject.SetActive(true);
            else // else, set inactive
                checkpoint.gameObject.SetActive(false);

            // set checkpoint as trigger
            checkpoint.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            // add script to checkpoint
            checkpoint.gameObject.AddComponent<CheckpointStateHandler>(); 
            // add checkpoint to list
            checkpoints.Add(checkpoint);
            iteration++;
        }
	}
}
