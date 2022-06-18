using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        SquareLimit.sqTouch = true;
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        SquareLimit.sqTouch = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
