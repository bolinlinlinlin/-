using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachModeAnimator : MonoBehaviour
{
    public Animator WASD;
    public Animator IJKL;
    DroneMovementScript droneMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WASD != null)
            WASD.SetBool("starup", droneMovementScript.start_up);
        if (IJKL != null)
        {
            IJKL.SetBool("starup", droneMovementScript.start_up);
            IJKL.SetInteger("count", droneMovementScript.count);
        }
    }
}
