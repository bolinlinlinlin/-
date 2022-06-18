using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetOn : MonoBehaviour
{
    public RawImage MapArrow;
    DroneMovementScript droneMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MapArrow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -droneMovementScript.DroneAngle));

    }
}
