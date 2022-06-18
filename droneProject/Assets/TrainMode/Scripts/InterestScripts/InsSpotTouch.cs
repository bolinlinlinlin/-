using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsSpotTouch : MonoBehaviour
{
    public static bool canChange = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Counting.timerbool = true;
        SquareLimit.sqTouch = false;
        Counting.cyTouch = false;
        Debug.Log("cyTouch " + Counting.cyTouch + " canChange " + canChange);
        Counting.SD = false;
        Counting.inspot = true;
        if (canChange)
        {
            Debug.Log("canChange " + canChange);
            Counting.inspotcount++;
            canChange = false;
            Debug.Log("canChange " + canChange);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        SquareLimit.sqTouch = false;
    }
    private void OnTriggerExit(Collider other)
    {
        SquareLimit.sqTouch = true;
        Counting.cyTouch = true;
        Counting.inspot = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Counting.cyTouch:" + Counting.cyTouch);
        if (Counting.inspotcount == 6)
        {
            //Counting.timerbool = true;
            if (Counting.tt == true)
            {
                Counting.timerbool = false;
                Counting.judStay = false;
                Find("Time").GetComponent<CanvasGroup>().alpha = 0;
                Counting.tt = false;
            }
        }
    }
    GameObject Find(string name)
    {
        return GameObject.Find(name);
    }
}
