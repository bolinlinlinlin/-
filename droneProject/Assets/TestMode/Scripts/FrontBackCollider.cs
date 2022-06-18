using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontBackCollider : MonoBehaviour
{
    DroneMovementScript droneMovementScript;
    public bool range, fivestay, Failed;
    public int checkpoint, dir;
    public float timer;
    public GameObject startrange, Hcircle, c1, c2, cube1;
    public Text HintText, PassText;
    public Animator FiveCount;
    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        checkpoint = 1;
        dir = 0;
        range = true;
        Failed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Failed == true)
        {
            UIswitch.BadEnd();
        }

        FiveCount.SetFloat("FiveCount", timer);
        if (Input.GetKeyDown(KeyCode.Space)) droneMovementScript.start_up = true;
        if (range == false) Failed = true;

        if (fivestay == true && (checkpoint == 2 || checkpoint == 3))
        {
            
            if (gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280)
            {
                timer += Time.deltaTime;
                HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 方向朝左方懸停</color>\n4. 前進至前方角椎停懸\n5. 後退至後方角椎停懸\n6. 前進至H點停懸\n7. 準備降落(機頭朝前)\n8. 完成測驗");
            }
            else timer = 0;
            if (timer > 1 && checkpoint == 2)
            {
                checkpoint = 3;
            }
            if (timer > 5)
            {
                checkpoint = 4;
                timer = 6;
            }
        }
        if (timer <= 5 && fivestay == false && checkpoint == 3)
        {
            //PassText.text = ("未通過測試(未完成懸停)");
            timer = 0;
            Failed = true;
        }

        if (fivestay == true && checkpoint == 6 )
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                checkpoint = 7;
                timer = 6;
                
            }
        }
        if (timer <= 5 && fivestay == false && checkpoint == 6)
        {
            //PassText.text = ("未通過測試(未完成懸停)");
            timer = 0;
            Failed = true;
        }

        if (fivestay == true && checkpoint == 9)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                checkpoint = 10;
                timer = 6;
                
            }
        }
        if (timer <= 5 && fivestay == false && checkpoint == 9)
        {
            //PassText.text = ("未通過測試(未完成懸停)");
            timer = 0;
            Failed = true;
        }

        if (fivestay == true && checkpoint == 12)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                checkpoint = 13;
                timer = 6;
                HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 方向朝左方懸停\n4. 前進至前方角椎停懸\n5. 後退至後方角椎停懸\n6. 前進至H點停懸\n7. 準備降落(機頭朝前)</color>\n8. 完成測驗");
            }
        }
        if (timer <= 5 && fivestay == false && checkpoint == 12)
        {
            //PassText.text = ("未通過測試(未完成懸停)");
            timer = 0;
            Failed = true;
        }

        if(checkpoint == 13)
        {
            Hcircle.SetActive(false);
            startrange.SetActive(true);
            cube1.SetActive(false);
            if(droneMovementScript.start_up == false && (gameObject.transform.eulerAngles.y > 345 || gameObject.transform.eulerAngles.y < 15))
            {
                UIswitch.End();
                PassText.text = ("通過測試");
                HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 方向朝左方懸停\n4. 前進至前方角椎停懸\n5. 後退至後方角椎停懸\n6. 前進至H點停懸\n7. 準備降落(機頭朝前)\n8. 完成測驗</color>");
            }
            if (droneMovementScript.start_up == false && !(gameObject.transform.eulerAngles.y > 345 || gameObject.transform.eulerAngles.y < 15))
            {
                //PassText.text = ("未通過測試(機頭未朝外降落)");
                Failed = true;
            }
        }

        if (dir == 2)
        {
            if (!(gameObject.transform.eulerAngles.y > 260 && gameObject.transform.eulerAngles.y < 280))
            {
                //PassText.text = ("未通過測試(角度未朝前)");
                Failed = true;
            }
            //else PassText.text = ("");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hcircle" || other.gameObject.name == "circle1" || other.gameObject.name == "circle2")
        {
            fivestay = true;
        }
        if(other.gameObject.name == "Hcircle" && checkpoint ==1)
        {
            checkpoint = 2;
            startrange.SetActive(false);
            cube1.SetActive(true);
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內</color>\n3. 方向朝左方懸停\n4. 前進至前方角椎停懸\n5. 後退至後方角椎停懸\n6. 前進至H點停懸\n7. 準備降落(機頭朝前)\n8. 完成測驗");
        }
        if (other.gameObject.name == "circle1" && checkpoint == 5)
        {
            checkpoint = 6;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 方向朝左方懸停\n4. 前進至前方角椎停懸</color>\n5. 後退至後方角椎停懸\n6. 前進至H點停懸\n7. 準備降落(機頭朝前)\n8. 完成測驗");
        }
        if (other.gameObject.name == "circle2" && checkpoint == 8)
        {
            checkpoint = 9;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 方向朝左方懸停\n4. 前進至前方角椎停懸\n5. 後退至後方角椎停懸</color>\n6. 前進至H點停懸\n7. 準備降落(機頭朝前)\n8. 完成測驗");
        }
        if (other.gameObject.name == "Hcircle" && checkpoint == 11)
        {
            checkpoint = 12;
            dir = 0;
            HintText.text = ("<color=green>1. 準備起飛\n2. 進入範圍內\n3. 方向朝左方懸停\n4. 前進至前方角椎停懸\n5. 後退至後方角椎停懸\n6. 前進至H點停懸</color>\n7. 準備降落(機頭朝前)\n8. 完成測驗");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Hcircle" || other.gameObject.name == "circle1" || other.gameObject.name == "circle2")
        {
            fivestay = false;
        }
        if((checkpoint == 1||checkpoint==13) && other.gameObject.name == "startrange")
        {
            range = false;
        }
        if (other.gameObject.name == "Hcircle" && checkpoint == 4)
        {
            checkpoint = 5;
            c1.SetActive(true);
            timer = 0;
            dir = 2;
        }

        if (other.gameObject.name == "circle1" && checkpoint == 7)
        {
            checkpoint = 8;
            c1.SetActive(false);
            c2.SetActive(true);
            timer = 0;
        }

        if (other.gameObject.name == "circle2" && checkpoint == 10)
        {
            checkpoint = 11;
            c2.SetActive(false);
            timer = 0;
        }

        if(other.gameObject.name == "Cube1")
        {
            range = false;
        }
    }
}
