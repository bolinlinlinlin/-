using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counting : MonoBehaviour
{
    public static bool timerbool = false;
    public static int countt = 0;
    public static int Inscountt = 0;
    public int ttimer = 6;
    public Text timing;
    public static bool tt = false;
    public static int ttimerc = 0;
    public static bool time0 = false;
    public float droneStay1 = 0;
    public float droneStay2 = 0;
    public float droneStayRot1 = 0;
    public float droneStayRot2 = 0;
    public int droneStayjud = 0;
    public static bool judStay = false;
    public float judTime = 0;
    public bool inZoneY = false;
    public static bool cyTouch = false;
    public static bool SD = false;
    public bool end = false;
    public GameObject CorridorH2A;
    public GameObject CorridorA2B;
    public GameObject Aspot;
    public GameObject Bspot;
    public GameObject Aspot2;
    public static bool inspot = false;
    public static int inspotcount = 0;
    public static int timer2 = 5;
    public static int BlackCyCount = 0;
    public static int TransCyCount = 6;
    public static bool create = true;
    public bool canCount = true;
    public static bool anti = false;
    public static int BTCyCount = 0;
    public GameObject BlackCy;
    public GameObject TransCy;
    public GameObject One2TwentyCy;
    public GameObject TwentyCy;
    private float[,] CyXZ = new float[,] { { -132f, 117f }, { -136f, 119f }, { -138f, 123f }, { -136f, 127f }, { -132f, 129f }, { -128f, 127f }, { -126f, 123f }, { -128f, 119f }, { -132f, 117f } };//264.5
    GameObject Drone;
    DroneMovementScript droneMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        Drone = GameObject.FindGameObjectWithTag("Drone");
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        InvokeRepeating("Timer", 1, 1);
        InvokeRepeating("Timer2", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("cyTouch:" + cyTouch);
        bool start_up = droneMovementScript.start_up;
        //if (MainMenu.loadingbool == false)
        if (Inscountt < 3)
        {
            if (Drone.transform.position.y > 10f && Drone.transform.position.y < 20f && cyTouch == false)
            {
                inZoneY = true;
                //Debug.Log("inZoneY " + inZoneY + " judStay " + judStay);
            }
            else
            {
                //cyTouch = true;
                inZoneY = false;
                judStay = false;
                Find("Time").GetComponent<CanvasGroup>().alpha = 0;
                ttimer = 6;
            }
        }
        if (Inscountt == 3 && inspotcount == 6)
        {
            if (Drone.transform.position.y > 200f && Drone.transform.position.y < 210f && cyTouch == false)
            {
                inZoneY = true;
                //Debug.Log("inZoneY " + inZoneY + " judStay " + judStay);
            }
            else
            {
                //cyTouch = true;
                inZoneY = false;
                judStay = false;
                Find("Time").GetComponent<CanvasGroup>().alpha = 0;
                ttimer = 6;
            }
        }
        //Debug.Log("inZoneY:" + inZoneY);
        if (start_up == true && Inscountt < 3)
        {
            Find("Start").GetComponent<CanvasGroup>().alpha = 0;
        }
        // Square
        if (countt == 1 && ttimerc == 0) 
        {
            if (time0 == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            else
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向左方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 260f && Drone.transform.eulerAngles.y < 280f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 2 && ttimerc == 1)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向右方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 350f && Drone.transform.eulerAngles.y < 359.9f || Drone.transform.eulerAngles.y > 0.0f && Drone.transform.eulerAngles.y < 10.0f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 3 && ttimerc == 2)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向右方圓柱旋轉";;
                if (Drone.transform.eulerAngles.y > 80f && Drone.transform.eulerAngles.y < 100f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 4 && ttimerc == 3)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向右方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 170f && Drone.transform.eulerAngles.y < 190f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 5 && ttimerc == 4)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向右方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 260f && Drone.transform.eulerAngles.y < 280f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 6 && ttimerc == 5)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向後方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 80f && Drone.transform.eulerAngles.y < 100f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 7 && ttimerc == 6)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向左方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 350f && Drone.transform.eulerAngles.y < 359.9f || Drone.transform.eulerAngles.y > 0.0f && Drone.transform.eulerAngles.y < 10.0f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 8 && ttimerc == 7)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向左方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 260f && Drone.transform.eulerAngles.y < 280f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 9 && ttimerc == 8)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向左方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 170f && Drone.transform.eulerAngles.y < 190f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                }
            }
        }
        else if (countt == 10 && ttimerc == 9)
        {
            if (SD == true)
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            if (time0 == false && SD == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            if (time0 == true)
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向左方圓柱旋轉";
                if (Drone.transform.eulerAngles.y > 80f && Drone.transform.eulerAngles.y < 100f)
                {
                    SD = true;
                    time0 = false;
                    countt++;
                    ttimerc++;
                    end = true;
                }
            }
        }
        else if (countt == 11 && ttimerc == 10)
        {
            if (SD == true)
            {
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
            }
            else
            {
                if (end == true)
                {
                    Find("Instruction").GetComponent<Text>().text = "機頭向左旋轉90°（向右旋轉270°也行ˊˋ）";
                    if (Drone.transform.eulerAngles.y > 350f && Drone.transform.eulerAngles.y < 359.9f || Drone.transform.eulerAngles.y > 0.0f && Drone.transform.eulerAngles.y < 10.0f)
                    {
                        if (time0 == false)
                        {
                            Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
                        }
                        else
                        {
                            Find("Instruction").GetComponent<Text>().text = "降落至H起飛點";
                            if (start_up == false)
                            {
                                Find("Instruction").GetComponent<CanvasGroup>().alpha = 0;
                                //Find("Start").GetComponent<Text>().text = "訓練完成！";
                                //Find("Start").GetComponent<CanvasGroup>().alpha = 1;
                                UIswitch.End();
                                star.starquality = 1;
                            }
                        }
                    }
                }
            }
            
        }
        //Debug.Log("Inscountt " + Inscountt + ", inspot " + inspot + ", inspotcount " + inspotcount + ", time0 " + time0 + ", cyTouch " + cyTouch + ", canChange " + InsSpotTouch.canChange);
        // Insterst
        if (Inscountt == 1)
        {
            if (time0 == false)
            {
                Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
            }
            else
            {
                Find("Instruction").GetComponent<Text>().text = "機頭向A點旋轉";
                if (Drone.transform.eulerAngles.y > 305f && Drone.transform.eulerAngles.y < 325f)
                {
                    SD = true;
                    time0 = false;
                    Inscountt++;
                    Instantiate(CorridorH2A, CorridorH2A.transform.position, Quaternion.Euler(CorridorH2A.transform.eulerAngles));
                    Instantiate(Aspot, Aspot.transform.position, Quaternion.Euler(Aspot.transform.eulerAngles));
                }
            }
        }
        else if (Inscountt == 2)
        {
            if (SD == true)
            {
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
                if (Drone.transform.eulerAngles.y < 305f || Drone.transform.eulerAngles.y > 325f)
                {
                    Find("RotWarning").GetComponent<CanvasGroup>().alpha = 1;
                    Find("RotWarning").GetComponent<Text>().text = (timer2 + " 秒內更正機頭方向，否則失敗");
                }
                else
                {
                    Find("RotWarning").GetComponent<CanvasGroup>().alpha = 0;
                    timer2 = 5;
                }
            }
            if (inspot == true)
            {
                if (inspotcount == 1)
                {
                    Destroy(GameObject.Find("H2A(Clone)"));
                    inspotcount++;
                }
                else if (inspotcount == 2)
                {
                    canCount = false;
                    Find("Instruction").GetComponent<Text>().text = "將機頭朝前";
                    if (Drone.transform.eulerAngles.y > 350f && Drone.transform.eulerAngles.y < 359.9f || Drone.transform.eulerAngles.y > 0.0f && Drone.transform.eulerAngles.y < 10.0f)
                    {
                        Find("Instruction").GetComponent<Text>().text = "依序觸碰黑色圓柱順時針繞一圈";
                        inspotcount++;
                    }
                }
                else if (inspotcount == 3)
                {
                    if (create == true && BlackCyCount>=0)
                    {
                        if (anti == true && BlackCyCount == 7)
                            Find("Instruction").GetComponent<Text>().text = "逆時針繞一圈";
                        //Debug.Log(BlackCyCount);
                        //Debug.Log("TransCyCount " + TransCyCount);
                        Instantiate(BlackCy, new Vector3(CyXZ[BlackCyCount, 0], 15f, CyXZ[BlackCyCount, 1]), Quaternion.Euler(Vector3.zero));
                        Instantiate(TransCy, new Vector3(CyXZ[TransCyCount, 0], 15f, CyXZ[TransCyCount, 1]), Quaternion.Euler(Vector3.zero));
                        create = false;
                    }
                    if (Drone.transform.eulerAngles.y < 350f && Drone.transform.eulerAngles.y > 10f)
                    {
                        Find("RotWarning").GetComponent<CanvasGroup>().alpha = 1;
                        Find("RotWarning").GetComponent<Text>().text = (timer2 + " 秒內更正機頭方向，否則失敗");
                    }
                    else
                    {
                        Find("RotWarning").GetComponent<CanvasGroup>().alpha = 0;
                        timer2 = 5;
                    }
                    if (timer2 == 0)
                    {
                        //Find("RotWarning").GetComponent<Text>().text = "失敗";
                        UIswitch.BadEnd();
                    }
                }
                else if (inspotcount == 4)
                {
                    Find("Instruction").GetComponent<Text>().text = "降落";
                    if (start_up == false)
                    {
                        inspotcount++;
                        Instantiate(Aspot2, Aspot2.transform.position, Quaternion.Euler(Aspot2.transform.eulerAngles));
                    }
                }
                else if (inspotcount == 5)
                {
                    Find("Instruction").GetComponent<Text>().text = "升空至高度約1~2公尺";
                }
                else if (inspotcount == 6)
                {
                    //Debug.Log(inZoneY);
                    //Debug.Log("time0:"+time0);
                    canCount = true;
                    if (time0 == false)
                    {
                        Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
                    }
                    if (time0 == true)
                    {
                        Find("Instruction").GetComponent<Text>().text = "機頭向B點旋轉";
                        if (Drone.transform.eulerAngles.y > 80f && Drone.transform.eulerAngles.y < 100f)
                        {
                            SD = true;
                            time0 = false;
                            Inscountt++;
                            inspotcount = 0;
                            InsSpotTouch.canChange = true;
                            BlackCyCount = 0;
                            TransCyCount = 6;
                            Instantiate(CorridorA2B, CorridorA2B.transform.position, Quaternion.Euler(CorridorA2B.transform.eulerAngles));
                            Instantiate(Bspot, Bspot.transform.position, Quaternion.Euler(Bspot.transform.eulerAngles));
                        }
                    }
                }
            }
        }
        else if (Inscountt == 3)
        {
            if (SD == true)
            {
                Find("Instruction").GetComponent<Text>().text = "朝圓柱方向飛行";
                if (Drone.transform.eulerAngles.y < 80f || Drone.transform.eulerAngles.y > 100f)
                {
                    Find("RotWarning").GetComponent<CanvasGroup>().alpha = 1;
                    Find("RotWarning").GetComponent<Text>().text = (timer2 + " 秒內更正機頭方向，否則失敗");
                }
                else
                {
                    Find("RotWarning").GetComponent<CanvasGroup>().alpha = 0;
                    timer2 = 5;
                }
                if (Drone.transform.position.x > -112f)
                {
                    Destroy(GameObject.Find("InsSpotA(Clone)"));
                }
            }
            if (inspot == true)
            {
                if (inspotcount == 1)
                {
                    Destroy(GameObject.Find("A2B(Clone)"));
                    inspotcount++;
                }
                else if (inspotcount == 2)
                {
                    canCount = false;
                    Find("Instruction").GetComponent<Text>().text = "將機頭朝前";
                    if (Drone.transform.eulerAngles.y > 350f && Drone.transform.eulerAngles.y < 359.9f || Drone.transform.eulerAngles.y > 0.0f && Drone.transform.eulerAngles.y < 10.0f)
                    {
                        Find("Instruction").GetComponent<Text>().text = "依序觸碰黑色圓柱順時針繞一圈";
                        inspotcount++;
                    }
                }
                else if (inspotcount == 3)
                {
                    if (create == true && BlackCyCount >= 0)
                    {
                        if (anti == true && BlackCyCount == 7)
                            Find("Instruction").GetComponent<Text>().text = "逆時針繞一圈";
                        //Debug.Log(BlackCyCount);
                        Instantiate(BlackCy, new Vector3(CyXZ[BlackCyCount, 0]+ 264.5f, 15f, CyXZ[BlackCyCount, 1]), Quaternion.Euler(Vector3.zero));
                        Instantiate(TransCy, new Vector3(CyXZ[TransCyCount, 0]+ 264.5f, 15f, CyXZ[TransCyCount, 1]), Quaternion.Euler(Vector3.zero));
                        create = false;
                    }
                    if (Drone.transform.eulerAngles.y < 350f && Drone.transform.eulerAngles.y > 10f)
                    {
                        Find("RotWarning").GetComponent<CanvasGroup>().alpha = 1;
                        Find("RotWarning").GetComponent<Text>().text = (timer2 + " 秒內更正機頭方向，否則失敗");
                    }
                    else
                    {
                        Find("RotWarning").GetComponent<CanvasGroup>().alpha = 0;
                        timer2 = 5;
                    }
                    if (timer2 == 0)
                    {
                        //Find("RotWarning").GetComponent<Text>().text = "失敗";
                        UIswitch.BadEnd();
                    }
                }
                else if (inspotcount == 4)
                {
                    Find("Instruction").GetComponent<Text>().text = "降落";
                    if (start_up == false)
                    {
                        inspotcount++;
                        Instantiate(One2TwentyCy, One2TwentyCy.transform.position, Quaternion.Euler(One2TwentyCy.transform.eulerAngles));
                        Instantiate(TwentyCy, TwentyCy.transform.position, Quaternion.Euler(TwentyCy.transform.eulerAngles));
                    }
                }
                else if (inspotcount == 5)
                {
                    Find("Instruction").GetComponent<Text>().text = "升空至高度約20公尺";
                    InsSpotTouch.canChange = true;
                }
                else if (inspotcount == 6)
                {
                    canCount = true;
                    Destroy(GameObject.Find("1to20m(Clone)"));
                    Destroy(GameObject.Find("1meterB"));
                    if (time0 == false)
                    {
                        Find("Instruction").GetComponent<Text>().text = "定點停懸5秒以上";
                    }
                    else
                    {
                        //Debug.Log("tt " + tt);
                        if (tt == true)
                        {
                            Find("Instruction").GetComponent<CanvasGroup>().alpha = 0;
                            UIswitch.End();
                            star.starquality = 1;
                            //Find("Start").GetComponent<Text>().text = "訓練完成！";
                            //Find("Start").GetComponent<CanvasGroup>().alpha = 1;
                            Find("Time").GetComponent<CanvasGroup>().alpha = 0;
                            inspotcount++;
                        }
                    }
                }
                else if (inspotcount == 7)
                {
                    Time.timeScale = 0;
                }
            }
        }
    }
    void FixedUpdate()
    {
        Debug.Log(inZoneY);
        if (inZoneY == true && canCount == true)
        {
            if (judStay == false)
            {
                droneStay1 = Drone.transform.position.y;
                droneStayRot1 = Drone.transform.eulerAngles.y;
                droneStayjud++;
                if (droneStayjud == 2)
                {
                    droneStay2 = droneStay1;
                    droneStayRot2 = droneStayRot1;
                }
                if (droneStay2 > Drone.transform.position.y - 1f && droneStay2 < Drone.transform.position.y + 1f && droneStayRot2 > Drone.transform.eulerAngles.y - 5.0f && droneStayRot2 < Drone.transform.eulerAngles.y + 5.0f)
                {
                    /*
                    judTime += Time.deltaTime;
                    if (judTime > 0.01f)
                    {
                        Debug.Log("judStay " + judStay);
                    }*/
                        judStay = true;
                }
                else
                {
                    if (droneStayjud >= 2)
                        droneStayjud = 0;
                    judTime = 0;
                    judStay = false;
                }
            }
            else
            {
                if (droneStay2 < Drone.transform.position.y - 1f || droneStay2 > Drone.transform.position.y + 1f || droneStayRot2 < Drone.transform.eulerAngles.y - 5.0f || droneStayRot2 > Drone.transform.eulerAngles.y + 5.0f)
                {
                    droneStayjud = 0;
                    judTime = 0;
                    judStay = false;
                    //Debug.Log(judStay);
                    Find("Time").GetComponent<CanvasGroup>().alpha = 0;
                    ttimer = 6;

                }
            }
        }
    }
    void Timer()
    {
        //Debug.Log("" + (droneStay2 > Drone.transform.position.y - 1f) +", "+ (droneStay2 < Drone.transform.position.y + 1f) + ", " + (droneStayRot2 > Drone.transform.eulerAngles.y - 5.0f) + ", " + (droneStayRot2 < Drone.transform.eulerAngles.y + 5.0f));
        if (inZoneY == true && canCount == true)
        {
            //Debug.Log("!!!");
            if (timerbool == true && judStay == true && UIswitch.endbool == false)
            {
                //Debug.Log("~~~");
                ttimer -= 1;
                Find("Time").GetComponent<CanvasGroup>().alpha = 1;
                timing.text = (ttimer + " 秒");
                //Debug.Log(ttimer);
                if (ttimer < 1)
                {
                    time0 = true;
                    //Debug.Log(time0);
                    tt = true;
                    //Debug.Log("tt " + tt);
                    ttimer = 6;
                }
            }
        }
    }
    void Timer2()
    {
        timer2--;
    }
    GameObject Find(string name)
    {
        return GameObject.Find(name);
    }
}
