using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum wind
{
    north,
    northeast,
    east,
    southeast,
    south,
    southwest,
    west,
    northwest
}

public class wind_region : MonoBehaviour
{
    Rigidbody ourDrone;
    public string str_wind;
    public int wind_state = 0;
    public float wind_count = 0;
    int x = 0;
    DroneMovementScript droneMovementScript;
    Vector3 Northeast = new Vector3(1, 0, 1) / Mathf.Sqrt(2);
    Vector3 Southeast = new Vector3(1, 0, -1) / Mathf.Sqrt(2);
    Vector3 Southwest = new Vector3(-1, 0, -1) / Mathf.Sqrt(2);
    Vector3 Northwest = new Vector3(-1, 0, 1) / Mathf.Sqrt(2);
    void Awake()
    {

        ourDrone = GetComponent<Rigidbody>();
        x = UnityEngine.Random.Range(0, 7);
        wind_state = x;
        wind_count = 10;
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            wind_state += 1;
        }
        if(wind_state >7)
        {
            wind_state = -1;
        }
        /*if(wind_count > 2)
            wind_count += Time.deltaTime;
        {   
            wind_state = new System.Random(Guid.NewGuid().GetHashCode()).Next(0, 1000)%8;
            wind_count = 0;
        }*/
        if (!droneMovementScript.atground)
        {
            switch (wind_state)
            {
                case (int)wind.north:
                    ourDrone.AddForce(Vector3.forward * wind_count);// new Vector3(0f, 0f, 100f));
                    str_wind = "北";
                    break;
                case (int)wind.northeast:
                    ourDrone.AddForce(Northeast * wind_count);
                    str_wind = "東北";
                    break;
                case (int)wind.east:
                    ourDrone.AddForce(Vector3.right * wind_count);// new Vector3(0f, 0f, 100f));
                    str_wind = "東";
                    break;
                case (int)wind.southwest:
                    ourDrone.AddForce(Southwest * wind_count);
                    str_wind = "東南";
                    break;
                case (int)wind.south:
                    ourDrone.AddForce(Vector3.back * wind_count);// new Vector3(0f, 0f, 100f));
                    str_wind = "南";
                    break;
                case (int)wind.southeast:
                    ourDrone.AddForce(Southeast * wind_count);
                    str_wind = "西南";
                    break;
                case (int)wind.west:
                    ourDrone.AddForce(Vector3.left * wind_count);// new Vector3(0f, 0f, 100f));
                    str_wind = "西";
                    break;
                case (int)wind.northwest:
                    ourDrone.AddForce(Northwest * wind_count);
                    str_wind = "西北";
                    break;
                case -1 :
                    str_wind = "無";
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.gameObject.name == "WindZone")
        {
            if ((wind)wind_state == wind.north) Debug.Log("北");
            else if (wind_state == 1) Debug.Log("東北");
            else if (wind_state == 2) Debug.Log("東");
            else if (wind_state == 3) Debug.Log("東南");
            else if (wind_state == 4) Debug.Log("南");
            else if (wind_state == 5) Debug.Log("西南");
            else if (wind_state == 6) Debug.Log("西");
            else if (wind_state == 7) Debug.Log("西北");
        }
        */
    }
}
