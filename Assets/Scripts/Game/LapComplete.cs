using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

    public GameObject MinuteLabel;
    public GameObject SecondLabel;
    public GameObject MilliLabel;
    public GameObject LapCounter;
    public int LapsDone;
    public float RawTime;

    public static LapComplete instance;

    // The singleton instance is set
    private void Awake()
    {
        instance = this;
    }

    // Singleton instance to be able to access data from LapComplete
    public static LapComplete Instance
    {
        get
        {
            return instance;
        }
    }

    private void OnTriggerEnter(Collider theCollision)
    {
        /*
         * Add a new lap to lap counter
         * Checks if the best record time has been beaten to save a new record
         * Return lap timer to start point
         * Change the lap label to show current laps done
         * Activate first checkpoint to start the checkpoints from the beggining
         * Deactivate the last checkpoint
         */


		LapsDone++;

        RawTime = PlayerPrefs.GetFloat("RawTime");

        if (LapTimeManager.RawTime <= RawTime)
        {
            // set label for best time on lap complete
            MilliLabel.GetComponent<Text>().text = LapTimeManager.Instance.MilliBox.GetComponent<Text>().text;
            SecondLabel.GetComponent<Text>().text = LapTimeManager.Instance.SecondBox.GetComponent<Text>().text;
			MinuteLabel.GetComponent<Text>().text = LapTimeManager.Instance.MinuteBox.GetComponent<Text>().text;

			PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
			PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
			PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MilliCount);
			PlayerPrefs.SetFloat("RawTime", LapTimeManager.RawTime);
        }

        PlayerPrefs.SetInt("LapMin_" + LapsDone, LapTimeManager.MinuteCount);
        PlayerPrefs.SetInt("LapSec_" + LapsDone, LapTimeManager.SecondCount);
        PlayerPrefs.SetFloat("LapMilli_" + LapsDone, LapTimeManager.MilliCount);

        // set current lap timer to 0
        LapTimeManager.MilliCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.RawTime = 0;

        // count the laps completed
        LapCounter.GetComponent<Text>().text = "" + LapsDone;

        // set first checkpoint to active
        CheckpointsController.checkpoints[0].gameObject.SetActive(true);

        // deactivate current checkpoint (finish line)
        gameObject.SetActive(false);
    }
}
