﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public GameObject CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControls;

	// Use this for initialization
	void Start () {
        StartCoroutine(CountStart());
	}

    IEnumerator CountStart()
    {
        /*
         * Manages sound, number countdown and animation by activating/deactivating
         * ui text object to initialize animation again and changing the text value,
         * counts down from 3 to 1 and plays starting sound, activates the timer and
         * calls the car control manager to activate player and ai cars to begin race
         */
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<Text>().text = "3";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "2";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        GoAudio.Play();

        LapTimer.SetActive(true);
        CarControls.SetActive(true);
    }
}
