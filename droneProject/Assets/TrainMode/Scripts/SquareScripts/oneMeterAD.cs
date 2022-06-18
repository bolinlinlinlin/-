using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneMeterAD : MonoBehaviour
{
    public GameObject cylinder, cub;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectsWithTag("OneM").Length == 0)
        {
            Destroy(cylinder);
            Instantiate(cub, new Vector3(0.0f, 5.0f, 50.0f), Quaternion.Euler(Vector3.zero));
        }
    }
    // Update is called once per frame
    void Update()
    {
            
    }
}
