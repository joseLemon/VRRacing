using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLapTime : MonoBehaviour {

    public int MinCount;
    public int SecCount;
    public float MilliCount;

    public GameObject MinLabel;
    public GameObject SecLabel;
    public GameObject MilliLabel;

    public GameObject LapLabel;

    // Use this for initialization
    void Start() {
        /*
         * Get the saved best time
         * Set the correct format of minutes and seconds
         * Set the record time to the best time labels
         */
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MilliCount = PlayerPrefs.GetFloat("MilliSave");

        string MinString = "" + MinCount + ":";
        if(MinCount < 10)
            MinString = "0" + MinCount + ":";

        string SecString = "" + SecCount + ".";
        if (SecCount < 10)
            SecString = "0" + SecCount + ".";

        MinLabel.GetComponent<Text>().text = MinString;
        SecLabel.GetComponent<Text>().text = SecString;
        MilliLabel.GetComponent<Text>().text = "" + MilliCount;

        LapLabel.GetComponent<Text>().text = "" + LapComplete.instance.LapsTotal;
    }
}
