using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareCollider : MonoBehaviour
{
    // Start is called before the first frame update
    DroneMovementScript droneMovementScript;
    public int checkpoint;
    public bool InRange, FiveStay, added, Failed;
    public Text PassText, HintText;
    public float mode;
    public float timer;
    public int dir;
    public GameObject range, range1, range2, range3, range4;
    public Animator FiveCount;

    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        InRange = true;
        checkpoint = 1;
        FiveStay = false;
        dir = 1;
        Failed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Failed == true)
        {
            UIswitch.BadEnd();
        }

        if (Input.GetKeyDown(KeyCode.Space)) droneMovementScript.start_up = true; //不用內八起飛

        FiveCount.SetFloat("FiveCount", timer);

        if(checkpoint == 2)
        {
            HintText.text=("<color=green>1. 準備起飛\n2. 進入範圍內</color>\n3. 矩形航線(順)\n4. 矩形航線(逆)\n5. 準備降落\n6. 完成測驗");
        }
        if (checkpoint == 3)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 矩形航線(順)</color>\n4. 矩形航線(逆)\n5. 準備降落\n6. 完成測驗");
        }
        if (checkpoint == 19)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 矩形航線(順)\n4. 矩形航線(逆)</color>\n5. 準備降落\n6. 完成測驗");
        }
        if (checkpoint == 33)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 矩形航線(順)\n4. 矩形航線(逆)\n5. 準備降落</color>\n6. 完成測驗");
        }
        if (checkpoint == 34)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 矩形航線(順)\n4. 矩形航線(逆)\n5. 準備降落\n6. 完成測驗</color>");
        }

        if (InRange == false)
        {
            //PassText.text = ("未通過測試1");
            Failed = true;
        }

        if (mode == 1 && checkpoint != 33 && checkpoint != 34 && timer<=6)
        {
            FiveStay = false;
            timer += Time.deltaTime;
            if (timer > 1 && checkpoint == 2)
            {
                checkpoint = 3;
            }
            if (timer > 5)
            {
                //PassText.text = ("懸停成功");
                FiveStay = true;
                if(added == false)
                {
                    checkpoint++;
                    added = true;
                }
            }
        }
        if (mode == 2)
        {
            added = false;
            if (FiveStay == false)
            {
                //PassText.text = ("未通過測試2");
                Failed = true;
            }
            timer = 0;

            if (dir == 1)
            {
                if ((gameObject.transform.eulerAngles.y > 350f || gameObject.transform.eulerAngles.y < 10f))
                {
                    //PassText.text = ("");
                }
                else
                {
                    //PassText.text = ("未通過測試3");
                    Failed = true;
                }
            }
            if (dir == 2)
            {
                if (gameObject.transform.eulerAngles.y > 80f && gameObject.transform.eulerAngles.y < 100f)
                {
                    //PassText.text = ("");
                }
                else
                {
                    //PassText.text = ("未通過測試3");
                    Failed = true;
                }
            }

            if (dir == 3)
            {
                if (gameObject.transform.eulerAngles.y > 170.0f && gameObject.transform.eulerAngles.y < 190.0f)
                {
                    //PassText.text = ("");
                }
                else
                {
                    //PassText.text = ("未通過測試3");
                    Failed = true;
                }
            }

            if (dir == 4)
            {
                if (gameObject.transform.eulerAngles.y > 260f && gameObject.transform.eulerAngles.y < 280f)
                {
                    //PassText.text = ("");
                }
                else
                {
                    //PassText.text = ("未通過測試3");
                    Failed = true;
                }
            }
        }

        if ((checkpoint == 7 || checkpoint == 22 || checkpoint == 33) && mode==1)
        {
            dir = 1;
        }
        if ((checkpoint == 10 || checkpoint == 19 || checkpoint == 31) && mode == 1)
        {
            dir = 2;
        }
        if ((checkpoint == 13 || checkpoint == 28) && mode==1)
        {
            dir = 3;
        }
        if ((checkpoint == 4 || checkpoint == 16 || checkpoint == 25) && mode == 1)
        {
            dir = 4;
        }


        if (checkpoint == 1 && droneMovementScript.start_up == true && mode == 1)
        {
            checkpoint = 2;
        }
        if(checkpoint ==5 && mode == 2)
        {
            range.SetActive(false);
            range1.SetActive(true);
        }
        if(checkpoint == 8 && mode == 2)
        {
            range1.SetActive(false);
            range2.SetActive(true);
        }
        if (checkpoint == 11 && mode == 2)
        {
            range2.SetActive(false);
            range3.SetActive(true);
        }
        if (checkpoint == 14 && mode == 2)
        {
            range3.SetActive(false);
            range4.SetActive(true);
        }
        if (checkpoint == 17 && mode == 2)
        {
            range4.SetActive(false);
            range.SetActive(true);
        }
        if (checkpoint == 20 && mode == 2)
        {
            range.SetActive(false);
            range4.SetActive(true);
        }
        if (checkpoint == 23 && mode == 2)
        {
            range4.SetActive(false);
            range3.SetActive(true);
        }
        if (checkpoint == 26 && mode == 2)
        {
            range3.SetActive(false);
            range2.SetActive(true);
        }
        if (checkpoint == 29 && mode == 2)
        {
            range2.SetActive(false);
            range1.SetActive(true);
        }
        if (checkpoint == 32 && mode == 2)
        {
            range1.SetActive(false);
            range.SetActive(true);
        }

        if(checkpoint == 33 && droneMovementScript.atground == true && droneMovementScript.start_up == false && (gameObject.transform.eulerAngles.y > 350f || gameObject.transform.eulerAngles.y < 10f))
        {
            checkpoint = 34;
            PassText.text = ("過過測試"); //通過測試檢查點
            UIswitch.End();
        }

        if (checkpoint == 33 && droneMovementScript.atground == true && droneMovementScript.start_up == false && !(gameObject.transform.eulerAngles.y > 350f || gameObject.transform.eulerAngles.y < 10f))
        {
            //PassText.text = ("未通過測試4");
            Failed = true;
        }
    }
    private void OnTriggerEnter(Collider other) //偵測是否進入有效懸停範圍內
    {
        if (other.gameObject.name == "Cube2")
        {
            //Debug.Log(other.name);
            InRange = false;
        }
        /*if (other.gameObject.name == "Cube1") //回到範圍內不會測驗失敗
        {
            Debug.Log(other.name);
            InRange = true;
        }*/
        if (other.gameObject.name == "range" || other.gameObject.name == "range1" || other.gameObject.name == "range2" || other.gameObject.name == "range3" || other.gameObject.name == "range4")
        {
            mode = 1;
        }
        if(other.gameObject.name == "range1" && checkpoint == 5)
        {
            checkpoint = 6;
        }
        if (other.gameObject.name == "range2" && checkpoint == 8)
        {
            checkpoint = 9;
        }
        if (other.gameObject.name == "range3" && checkpoint == 11)
        {
            checkpoint = 12;
        }
        if (other.gameObject.name == "range4" && checkpoint == 14)
        {
            checkpoint = 15;
        }
        if (other.gameObject.name == "range" && checkpoint ==17)
        {
            checkpoint = 18;
        }
        if (other.gameObject.name == "range4" && checkpoint == 20)
        {
            checkpoint = 21;
        }
        if (other.gameObject.name == "range3" && checkpoint == 23)
        {
            checkpoint = 24;
        }
        if (other.gameObject.name == "range2" && checkpoint == 26)
        {
            checkpoint = 27;
        }
        if (other.gameObject.name == "range1" && checkpoint == 29)
        {
            checkpoint = 30;
        }
        if (other.gameObject.name == "range1" && checkpoint == 32)
        {
            checkpoint = 33;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cube1" && checkpoint !=33 && checkpoint !=34)
        {
            Debug.Log(other.name);
            InRange = false;
        }
        if (other.gameObject.name == "Cube3")
        {
            Debug.Log(other.name);
            InRange = false;
        }
        if (other.gameObject.name == "range" || other.gameObject.name == "range1" || other.gameObject.name == "range2" || other.gameObject.name == "range3" || other.gameObject.name == "range4")
        {
            mode = 2;
        }
        if (other.gameObject.name == "range" && checkpoint == 4)
        {
            checkpoint = 5;
        }
        if (other.gameObject.name == "range1" && checkpoint == 7)
        {
            checkpoint = 8;
        }
        if (other.gameObject.name == "range2" && checkpoint == 10)
        {
            checkpoint = 11;
        }
        if (other.gameObject.name == "range3" && checkpoint == 13)
        {
            checkpoint = 14;
        }
        if (other.gameObject.name == "range4" && checkpoint == 16)
        {
            checkpoint = 17;
        }
        if (other.gameObject.name == "range" && checkpoint == 19)
        {
            checkpoint = 20;
        }
        if (other.gameObject.name == "range4" && checkpoint == 22)
        {
            checkpoint = 23;
        }
        if (other.gameObject.name == "range3" && checkpoint == 25)
        {
            checkpoint = 26;
        }
        if (other.gameObject.name == "range2" && checkpoint == 28)
        {
            checkpoint = 29;
        }
        if (other.gameObject.name == "range1" && checkpoint == 31)
        {
            checkpoint = 32;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Cube2")
        {
            InRange = false;
        }
    }
}
