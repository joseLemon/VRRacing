using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrack : MonoBehaviour
{

    public GameObject TheMarker;
    public static List<Transform> waypoints = new List<Transform>();
    public string AICarTag;
    public GameObject WaypointsContainer;

    //private GameObject WaypointsContainer;
    private int MarkTracker;
    private int currentFlag = -1;

    private void Start()
    {
        // Set the list of all the waypoints within an object (Waypoints Container)
        //WaypointsContainer = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform waypoint in WaypointsContainer.transform)
        {
            waypoints.Add(waypoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int iteration = 0;
        foreach (Transform waypoint in waypoints)
        {
            /*
             * If marker tracker (iteration of marker if car has gone through it) is the same as waypoint
             * iteration, then set the maker position to the waypoint positon
             * Get the axis of current waypoint and set a bit of an offset to x and z axis
             * Now set the position of the marker to the waypoint position with the offset applied
             */

            if (MarkTracker == iteration && currentFlag != MarkTracker)
            {
                currentFlag = MarkTracker;

                //Asignamos el mismo tag
                TheMarker.tag = waypoint.tag;

                //waypoint.GetComponent<WaypointVariables>().BrakeSensitivity;

                float offset = waypoint.GetComponent<WaypointVariables>().WaypointDispertion;
                float waypoint_x = waypoint.transform.position.x + Random.Range(-offset, offset);
                float waypoint_y = waypoint.transform.position.y;
                float waypoint_z = waypoint.transform.position.z + Random.Range(-(offset / 2), (offset / 2));
                TheMarker.transform.position = new Vector3(waypoint_x, waypoint_y, waypoint_z);
                TheMarker.transform.rotation = Quaternion.Euler(0, waypoint.transform.rotation.eulerAngles.y, 0);
            }
            iteration++;
        }
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        /*
         * If the current gameobject entering the collider of the marker is equal to the
         * passed car tag, then iterate to the new waypoint position, this to prevent any other
         * ai car or the player to iterate through it
         * Disable the collider so then this function does not trigger more than once per trigger enter
         * If the iteration of the marker is the same as the total of waypoints, return back to the initial
         * waypointm this meaning a lap was completed
         * Wait for a second so then we enable the collider again, waiting for the car to leave the current
         * marker positon and not trigger this function multiple times and re-eanbling it for the next
         * position
         */
        if (collision.gameObject.tag == AICarTag)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            MarkTracker++;
            if (MarkTracker == waypoints.Count)
            {
                MarkTracker = 0;
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
