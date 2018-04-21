using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour {

    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliLabel;

    public static LapTimeManager instance = null;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    public static float RawTime;

    // The singleton instance is set
    private void Awake()
    {
        instance = this;
    }

    // Singleton instance to be able to access timer data on lap finish
    public static LapTimeManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Update is called once per frame
    void Update() {
        /*
         * Manages the different label to show current lap timer
         */
        MilliCount += Time.deltaTime * 10;
        RawTime += Time.deltaTime;

        if (MilliCount >= 10)
        {
            MilliCount -= 10;
            SecondCount++;
        }

        MilliLabel = Mathf.Floor(MilliCount).ToString("F0");
        MilliBox.GetComponent<Text>().text = "" + MilliLabel;

        if(SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
        }
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
        }

        if(SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount++;
        }

        if(MinuteCount <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }
    }
}
