using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Misson : MonoBehaviour
{
    public bool InRange1, InRange2, InRange3, InRange4, InRange5, InRange6, InRange7, InRange8, InRange9, StartUp, Land, Fail, out1;
    //public Text PassText, HintText;
    DroneMovementScript droneMovementScript;
    public int checkpoint, RangeCheck;
    public float StopTimer;
    public Text PassText, HintText;

    // Start is called before the first frame update
    void Start()
    {
        RangeCheck = 0;
        InRange1 = true;
        InRange2 = false;
        InRange3 = false;
        InRange4 = false;
        InRange5 = false;
        InRange6 = false;
        InRange7 = false;
        InRange8 = false;
        InRange9 = false;
        StartUp = false;
        Land = false;
        Fail = false;
        out1 = false;
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        checkpoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fail == true)
        {
            UIswitch.BadEnd();
        }

        if (Input.GetKeyDown(KeyCode.Space)) droneMovementScript.start_up = true; //不用內八起飛

        if (InRange1 == true && RangeCheck == 1)
        {
            StopTimer += Time.deltaTime;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內</color>\n3. 任務模式飛行\n4. 準備降落\n5. 降落完成");
            if (StopTimer >= 5)
            {
                RangeCheck = 2;
            }
        }

        if (RangeCheck == 2 && InRange2 == true)
        {
            InRange1 = false;
            RangeCheck = 3;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 任務模式飛行</color>\n4. 準備降落\n5. 降落完成");
        }


        if (InRange2 == true && RangeCheck == 3 && InRange3 == true)
        {
            RangeCheck = 4;
        }

        //角度
        if (InRange2 == true && RangeCheck == 3 && InRange3 == false)
        {
            if (gameObject.transform.eulerAngles.y > 310f || gameObject.transform.eulerAngles.y < 230f)
            {
                if(out1 == true)
                {
                    //Debug.Log("out");
                    Fail = true;
                }
            }
        }


        if (InRange3 == true && RangeCheck == 4 && InRange4 == true)
        {
            RangeCheck = 5;
        }

        //角度
        if (InRange4 == true && RangeCheck == 5 && InRange3 == false)
        {
            if (gameObject.transform.eulerAngles.y > 130f || gameObject.transform.eulerAngles.y < 50f)
            {
                //Debug.Log("out");
                Fail = true;
            }
        }


        if (InRange4 == true && RangeCheck == 5 && InRange5 == true)
        {
            RangeCheck = 6;
        }

        if (InRange5 == true && RangeCheck == 6 && InRange6 == true)
        {
            RangeCheck = 7;
        }

        //角度
        if (InRange6 == true && RangeCheck == 7 && InRange5 == false)
        {
            if (gameObject.transform.eulerAngles.y > 310f || gameObject.transform.eulerAngles.y < 230f)
            {
                //Debug.Log("out");
                Fail = true;
            }
        }


        if (InRange6 == true && RangeCheck == 7 && InRange7 == true)
        {
            RangeCheck = 8;
        }

        if (InRange7 == true && RangeCheck == 8 && InRange8 == true)
        {
            RangeCheck = 9;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 任務模式飛行\n4. 準備降落</color>\n5. 降落完成");
        }

        //角度
        if (InRange8 == true && RangeCheck == 9 && InRange7 == false)
        {
            if (gameObject.transform.eulerAngles.y > 130f || gameObject.transform.eulerAngles.y < 50f)
            {
                //Debug.Log("out");
                Fail = true;
            }
        }

        if (InRange8 == true && RangeCheck == 9 && InRange9 == true)
        {
            //Debug.Log("V");
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 任務模式飛行\n4. 準備降落</color>\n5. 降落完成");

        }
        if(droneMovementScript.start_up == false && RangeCheck == 9)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 任務模式飛行\n4. 準備降落\n5. 降落完成</color>");
            PassText.text = ("通過測試");
            UIswitch.End();
        }
    }
    private void OnTriggerEnter(Collider other) //偵測是否進入有效懸停範圍內
    {
        if (other.gameObject.name == "range1" && RangeCheck == 0)
        {
            InRange1 = true;
            StartUp = true;
            RangeCheck = 1;
        }

        if (other.gameObject.name == "range2")
        {
            InRange2 = true;
        }

        if (other.gameObject.name == "range3" && RangeCheck == 3)
        {
            InRange3 = true;
        }

        if (other.gameObject.name == "range4" && RangeCheck == 4)
        {
            InRange4 = true;
        }

        if (other.gameObject.name == "range5" && RangeCheck == 5)
        {
            InRange5 = true;
        }

        if (other.gameObject.name == "range6" && RangeCheck == 6)
        {
            InRange6 = true;
        }

        if (other.gameObject.name == "range7" && RangeCheck == 7)
        {
            InRange7 = true;
        }

        if (other.gameObject.name == "range8" && RangeCheck == 8)
        {
            InRange8 = true;
        }

        if (other.gameObject.name == "range9" && RangeCheck == 9)
        {
            InRange9 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "range1" && Land == false)
        {
            out1 = true;
        }

        if (other.gameObject.name == "range1" && Land == false && RangeCheck <= 1   )
        {
            //Debug.Log("out");
            Fail = true;
        }

        if (other.gameObject.name == "range2" && Land == false)
        {
            InRange2 = false;
            if (RangeCheck < 3)
            {
                //Debug.Log("out");
                Fail = true;
            }
        }

        if (other.gameObject.name == "range3" && Land == false)
        {
            InRange3 = false;
        }

        if (other.gameObject.name == "range4" && Land == false)
        {
            InRange4 = false;
            if (RangeCheck < 5)
            {
                //Debug.Log("out");
                Fail = true;
            }
        }

        if (other.gameObject.name == "range5" && Land == false)
        {
            InRange5 = false;
        }

        if (other.gameObject.name == "range6" && Land == false)
        {
            InRange6 = false;
            if (RangeCheck < 7)
            {
                //Debug.Log("out"); 
                Fail = true;
            }
        }

        if (other.gameObject.name == "range7" && Land == false)
        {
            InRange7 = false;
        }

        if (other.gameObject.name == "range8" && Land == false)
        {
            InRange8 = false;
            if (RangeCheck < 9)
            {
                //Debug.Log("out"); 
                Fail = true;
            }
        }

        if (other.gameObject.name == "testspace" && RangeCheck <= 1)
        {
            //Debug.Log("out"); 
            Fail = true; //PassText.text = ("未通過測試");
        }
    }
}
