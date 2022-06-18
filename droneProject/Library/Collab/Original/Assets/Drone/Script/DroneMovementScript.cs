using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneMovementScript : MonoBehaviour
{
    public float BatteryPowerTimer = 0f;
    public float DroneHorizontal;
    public float DroneHigh;
    public float DroneAngle;
    public float StartX;
    public float StartY; //�_�l��m
    public float StartZ;

    Rigidbody ourDrone;
    static int none = 0;
    static int up = 1;
    static int rightup = 2;
    static int right = 3;
    static int rightdown = 4;
    static int down = 5;
    static int leftdown = 6;
    static int left = 7;
    static int leftup = 8;

    public float input_V_L;
    public float input_H_L;
    public float input_V_R;
    public float input_H_R;
    public float H;

    public bool anglo = false;
    public bool onlyone = true;
    public bool has_L = false;
    public bool has_R = false;
    bool broken = false;

    public GameObject fire;

    

    void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();
        StartX = ourDrone.transform.position.x;
        StartY = ourDrone.transform.position.y;
        StartZ = ourDrone.transform.position.z;
        droneSound = GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>();
        Debug.Log(droneSound);
        //start_up = true;
        count = 0;
        
    }

    public bool start_up = false; //�Ұ�
    public bool atground = false;
    public float timer = 0f;
    public float timer2 = 0f;
    public float timer3 = 0f;
    public float timer4 = 0f;
    public float timer5 = 0f;
    public float timer6 = 0f;
    public int count = 0;
    public bool limit = false;

    public double v = 0f;
    public float Horizontal_v;
    public float Vertical_v;

    public int angleregion_num_L;
    public int angleregion_num_R;


    void FixedUpdate()
    {
        DroneHorizontal = Mathf.Pow((Mathf.Pow((transform.position.x - StartX), 2) + Mathf.Pow((transform.position.z - StartZ), 2)), 0.5f); //�����Z��
        DroneHigh = transform.position.y - StartY; //����
        DroneAngle = transform.eulerAngles.y; //����
        Horizontal_v = Mathf.Sqrt(Mathf.Pow(ourDrone.velocity.x, 2) + Mathf.Pow(ourDrone.velocity.z, 2));
        Vertical_v = ourDrone.velocity.y;
        v = ourDrone.velocity.magnitude;

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.one * Time.deltaTime * 100);
        }

        atground = false;
        if (belowDistance() != null)
        {
            H = (float)belowDistance();
            if (H <= 0.1f)
                atground = true;
        }
        else
        {
            H = -1;
        }
        ourDrone.drag = 1;
        #region ��Shift�[�t
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ourDrone.drag *= 0.5f;
        }
        #endregion

        input_V_L = Input.GetAxis("Vertical"); //�����a�V
        input_H_L = Input.GetAxis("Horizontal"); //�����V
        input_V_R = Input.GetAxis("Vertical2"); //�k���a�V
        input_H_R = Input.GetAxis("Horizontal2"); //�k���V

        if (SceneManager.GetActiveScene().name == "TeachMode")
        {
            limited();
            ourDrone.drag *= 3;
        }
        Vector2 vector2 = FixXY(new Vector2(input_H_L, input_V_L));
        input_V_L = vector2.y;
        input_H_L = vector2.x;
        vector2 = FixXY(new Vector2(input_H_R, input_V_R));
        input_V_R = vector2.y;
        input_H_R = vector2.x;
        #region ���P�B
        /*
        Vector2 vector2 = FixXY(new Vector2(input_H_L, input_V_L));
        input_V_L = vector2.y;
        input_H_L = vector2.x;
        RectTransform rectTransform = GameObject.Find("LC_Image").transform as RectTransform;
        rectTransform.anchoredPosition = new Vector2(input_H_L * 8, input_V_L * 8);

        vector2 = FixXY(new Vector2(input_H_R, input_V_R));
        input_V_R = vector2.y;
        input_H_R = vector2.x;
        rectTransform = GameObject.Find("RC_Image").transform as RectTransform;
        rectTransform.anchoredPosition = new Vector2(input_H_R * 8, input_V_R * 8);
        */
        #endregion

        timer3 = Time.time;
        if (timer3 > 3)
            timer3 = 5;

        angleregion_num_L = angleregion(getVerticalAndHorizontalToAngle(input_H_L, input_V_L));
        angleregion_num_R = angleregion(getVerticalAndHorizontalToAngle(input_H_R, input_V_R));

        if (atground && !broken)
        {
            if (!start_up)
            {
                if (angleregion_num_L == rightdown && angleregion_num_R == leftdown)
                {
                    timer += Time.deltaTime;
                    if (timer > 2)
                    {
                        start_up = true;
                        timer = 0f;
                        StartX = ourDrone.transform.position.x;
                        StartY = ourDrone.transform.position.y;
                        StartZ = ourDrone.transform.position.z;
                    }
                }
            }
            else
            {
                limit = true;
                if (angleregion_num_L == none && angleregion_num_R == down)
                {
                    timer += Time.deltaTime;
                    if (timer > 2)
                    {
                        start_up = false;
                        timer = 0f;
                    }
                }
                else
                    timer = 0f;
            }
        }

        if (start_up)
        {
            BatteryCount();
            transform.Find("RightUp").Rotate(0f, -1000f * Time.deltaTime, 0f);
            transform.Find("RightDown").Rotate(0f, 1000f * Time.deltaTime, 0f);
            transform.Find("LeftUp").Rotate(0f, 1000f * Time.deltaTime, 0f);
            transform.Find("LeftDown").Rotate(0f, -1000f * Time.deltaTime, 0f);
            //transform.GetChild(5).gameObject.SetActive(true);

            droneSound.UnPause();
        }
        else
        {
            transform.Find("RightUp").Rotate(0f, 0f, 0f);
            transform.Find("RightDown").Rotate(0f, 0f, 0f);
            transform.Find("LeftUp").Rotate(0f, 0f, 0f);
            transform.Find("LeftDown").Rotate(0f, 0f, 0f);
            //transform.GetChild(5).gameObject.SetActive(false);
            droneSound.Pause();
        }

        #region �P�_�O�_�i�H����
        if (atground || broken)
        {
            if (atground)
            {
                ourDrone.velocity = Vector3.zero;
                ourDrone.angularVelocity = Vector3.zero;
            }
            if (!start_up || broken)
            {
                upForce = 0;
                input_V_R = 0;
                droneSound.Pause();
                //ourDrone.velocity = Vector3.up * ourDrone.velocity.y;
            }
            input_V_L = 0;
            input_H_L = 0;
            input_H_R = 0;
            vector2 = FixXY(new Vector2(input_H_L, input_V_L));
            input_V_L = vector2.y;
            input_H_L = vector2.x;
            vector2 = FixXY(new Vector2(input_H_R, input_V_R));
            input_V_R = vector2.y;
            input_H_R = vector2.x;
            angleregion_num_L = angleregion(getVerticalAndHorizontalToAngle(input_H_L, input_V_L));
            angleregion_num_R = angleregion(getVerticalAndHorizontalToAngle(input_H_R, input_V_R));
        }
        if (!broken)
        {
            MovementUpDown();
            MovementForward();
            Rotation();
            ClampingSpeedValues();
            Swerwe();
            DroneSound();
        }
        else
        {
            upForce = -400f;
            
        }
        #endregion
        
        ourDrone.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways));
        

        if (H != -1 && !broken)
        {
            if (upForce >= 98.1f)
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Vertical_v / (13 - H) * 10, ourDrone.velocity.z);

            else if (upForce <= 0f)
                upForce = -200f + Mathf.Abs(Vertical_v * 80);
        }
        ourDrone.AddRelativeForce(Vector3.up * upForce);
        // ourDrone.velocity = ourDrone.velocity + Vector3.forward;
        /*if (!atground)
            ourDrone.AddForce(Vector3.forward * 10);// new Vector3(0f, 0f, 100f));*/

        
    }

    public float upForce;

    void MovementUpDown()
    {
        if (Mathf.Abs(input_V_L) > 0.2f || Mathf.Abs(input_H_L) > 0.2f)
        {
            if (angleregion_num_R != left && angleregion_num_R != right && angleregion_num_R != none) //Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K)) //if (input_V_R != 0)
            {
                ourDrone.velocity = ourDrone.velocity;
            }
            if (angleregion_num_R == none) //!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L)
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 104.821f;//�e��
            }
            if (angleregion_num_R != up && angleregion_num_R != down && angleregion_num_R != none) //Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L) 
            {
                if (angleregion_num_L == rightup || angleregion_num_L == rightdown || angleregion_num_L == leftup || angleregion_num_L == leftdown)
                {
                    upForce = 158f;//�k�W���U���W�k�U LJ
                }
                else upForce = 103.34f;//�P�ɫ� WL WJ SL SJ 
            }
            if (angleregion_num_L == right || angleregion_num_L == left)
            {
                upForce = 213.63f;//AJ AL DJ DL
            }
            if ((angleregion_num_L == rightup || angleregion_num_L == leftup || angleregion_num_L == rightdown || angleregion_num_L == leftdown) && angleregion_num_R == none)
            {
                upForce = 158.2f;//�k�W���W�k�U���U(����)
            }
        }
        /*
        if (Mathf.Abs(input_V_L) > 0.2f || Mathf.Abs(input_H_L) > 0.2f)
        {
            if (angleregion_num_R != left && angleregion_num_R != right && angleregion_num_R != none) //Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K)) //if (input_V_R != 0)
            {
                ourDrone.velocity = ourDrone.velocity;
            }
            if (angleregion_num_R == none) //!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L)
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 104.821f;//281
            }
            if (angleregion_num_R == left || angleregion_num_R == right) //!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (!Input.GetKey(KeyCode.J) || !Input.GetKey(KeyCode.L))
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 110;//110
            }
            if (angleregion_num_R != up && angleregion_num_R != down && angleregion_num_R != none) //Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L)
            {
                upForce = 410;//410
            }
        }
        */
        if (Mathf.Abs(input_V_L) < 0.2f && Mathf.Abs(input_H_L) > 0.2f)
        {
            upForce = 135;//135
        }

        //�W�U
        if (angleregion_num_R == up || angleregion_num_R == leftup || angleregion_num_R == rightup) //Input.GetKey(KeyCode.I)
        {
            upForce = 450;//450 �Ů���O (�V�U�A�ƭȶV�p���O�V�j
            if (Mathf.Abs(input_H_L) > 0.2f)
            {
                upForce = 500;//500 ��J���O (�V�W
            }
        }
        else if (angleregion_num_R == down || angleregion_num_R == leftdown || angleregion_num_R == rightdown) //Input.GetKey(KeyCode.K)
        {
            upForce = -200;//-200 ��J���O (�V�U
        }
        else if (Mathf.Abs(input_V_L) < 0.2f && Mathf.Abs(input_H_L) < 0.2f && (angleregion_num_R == right || angleregion_num_R == left || angleregion_num_R == none)) // && !Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K)
        {
            upForce = 98.1f;//98.1f �w�]�B�O (�V�W�A�ƭȶV�j�B�O�V�j
        }
    }

    private float movementForwardSpeed = 300.0f; //500.0f �e��t��
    private float tiltAmountForward = 0;
    private float tiltVelocityForward;
    void MovementForward()
    {
        if (input_V_L != 0)
        {
            ourDrone.AddRelativeForce(Vector3.forward * input_V_L * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 1 * input_V_L, ref tiltAmountForward, 0.1f); //0.1f ���M�� //20 ��v���T��
        }
    }

    //����k��
    private float wantedYRotation;
    [HideInInspector] public float currentYRotation;
    private float rotateAmountByKeys = 2.5f;//2.5f
    private float rotationYVelocity;

    void Rotation()
    {
        if (angleregion_num_R == left || angleregion_num_R == leftup || angleregion_num_R == leftdown) //Input.GetKey(KeyCode.J)
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if (angleregion_num_R == right || angleregion_num_R == rightup || angleregion_num_R == rightdown) //Input.GetKey(KeyCode.L)
        {
            wantedYRotation += rotateAmountByKeys;
        }

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f); //0.25f �\�Y�t��
    }
    public float smoothTime = 0.95f;
    private Vector3 velocityToSmoothDampToZero;
    //�e�ᥪ�k
    void ClampingSpeedValues()
    {
        if (angleregion_num_L == none)
        {
            timer6 += Time.deltaTime;
            if (timer6 >= 1.5f)
            {
                timer6 = 2f;
            }
        }
        else
            timer6 = 0;
        if (Mathf.Abs(input_V_L) > 0.2f && Mathf.Abs(input_H_L) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 30.0f, Time.deltaTime * 20f));//10.0f ���ӲM��
        }
        if (Mathf.Abs(input_V_L) > 0.2f && Mathf.Abs(input_H_L) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 30.0f, Time.deltaTime * 20f));//10.0f ���ӲM��
        }
        if (Mathf.Abs(input_V_L) < 0.2f && Mathf.Abs(input_H_L) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));//5.0f ���k
        }
        if (Mathf.Abs(input_V_L) < 0.2f && Mathf.Abs(input_H_L) < 0.2f)
        {
            if (timer6 >= 1.5f && timer6 < 2f)
            {
                ourDrone.velocity = Vector3.up * ourDrone.velocity.y;
                ourDrone.angularVelocity = Vector3.zero;
                velocityToSmoothDampToZero = Vector3.zero;
            }
            else
                ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, smoothTime);
        }
    }

    //���k����
    private float sideMovementAmount = 300.0f;//300.0f
    private float tiltAmountSideways;
    private float tiltAmountVelocity;

    void Swerwe()
    {
        if (Mathf.Abs(input_H_L) > 0.2f)
        {
            ourDrone.AddRelativeForce(Vector3.right * input_H_L * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -20 * input_H_L, ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            if (timer6 >= 1.5f && timer6 < 2f)
            {
                tiltAmountSideways = 0f;
                tiltAmountVelocity = 0f;
            }
            else
                tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }
    
    #region �L�H������
    private AudioSource droneSound;
    void DroneSound()
    {
        droneSound.pitch = 1 + (ourDrone.velocity.magnitude / 100);
    }
    #endregion
    #region �P�_�n���V
    int angleregion(float a)
    {
        if (a >= -22.5f && a <= 22.5f)
        {
            return up;
        }
        else if (a > 22.5f && a < 67.5f)
        {
            return rightup;
        }
        else if (a >= 67.5f && a <= 112.5f)
        {
            return right;
        }
        else if (a > 112.5f && a < 157.5f)
        {
            return rightdown;
        }
        else if ((a >= 157.5f && a <= 180f) || (a <= -157.5f && a >= -180f))
        {
            return down;
        }
        else if (a > -157.5f && a < -112.5f)
        {
            return leftdown;
        }
        else if (a >= -112.5f && a <= -67.5f)
        {
            return left;
        }
        else if (a > -67.5f && a < -22.5f)
        {
            return leftup;
        }
        else
        {
            return none;
        }
    }
    #endregion
    #region �оǼҦ�
    void limited()
    {
        Vector3 Pos = gameObject.transform.localPosition;
        Vector3 Rot = gameObject.transform.localEulerAngles;
        if (count > 1 && count < 7)
            gameObject.transform.localPosition = new Vector3(Pos.x, 30.0f, Pos.z);
        if (limit)
        {
            switch (count)
            {
                case 0: //�Ұ�
                    if (timer3 >= 3.0f)
                    {
                        count = 1;
                    }
                    input_V_L = 0;
                    input_H_L = 0;
                    input_V_R = 0;
                    input_H_R = 0;
                    break;
                case 1: //�W��
                    if (Pos.y >= 30.0f)
                    {
                        count = 2;
                        gameObject.transform.localPosition = new Vector3(14.63f, 30.0f, -14.64f);
                    }
                    input_V_L = 0;
                    input_H_L = 0;
                    //input_V_R = 0;
                    input_H_R = 0;
                    if (input_V_R < 0)
                        input_V_R = 0;
                    break;
                case 2: //�V�e
                    if (Pos.y >= 30.0f)
                    {
                        gameObject.transform.localPosition = new Vector3(Pos.x, 30.0f, Pos.z);
                    }
                    if (Pos.z >= 14.62f)
                    {
                        count = 3;
                        gameObject.transform.localPosition = new Vector3(14.63f, 30.0f, 14.62f);
                    }
                    //input_V_L = 0;
                    input_H_L = 0;
                    input_V_R = 0;
                    input_H_R = 0;
                    if (input_V_L < 0)
                        input_V_L = 0;
                    break;
                case 3: //����
                    if (Pos.z >= 14.62f)
                    {
                        gameObject.transform.localPosition = new Vector3(Pos.x, 30.0f, 14.62f);
                    }
                    if (Pos.x <= -14.76f)
                    {
                        count = 4;
                        gameObject.transform.localPosition = new Vector3(-14.76f, 30.0f, 14.62f);
                    }
                    input_V_L = 0;
                    //input_H_L = 0;
                    input_V_R = 0;
                    input_H_R = 0;
                    if (input_H_L > 0)
                        input_H_L = 0;
                    break;
                case 4: //�V��
                    if (Pos.x <= -14.76f)
                    {
                        gameObject.transform.localPosition = new Vector3(-14.76f, 30.0f, Pos.z);
                    }
                    if (Pos.z >= 14.64f)
                    {
                        gameObject.transform.localPosition = new Vector3(-14.76f, 30.0f, 14.62f);
                    }
                    if (Pos.z <= -14.64f)
                    {
                        gameObject.transform.localPosition = new Vector3(-14.76f, 30.0f, -14.64f);
                        count = 5;
                    }

                    //input_V_L = 0;
                    input_H_L = 0;
                    input_V_R = 0;
                    input_H_R = 0;
                    if (input_V_L > 0)
                        input_V_L = 0;
                    break;
                case 5: //���k
                    if (Pos.z <= -14.64f)
                    {
                        gameObject.transform.localPosition = new Vector3(Pos.x, 30.0f, -14.64f);
                    }
                    if (Pos.x >= 14.63f)
                    {
                        gameObject.transform.localPosition = new Vector3(14.63f, 30.0f, -14.64f);
                        count = 6;
                    }
                    input_V_L = 0;
                    //input_H_L = 0;
                    input_V_R = 0;
                    input_H_R = 0;
                    if (input_H_L < 0)
                        input_H_L = 0;
                    break;
                case 6: //����
                    gameObject.transform.localPosition = new Vector3(14.63f, 30.0f, -14.64f);
                    if (angleregion_num_R == left)
                    {
                        timer4 += Time.deltaTime;
                        has_R = true;
                    }
                    if (angleregion_num_R == right)
                    {
                        timer4 += Time.deltaTime;
                        has_L = true;
                    }
                    if (has_R && has_L && timer4 > 1.5)
                    {
                        count = 7;
                    }
                    input_V_L = 0;
                    input_H_L = 0;
                    input_V_R = 0;
                    //input_H_R = 0;
                    break;
                case 7: //�U��
                    gameObject.transform.localPosition = new Vector3(14.63f, Pos.y, -14.64f);
                    if (Pos.y >= 30.0f)
                    {
                        gameObject.transform.localPosition = new Vector3(14.63f, 30.0f, -14.64f);
                    }
                    if (Pos.y <= 10.0f) //phase3.ry
                    {
                        count = 8;
                    }
                    input_V_L = 0;
                    input_H_L = 0;
                    //input_V_R = 0;
                    input_H_R = 0;
                    if (input_V_R > 0)
                        input_V_R = 0;
                    break;
                case 8: //����boy
                    timer5 += Time.deltaTime;
                    if (timer5 >= 1.0f) //0.5
                    {
                        count = 9;
                    }
                    if (Pos.y <= 10.0f) //phase3.ry
                    {
                        gameObject.transform.localPosition = new Vector3(14.63f, 10.0f, -14.64f); //phase3.ry
                    }
                    input_V_L = 0;
                    input_H_L = 0;
                    input_V_R = 0;
                    input_H_R = 0;
                    break;
                //case 9 ����boy
                case 10: //����
                    input_V_L = 0;
                    input_H_L = 0;
                    //input_V_R = 0;
                    input_H_R = 0;
                    if (input_V_R > 0)
                        input_V_R = 0;
                    if (!start_up)
                        count = 11;
                    break;
                case 11:
                    break;
            }
        }
    }
    #endregion
    #region �ץ���L���q
    private Vector2 FixXY(Vector2 vector2)
    {
        float x = vector2.x;
        float y = vector2.y;
        if (x != 0 && y != 0)
        {
            float tan = Mathf.Tan(getVerticalAndHorizontalToAngle(x, y) / Mathf.Rad2Deg);
            if (Mathf.Abs(tan) >= 1)
            {
                x = Mathf.Abs(x) / x;
                y = Mathf.Abs(y) / y / Mathf.Abs(tan);
            }
            else
            {
                tan = 1 / Mathf.Abs(tan);
                x = Mathf.Abs(x) / x / Mathf.Abs(tan);
                y = Mathf.Abs(y) / y;
            }
            float temp = 1 / Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
            x *= temp;
            y *= temp;
        }
        return new Vector2(x, y);
    }
    #endregion
    #region �p�⨤��
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
    #region �P�_�U�誫��
    private float? belowDistance()
    {
        #region �ʸˤl�N Collider
        Collider[] myColliders = GetComponentsInChildren<Collider>();
        Bounds myBounds = new Bounds(transform.position, Vector3.zero);
        foreach (Collider nextCollider in myColliders)
        {
            myBounds.Encapsulate(nextCollider.bounds);
        }
        #endregion
        Ray ray = new Ray(myBounds.center - transform.up * (myBounds.extents.y - gameObject.transform.localScale.x), -transform.up);
        RaycastHit hit;
        float? distance = null;
        if (Physics.Raycast(ray, out hit, 3f + gameObject.transform.localScale.x))
        {
            if (hit.transform.tag == "ring" || hit.transform.tag == "NoTrigger" || hit.transform.tag == "OneM" || hit.transform.tag == "Spot")
                return distance;
            //Debug.Log("�I����H: " + hit.collider.name);
            Collider A = hit.collider;
            Bounds B = myBounds;
            Plane plane;
            Vector3 ptA = B.ClosestPoint(A.transform.position);
            Vector3 closestAtA;
            Vector3 closestAtB;

            if (hit.transform.tag == "Plane")
            {
                Vector3 temp1 = RandomPointInBounds(A.bounds);
                Vector3 temp2 = RandomPointInBounds(A.bounds);
                Vector3 temp3 = RandomPointInBounds(A.bounds);
                Debug.DrawLine(temp1, temp2, Color.red);
                Debug.DrawLine(temp3, temp2, Color.red);
                Debug.DrawLine(temp1, temp3, Color.red);

                plane = new Plane();
                plane.Set3Points(temp1, temp2, temp3);
                Vector3 ptB = plane.ClosestPointOnPlane(B.center);
                Vector3 ptM = ptA + (ptB - ptA) / 2;
                closestAtA = plane.ClosestPointOnPlane(ptM);
                closestAtB = B.ClosestPoint(ptM);
            }
            else
            {
                Vector3 ptB = A.ClosestPoint(B.center);
                Vector3 ptM = ptA + (ptB - ptA) / 2;
                closestAtA = A.ClosestPoint(ptM);
                closestAtB = B.ClosestPoint(ptM);
            }

            distance = Vector3.Distance(closestAtA, closestAtB);
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        return distance;
    }
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
    #endregion
    #region �P�_�i���i�H����
    /*
    private bool canMove()
    {
        if (start_up)
        {
            Debug.Log(belowDistance());
            if (belowDistance() == null || belowDistance() > 0.25f)
                return true;
        }
        return false;
    }
    */
    #endregion
    #region �z��
    void OnCollisionEnter(Collision wall)
    {
        if (wall.gameObject.name == "wall") 
        {
            GameObject obj = Instantiate(fire, transform.position, transform.rotation);
            Destroy(obj, 5f);
            broken = true;
            start_up = false;

            //Destroy(gameObject);
        }
    }
    #endregion
    #region �p��q���q�q
    void BatteryCount()
    {
        BatteryPowerTimer += Time.deltaTime; //���ۼզ��b��
        if (angleregion_num_L != none)
        {
            BatteryPowerTimer += Time.deltaTime * 0.3f; //����
        }
        if (angleregion_num_R == up || angleregion_num_R == down)
        {
            BatteryPowerTimer += Time.deltaTime * 0.5f; //�k��W�U
        }
        if (angleregion_num_R == left || angleregion_num_R == right)
        {
            BatteryPowerTimer += Time.deltaTime * 0.2f; //�k�⥪�k
        }
        if (angleregion_num_R == rightdown || angleregion_num_R == rightup || angleregion_num_R == leftdown || angleregion_num_R == leftup)
        {
            BatteryPowerTimer += Time.deltaTime * 0.7f; //�k��W�U&���k
        }
        //Debug.Log(BatteryPowerTimer);
    }
    #endregion

    
}
