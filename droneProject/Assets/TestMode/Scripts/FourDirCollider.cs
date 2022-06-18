using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourDirCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public Text PassText, HintText, ftext, btext, rtext, ltext;
    public bool InRange, StartUp, Land;
    public bool f = false, b = false, r = false, l = false; //前後左右的懸停判斷
    public bool Failed;
    public float ftimer, btimer, rtimer, ltimer;
    DroneMovementScript droneMovementScript;
    public int checkpoint;
    public Animator FiveCount;

    void Start()
    {
        InRange = true;
        StartUp = false;
        Land = false;
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        checkpoint = 1;
        Failed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Failed == true)
        {
            UIswitch.BadEnd();
        }
        //HintText.text = ("測試");
        //Debug.Log(gameObject.transform.eulerAngles.y);
        if (Input.GetKeyDown(KeyCode.Space)) droneMovementScript.start_up = true; //不用內八起飛

        if (StartUp == true && checkpoint == 1)
        {
            checkpoint = 2;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內</color>\n3. 四面懸停\n\n\n\n\n4. 準備降落\n5. 降落完成");
        }

        if (InRange == true)
        {
            if ((gameObject.transform.eulerAngles.y > 350f || gameObject.transform.eulerAngles.y < 10f) && f == false && StartUp == true)
            {
                FiveCount.SetFloat("FiveCount", ftimer);
                ftimer += 1 * Time.deltaTime;
                if (checkpoint == 2 && ftimer > 1)
                {
                    checkpoint = 3;
                    HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 四面懸停</color>\n\n\n\n\n4. 準備降落\n5. 降落完成");
                }
                if (ftimer > 5)
                {
                    FiveCount.SetFloat("FiveCount", ftimer);
                    f = true;
                    Debug.Log("f通過");
                    //HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 四面懸停\n</color>\n\n\n\n4. 準備降落\n5. 降落完成");
                    ftext.text=("<color=green>前方懸停</color>");
                }
            }
            //else ftimer = 0;


            if (gameObject.transform.eulerAngles.y > 80f && gameObject.transform.eulerAngles.y < 100f && r == false && StartUp == true)
            {
                FiveCount.SetFloat("FiveCount", rtimer);
                rtimer += 1 * Time.deltaTime;
                if (rtimer > 5)
                {
                    FiveCount.SetFloat("FiveCount", rtimer);
                    r = true;
                    Debug.Log("r通過");
                    //HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 四面懸停\n\n</color>\n\n\n4. 準備降落\n5. 降落完成");
                    rtext.text = ("<color=green>右方懸停</color>");
                }
            }
            else rtimer = 0;


            if (gameObject.transform.eulerAngles.y > 170.0f && gameObject.transform.eulerAngles.y < 190.0f && b == false && StartUp == true)
            {
                FiveCount.SetFloat("FiveCount", btimer);
                btimer += 1 * Time.deltaTime;
                if (btimer > 5)
                {
                    FiveCount.SetFloat("FiveCount", btimer);
                    b = true;
                    Debug.Log("b通過");
                    //HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 四面懸停\n\n\n</color>\n\n4. 準備降落\n5. 降落完成");
                    btext.text = ("<color=green>後方懸停</color>");
                }
            }
            else btimer = 0;


            if (gameObject.transform.eulerAngles.y > 260f && gameObject.transform.eulerAngles.y < 280f && l == false && StartUp == true)
            {
                FiveCount.SetFloat("FiveCount", ltimer);
                ltimer += 1 * Time.deltaTime;
                if (ltimer > 5)
                {
                    FiveCount.SetFloat("FiveCount", ltimer);
                    l = true;
                    Debug.Log("l通過");
                    //HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 四面懸停\n\n\n\n\n4. 準備降落</color>\n5. 降落完成");
                    ltext.text = ("<color=green>左方懸停</color>");
                }

            }
            else ltimer = 0;

            if (f == true && b == true && r == true && l == true)
            {

                Land = true;
                if (checkpoint == 3)
                {
                    checkpoint = 4;
                    HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 四面懸停\n\n\n\n\n4. 準備降落</color>\n5. 降落完成");
                }
                if ((gameObject.transform.eulerAngles.y > 350f || gameObject.transform.eulerAngles.y < 10f) && droneMovementScript.atground == true && droneMovementScript.start_up == false)
                {
                    PassText.text = ("通過測試"); //通過測試檢查點
                    if (checkpoint == 4 && droneMovementScript.start_up == false)
                    {
                        checkpoint = 5;
                        HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 四面懸停\n\n\n\n\n4. 準備降落\n5. 降落完成</color>");
                        UIswitch.End();
                    }
                }
                if ((gameObject.transform.eulerAngles.y < 351f && gameObject.transform.eulerAngles.y > 9f) && droneMovementScript.atground == true)
                {
                    //PassText.text = ("未通過測試");
                    Failed = true;
                }
            }
        }
        else if (InRange == false && Land == false)
        {
            //PassText.text = ("未通過測試");
            Failed = true;
        }
    }
    private void OnTriggerEnter(Collider other) //偵測是否進入有效懸停範圍內
    {
        Debug.Log(other.name);
        if (other.gameObject.name == "range")
        {
            InRange = true;
            StartUp = true;
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out");
        if (other.gameObject.name == "range" && Land == false) InRange = false;
        if (other.gameObject.name == "testspace")
        {
            //PassText.text = ("未通過測試");
            Failed = true;
        }
    }
}
