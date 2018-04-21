using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {

    public AudioClip collisionClip;
    private AudioSource collisionSource;

	// Use this for initialization
	void Start ()
    {
        /*
         * This script was meant to provide a "collision sound" when car collided with barriers
         * or other cars, currently not working
         */
        collisionSource = gameObject.AddComponent<AudioSource>();
        collisionSource.clip = collisionClip;
        collisionSource.volume = 2;
        collisionSource.loop = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision");
        collisionSource.Play();
    }
}
