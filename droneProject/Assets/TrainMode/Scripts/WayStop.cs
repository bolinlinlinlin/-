using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayStop : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Drone;
    private bool inzone; //判斷xz軸是否在H的範圍內
    private float timer; //計算離開H範圍的時間
    private float ftimer, btimer, rtimer, ltimer;
    public Text uitext, warningtext; //UI訓練提示
    public Text uitextf, uitextb, uitextr, uitextl; //UI四方向秒數計算
    public bool f = false, b = false, r = false, l = false;
    DroneMovementScript droneMovementScript;

    void Start()
    {
        Drone = GameObject.FindGameObjectWithTag("Drone");
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Drone.transform.position.x > -8.5f && Drone.transform.position.x < 9.3f && Drone.transform.position.z > -21.23f && Drone.transform.position.z < -3.64f)
        {
            inzone = true;
        }
        else inzone = false;

        //Debug.Log(Drone.transform.eulerAngles.y);

        if (inzone == true)
        {
            /*ftimer = 0; btimer = 0; rtimer = 0; ltimer = 0; f = false; b = false; r = false; l = false;*/
            timer = 6;
            warningtext.text = ("");
            if (Drone.transform.position.y > 10.5 && Drone.transform.position.y < 21)
            {
                uitext.text = ("訓練中");

                if ((Drone.transform.eulerAngles.y > 350f || Drone.transform.eulerAngles.y < 10f) && f == false)
                {
                    ftimer += 1 * Time.deltaTime;
                    int intftimer = (int)ftimer;
                    uitextf.text = ("前面" + intftimer + "秒");
                    if (ftimer > 5)
                    {
                        uitextf.text = ("前面完成");
                        f = true;
                    }
                }
                else ftimer = 0;


                if (Drone.transform.eulerAngles.y > 80f && Drone.transform.eulerAngles.y < 100f && r == false)
                {
                    rtimer += 1 * Time.deltaTime;
                    int intrtimer = (int)rtimer;
                    uitextr.text = ("右邊" + intrtimer + "秒");
                    if (rtimer > 5)
                    {
                        uitextr.text = ("右邊完成");
                        r = true;
                    }
                }
                else rtimer = 0;


                if (Drone.transform.eulerAngles.y > 170.0f && Drone.transform.eulerAngles.y < 190.0f && b == false)
                {
                    btimer += 1 * Time.deltaTime;
                    int intbtimer = (int)btimer;
                    uitextb.text = ("後面" + intbtimer + "秒");
                    if (btimer > 5)
                    {
                        uitextb.text = ("後面完成");
                        b = true;
                    }
                }
                else btimer = 0;


                if (Drone.transform.eulerAngles.y > 260f && Drone.transform.eulerAngles.y < 280f && l == false)
                {
                    ltimer += 1 * Time.deltaTime;
                    int intltimer = (int)ltimer;
                    uitextl.text = ("左邊" + intltimer + "秒");
                    if (ltimer > 5)
                    {
                        uitextl.text = ("左邊完成");
                        l = true;
                    }

                }
                else ltimer = 0;

            }
            else
            {
                if (Drone.transform.position.y < 10.5)
                {
                    uitext.text = ("往上一點");
                    ftimer = 0;
                    btimer = 0;
                    rtimer = 0;
                    ltimer = 0;
                    if (f == true && b == true && r == true && l == true)
                    {
                        uitext.text = ("準備降落");
                    }
                }

                if (Drone.transform.position.y > 21)
                {
                    uitext.text = ("往下一點");
                    ftimer = 0;
                    btimer = 0;
                    rtimer = 0;
                    ltimer = 0;
                    if (f == true && b == true && r == true && l == true)
                    {
                        uitext.text = ("準備降落");
                    }
                }

            }
            if (f == true && b == true && r == true && l == true)
            {
                uitext.text = ("準備降落");
                if (droneMovementScript.start_up == false)
                {
                    //warningtext.text = ("成功");
                    UIswitch.End();
                    star.starquality = 1;
                }
            }

        }
        else if (inzone == false && timer >= 1)
        {
            star.FBIwarning = true;
            timer -= 1 * Time.deltaTime;
            int inttimer = (int)timer;
            warningtext.text = (inttimer + "秒內回到區域內，否則失敗");
            ftimer = 0;
            btimer = 0;
            rtimer = 0;
            ltimer = 0;
            if (inttimer== 0)
            {
                warningtext.text = ("");
                UIswitch.BadEnd();
            }
        }
    }
}
