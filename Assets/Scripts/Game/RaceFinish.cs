using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

public class RaceFinish : MonoBehaviour {

    public GameObject PlayerCar;
    public GameObject PlayerFPCam;
    public GameObject PlayerVRCam;
    public GameObject FinishFX;
	public GameObject LapTimeManager;
	public GameObject SteeringWheel;
    public GameObject RaceFinishTrigger;
    public GameObject CarHUD;
    public GameObject FinishMenu;
    public GameObject FinishLapLabelContainer;

    private void OnTriggerEnter(Collider other)
    {
        /*
         * Triggers the end of the race when the final collider is activated and passed
         * through, first disables the collider, deactivates the player, sets all the cars
         * top speed to 0, disables the car and user control and reactivatess the user again,
         * finally the completion sound is played
         */
        this.GetComponent<BoxCollider>().enabled = false;
        LapTimeManager.SetActive(false);
        PlayerCar.SetActive(false);
        RaceFinishTrigger.SetActive(false);
        CarController.m_Topspeed = 0.0f;
        PlayerCar.GetComponent<CarController>().enabled = false;
        PlayerCar.GetComponent<CarUserControl>().enabled = false;
        //PlayerCar.GetComponent<CarAudio>().enabled = false;
        //PlayerCar.GetComponent<AudioSource>().enabled = false;
        FinishFX.GetComponent<AudioSource>().Play();
        PlayerFPCam.GetComponent<AudioListener>().enabled = false;
        PlayerVRCam.GetComponent<AudioListener>().enabled = false;
        PlayerCar.SetActive(true);

        SteeringWheel.GetComponent<SteeringWheel>().enabled = false;

        int iteration = 1;
        foreach(Transform lapLabel in FinishLapLabelContainer.transform)
        {
            if (iteration <= LapComplete.instance.LapsTotal)
            {
                int MinCount = PlayerPrefs.GetInt("LapMin_" + iteration);
                int SecCount = PlayerPrefs.GetInt("LapSec_" + iteration);
                float MilliCount = PlayerPrefs.GetFloat("LapMilli_" + iteration);

                string MinString = "" + MinCount + ":";
                if (MinCount < 10)
                    MinString = "0" + MinCount + ":";

                string SecString = "" + SecCount + ".";
                if (SecCount < 10)
                    SecString = "0" + SecCount + ".";

                lapLabel.gameObject.SetActive(true);
                lapLabel.GetChild(0).GetComponent<Text>().text = MinString + SecString + (MilliCount.ToString()).Substring(0, 1);
            }
            else
                break;

            iteration++;
        }

        CarHUD.SetActive(false);
        FinishMenu.SetActive(true);

    }
}
