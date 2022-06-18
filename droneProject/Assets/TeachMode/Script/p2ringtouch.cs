using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2ringtouch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ring2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool add = false;
    private void OnTriggerEnter(Collider other)
    {
        
        add = true;
        if (add == true)
        {
            ScoreCount.score += 10;
            add = false;
        }
        Destroy(ring2);
        UnityEngine.Debug.Log(ScoreCount.score);
    }
}