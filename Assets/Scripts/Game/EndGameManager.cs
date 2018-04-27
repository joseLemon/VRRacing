using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    
    [Range(1, 3)] public int LapsTotal;
    public GameObject RaceFinish;

    public static EndGameManager instance;

    // The singleton instance is set
    private void Awake()
    {
        instance = this;
    }

    // Singleton instance to be able to access data from LapComplete
    public static EndGameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void OnTriggerEnter(Collider theCollision)
    {
        if ((LapComplete.instance.LapsDone == LapsTotal) && (theCollision.gameObject.tag == "Player"))
        {
            RaceFinish.SetActive(true);
        }
    }

}
