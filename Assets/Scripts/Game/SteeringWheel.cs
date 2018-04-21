using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SteeringWheel : MonoBehaviour
{
    private float rotationZ = 0f;
    private float rotationForce = 50f;
    private float minRotationAngle = -15;
    private float maxRotationAngle = 15;

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*
         * Gets all horizontal input movement so then we can trigger the steering wheel
         * rotation, if there's no rotation the steering wheel gets back to its original position
         * by a "rotate back force" which determines how fast it gets back to that position.
         * If the steering wheel is moving to the left or right, set the rotation to that side slowly
         * within a rotation range.
         * Finally the rotation values are set according to the case detected.
         */
        float horizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");

        if (horizontalAxis == 0 && rotationZ != 0)
        {
            float rotateBackForce = .8f;
            if (rotationZ > 0)
            {
                if (rotationZ > rotateBackForce) { rotationZ -= rotateBackForce; } else { rotationZ = 0f; };
            } else if(rotationZ < 0)
            {
                if (rotationZ < rotateBackForce) { rotationZ += rotateBackForce; } else { rotationZ = 0f; };
            }

        }
        else
        {
            rotationZ = horizontalAxis;
            //rotationZ = Mathf.Clamp(rotationZ, minRotationAngle, maxRotationAngle);

        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ * rotationForce);
    }
}