using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Five : MonoBehaviour
{
    DroneMovementScript droneMovementScript;
    public Text uitext, hinttext, warningtext; //UI訓練提示
    public int checkpoint = 0;
    public int collider_num;
    public float timer, outtimer = 6;
    public bool inrange, failed;
    public GameObject LandSpace, range;
    public Animator arrow;

    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        inrange = true;
        outtimer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        arrow.SetInteger("arrow", (int)checkpoint);

        if (inrange == false)
        {
            star.FBIwarning = true;
            outtimer -= 1 * Time.deltaTime;
            int intouttimer = (int)outtimer;
            warningtext.text = (intouttimer + "秒內回到區域內，否則失敗");
            if (outtimer < 0)
            {
                failed = true;
                outtimer = 0;
                UIswitch.BadEnd();
            }
        }

        if (checkpoint == 0 && droneMovementScript.start_up == true)
        {
            hinttext.text = ("起飛至1-2公尺停懸");
            checkpoint = 1;
        }
        if (checkpoint == 2)
        {
            uitext.text = ("進入範圍內");
            timer += 1 * Time.deltaTime;
            int inttimer = (int)timer;
            hinttext.text = ("懸停" + inttimer + "秒");
            if (timer > 5)
            {
                uitext.text = ("將機頭朝向行進方向，依照圖示方向前進");
                hinttext.text = ("懸停完成");
                checkpoint = 3;
            }
        }
        if (collider_num ==3)
        {
            uitext.text = ("依照圖示方向前進");
            hinttext.text = ("");
        }
        if (checkpoint == 4 && collider_num==2)
        {
            if (gameObject.transform.eulerAngles.y > 80 && gameObject.transform.eulerAngles.y < 100)
            {
                uitext.text = ("依照圖示方向前進");
                hinttext.text = ("");
            }

            if (!(gameObject.transform.eulerAngles.y > 80 && gameObject.transform.eulerAngles.y < 100))
            {
                uitext.text = ("將機頭朝向飛行方向");
            }
        }
        if (checkpoint == 5 && collider_num == 2)
        {
            if (gameObject.transform.eulerAngles.y > 350 || gameObject.transform.eulerAngles.y < 10)
            {
                uitext.text = ("依照圖示方向前進");
                hinttext.text = ("");
            }

            if (!(gameObject.transform.eulerAngles.y > 350 || gameObject.transform.eulerAngles.y < 10))
            {
                uitext.text = ("將機頭朝向飛行方向");
            }
        }
        if (checkpoint == 6 && collider_num == 2)
        {
            if (gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280)
            {
                uitext.text = ("依照圖示方向前進");
                hinttext.text = ("");
            }

            if (!(gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280))
            {
                uitext.text = ("將機頭朝向飛行方向");
            }
        }
        if (checkpoint == 7 && collider_num == 2)
        {
            if (gameObject.transform.eulerAngles.y > 170 && gameObject.transform.eulerAngles.y < 190)
            {
                uitext.text = ("依照圖示方向前進");
                hinttext.text = ("");
            }

            if (!(gameObject.transform.eulerAngles.y > 170 && gameObject.transform.eulerAngles.y < 190))
            {
                uitext.text = ("將機頭朝向飛行方向");
            }
        }
        if (checkpoint == 8 && collider_num == 2)
        {
            if (gameObject.transform.eulerAngles.y > 80 && gameObject.transform.eulerAngles.y < 100)
            {
                uitext.text = ("依照圖示方向前進");
                hinttext.text = ("");
            }

            if (!(gameObject.transform.eulerAngles.y > 80 && gameObject.transform.eulerAngles.y < 100))
            {
                uitext.text = ("將機頭朝向飛行方向");
            }
        }
        if (checkpoint == 9)
        {
            uitext.text = ("準備降落");
            hinttext.text = ("");
        }
        if (checkpoint==9&& droneMovementScript.start_up == false && inrange ==true)
        {
            uitext.text = ("降落完成");
            hinttext.text = ("完成訓練");
            UIswitch.End();
            star.starquality = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LandSpace")
        {
            inrange = true;
            outtimer = 6;
            warningtext.text = ("");
        }
        collider_num++;
        if(checkpoint==1 && other.name == "range")
        {
            checkpoint = 2;
            LandSpace.SetActive(false);
        }
        if (checkpoint == 3 && other.name == "side1")
        {
            checkpoint = 4;
        }
        if (checkpoint == 4 && other.name == "side2")
        {
            checkpoint = 5;
        }
        if (checkpoint == 5 && other.name == "side3")
        {
            checkpoint = 6;
        }
        if (checkpoint == 6 && other.name == "side4")
        {
            checkpoint = 7;
        }
        if (checkpoint == 7 && other.name == "side5")
        {
            checkpoint = 8;
        }
        if ((other.name == "side1" || other.name == "side2" || other.name == "side3" || other.name == "side4" || other.name == "side5") && collider_num >= 2 && checkpoint<9)
        {
            inrange = true;
            outtimer = 6;
            warningtext.text = ("");
        }
        if (checkpoint == 8 && other.name == "range")
        {
            checkpoint = 9;
            LandSpace.SetActive(true);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        collider_num--;
        if (other.name == "LandSpace")
        {
            inrange = false;
        }
        if (other.name == "range" && checkpoint==2)
        {
            star.FBIwarning = true;
            timer = 0;
            uitext.text = ("請回到範圍內");
            hinttext.text = ("");
            checkpoint = 1;
        }
        if ((other.name == "side1" || other.name == "side2" || other.name == "side3" || other.name == "side4" || other.name == "side5" ) && collider_num < 2 && checkpoint < 9)
        {
            inrange = false;
        }
        
    }
}
