using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCyTouch : MonoBehaviour
{
    //public static bool anti = false;
    public GameObject BlackCy;
    public GameObject TransCy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Counting.anti == false)
        {
            Counting.BTCyCount++;
            Counting.BlackCyCount++;
            if (Counting.BlackCyCount == 9)
                Counting.BlackCyCount = 1;
            Counting.TransCyCount = Counting.BlackCyCount - 2;
            if (Counting.TransCyCount == -2)
                Counting.TransCyCount = 6;
            else if (Counting.TransCyCount == -1)
                Counting.TransCyCount = 7;
            if (Counting.BTCyCount == 9)
            {
                Counting.anti = true;
                Counting.BlackCyCount = 7;
                Counting.TransCyCount = 1;
            }
        }
        else
        {
            Counting.BTCyCount--;
            Counting.BlackCyCount--;
            if (Counting.BlackCyCount == -1)
                Counting.BlackCyCount = 7;//
            Counting.TransCyCount = Counting.BlackCyCount + 2;
            if (Counting.TransCyCount == 9)
                Counting.TransCyCount = 1;
            else if (Counting.TransCyCount == 10)
                Counting.TransCyCount = 2;
            if (Counting.BTCyCount == 1)
            {
                Counting.inspotcount++;
                Counting.timer2 = 5;
                Counting.anti = false;
            }
        }
        Debug.Log("BlackCyCount " + Counting.BlackCyCount + " TransCyCount " +Counting.TransCyCount + " BYCyCount " + Counting.BTCyCount);
        Counting.create = true;
        Destroy(GameObject.Find("BlackCy(Clone)"));
        Destroy(GameObject.Find("TransCy(Clone)"));
    }

    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
