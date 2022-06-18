using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontBack : MonoBehaviour
{
    DroneMovementScript droneMovementScript;
    public Text uitext, hinttext, warningtext; //UI訓練提示
    public int checkpoint = 0;
    public float timer, outtimer=6;
    public bool stayrange = true, inrange, failed;
    public GameObject landrange, testspace;
    public Animator arrow;

    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        inrange = true;
    }

    void Update()
    {
        arrow.SetInteger("arrow", (int)checkpoint);

        if (checkpoint==0 && droneMovementScript.start_up==true)
        {
            hinttext.text = ("起飛至1-2公尺停懸");
            checkpoint = 1;
        }
        if(checkpoint == 2)
        {
            uitext.text = ("進入範圍內");
            timer += 1 * Time.deltaTime;
            int inttimer = (int)timer;
            hinttext.text = ("懸停" + inttimer + "秒");
            if (timer > 5)
            {
                uitext.text = ("將機頭朝向左方");
                hinttext.text = ("懸停完成");
                checkpoint = 3;
            }
        }
        if (checkpoint == 3)
        {
            if (stayrange == true)
            {
                if (gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280)
                {
                    uitext.text = ("往前飛行至角椎上方1-2公尺");
                    hinttext.text = ("");
                }

                if (!(gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280))
                {
                    uitext.text = ("將機頭朝向左方");
                }
            }
        }
        if (checkpoint == 4)
        {
            stayrange = true;
            uitext.text = ("進入範圍內");
            timer += 1 * Time.deltaTime;
            int inttimer = (int)timer;
            hinttext.text = ("懸停" + inttimer + "秒");
            if (timer > 5)
            {
                uitext.text = ("後退至後方角椎");
                hinttext.text = ("懸停完成");
                checkpoint = 5;
                stayrange = false;
            }
        }

        if (checkpoint == 5)
        {
            if (stayrange == true)
            {
                if (gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280)
                {
                    uitext.text = ("後退至後方角椎");
                    hinttext.text = ("");
                }

                if (!(gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280))
                {
                    uitext.text = ("將機頭朝向左方角錐");
                }
            }
        }

        if (checkpoint == 6)
        {
            stayrange = true;
            uitext.text = ("進入範圍內");
            timer += 1 * Time.deltaTime;
            int inttimer = (int)timer;
            hinttext.text = ("懸停" + inttimer + "秒");
            if (timer > 5)
            {
                uitext.text = ("前進至H點上方1-2公尺");
                hinttext.text = ("懸停完成");
                checkpoint = 7;
                stayrange = false;
            }
        }

        if (checkpoint == 8)
        {
            if (stayrange == true)
            {
                if (gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280)
                {
                    uitext.text = ("前進至H點上方1-2公尺");
                    hinttext.text = ("");
                }

                if (!(gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280))
                {
                    uitext.text = ("將機頭朝向左方角錐");
                }
            }
        }

        if (checkpoint == 9)
        {
            stayrange = true;
            uitext.text = ("進入範圍內");
            timer += 1 * Time.deltaTime;
            int inttimer = (int)timer;
            hinttext.text = ("懸停" + inttimer + "秒");
            if (timer > 5)
            {
                uitext.text = ("準備降落");
                hinttext.text = ("懸停完成");
                checkpoint = 10;
                stayrange = false;
                landrange.SetActive(true);
                testspace.SetActive(false);
            }

        }
        if (checkpoint == 11 && droneMovementScript.start_up == false)
        {
            star.starquality = 1;
            uitext.text = ("降落完成");
            hinttext.text = ("完成訓練");
            UIswitch.End();
        }

        if(inrange == false)
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "range1" &&checkpoint ==1)
        {
            checkpoint = 2;
            landrange.SetActive(false);
            testspace.SetActive(true);
        }
        if (other.name == "range2" && checkpoint == 3)
        {
            checkpoint = 4;
            timer = 0;
        }
        if (other.name == "range3" && checkpoint == 5)
        {
            checkpoint = 6;
            timer = 0;
        }
        if (other.name == "range1" && checkpoint == 8)
        {
            checkpoint = 9;
            timer = 0;
        }
        if (other.name == "landrange")
        {
            if(checkpoint==1) hinttext.text = ("起飛至1-2公尺停懸");
            if (checkpoint == 10)
            {
                hinttext.text = ("");
                checkpoint = 11;
            }
        }

        if(other.name == "Cube1")
        {
            inrange = true;
            outtimer = 6;
            warningtext.text = ("");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "range1" && checkpoint ==2)
        {
            timer = 0;
            uitext.text = ("請回到範圍內");
            hinttext.text = ("");
            checkpoint = 1;
        }
        if (other.name == "range2" && checkpoint == 4)
        {
            timer = 0;
            uitext.text = ("請回到範圍內");
            hinttext.text = ("");
            stayrange = false;
            checkpoint = 3;
        }
        if (other.name == "range2" && checkpoint == 5)
        {
            stayrange = true;
        }
        if (other.name == "range3" && checkpoint == 6)
        {
            timer = 0;
            uitext.text = ("請回到範圍內");
            hinttext.text = ("");
            stayrange = false;
            checkpoint = 5;
        }
        if (other.name == "range3" && checkpoint == 7)
        {
            checkpoint = 8;
            stayrange = true;
        }
        if (other.name == "range1" && checkpoint == 9)
        {
            timer = 0;
            uitext.text = ("請回到範圍內");
            hinttext.text = ("");
            stayrange = false;
            checkpoint = 8;
        }
        if (other.name == "landrange")
        {
           hinttext.text = ("請回到範圍內");
            if (checkpoint == 11) checkpoint = 10;
        }
        if (other.name == "Cube1")
        {
            inrange = false;
        }
    }
}
