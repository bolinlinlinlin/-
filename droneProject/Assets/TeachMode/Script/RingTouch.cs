using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RingTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ring1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(ring1);
        ScoreCount.score = 10;
        UnityEngine.Debug.Log(ScoreCount.score);
    }

}