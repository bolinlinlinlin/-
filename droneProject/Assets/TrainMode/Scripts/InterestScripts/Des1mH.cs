﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des1mH : MonoBehaviour
{
    public GameObject cylinder;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(cylinder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
