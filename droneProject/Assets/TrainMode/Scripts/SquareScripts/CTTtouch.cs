using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTTtouch : MonoBehaviour
{
    public GameObject ctt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Counting.countt = 1;
        Destroy(ctt);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
