using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Transform ourDrone;
    void Awake() {
        ourDrone = GameObject.FindGameObjectWithTag("Drone").transform;
    }

    private Vector3 velocityCameraFollow;
    public Vector3 behindPosition = new Vector3(0, 8, -25);
    public float angle;

    void FixedUpdate() {
        if (ourDrone != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, ourDrone.transform.TransformPoint(behindPosition) , ref velocityCameraFollow, 0.01f); //0.1f // + Vector3.up * Input.GetAxis("Vertical")
            transform.rotation = Quaternion.Euler(new Vector3(angle, ourDrone.GetComponent<DroneMovementScript>().currentYRotation, 0));

        }
    }

}
