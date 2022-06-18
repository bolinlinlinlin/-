using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class UIInterface : MonoBehaviour
{
    public float Timer;
    public float TiltX;
    public float TiltZ;

    public static int CaseSwitch = 0;

    //飛行速度--OK
    public Text D;
    public Text H;
    public Text HS;
    public Text VS;

    //電池(24分鐘)
    public int BatteryPowerCount;
    public int BatteryPower = 100;
    public Text BatteryPowerNum;
    public RawImage BatteryStatusImage;
    public RawImage BatteryStatusImage2;

    //雷達&小地圖
    public RawImage Arrow;
    public RawImage North;
    public RawImage Home;
    public RawImage MapArrow;

    //飛行狀態--OK
    public Text FlightStatus;
    public RawImage GreenLight;
    public RawImage YellowLight;
    public RawImage YellowLight2;
    public RawImage YellowLight3;
    public RawImage YellowLight4;
    public RawImage RedLight;
    public RawImage RedLight2;
    public RawImage RedLight3;
    public RawImage RedLight4;
    public RawImage Tilt;
    public GameObject none;
    DroneMovementScript droneMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //TiltZ = droneMovementScript.TiltSetZ;
        if (droneMovementScript.TiltSetX > 2)
        {
            TiltX = 50 * (droneMovementScript.TiltSetX - 360);
        } 
        else
        {   
            TiltX = 50 * droneMovementScript.TiltSetX;
        }
        Vector3 pos = new Vector3(200f, 204f + TiltX, 0f);
        Tilt.transform.position = pos;

        if(droneMovementScript.TiltSetZ > 50)
        {
            TiltZ = droneMovementScript.TiltSetZ - 360;
        } 
        else
        {
            TiltZ = droneMovementScript.TiltSetZ;
        }
        Tilt.transform.rotation = Quaternion.Euler(0f, 0f, TiltZ);




        //電池

        BatteryPower = (28000 - (int)(10 * droneMovementScript.BatteryPowerTimer)) / 280;
        BatteryPowerNum.text = (BatteryPower + "%");

        if (BatteryPower <= 60) BatteryPowerNum.GetComponent<Text>().color = Color.yellow;
        if (BatteryPower <= 20)
        {
            BatteryPowerNum.GetComponent<Text>().color = Color.red;
            BatteryStatusImage.gameObject.SetActive(false);
            BatteryStatusImage2.gameObject.SetActive(true);
        }
        if(BatteryPower <= 0)
        {
            droneMovementScript.broken = true;
            droneMovementScript.start_up = false;
        }


        //小地圖
        MapArrow.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,-droneMovementScript.DroneAngle));

        //飛行參數
        H.text = (droneMovementScript.DroneHigh.ToString("0.0"));
        D.text = (droneMovementScript.DroneHorizontal.ToString("0.0"));
        HS.text = (droneMovementScript.Horizontal_v.ToString("0.0"));
        VS.text = (droneMovementScript.Vertical_v.ToString("0.0"));

        //North位置
        float NorthAngle = (droneMovementScript.DroneAngle + 90) * Mathf.PI / 180;
        float NorthX = 50 * Mathf.Cos(NorthAngle);
        float NorthY = 50 * Mathf.Sin(NorthAngle);
        North.transform.localPosition = new Vector2(NorthX, NorthY);

        //Home位置
        float HomeX = (droneMovementScript.transform.position.x - droneMovementScript.StartX) / 2;
        float HomeY = (droneMovementScript.transform.position.z - droneMovementScript.StartZ) / 2;
        Home.transform.localPosition = new Vector2(-HomeX, -HomeY);
        none.transform.rotation = Quaternion.Euler(Vector3.forward * droneMovementScript.DroneAngle);
        Home.transform.rotation = Quaternion.Euler(Vector3.zero);

        if (droneMovementScript.start_up == false && droneMovementScript.atground == true) CaseSwitch = 1;

        if (droneMovementScript.start_up == true && droneMovementScript.atground == false) CaseSwitch = 2;

        if (droneMovementScript.DroneHigh > 120)  CaseSwitch = 3;

        if(droneMovementScript.BatteryPowerTimer > 1152)  CaseSwitch = 4;

        switch (CaseSwitch)
        {
            case 1: //無
                FlightStatus.text = ("Ready!");
                GreenLight.gameObject.SetActive(false);
                YellowLight.gameObject.SetActive(false);
                YellowLight2.gameObject.SetActive(false);
                RedLight.gameObject.SetActive(false);
                RedLight2.gameObject.SetActive(false);

                break;
            case 2: //綠色
                FlightStatus.text = ("In Flight");
                GreenLight.gameObject.SetActive(true);
                YellowLight.gameObject.SetActive(false);
                YellowLight2.gameObject.SetActive(false);
                RedLight.gameObject.SetActive(false);
                RedLight2.gameObject.SetActive(false);
                break;
            case 3: //黃色+閃爍
                FlightStatus.text = ("Limited Altitude 120M!");
                Timer += Time.deltaTime;
                GreenLight.gameObject.SetActive(false);
                RedLight.gameObject.SetActive(false);
                RedLight2.gameObject.SetActive(false);
                if (Timer > 0.1)
                {
                    YellowLight.gameObject.SetActive(true);
                    YellowLight2.gameObject.SetActive(false);
                    YellowLight3.gameObject.SetActive(false);
                    YellowLight4.gameObject.SetActive(false);
                }
                if (Timer > 0.2)
                {
                    YellowLight.gameObject.SetActive(false);
                    YellowLight2.gameObject.SetActive(true);
                    YellowLight3.gameObject.SetActive(false);
                    YellowLight4.gameObject.SetActive(false);
                }
                if (Timer > 0.3)
                {
                    YellowLight.gameObject.SetActive(false);
                    YellowLight2.gameObject.SetActive(false);
                    YellowLight3.gameObject.SetActive(true);
                    YellowLight4.gameObject.SetActive(false);
                }
                if (Timer > 0.4)
                {
                    YellowLight.gameObject.SetActive(false);
                    YellowLight2.gameObject.SetActive(false);
                    YellowLight3.gameObject.SetActive(false);
                    YellowLight4.gameObject.SetActive(true);
                }
                if (Timer > 0.5)
                {
                    YellowLight.gameObject.SetActive(false);
                    YellowLight2.gameObject.SetActive(false);
                    YellowLight3.gameObject.SetActive(false);
                    YellowLight4.gameObject.SetActive(true);
                    Timer = 0;
                }
                break;
            case 4: //紅色+閃爍
                FlightStatus.text = "Battery Level Low!";
                Timer += Time.deltaTime;
                GreenLight.gameObject.SetActive(false);
                YellowLight.gameObject.SetActive(false);
                YellowLight2.gameObject.SetActive(false);
                if (Timer > 0.1)
                {
                    RedLight.gameObject.SetActive(true);
                    RedLight2.gameObject.SetActive(false);
                    RedLight3.gameObject.SetActive(false);
                    RedLight4.gameObject.SetActive(false);
                }
                if (Timer > 0.2)
                {
                    RedLight.gameObject.SetActive(false);
                    RedLight2.gameObject.SetActive(true);
                    RedLight3.gameObject.SetActive(false);
                    RedLight4.gameObject.SetActive(false);
                }
                if (Timer > 0.3)
                {
                    RedLight.gameObject.SetActive(false);
                    RedLight2.gameObject.SetActive(false);
                    RedLight3.gameObject.SetActive(true);
                    RedLight4.gameObject.SetActive(false);
                }
                if (Timer > 0.4)
                {
                    RedLight.gameObject.SetActive(false);
                    RedLight2.gameObject.SetActive(false);
                    RedLight3.gameObject.SetActive(false);
                    RedLight4.gameObject.SetActive(true);
                }
                if (Timer > 0.5)
                {
                    RedLight.gameObject.SetActive(false);
                    RedLight2.gameObject.SetActive(false);
                    RedLight3.gameObject.SetActive(false);
                    RedLight4.gameObject.SetActive(true);
                    Timer = 0;
                }
                break;

        }
    }
}
