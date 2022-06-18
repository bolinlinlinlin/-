using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windway : MonoBehaviour
{
    wind_region wind_Region;
    // Start is called before the first frame update
    void Awake()
    {
        wind_Region = GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((int)wind_Region.wind_state == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0,0));
        }
        else if ((int)wind_Region.wind_state == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45));
        }
        else if ((int)wind_Region.wind_state == 2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
        else if ((int)wind_Region.wind_state == 3)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -135));
        }
        else if ((int)wind_Region.wind_state == 4)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else if ((int)wind_Region.wind_state == 5)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
        }
        else if ((int)wind_Region.wind_state == 6)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if ((int)wind_Region.wind_state == 7)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
        }
        
    }
}
