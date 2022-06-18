using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class phase2 : MonoBehaviour
{
    public GameObject player;
    public GameObject ring1;
    public bool is7 = false;
    public bool p2 = true;
    public static bool p3 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreCount.score == 10 && p2 == true)
        {
            Instantiate(ring1, new Vector3(14.63f, 30.0f, 11.62f), Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f)));
            Instantiate(ring1, new Vector3(-11.76f, 30.0f, 14.62f), Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f)));
            Instantiate(ring1, new Vector3(-14.76f, 30.0f, -11.64f), Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f)));
            Instantiate(ring1, new Vector3(11.63f, 30.0f, -14.64f), Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f)));
            Instantiate(ring1, new Vector3(14.63f, 13.0f, -14.64f), Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
            p2 = false;

        }
        if (ScoreCount.score >= 60f)
        {
            p3 = true;
        }
    }
}