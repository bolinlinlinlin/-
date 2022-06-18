using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterstCollider : MonoBehaviour
{
    GameObject Drone;
    DroneMovementScript droneMovementScript;
    public int checkpoint = 0;
    public Animator FiveCount;
    public int timer = -1;
    public int AoB = 0;
    public int clockwise1 = 0;
    public int clockwise2 = 0;
    public int firstSpot = 0;
    public bool move = true;
    public bool Failed = false;
    public bool locks = false;
    public Text PassText, HintText, Text1, Text2;
    public GameObject Aspot, AspotA, AspotB, AspotC, AspotD, AspotL, Bspot, BspotA, BspotB, BspotC, BspotD, BspotL;
    public GameObject A, B;
    public GameObject edge1, edge2, edgeM;
    // Start is called before the first frame update
    void Start()
    {
        Drone = GameObject.FindGameObjectWithTag("Drone");
        InvokeRepeating("Timer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Failed == true)
        {
            UIswitch.BadEnd();
        }
        FiveCount.SetInteger("FiveCountInt", timer);

        if (checkpoint == 1)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺</color>\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
        }
        if (checkpoint == 2)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒</color>\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
        }
        if (checkpoint == 3)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點</color>\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
            edge1.SetActive(false);
            edge2.SetActive(false);
        }
        if (checkpoint == 5)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落</color>\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
            clockwise1 = 0;
            clockwise2 = 0;
            firstSpot = 0;
            locks = false;
        }
        if (checkpoint == 6)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺</color>\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
        }
        if (checkpoint == 7)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點</color>\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
        }
        if (checkpoint == 9)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落</color>\n11. 垂直上升至約20公尺");
        }
        if (checkpoint == 10)
        {
            HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺</color>");
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
        if (other.gameObject.name == "AspotMid" && checkpoint == 2)
        {
            checkpoint = 3;
            AspotA.SetActive(true);
            AspotB.SetActive(true);
            AspotC.SetActive(true);
            AspotD.SetActive(true);
            AspotL.SetActive(true);
        }
        if (other.gameObject.name == "BspotMid" && checkpoint == 2)
        {
            checkpoint = 3;
            BspotA.SetActive(true);
            BspotB.SetActive(true);
            BspotC.SetActive(true);
            BspotD.SetActive(true);
            BspotL.SetActive(true);
        }
        if (other.gameObject.name == "AspotG" && checkpoint == 4)
        {
            checkpoint = 5;
            Aspot.SetActive(true);
        }
        if (other.gameObject.name == "BspotG" && checkpoint == 4)
        {
            checkpoint = 5;
            Bspot.SetActive(true);
        }
        if (other.gameObject.name == "Aspot" && checkpoint == 5)
        {
            checkpoint = 6;
        }
        if (other.gameObject.name == "Bspot" && checkpoint == 5)
        {
            checkpoint = 6;
        }
        if (other.gameObject.name == "BspotMid" && checkpoint == 6)
        {
            checkpoint = 7;
            BspotA.SetActive(true);
            BspotB.SetActive(true);
            BspotC.SetActive(true);
            BspotD.SetActive(true);
            BspotL.SetActive(true);
        }
        if (other.gameObject.name == "AspotMid" && checkpoint == 6)
        {
            checkpoint = 7;
            AspotA.SetActive(true);
            AspotB.SetActive(true);
            AspotC.SetActive(true);
            AspotD.SetActive(true);
            AspotL.SetActive(true);
        }
        if (other.gameObject.name == "BspotG" && checkpoint == 8)
        {
            checkpoint = 9;
        }
        if (other.gameObject.name == "AspotG" && checkpoint == 8)
        {
            checkpoint = 9;
        }
        if (other.gameObject.name == "Bspot20" && checkpoint == 9)
        {
            checkpoint = 10;
        }
        if (other.gameObject.name == "Aspot20" && checkpoint == 9)
        {
            checkpoint = 10;
        }

        if (other.gameObject.name == "A" && checkpoint == 2)
        {
            AoB = 1;
            A.SetActive(false);
            B.SetActive(false);
        }
        if (other.gameObject.name == "B" && checkpoint == 2)
        {
            AoB = 2;
            A.SetActive(false);
            B.SetActive(false);
        }

        //start from AspotA
        if (other.gameObject.name == "AspotA" && locks == false)
        {
            locks = true;
            firstSpot = 1;
        }
        if (locks == true && firstSpot == 1)
        {
            if (other.gameObject.name == "AspotD" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise1 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise1 == 1)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise1 == 1)
            {
                clockwise1 = 2;
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "AspotB" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise1 == 2)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
            }
            if (other.gameObject.name == "AspotB" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise2 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise2 == 1)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise2 == 1)
            {
                clockwise2 = 2;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "AspotD" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise2 == 2)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
            }
        }
        //start from AspotB
        if (other.gameObject.name == "AspotB" && locks == false)
        {
            locks = true;
            firstSpot = 2;
        }
        if (locks == true && firstSpot == 2)
        {
            if (other.gameObject.name == "AspotA" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise1 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise1 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise1 == 1)
            {
                clockwise1 = 2;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "AspotC" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise1 == 2)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise1 == 2)
            {
                AspotB.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
            }
            if (other.gameObject.name == "AspotC" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise2 == 1)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise2 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise2 == 1)
            {
                clockwise2 = 2;
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "AspotA" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise2 == 2)
            {
                AspotB.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
            }
        }
        //start from AspotC
        if (other.gameObject.name == "AspotC" && locks == false)
        {
            locks = true;
            firstSpot = 3;
        }
        if (locks == true && firstSpot == 3)
        {
            if (other.gameObject.name == "AspotB" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise1 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise1 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise1 == 1)
            {
                clockwise1 = 2;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "AspotD" && clockwise1 == 2)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise1 == 2)
            {
                AspotC.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
            }
            if (other.gameObject.name == "AspotD" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise2 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise2 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise2 == 1)
            {
                clockwise2 = 2;
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "AspotB" && clockwise2 == 2)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise2 == 2)
            {
                AspotC.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
            }
        }
        //start from AspotD
        if (other.gameObject.name == "AspotD" && locks == false)
        {
            locks = true;
            firstSpot = 4;
        }
        if (locks == true && firstSpot == 4)
        {
            if (other.gameObject.name == "AspotC" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise1 == 1)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise1 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise1 == 1)
            {
                clockwise1 = 2;
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "AspotA"&& clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise1 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise1 == 2)
            {
                AspotD.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
            }
            if (other.gameObject.name == "AspotA" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise2 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotC" && clockwise2 == 1)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise2 == 1)
            {
                clockwise2 = 2;
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(true);
                AspotD.SetActive(false);
                if (AoB == 1)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "AspotC" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(true);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotB" && clockwise2 == 2)
            {
                AspotA.SetActive(true);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(false);
            }
            else if (other.gameObject.name == "AspotA" && clockwise2 == 2)
            {
                AspotA.SetActive(false);
                AspotB.SetActive(false);
                AspotC.SetActive(false);
                AspotD.SetActive(true);
            }
            else if (other.gameObject.name == "AspotD" && clockwise2 == 2)
            {
                AspotD.SetActive(false);
                AspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
            }
        }
        //start from BspotA
        if (other.gameObject.name == "BspotA" && locks == false)
        {
            locks = true;
            firstSpot = 1;
        }
        if (locks == true && firstSpot == 1)
        {
            if (other.gameObject.name == "BspotD" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise1 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise1 == 1)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise1 == 1)
            {
                clockwise1 = 2;
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "BspotB" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise1 == 2)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
            }
            if (other.gameObject.name == "BspotB" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise2 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise2 == 1)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise2 == 1)
            {
                clockwise2 = 2;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "BspotD" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise2 == 2)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
            }
        }
        //start from BspotB
        if (other.gameObject.name == "BspotB" && locks == false)
        {
            locks = true;
            firstSpot = 2;
        }
        if (locks == true && firstSpot == 2)
        {
            if (other.gameObject.name == "BspotA" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise1 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise1 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise1 == 1)
            {
                clockwise1 = 2;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "BspotC" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise1 == 2)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise1 == 2)
            {
                BspotB.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
            }
            if (other.gameObject.name == "BspotC" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise2 == 1)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise2 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise2 == 1)
            {
                clockwise2 = 2;
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "BspotA" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise2 == 2)
            {
                BspotB.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
            }
        }
        //start from BspotC
        if (other.gameObject.name == "BspotC" && locks == false)
        {
            locks = true;
            firstSpot = 3;
        }
        if (locks == true && firstSpot == 3)
        {
            if (other.gameObject.name == "BspotB" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise1 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise1 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise1 == 1)
            {
                clockwise1 = 2;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "BspotD" && clockwise1 == 2)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise1 == 2)
            {
                BspotC.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
            }
            if (other.gameObject.name == "BspotD" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise2 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise2 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise2 == 1)
            {
                clockwise2 = 2;
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "BspotB" && clockwise2 == 2)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise2 == 2)
            {
                BspotC.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
            }
        }
        //start from BspotD
        if (other.gameObject.name == "BspotD" && locks == false)
        {
            locks = true;
            firstSpot = 4;
        }
        if (locks == true && firstSpot == 4)
        {
            if (other.gameObject.name == "BspotC" && clockwise1 == 0 && clockwise2 == 0)
            {
                clockwise1 = 1;
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise1 == 1)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise1 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise1 == 1)
            {
                clockwise1 = 2;
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                }
            }
            else if (other.gameObject.name == "BspotA" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise1 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise1 == 2)
            {
                BspotD.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                    checkpoint = 4;
                }
            }
            if (other.gameObject.name == "BspotA" && clockwise2 == 0 && clockwise1 == 0)
            {
                clockwise2 = 1;
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise2 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotC" && clockwise2 == 1)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise2 == 1)
            {
                clockwise2 = 2;
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(true);
                BspotD.SetActive(false);
                if (AoB == 1)
                {
                    Text2.text = ("<color=green>逆時針繞一圈</color>");
                }
                if (AoB == 2)
                {
                    Text1.text = ("<color=green>逆時針繞一圈</color>");
                }
            }
            else if (other.gameObject.name == "BspotC" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(true);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotB" && clockwise2 == 2)
            {
                BspotA.SetActive(true);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(false);
            }
            else if (other.gameObject.name == "BspotA" && clockwise2 == 2)
            {
                BspotA.SetActive(false);
                BspotB.SetActive(false);
                BspotC.SetActive(false);
                BspotD.SetActive(true);
            }
            else if (other.gameObject.name == "BspotD" && clockwise2 == 2)
            {
                BspotD.SetActive(false);
                BspotL.SetActive(false);
                if (AoB == 1)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈</color>\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 8;
                }
                if (AoB == 2)
                {
                    HintText.text = ("<color=green>1. 準備起飛\n2. 上升至1~2公尺\n3. 懸停5秒\n4. 飛往其中一個興趣點\n5. 順時針繞一圈</color>\n\n6. 降落\n7. 垂直上升至1~2公尺\n8. 飛往另一個興趣點\n9. 順時針繞一圈\n\n10. 降落\n11. 垂直上升至約20公尺");
                    checkpoint = 4;
                }
            }
        }
        if (other.gameObject.name == "Limit1" || other.gameObject.name == "Limit2" || other.gameObject.name == "Limit3" || other.gameObject.name == "Limit4" || other.gameObject.name == "Limit5" || other.gameObject.name == "Limit6" || other.gameObject.name == "Limit7" || other.gameObject.name == "Limit8" || other.gameObject.name == "Limit9" || other.gameObject.name == "Limit10" || other.gameObject.name == "Limit11" || other.gameObject.name == "Limit12")
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
            if (y < 302 || y > 322)
                Failed = true;
        }
        if (other.gameObject.name == "edge2")
        {
            if (y < 38 || y > 58)
                Failed = true;
        }
        if (AoB == 1)
        {
            if (other.gameObject.name == "edgeM")
            {
                if (y < 80 || y > 100)
                    Failed = true;
            }
        }
        if (AoB == 2)
        {
            if (other.gameObject.name == "edgeM")
            {
                if (y < 260 || y > 280)
                    Failed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "1to2")
        {
            move = true;
        }
        if (other.gameObject.name == "AspotL" || other.gameObject.name == "BspotL")
        {
            Failed = true;
        }
    }
}
