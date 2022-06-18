using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareLimit : MonoBehaviour
{
    public static bool sqTouch = false;
    public int timer = 5;
    public Text warning;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Timer", 1, 1);
        sqTouch = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sqTouch);
        if (sqTouch == true)
        {
            warning.GetComponent<CanvasGroup>().alpha = 1;
            warning.text = (timer + " 秒內回到航道，否則失敗");
            star.FBIwarning = true;
        }
        else
        {
            warning.GetComponent<CanvasGroup>().alpha = 0;
            timer = 5;
        }
        if (timer == 0)
        {
            //warning.text = "失敗";
            UIswitch.BadEnd();
        }
    }
    void Timer()
    {
        timer -= 1;
        if (timer == 0)
            CancelInvoke("Timer");
    }
}
