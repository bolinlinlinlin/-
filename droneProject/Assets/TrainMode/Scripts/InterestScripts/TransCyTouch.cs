using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransCyTouch : MonoBehaviour
{
    //public bool isInBlackCy = false;
    //public bool isInTransCy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Counting.anti == false)
        {
            Counting.BTCyCount--;
            Counting.BlackCyCount--;
            if (Counting.BlackCyCount == -1)
                Counting.BlackCyCount = 7;
            else if (Counting.BlackCyCount == 9)
                Counting.BlackCyCount = 1;
            Counting.TransCyCount = Counting.BlackCyCount - 2;
            if (Counting.TransCyCount == -2)
                Counting.TransCyCount = 6;
            else if (Counting.TransCyCount == -1)
                Counting.TransCyCount = 7;
            
        }
        else
        {
            Counting.BTCyCount++;
            Counting.BlackCyCount++;
            if (Counting.BlackCyCount == -1)
                Counting.BlackCyCount = 7;
            else if (Counting.BlackCyCount == 9)
                Counting.BlackCyCount = 1;
            Counting.TransCyCount = Counting.BlackCyCount + 2;
            if (Counting.TransCyCount == 9)
                Counting.TransCyCount = 1;
            else if (Counting.TransCyCount == 10)
                Counting.TransCyCount = 2;
        }
        Counting.create = true;
        Destroy(GameObject.Find("BlackCy(Clone)"));
        Destroy(GameObject.Find("TransCy(Clone)"));
    }
    private void OnTriggerStay(Collider other)
    {
        //isInTransCy = true;
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
