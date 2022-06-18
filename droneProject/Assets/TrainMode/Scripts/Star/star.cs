using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star : MonoBehaviour
{
    public static int starquality = 0;
    public static bool FBIwarning = false;
    public int timerOfAllsec = 0;
    public int timerOfAllmin = 0;
    public Text TotalOfTime;
    public bool Limitbool = true;
    public GameObject star2;
    public GameObject star3;
    public GameObject star2H;
    public GameObject star3H;
    private bool zaLast = false;
    // Start is called before the first frame update
    void Start()
    {
        starquality = 0;
        FBIwarning = false;
        timerOfAllsec = 0;
        timerOfAllmin = 0;
        Limitbool = true;
        InvokeRepeating("Timer", 1, 1);
        star2.SetActive(false);
        star3.SetActive(false);
        star2H.SetActive(false);
        star3H.SetActive(false);
        zaLast = false;
    }

    // Update is called once per frame
    void Update()
    {
        TotalOfTime.text = string.Format("{0:00} {1:00}", timerOfAllmin, timerOfAllsec);
        #region TotalOfTime.text 改成上面那句，沒問題的話整段都可以刪掉
        /*
        if (timerOfAllmin < 1)
        {
            if (timerOfAllsec < 10)
            {
                TotalOfTime.text = "00:0" + timerOfAllsec;
            }
            else
            {
                TotalOfTime.text = "00:" + timerOfAllsec;
            }
        }
        else
        {
            if (timerOfAllmin < 10)
            {
                if (timerOfAllsec < 10)
                {
                    TotalOfTime.text = "0" + timerOfAllmin + ":0" + timerOfAllsec;
                }
                else
                {
                    TotalOfTime.text = "0" + timerOfAllmin + ":" + timerOfAllsec;
                }
            }
            else
            {
                if (timerOfAllsec < 10)
                {
                    TotalOfTime.text = timerOfAllmin + ":0" + timerOfAllsec;
                }
                else
                {
                    TotalOfTime.text = timerOfAllmin + ":" + timerOfAllsec;
                }
            }
        }
        */
        #endregion

        if (MainMenu.SceneNumber == 6) // waystop
        {
            if (timerOfAllmin != 0 || timerOfAllsec > 40)
            {
                Limitbool = false;
            }
        }
        else if (MainMenu.SceneNumber == 4) // eight
        {
            if (timerOfAllmin > 0 && timerOfAllsec > 0)
            {
                Limitbool = false;
            }
        }
        else if (MainMenu.SceneNumber == 5) // square
        {
            if (timerOfAllmin > 1 && timerOfAllsec > 0)
            {
                Limitbool = false;
            }
        }
        else if (MainMenu.SceneNumber == 7) // interest
        {
            if (timerOfAllmin > 0 && timerOfAllsec > 30)
            {
                Limitbool = false;
            }
        }
        else if (MainMenu.SceneNumber == 8) // five
        {
            if (timerOfAllmin != 0 || timerOfAllsec > 40)
            {
                Limitbool = false;
            }
        }
        else if (MainMenu.SceneNumber == 9) // frontback
        {
            if (timerOfAllmin != 0 || timerOfAllsec > 40)
            {
                Limitbool = false;
            }
        }

        if (UIswitch.endbool == true && zaLast == false)
        {
            // Debug.Log("starqualityF:" + starquality);
            // Debug.Log("FBIwarning:" + FBIwarning);
            // Debug.Log("Limitbool:" + Limitbool);
            if (FBIwarning == false)
            {
                starquality += 1;
            }
            if (Limitbool == true)
            {
                starquality += 1;
            }
            if (starquality == 1)
            {
                star2H.SetActive(true);
                star3H.SetActive(true);
            }
            else if (starquality == 2)
            {
                star2.SetActive(true);
                star3H.SetActive(true);
            }
            else if (starquality == 3)
            {
                star2.SetActive(true);
                star3.SetActive(true);
            }
            zaLast = true;
            // Debug.Log("starqualityL:" + starquality);
        }
    }

    void Timer()
    {
        if (Time.timeScale == 1)
        {
            timerOfAllsec++;
            if (timerOfAllsec == 60)
            {
                timerOfAllmin++;
                timerOfAllsec = 0;
            }
        }
    }
}
