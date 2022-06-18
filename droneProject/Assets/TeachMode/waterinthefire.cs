using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterinthefire : MonoBehaviour
{
    DroneMovementScript droneMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("waterAAAA");
        droneMovementScript.broken = true;
        droneMovementScript.start_up = false;
    }
}
