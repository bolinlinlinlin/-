using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public float input_V_L;
    public float input_H_L;
    public float input_V_R;
    public float input_H_R;
    DroneMovementScript droneMovementScript;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        input_V_L = Input.GetAxis("Vertical"); //左手縱向
        input_H_L = Input.GetAxis("Horizontal"); //左手橫向
        input_V_R = Input.GetAxis("Vertical2"); //右手縱向
        input_H_R = Input.GetAxis("Horizontal2"); //右手橫向
        #region 手把同步
        Vector2 vector2 = FixXY(new Vector2(input_V_L, input_H_L));
        input_V_L = vector2.x;
        input_H_L = vector2.y;
        Debug.Log(input_V_L + ", " + input_H_L);
        vector2 = FixXY(new Vector2(input_V_R, input_H_R));
        input_V_R = vector2.x;
        input_H_R = vector2.y;
        if (GameObject.Find("LC_Image") != null)
        {
            rectTransform = GameObject.Find("LC_Image").transform as RectTransform;
            rectTransform.anchoredPosition = new Vector2(input_H_L * 80, input_V_L * 80);
        }
        if (GameObject.Find("RC_Image") != null)
        {
            rectTransform = GameObject.Find("RC_Image").transform as RectTransform;
            rectTransform.anchoredPosition = new Vector2(input_H_R * 8, input_V_R * 8);
        }
        #endregion
    }
    #region 修正鍵盤分量
    private Vector2 FixXY(Vector2 vector2)
    {
        float x = vector2.x;
        float y = vector2.y;
        if (x != 0 && y != 0)
        {
            float angel = getVerticalAndHorizontalToAngle(x, y);
            float tan = Mathf.Tan(angel / Mathf.Rad2Deg);
            float temp;
            if (Mathf.Abs(angel) == 45.0f)
            {
                temp = 1 / Mathf.Sqrt(2);
            }
            else
            {
                if (Mathf.Abs(tan) > 1)
                {
                    y = y * Mathf.Abs(tan);
                }
                else
                {
                    tan = 1 / Mathf.Abs(tan);
                    x = x * Mathf.Abs(tan);
                }
                temp = 1 / Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
            }
            x *= temp;
            y *= temp;
        }
        return new Vector2(x, y);
    }
    #endregion
    #region 計算角度
    float getVerticalAndHorizontalToAngle(float x, float y)
    {
        float angle_Num = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
        if (float.IsNaN(angle_Num) || (x == 0 && y == 0))
        {
            angle_Num = 200;
        }
        return angle_Num;
    }
    #endregion
}
