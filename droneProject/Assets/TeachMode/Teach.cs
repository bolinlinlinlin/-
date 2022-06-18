using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teach : MonoBehaviour
{
    DroneMovementScript droneMovementScript;
    public int hand = 0;
    public int once = 0;
    public Text start;
    public Text land;
    public Text CN, CNforward, CNback, CNleft, CNright, CNup, CNdown, CNspinleft, CNspinright;
    public Text JP, JPforward, JPback, JPspinleft, JPspinright, JPup, JPdown, JPleft, JPright;
    public Text US, USup, USdown, USspinleft, USspinright, USforward, USback, USleft, USright;
    Text[,] TextArray;
    CanvasGroup[,] canvasGroupArray;

    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();

        hand = GameObjectScript.country;
        //CN = 0  US = 1  JP = 2 

        TextArray = new Text[3, 9] { { CN, CNforward, CNback, CNleft, CNright, CNup, CNdown, CNspinleft, CNspinright }, { US, USup, USdown, USspinleft, USspinright, USforward, USback, USleft, USright }, { JP, JPforward, JPback, JPspinleft, JPspinright, JPup, JPdown, JPleft, JPright } };
        canvasGroupArray = new CanvasGroup[3, 9];
        for (int i=0;i<3;i++)
        {
            for(int j=0;j<9;j++)
            {
                if (TextArray[i, j].gameObject.GetComponent<CanvasGroup>() == null)
                    canvasGroupArray[i, j] = TextArray[i, j].gameObject.AddComponent<CanvasGroup>();
                else
                    canvasGroupArray[i, j] = TextArray[i, j].gameObject.GetComponent<CanvasGroup>();
            }
        }
        foreach(CanvasGroup cg in canvasGroupArray)
        {
            cg.alpha = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (hand == i)
                    canvasGroupArray[i, j].alpha = 1;
                else
                    canvasGroupArray[i, j].alpha = 0;
            }
        }

        once = 0;
    }

    void Update()
    {
        if (droneMovementScript.start_up != false && once == 0)
        {
            start.GetComponent<CanvasGroup>().alpha = 0;
            once = 1;
        }

        if (hand == 0)
        {
            land.text = ("<color=#732F2F>降落至地面後，右手搖桿↓\n持續兩秒鐘即可關閉無人機\n並退出教學模式</color>");
            if (droneMovementScript.angleregion_num_L_without_country == 1 || droneMovementScript.angleregion_num_L_without_country == 2 || droneMovementScript.angleregion_num_L_without_country == 8)
            {
                CNforward.text = ("<color=green>左手搖桿↑：向前飛</color>");
            }
            else
            {
                CNforward.text = ("左手搖桿↑：向前飛");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 5 || droneMovementScript.angleregion_num_L_without_country == 4 || droneMovementScript.angleregion_num_L_without_country == 6)
            {
                CNback.text = ("<color=green>左手搖桿↓：向後飛</color>");
            }
            else
            {
                CNback.text = ("左手搖桿↓：向後飛");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 7 || droneMovementScript.angleregion_num_L_without_country == 6 || droneMovementScript.angleregion_num_L_without_country == 8)
            {
                CNleft.text = ("<color=green>左手搖桿←：向左飛</color>");
            }
            else
            {
                CNleft.text = ("左手搖桿←：向左飛");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 3 || droneMovementScript.angleregion_num_L_without_country == 2 || droneMovementScript.angleregion_num_L_without_country == 4)
            {
                CNright.text = ("<color=green>左手搖桿→：向右飛</color>");
            }
            else
            {
                CNright.text = ("左手搖桿→：向右飛");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 1 || droneMovementScript.angleregion_num_R_without_country == 2 || droneMovementScript.angleregion_num_R_without_country == 8)
            {
                CNup.text = ("<color=green>右手搖桿↑：上　升</color>");
            }
            else
            {
                CNup.text = ("右手搖桿↑：上　升");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 5 || droneMovementScript.angleregion_num_R_without_country == 4 || droneMovementScript.angleregion_num_R_without_country == 6)
            {
                CNdown.text = ("<color=green>右手搖桿↓：下　降</color>");
            }
            else
            {
                CNdown.text = ("右手搖桿↓：下　降");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 7 || droneMovementScript.angleregion_num_R_without_country == 6 || droneMovementScript.angleregion_num_R_without_country == 8)
            {
                CNspinleft.text = ("<color=green>右手搖桿←：向左旋</color>");
            }
            else
            {
                CNspinleft.text = ("右手搖桿←：向左旋");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 3 || droneMovementScript.angleregion_num_R_without_country == 2 || droneMovementScript.angleregion_num_R_without_country == 4)
            {
                CNspinright.text = ("<color=green>右手搖桿→：向右旋</color>");
            }
            else
            {
                CNspinright.text = ("右手搖桿→：向右旋");
            }
        }

        if (hand == 1)
        {
            land.text = ("<color=#732F2F>降落至地面後，左手搖桿↓\n持續兩秒鐘即可關閉無人機\n並退出教學模式</color>");
            if (droneMovementScript.angleregion_num_L_without_country == 1 || droneMovementScript.angleregion_num_L_without_country == 2 || droneMovementScript.angleregion_num_L_without_country == 8)
            {
                USup.text = ("<color=green>左手搖桿↑：上　升</color>");
            }
            else
            {
                USup.text = ("左手搖桿↑：上　升");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 5 || droneMovementScript.angleregion_num_L_without_country == 4 || droneMovementScript.angleregion_num_L_without_country == 6)
            {
                USdown.text = ("<color=green>左手搖桿↓：下　降</color>");
            }
            else
            {
                USdown.text = ("左手搖桿↓：下　降");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 7 || droneMovementScript.angleregion_num_L_without_country == 6 || droneMovementScript.angleregion_num_L_without_country == 8)
            {
                USspinleft.text = ("<color=green>左手搖桿←：向左旋</color>");
            }
            else
            {
                USspinleft.text = ("左手搖桿←：向左旋");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 3 || droneMovementScript.angleregion_num_L_without_country == 2 || droneMovementScript.angleregion_num_L_without_country == 4)
            {
                USspinright.text = ("<color=green>左手搖桿→：向右旋</color>");
            }
            else
            {
                USspinright.text = ("左手搖桿→：向右旋");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 1 || droneMovementScript.angleregion_num_R_without_country == 2 || droneMovementScript.angleregion_num_R_without_country == 8)
            {
                USforward.text = ("<color=green>右手搖桿↑：向前飛</color>");
            }
            else
            {
                USforward.text = ("右手搖桿↑：向前飛");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 5 || droneMovementScript.angleregion_num_R_without_country == 4 || droneMovementScript.angleregion_num_R_without_country == 6)
            {
                USback.text = ("<color=green>右手搖桿↓：向後飛</color>");
            }
            else
            {
                USback.text = ("右手搖桿↓：向後飛");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 7 || droneMovementScript.angleregion_num_R_without_country == 6 || droneMovementScript.angleregion_num_R_without_country == 8)
            {
                USleft.text = ("<color=green>右手搖桿←：向左飛</color>");
            }
            else
            {
                USleft.text = ("右手搖桿←：向左飛");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 3 || droneMovementScript.angleregion_num_R_without_country == 2 || droneMovementScript.angleregion_num_R_without_country == 4)
            {
                USright.text = ("<color=green>右手搖桿→：向右飛</color>");
            }
            else
            {
                USright.text = ("右手搖桿→：向右飛");
            }
        }

        if (hand == 2)
        {
            land.text = ("<color=#732F2F>降落至地面後，右手搖桿↓\n持續兩秒鐘即可關閉無人機\n並退出教學模式</color>");
            if (droneMovementScript.angleregion_num_L_without_country == 1 || droneMovementScript.angleregion_num_L_without_country == 2 || droneMovementScript.angleregion_num_L_without_country == 8)
            {
                JPforward.text = ("<color=green>左手搖桿↑：向前飛</color>");
            }
            else
            {
                JPforward.text = ("左手搖桿↑：向前飛");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 5 || droneMovementScript.angleregion_num_L_without_country == 4 || droneMovementScript.angleregion_num_L_without_country == 6)
            {
                JPback.text = ("<color=green>左手搖桿↓：向後飛</color>");
            }
            else
            {
                JPback.text = ("左手搖桿↓：向後飛");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 7 || droneMovementScript.angleregion_num_L_without_country == 6 || droneMovementScript.angleregion_num_L_without_country == 8)
            {
                JPspinleft.text = ("<color=green>左手搖桿←：向左旋</color>");
            }
            else
            {
                JPspinleft.text = ("左手搖桿←：向左旋");
            }
            if (droneMovementScript.angleregion_num_L_without_country == 3 || droneMovementScript.angleregion_num_L_without_country == 2 || droneMovementScript.angleregion_num_L_without_country == 4)
            {
                JPspinright.text = ("<color=green>左手搖桿→：向右旋</color>");
            }
            else
            {
                JPspinright.text = ("左手搖桿→：向右旋");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 1 || droneMovementScript.angleregion_num_R_without_country == 2 || droneMovementScript.angleregion_num_R_without_country == 8)
            {
                JPup.text = ("<color=green>右手搖桿↑：上　升</color>");
            }
            else
            {
                JPup.text = ("右手搖桿↑：上　升");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 5 || droneMovementScript.angleregion_num_R_without_country == 4 || droneMovementScript.angleregion_num_R_without_country == 6)
            {
                JPdown.text = ("<color=green>右手搖桿↓：下　降</color>");
            }
            else
            {
                JPdown.text = ("右手搖桿↓：下　降");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 7 || droneMovementScript.angleregion_num_R_without_country == 6 || droneMovementScript.angleregion_num_R_without_country == 8)
            {
                JPleft.text = ("<color=green>右手搖桿←：向左飛</color>");
            }
            else
            {
                JPleft.text = ("右手搖桿←：向左飛");
            }
            if (droneMovementScript.angleregion_num_R_without_country == 3 || droneMovementScript.angleregion_num_R_without_country == 2 || droneMovementScript.angleregion_num_R_without_country == 4)
            {
                JPright.text = ("<color=green>右手搖桿→：向右飛</color>");
            }
            else
            {
                JPright.text = ("右手搖桿→：向右飛");
            }
        }

        if (once == 1 && droneMovementScript.start_up!=true)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
