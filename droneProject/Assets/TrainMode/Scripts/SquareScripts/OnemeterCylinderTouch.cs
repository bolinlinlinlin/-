using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnemeterCylinderTouch : MonoBehaviour
{
    GameObject Drone;
    DroneMovementScript droneMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        Drone = GameObject.FindGameObjectWithTag("Drone");
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        SquareLimit.sqTouch = false;
    }
    private void OnTriggerStay(Collider other)
    {
        SquareLimit.sqTouch = false;
        if (Counting.inspotcount == 4)
        {
            Destroy(GameObject.FindGameObjectWithTag("Spot"));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bool start_up = droneMovementScript.start_up;
        SquareLimit.sqTouch = true;
        if (start_up == true && Counting.inspotcount == 5 && Counting.Inscountt < 3)
        {
            Counting.inspotcount++;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
