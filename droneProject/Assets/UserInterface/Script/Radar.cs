using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Radar : MonoBehaviour
{
    public GameObject[] trackedObjects;
    List<GameObject> radarObjects;
    public GameObject radarPrefab;
    
    void Start()
    {
        create_Radar_Objects();
    }

    
    void Update()
    {
        
    }

    void create_Radar_Objects()
    {
        radarObjects = new List<GameObject>();
        foreach(GameObject o in trackedObjects)
        {
            GameObject k = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            radarObjects.Add(k);
        }
    }
}
