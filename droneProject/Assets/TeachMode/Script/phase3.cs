using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase3 : MonoBehaviour
{
    public GameObject ring2;
    public bool end = false;
    public static float ry = 0;
    public static bool ringappear = false;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreCount.score >= 60f && end == false)
        {
            if (ringappear == false)
            {
                if (ry < 10f)
                {
                    ry = Random.Range(10f, 30f);
                    Instantiate(ring2, new Vector3(Random.Range(-13f, 13f), ry, Random.Range(-13f, 13f)), Quaternion.Euler(new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f))));
                }
                else
                {
                    Instantiate(ring2, new Vector3(Random.Range(-13f, 13f), Random.Range(10f, 30f), Random.Range(-13f, 13f)), Quaternion.Euler(new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f))));
                }
                ringappear = true;
            }
            if (ScoreCount.score == 90)
            {
                end = true;
            }
        }
    }
}