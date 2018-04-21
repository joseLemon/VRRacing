using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine;

public class CarControlActive : MonoBehaviour {
    public GameObject CarControl;
    public GameObject AICarsContainer;
    public GameObject Tracker;
    public GameObject WayPointsContainer;

    // Use this for initialization
    void Awake ()
    {
        //Enable car and user script controller of player car for them to start running
        CarControl.GetComponent<CarController>().enabled = true;
        CarControl.GetComponent<CarUserControl>().enabled = true;
        int iteration = 0;
        foreach (Transform AICar in GameInitConfig.AICars)
        {
            /*
             * Setting the ai car tag string
             * Instantiating a marker for the ai car to follow
             * Add AITrack script to marker
             * Pass the ai car tag for it to be detected by the marker collider
             * Pass the current marker game object
             */
            string AICarTag = "AICar" + iteration;
            GameObject CurentTracker = Instantiate(Tracker);
            CurentTracker.AddComponent<AITrack>();
            CurentTracker.GetComponent<AITrack>().AICarTag = AICarTag;
            CurentTracker.GetComponent<AITrack>().TheMarker = CurentTracker;
            CurentTracker.GetComponent<AITrack>().WaypointsContainer = WayPointsContainer;

            /*
             * Enable car and ai script controller of ai car for them to start running
             * Add ai car tag to body collider of car
             * Set the car tracker to the created marker
             */
            AICar.GetChild(0).GetComponent<CarController>().enabled = true;
            AICar.GetChild(0).GetComponent<CarAIControl>().enabled = true;
            AICar.GetChild(0).GetChild(0).GetChild(5).tag = AICarTag;
            AICar.GetChild(0).GetComponent<CarAIControl>().SetTarget(CurentTracker.transform);
            iteration++;
        }
    }
}
