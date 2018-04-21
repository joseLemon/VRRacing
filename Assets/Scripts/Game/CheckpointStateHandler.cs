using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointStateHandler : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        /*
         * Check if the object going through the checkpoint is the player
         * Iterate through checkpoints to check for the next checkpoint to activate,
         * deactivate current checkpoint to make it invisible
         */
        if(other.gameObject.tag == "Player")
        {
            Transform currentCheckpoint = transform;
            bool flagForNextCheckpoint = false;
            foreach (Transform checkpoint in CheckpointsController.checkpoints)
            {
                // if next checkpoint, set active
                if (flagForNextCheckpoint)
                {
                    checkpoint.gameObject.SetActive(true);
                    flagForNextCheckpoint = false;
                    break;
                }

                // set flag for next checkpoint
                if (checkpoint == currentCheckpoint)
                    flagForNextCheckpoint = true;
            }

            // Deactivate current checkpoint
            gameObject.SetActive(false);
        }
    }
}
