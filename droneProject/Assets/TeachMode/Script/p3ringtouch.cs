using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p3ringtouch : MonoBehaviour
{
    public GameObject ring;
    DroneMovementScript droneMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(ring);
        ScoreCount.score += 10;
        UnityEngine.Debug.Log(ScoreCount.score);
        phase3.ringappear = false;
        if (ScoreCount.score == 100)
        {
            droneMovementScript.count = 10;
        }
    }
}