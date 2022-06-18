using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EightRingTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public Image BackDark;
    public float ColorAlhpa;
    public float OverTime;

    private bool enter = false, exit = false;
    public GameObject goin, goout;
    public static int ringcount = 0, iscount = 1;
    public Text eightuitext, anglealert, outspacealert;
    public GameObject r5, r9, r10;
    public bool outspace, isIncircle = false, isOutcircle = true;
    private float outspacetimer = 5;
    private int intoutspacetimer = 6;
    public Animator arrow;
    DroneMovementScript droneMovementScript;
    GameObject Drone;

    void Start()
    {
        Drone = GameObject.FindGameObjectWithTag("Drone");
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        ColorAlhpa = 0f;
        OverTime = 0f;
        iscount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("endbool=" + UIswitch.endbool);
        arrow.SetInteger("arrow", iscount);

        if (iscount < 11)
        {
            outspace = isIncircle || !isOutcircle;
        }

        if (iscount == 4)
        {
            r5.SetActive(true);
        }
        if (iscount == 7)
        {
            r9.SetActive(true);
            
        }
        if (iscount == 10)
        {
            r10.SetActive(true);
        }


            anglealert.text = ("請將機頭朝前"); //判斷無人機角度是否朝前
        if ((Drone.transform.eulerAngles.y > 345 || Drone.transform.eulerAngles.y < 15) && ringcount == 0) anglealert.text = ("");
        if (Drone.transform.eulerAngles.y > 275 && (ringcount == 1 || ringcount == 8)) anglealert.text = ("");
        if (Drone.transform.eulerAngles.y > 170 && Drone.transform.eulerAngles.y < 280 && (ringcount == 2 || ringcount == 7)) anglealert.text = ("");
        if (Drone.transform.eulerAngles.y > 80 && Drone.transform.eulerAngles.y < 190 && (ringcount == 3 || ringcount == 6)) anglealert.text = ("");
        if (Drone.transform.eulerAngles.y > 0 && Drone.transform.eulerAngles.y < 100 && (ringcount == 4 || ringcount == 5)) anglealert.text = ("");
        if (Drone.transform.eulerAngles.y > 170 && Drone.transform.eulerAngles.y < 190 && ringcount == 9) anglealert.text = ("");
        if (ringcount == 10) anglealert.text = ("");

        if (outspace == false)
        {
            outspacetimer = 6;
            outspacealert.text = ("");
        }
        else if (outspace == true) //出界5秒即失敗
        {
            outspacetimer -= 1 * Time.deltaTime;
            intoutspacetimer = (int)outspacetimer;
            outspacealert.text = (intoutspacetimer + "秒內回到區域內，否則失敗");
            star.FBIwarning = true;
        }
        if (intoutspacetimer == 0)
        {
            /*OverTime += Time.deltaTime;
            BackDark.GetComponent<Image>().color = new Color(255, 255, 255, ColorAlhpa);
            if (OverTime > 0.05)
            {
                ColorAlhpa += 0.05f;
                BackDark.GetComponent<Image>().color = new Color(255, 255, 255, ColorAlhpa);
                Debug.Log("" + ColorAlhpa);
                OverTime = 0;
            }*/
            //outspacealert.text = ("失敗");
            UIswitch.endbool = true;
            UIswitch.EorB = 2;
            Time.timeScale = 0;
        }
        if (droneMovementScript.start_up == false && iscount == 11)
        {
            //outspacealert.text = ("成功");
            UIswitch.endbool = true;
            UIswitch.EorB = 1;
            Time.timeScale = 0;
            star.starquality = 1;
        }
    }
    private void OnTriggerEnter(Collider other) //檢查同一個圓環進入的方向是否正確
    {
        if (other.gameObject.name == "in" && exit == false)
        {
            enter = true;
            //Destroy(gameObject);
            goin = other.gameObject.transform.parent.gameObject;
        }
        else if (other.gameObject.name == "out" && enter == true)
        {
            exit = true;
            goout = other.gameObject.transform.parent.gameObject;
            if (goout.gameObject.name == goin.gameObject.name)
            {
                ringcount = int.Parse(goout.gameObject.name);
                if (ringcount == iscount)
                {
                    Destroy(goout.gameObject);
                    iscount++;
                    eightuitext.text = ("按照圖示說明操作無人機");
                }
                else eightuitext.text = ("請依序經過圓圈");
            }

            enter = false;
            exit = false;
        }

        if (iscount < 11)
        {
            if (other.gameObject.name == "incircle1" || other.gameObject.name == "incircle2")
            {
                isIncircle = true;
            }
            if (other.gameObject.name == "outcircle1")
            {
                isOutcircle = true;
            }
        }

        if (iscount == 11 && other.gameObject.name == "landing")
        {
            eightuitext.text = ("準備降落");
            outspace = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (iscount < 11)
        {
            if (other.gameObject.name == "incircle1" || other.gameObject.name == "incircle2")
            {
                isIncircle = false;
            }
            if (other.gameObject.name == "outcircle1")
            {
                isOutcircle = false;
            }
        }
        if (iscount == 11 && other.gameObject.name == "landing")
        {
            eightuitext.text = ("準備降落");
            outspace = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (iscount < 11)
        {
            if (other.gameObject.name == "incircle1" || other.gameObject.name == "incircle2")
            {
                isIncircle = true;
            }
            else if (other.gameObject.name == "outcircle1")
            {
                isOutcircle = true;
            }
        }
        if (iscount == 11&& other.gameObject.name =="landing")
        {
            eightuitext.text = ("準備降落");
            outspace = false;
        }

    }

}
