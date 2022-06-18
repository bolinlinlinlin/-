using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        SquareLimit.sqTouch = false;
    }
    private void OnTriggerStay(Collider other)
    {
        SquareLimit.sqTouch = false;
    }
    private void OnTriggerExit(Collider other)
    {
        SquareLimit.sqTouch = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
