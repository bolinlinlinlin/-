using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiveCollider : MonoBehaviour
{
    GameObject Drone;
    DroneMovementScript droneMovementScript;
    public int checkpoint = 0;
    public Animator FiveCount;
    public bool move = true;
    public bool Failed = false;
    public int timer = -1;
    public Text PassText, HintText, Text1, Text2, Text3, Text4, Text5;
    public GameObject mid, top, under, back, front, right, left;
    // Start is called before the first frame update
    void Start()
    {
        Drone = GameObject.FindGameObjectWithTag("Drone");
        InvokeRepeating("Timer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Failed == true)
        {
            UIswitch.BadEnd();
        }
        FiveCount.SetInteger("FiveCountInt", timer);

        float y = Drone.transform.eulerAngles.y;

        if (checkpoint == 1)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺</color>\n3. 懸停5秒\n4. 垂直上升至約20公尺\n5. 機頭朝飛行方向，逆時針飛行\n\n\n\n\n\n6. 下降至1~2公尺");
        }
        else if (checkpoint == 2)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒</color>\n4. 垂直上升至約20公尺\n5. 機頭朝飛行方向，逆時針飛行\n\n\n\n\n\n6. 下降至1~2公尺");
        }
        else if (checkpoint == 3)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 垂直上升至約20公尺</color>\n5. 機頭朝飛行方向，逆時針飛行\n\n\n\n\n\n6. 下降至1~2公尺");
            if (y > 80 && y < 100)
                checkpoint = 4;
        }
        else if (checkpoint == 4)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 垂直上升至約20公尺\n5. 機頭朝飛行方向，逆時針飛行</color>\n\n\n\n\n\n6. 下降至1~2公尺");
        }
        else if (checkpoint == 5)
        {
            Text1.text = ("<color=green>第一邊</color>");
        }
        else if (checkpoint == 6)
        {
            Text2.text = ("<color=green>第二邊</color>");
        }
        else if (checkpoint == 7)
        {
            Text3.text = ("<color=green>第三邊</color>");
        }
        else if (checkpoint == 8)
        {
            Text4.text = ("<color=green>第四邊</color>");
        }
        else if (checkpoint == 9)
        {
            Text5.text = ("<color=green>第五邊</color>");
        }
        else if (checkpoint == 10)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 垂直上升至約20公尺\n5. 機頭朝飛行方向，逆時針飛行\n\n\n\n\n\n6. 下降至1~2公尺</color>");
            PassText.text = ("通過測試");
            UIswitch.End();
        }
    }

    void Timer()
    {
        if (move == false && timer < 5)
        {
            timer++;
            if (timer == 5)
            {
                checkpoint = 2;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "1to2" && checkpoint == 0)
        {
            move = false;
            checkpoint = 1;
        }
        if (other.gameObject.name == "20upH" && checkpoint == 2)
        {
            checkpoint = 3;
            mid.SetActive(true);
            top.SetActive(true);
            under.SetActive(true);
            front.SetActive(true);
            back.SetActive(true);
            right.SetActive(true);
            left.SetActive(true);
        }
        if (other.gameObject.name == "20up1" && checkpoint == 4)
        {
            checkpoint = 5;
        }
        if (other.gameObject.name == "20up2" && checkpoint == 5)
        {
            checkpoint = 6;
        }
        if (other.gameObject.name == "20up3" && checkpoint == 6)
        {
            checkpoint = 7;
        }
        if (other.gameObject.name == "20up4" && checkpoint == 7)
        {
            checkpoint = 8;
        }
        if (other.gameObject.name == "20upH" && checkpoint == 8)
        {
            checkpoint = 9;
            mid.SetActive(false);
            top.SetActive(false);
            under.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
            right.SetActive(false);
            left.SetActive(false);
        }
        if (other.gameObject.name == "1to2" && checkpoint == 9)
        {
            checkpoint = 10;
        }
        if (other.gameObject.name == "mid" || other.gameObject.name == "top" || other.gameObject.name == "under" || other.gameObject.name == "front" || other.gameObject.name == "back" || other.gameObject.name == "right" || other.gameObject.name == "left")
        {
            Failed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        float y = Drone.transform.eulerAngles.y;
        if (y <= 10)
            y += 360;
        if (other.gameObject.name == "edge1")
        {
            if (y < 80 || y > 100)
                Failed = true;
        }
        if (other.gameObject.name == "edge2")
        {
            if (y < 350)
                Failed = true;
        }
        if (other.gameObject.name == "edge3")
        {
            if (y < 260 || y > 280)
                Failed = true;
        }
        if (other.gameObject.name == "edge4")
        {
            if (y < 170 || y > 190)
                Failed = true;
        }
        if (other.gameObject.name == "edge5")
        {
            if (y < 80 || y > 100)
                Failed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "1to2")
        {
            move = true;
        }
    }
}
