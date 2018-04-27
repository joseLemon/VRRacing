using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{

    public AudioClip collisionClip;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().clip = collisionClip;
    }

    private void OnCollisionStay(Collision col)
    {
        // detect collision against other cars, so that we can take evasive action
        if (col.rigidbody != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

}
