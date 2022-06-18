using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EightCollider : MonoBehaviour
{
    DroneMovementScript droneMovementScript;
    public bool StartTest, range, fivestay, Failed;
    public int bigcircle, checkpoint, dir;
    public float timer;
    public GameObject startrange, Hcircle, Image, c1, c2, c3, c4, c5, c6, c7;
    public Text HintText, PassText;
    public Animator FiveCount;

    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        range = true;
        bigcircle = 0;
        checkpoint = 1;
        dir = 0;
        Failed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Failed == true)
        {
            UIswitch.BadEnd();
        }

        if (Input.GetKeyDown(KeyCode.Space)) droneMovementScript.start_up = true; //不用內八起飛
        if (StartTest == true && bigcircle < 1) range = false;
        if (StartTest == true) startrange.SetActive(false);
        if (range == false) Failed = true;

        FiveCount.SetFloat("FiveCount", timer);

        if (fivestay == true &&(checkpoint ==2||checkpoint ==3))
        {
            timer += Time.deltaTime;
            if (timer > 1 && checkpoint == 2)
            {
                checkpoint = 3;
                HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. H點懸停開始</color>\n4. H點懸停完成\n5. 八字水平圓\n6. H點懸停開始\n7. H點懸停完成\n8. 準備降落\n9. 完成測驗");
            }
            if (timer > 5)
            {
                checkpoint = 4;
                timer = 6;
                HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. H點懸停開始\n4. H點懸停完成</color>\n5. 八字水平圓\n6. H點懸停開始\n7. H點懸停完成\n8. 準備降落\n9. 完成測驗");
            }
        }
        if(timer <= 5 && fivestay == false && checkpoint == 3)
        {
            //PassText.text = ("未通過測試(未完成懸停)");
            Failed = true;
            timer = 0;
        }

        if (dir == 1)
        {
            if (!(gameObject.transform.eulerAngles.y > 345 || gameObject.transform.eulerAngles.y<15))
            {
                //PassText.text = ("未通過測試(角度未朝前)");
                Failed = true;
            }
            //else PassText.text = ("");
        }
        if(dir == 2)
        {
            if (!(gameObject.transform.eulerAngles.y > 260 || gameObject.transform.eulerAngles.y < 15))
            {
                //PassText.text = ("未通過測試(角度未朝前)");
                Failed = true;
            }
            //else PassText.text = ("");
        }
        if (dir == 3)
        {
            if (!(gameObject.transform.eulerAngles.y > 170 && gameObject.transform.eulerAngles.y < 280))
            {
                //PassText.text = ("未通過測試(角度未朝前)");
                Failed = true;
            }
            //else PassText.text = ("");
        }
        if (dir == 4)
        {
            if (!(gameObject.transform.eulerAngles.y > 80 && gameObject.transform.eulerAngles.y < 190))
            {
                //PassText.text = ("未通過測試(角度未朝前)");
                Failed = true;
            }
            //else PassText.text = ("");
        }
        if (dir == 5)
        {
            if (!(gameObject.transform.eulerAngles.y > 350 || gameObject.transform.eulerAngles.y < 90))
            {
                //PassText.text = ("未通過測試(角度未朝前)");
                Failed = true;
            }
            //else PassText.text = ("");
        }

        if (fivestay == true &&checkpoint == 14)
        {
            timer += Time.deltaTime;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. H點懸停開始\n4. H點懸停完成\n5. 八字水平圓\n6. H點懸停開始</color>\n7. H點懸停完成\n8. 準備降落\n9. 完成測驗");
            if (timer > 5)
            {
                checkpoint = 15;
                timer = 6;
                startrange.SetActive(true);
                HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. H點懸停開始\n4. H點懸停完成\n5. 八字水平圓\n6. H點懸停開始\n7. H點懸停完成\n8. 準備降落</color>\n9. 完成測驗");
            }
        }
        if (timer <= 5 && fivestay == false && checkpoint == 14)
        {
            //PassText.text = ("未通過測試(未完成懸停)");
            Failed = true;
            timer = 0;
        }

        if(checkpoint == 16 && droneMovementScript.start_up == false)
        {
            checkpoint = 17;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. H點懸停開始\n4. H點懸停完成\n5. 八字水平圓\n6. H點懸停開始\n7. H點懸停完成\n8. 準備降落\n9. 完成測驗</color>");
            PassText.text = ("通過測試");
            UIswitch.End();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "bigcircle" || other.gameObject.name == "Hcircle")
        {
            bigcircle++;
            StartTest = true;
        }
        if(other.gameObject.name == "Hcircle" && checkpoint == 1)
        {
            checkpoint = 2;
            fivestay = true;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內</color>\n3. H點懸停開始\n4. H點懸停完成\n5. 八字水平圓\n6. H點懸停開始\n7. H點懸停完成\n8. 準備降落\n9. 完成測驗");
        }
        if (other.gameObject.name == "smallcircle")
        {
            range = false;
        }
        if(other.gameObject.name== "Cube1" && checkpoint ==5)
        {
            checkpoint = 6;
            dir = 2;
            c1.SetActive(false);
            c2.SetActive(true);
        }
        if (other.gameObject.name == "Cube2" && checkpoint == 6)
        {
            checkpoint = 7;
            dir = 3;
            c2.SetActive(false);
            c3.SetActive(true);
        }
        if (other.gameObject.name == "Cube3" && checkpoint == 7)
        {
            checkpoint = 8;
            dir = 4;
            c3.SetActive(false);
            c4.SetActive(true);
        }
        if (other.gameObject.name == "Cube4" && checkpoint == 8)
        {
            checkpoint = 9;
            dir = 5;
            c4.SetActive(false);
            c5.SetActive(true);
        }
        if (other.gameObject.name == "Cube5" && checkpoint == 9)
        {
            checkpoint = 10;
            dir = 4;
            c5.SetActive(false);
            c6.SetActive(true);
        }
        if (other.gameObject.name == "Cube6" && checkpoint == 10)
        {
            checkpoint = 11;
            dir = 3;
            c6.SetActive(false);
            c7.SetActive(true);
        }
        if (other.gameObject.name == "Cube7" && checkpoint == 11)
        {
            checkpoint = 12;
            dir = 2;
            c7.SetActive(false);
            c1.SetActive(true);
        }
        if (other.gameObject.name == "Cube1" && checkpoint == 12)
        {
            checkpoint = 13;
            dir = 0;
            timer = 0;
            c1.SetActive(false);
            Hcircle.SetActive(true);
            Image.SetActive(true);
        }

        if (other.gameObject.name == "Hcircle" && checkpoint == 13)
        {
            checkpoint = 14;
            fivestay = true;
            StartTest = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "startrange")
        {
            range = false;
        }
        if (other.gameObject.name == "bigcircle" || other.gameObject.name == "Hcircle")
        {
            bigcircle--;
        }
        if (other.gameObject.name == "Hcircle")
        { 
            fivestay = false;
            if(checkpoint == 4)
            {
                checkpoint = 5;
                Hcircle.SetActive(false);
                Image.SetActive(false);
                timer = 0;
                dir = 1;
                HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. H點懸停開始\n4. H點懸停完成\n5. 八字水平圓</color>\n6. H點懸停開始\n7. H點懸停完成\n8. 準備降落\n9. 完成測驗");
            }
            if (checkpoint == 15)
            {
                checkpoint = 16;
                Hcircle.SetActive(false);
                Image.SetActive(false);
            }
        }
    }

}
