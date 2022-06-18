using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsCTTtouch : MonoBehaviour
{
    public GameObject Insctt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Counting.Inscountt = 1;
        Destroy(Insctt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
