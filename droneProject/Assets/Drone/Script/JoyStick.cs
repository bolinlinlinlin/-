using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class JoyStick : MonoBehaviour
{
    public float input_V_L;
    public float input_H_L;
    public float input_V_R;
    public float input_H_R;
    DroneMovementScript droneMovementScript;
    RectTransform rectTransform;
    public Vector2 vr_input_L, vr_input_R;

    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region 輸入
        vr_input_L = vr_input_R = Vector2.zero;

        try
        {
            vr_input_L = SteamVR_Actions._default.Axis.GetAxis(SteamVR_Input_Sources.LeftHand);
            vr_input_R = SteamVR_Actions._default.Axis.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        if (vr_input_L == Vector2.zero)
        {
            input_V_L = FixXY(new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"))).x; //左手縱向
            input_H_L = FixXY(new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"))).y; //左手橫向
        }
        else
        {
            input_V_L = vr_input_L.y;
            input_H_L = vr_input_L.x;
        }
        if (vr_input_R == Vector2.zero)
        {
            input_V_R = FixXY(new Vector2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2"))).x; //右手縱向
            input_H_R = FixXY(new Vector2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2"))).y; //右手橫向
        }
        else
        {
            input_V_R = vr_input_R.y;
            input_H_R = vr_input_R.x;
        }
        #endregion

        #region 手把同步
        /*
        Vector2 vector2;

        vector2 = FixXY(new Vector2(input_V_L, input_H_L));
        input_V_L = vector2.x;
        input_H_L = vector2.y;
        //Debug.Log(input_V_L + ", " + input_H_L);
        vector2 = FixXY(new Vector2(input_V_R, input_H_R));
        input_V_R = vector2.x;
        input_H_R = vector2.y;
        */
        if (GameObject.Find("LC_Image") != null)
        {
            rectTransform = GameObject.Find("LC_Image").transform as RectTransform;
            rectTransform.anchoredPosition = new Vector2(input_H_L * 6, input_V_L * 6);
        }
        if (GameObject.Find("RC_Image") != null)
        {
            rectTransform = GameObject.Find("RC_Image").transform as RectTransform;
            rectTransform.anchoredPosition = new Vector2(input_H_R * 6, input_V_R * 6);
        }
        #endregion
        // print(new Vector4(input_H_L, input_V_L, input_H_R, input_V_R));

    }
    #region 修正鍵盤分量
    private Vector2 FixXY(Vector2 vector2)
    {
        float x = vector2.x;
        float y = vector2.y;
        float temp = 1;
        float max = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
        if(max != 0.0f)
            temp = Mathf.Sqrt(Mathf.Pow(x / max, 2) + Mathf.Pow(y / max, 2));
        return new Vector2(x / temp, y / temp);
    }
    #endregion
}
