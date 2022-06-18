using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylinderAppeared : MonoBehaviour
{
    public static int CylinderCount = 0;
    public static bool CylinderAppear = false;
    public GameObject CylinderNew;
    private float[,] XZ = new float[,] { { 0f, 0f }, { -60.0f, -10f }, { -60.0f, 110f }, { 60.0f, 110f }, { 60.0f, -10f }, { 0f, -10f }, { 60.0f, -10f }, { 60.0f, 110f }, { -60.0f, 110f }, { -60.0f, -10f }, { 0f, -10f } };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CylinderAppear == true)
        {
            CylinderAppear = false;
            if (CylinderCount >= 0 && CylinderCount <= 10)
                Instantiate(CylinderNew, new Vector3(XZ[CylinderCount, 0], 15.0f, XZ[CylinderCount, 1]), Quaternion.Euler(Vector3.zero));
            /*
            if (CylinderCount == 1)
                Instantiate(CylinderNew, new Vector3(-60.0f, 15.0f, -10.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 2)
                Instantiate(CylinderNew, new Vector3(-60.0f, 15.0f, 110.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 3)
                Instantiate(CylinderNew, new Vector3(60.0f, 15.0f, 110.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 4)
                Instantiate(CylinderNew, new Vector3(60.0f, 15.0f, -10.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 5)
                Instantiate(CylinderNew, new Vector3(0.0f, 15.0f, -10.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 6)
                Instantiate(CylinderNew, new Vector3(60.0f, 15.0f, -10.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 7)
                Instantiate(CylinderNew, new Vector3(60.0f, 15.0f, 110.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 8)
                Instantiate(CylinderNew, new Vector3(-60.0f, 15.0f, 110.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 9)
                Instantiate(CylinderNew, new Vector3(-60.0f, 15.0f, -10.0f), Quaternion.Euler(Vector3.zero));
            else if (CylinderCount == 10)
                Instantiate(CylinderNew, new Vector3(0.0f, 15.0f, -10.0f), Quaternion.Euler(Vector3.zero));
            ????????????????????????????????????????????????????????
            else if (CylinderCount == 10)
                CylinderCount = 0;
            */
        }
    }
}
