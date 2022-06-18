using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotLimit : MonoBehaviour
{
    public int timer = 5;
    public Text rotWarning;
    private float[,] eulerAnglesY = new float[,] { { 0f, 0f }, { 260f, 280f }, { 350f, 370f }, { 80f, 100f }, { 170f, 190f }, { 260f, 280f }, { 80f, 100f }, { 350f, 370f }, { 260f, 280f }, { 170f, 190f }, { 80f, 100f } };
    GameObject Drone;

    // Start is called before the first frame update
    void Start()
    {
        Drone = GameObject.FindGameObjectWithTag("Drone");
        InvokeRepeating("Timer", 1, 1);
        Counting.SD = false;
        Counting.countt = 0;
        Counting.ttimerc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //CanvasGroup CanvasGroup = GameObject.Find("RotWarning").GetComponent<CanvasGroup>();
        float y = Drone.transform.eulerAngles.y;
        if (y <= 10)
            y += 360;
        int countt = Counting.countt;
        int ttimerc = Counting.ttimerc;
        if (Counting.SD == true && (countt - ttimerc == 1) && ttimerc != 0 && (y < eulerAnglesY[ttimerc, 0] || y > eulerAnglesY[ttimerc, 1]))
        {
            //CanvasGroup.alpha = 1;
            rotWarning.GetComponent<CanvasGroup>().alpha = 1;
            rotWarning.text = (timer + " 秒內更正機頭方向，否則失敗");
            //star.FBIwarning = true;
        }
        else
        {
            //CanvasGroup.alpha = 0;
            rotWarning.GetComponent<CanvasGroup>().alpha = 0;
            timer = 5;
        }
        if (timer == 0)
        {
            //rotWarning.text = "失敗";
            UIswitch.BadEnd();
        }
    }

    void Timer()
    {
        timer--;
    }
}
