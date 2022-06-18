using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CylinderOld;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Counting.timerbool = true;
        Counting.cyTouch = false;
        Counting.SD = false;
    }

    private void OnTriggerStay (Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        Counting.cyTouch = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Counting.tt == true)
        {
            CylinderAppeared.CylinderCount++;
            CylinderAppeared.CylinderAppear = true;
            Counting.timerbool = false;
            Counting.judStay = false;
            Find("Time").GetComponent<CanvasGroup>().alpha = 0;
            Counting.tt = false;
            Destroy(CylinderOld);
        }
    }
    GameObject Find(string name)
    {
        return GameObject.Find(name);
    }
}
