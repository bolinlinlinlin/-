using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_map : MonoBehaviour
{
    private Transform ourDrone;
    

    void Awake()
    {
        ourDrone = GameObject.FindGameObjectWithTag("Drone").transform;
    }

    
    void FixedUpdate() {
        if (ourDrone != null)
        {
            transform.position = new Vector3(ourDrone.position.x , 300f, ourDrone.position.z);
            //transform.rotation = Quaternion.Euler(new Vector3(90, ourDrone.GetComponent<DroneMovementScript>().currentYRotation,0f));

        }
    }
}