using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Random = UnityEngine.Random;

public class DroneMovementScript : MonoBehaviour
{
    public float BatteryPowerTimer = 0f;
    public float DroneHorizontal;
    public float DroneHigh;
    public float DroneAngle;
    public float StartX;
    public float StartY; //�_�l��m
    public float StartZ;
    UIInterface uIInterface;

    Rigidbody ourDrone;
    public enum angleregion_num
    {
        none,
        up,
        rightup,
        right,
        rightdown,
        down,
        leftdown,
        left,
        leftup
    }

    public float input_V_L, input_H_L, input_V_R, input_H_R;
    public float H;
    public float TiltSetX;
    public float TiltSetZ;

    public bool anglo = false;
    public bool onlyone = true;
    public bool has_L = false;
    public bool has_R = false;
    public bool UIctrl = false;
    public bool broken = false;

    public GameObject UserInterface;
    public GameObject fire;
    void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();
        StartX = ourDrone.transform.position.x;
        StartY = ourDrone.transform.position.y;
        StartZ = ourDrone.transform.position.z;
        droneSound = GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>();
        //Debug.Log(droneSound);
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
    public float timeCount = 0f;
    public int count = 0;
    public bool limit = false;

    public double v = 0f;
    public float Horizontal_v;
    public float Vertical_v;

    public int angleregion_num_L;
    public int angleregion_num_R;
    public int angleregion_num_L_without_country;
    public int angleregion_num_R_without_country;
    public Vector2 vr_input_L, vr_input_R;

    void Update()
    {
        #region UI�����}��
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (UIctrl == false)
            {
                UserInterface.SetActive(true);
                UIctrl = true;
            }
            else
            {
                UserInterface.SetActive(false);
                UIctrl = false;
            }
        }
        #endregion
    }
    void FixedUpdate()
    {
        DroneHorizontal = Mathf.Pow((Mathf.Pow((transform.position.x - StartX), 2) + Mathf.Pow((transform.position.z - StartZ), 2)), 0.5f); //�����Z��
        DroneHigh = transform.position.y - StartY; //����
        DroneAngle = transform.eulerAngles.y; //����
        Horizontal_v = Mathf.Sqrt(Mathf.Pow(ourDrone.velocity.x, 2) + Mathf.Pow(ourDrone.velocity.z, 2));
        Vertical_v = ourDrone.velocity.y;
        v = ourDrone.velocity.magnitude;
        TiltSetX = transform.eulerAngles.x;
        TiltSetZ = transform.eulerAngles.z;

        atground = false;
        if (belowDistance() != null)
        {
            H = (float)belowDistance();
            if (H <= 0.1f)
                atground = true;
        }
        else
            H = -1;
        ourDrone.drag = 1;

        #region ��Shift�[�t
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ourDrone.drag *= 0.5f;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ourDrone.drag *= 0.25f;
        }
        #endregion
        #region ��J
        vr_input_L = vr_input_R = Vector2.zero;

        try
        {
            if (MainMenu.hasVRDevice())
            {
                vr_input_L = SteamVR_Actions._default.Axis.GetAxis(SteamVR_Input_Sources.LeftHand);
                vr_input_R = SteamVR_Actions._default.Axis.GetAxis(SteamVR_Input_Sources.RightHand);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }

        if (vr_input_L == Vector2.zero)
        {
            input_V_L = FixXY(new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"))).x; //�����a�V
            input_H_L = FixXY(new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"))).y; //�����V
        }
        else
        {
            input_V_L = vr_input_L.y;
            input_H_L = vr_input_L.x;
        }
        if (vr_input_R == Vector2.zero)
        {
            input_V_R = FixXY(new Vector2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2"))).x; //�k���a�V
            input_H_R = FixXY(new Vector2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2"))).y; //�k���V
        }
        else
        {
            input_V_R = vr_input_R.y;
            input_H_R = vr_input_R.x;
        }
        #endregion
        //print(new Vector4(input_H_L, input_V_L, input_H_R, input_V_R));

        if (SceneManager.GetActiveScene().name == "TeachMode")
        {
            //limited();
            ourDrone.drag *= 3;
        }
        /*
        Vector2 vector2 = FixXY(new Vector2(input_H_L, input_V_L));
        input_V_L = vector2.y;
        input_H_L = vector2.x;
        vector2 = FixXY(new Vector2(input_H_R, input_V_R));
        input_V_R = vector2.y;
        input_H_R = vector2.x;
        */
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
        (angleregion_num_L, angleregion_num_R) = angleregion();
        (angleregion_num_L_without_country, angleregion_num_R_without_country) = angleregion_without_country();

        if (atground && !broken)
        {
            if (!start_up)
            {
                if (angleregion_num_L_without_country == (int)angleregion_num.rightdown && angleregion_num_R_without_country == (int)angleregion_num.leftdown)
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
                if (angleregion_num_L == (int)angleregion_num.none && angleregion_num_R == (int)angleregion_num.down)
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
            droneSound.UnPause();
        }
        else
        {
            transform.Find("RightUp").Rotate(0f, 0f, 0f);
            transform.Find("RightDown").Rotate(0f, 0f, 0f);
            transform.Find("LeftUp").Rotate(0f, 0f, 0f);
            transform.Find("LeftDown").Rotate(0f, 0f, 0f);
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
                if (GameObjectScript.country != (int)GameObjectScript.Country.US)
                    input_V_R = 0;
                else
                    input_V_L = 0;
                droneSound.Pause();
            }
            if (GameObjectScript.country == (int)GameObjectScript.Country.US)
                input_V_R = 0;
            else
                input_V_L = 0;
            input_H_L = 0;
            input_H_R = 0;
            (angleregion_num_L, angleregion_num_R) = angleregion();
        }
        if (!broken)
        {
            #region �����o�s���n���V
            #endregion
            #region �p��s���n���V
            if (GameObjectScript.country == (int)GameObjectScript.Country.JP)
                (input_H_R, input_H_L) = (input_H_L, input_H_R);
            else if (GameObjectScript.country == (int)GameObjectScript.Country.US)
                (input_V_R, input_V_L, input_H_R, input_H_L) = (input_V_L, input_V_R, input_H_L, input_H_R);
            (angleregion_num_L, angleregion_num_R) = angleregion_without_country();
            #endregion
            #region �w���o�s���n���V
            MovementUpDown();
            MovementForward();
            Rotation();
            ClampingSpeedValues();
            Swerwe();
            DroneSound();
            #endregion
        }
        else upForce = -400f;
        #endregion
        if (timeCount > 0)
            timeCount += Time.deltaTime * 1;
        if (timeCount > 1)
            timeCount = 0;
        #region �ʸˤl�N Collider
        Collider[] myColliders = GetComponentsInChildren<Collider>();
        Bounds myBounds = new Bounds(transform.position, Vector3.zero);
        foreach (Collider nextCollider in myColliders)
        {
            myBounds.Encapsulate(nextCollider.bounds);
        }
        #endregion
        if(!atground)
        {
            if (timeCount > 0)
                ourDrone.transform.Rotate(Vector3.forward * 5, Space.World);
            ourDrone.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways));
        }
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

    //�W�U����
    void MovementUpDown()
    {
        if (Mathf.Abs(input_V_L) > 0.2f || Mathf.Abs(input_H_L) > 0.2f)
        {
            if (angleregion_num_R != (int)angleregion_num.left && angleregion_num_R != (int)angleregion_num.right && angleregion_num_R != (int)angleregion_num.none)
            {
                ourDrone.velocity = ourDrone.velocity;
            }
            if (angleregion_num_R == (int)angleregion_num.none)
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 104.821f;
            }
            if (angleregion_num_R != (int)angleregion_num.up && angleregion_num_R != (int)angleregion_num.down && angleregion_num_R != (int)angleregion_num.none)
            {
                if (angleregion_num_L == (int)angleregion_num.rightup || angleregion_num_L == (int)angleregion_num.rightdown || angleregion_num_L == (int)angleregion_num.leftup || angleregion_num_L == (int)angleregion_num.leftdown)
                {
                    upForce = 158f;
                }
                else upForce = 103.34f;
            }
            if (angleregion_num_L == (int)angleregion_num.right || angleregion_num_L == (int)angleregion_num.left)
            {
                upForce = 213.63f;
            }
            if ((angleregion_num_L == (int)angleregion_num.rightup || angleregion_num_L == (int)angleregion_num.leftup || angleregion_num_L == (int)angleregion_num.rightdown || angleregion_num_L == (int)angleregion_num.leftdown) && angleregion_num_R == (int)angleregion_num.none)
            {
                upForce = 158.2f;
            }
        }

        if (Mathf.Abs(input_V_L) < 0.2f && Mathf.Abs(input_H_L) > 0.2f)
        {
            upForce = 135;
        }
        
        if (angleregion_num_R == (int)angleregion_num.up || angleregion_num_R == (int)angleregion_num.leftup || angleregion_num_R == (int)angleregion_num.rightup) //Input.GetKey(KeyCode.I)
        {
            upForce = 450;
            if (Mathf.Abs(input_H_L) > 0.2f)
            {
                upForce = 500;
            }
        }
        else if (angleregion_num_R == (int)angleregion_num.down || angleregion_num_R == (int)angleregion_num.leftdown || angleregion_num_R == (int)angleregion_num.rightdown) //Input.GetKey(KeyCode.K)
        {
            upForce = -200;
        }
        else if (Mathf.Abs(input_V_L) < 0.2f && Mathf.Abs(input_H_L) < 0.2f && (angleregion_num_R == (int)angleregion_num.right || angleregion_num_R == (int)angleregion_num.left || angleregion_num_R == (int)angleregion_num.none)) // && !Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K)
        {
            upForce = 98.1f;
        }
    }


    private float wantedYRotation;
    [HideInInspector] public float currentYRotation;
    private float rotateAmountByKeys = 2.5f;//2.5f
    private float rotationYVelocity;

    //����k��
    void Rotation()
    {
        if (angleregion_num_R == (int)angleregion_num.left || angleregion_num_R == (int)angleregion_num.leftup || angleregion_num_R == (int)angleregion_num.leftdown) //Input.GetKey(KeyCode.J)
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if (angleregion_num_R == (int)angleregion_num.right || angleregion_num_R == (int)angleregion_num.rightup || angleregion_num_R == (int)angleregion_num.rightdown) //Input.GetKey(KeyCode.L)
        {
            wantedYRotation += rotateAmountByKeys;
        }

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f); //0.25f �\�Y�t��
    }
    //�e�ᥪ�k
    public float smoothTime = 0.95f;
    private Vector3 velocityToSmoothDampToZero;
    void ClampingSpeedValues()
    {
        if (angleregion_num_L == (int)angleregion_num.none)
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
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 30.0f, Time.deltaTime * 20f));
        }
        if (Mathf.Abs(input_V_L) > 0.2f && Mathf.Abs(input_H_L) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 30.0f, Time.deltaTime * 20f));
        }
        if (Mathf.Abs(input_V_L) < 0.2f && Mathf.Abs(input_H_L) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
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
    private float sideMovementAmount = 300.0f;
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

    //�e�ᥭ��
    private float movementForwardSpeed = 300.0f;
    private float tiltAmountForward = 0;
    private float tiltVelocityForward;
    void MovementForward()
    {
        if (Mathf.Abs(input_V_L) > 0.2f)
        {
            ourDrone.AddRelativeForce(Vector3.forward * input_V_L * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 1 * input_V_L, ref tiltVelocityForward, 0.1f);
        }
        else tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 0, ref tiltVelocityForward, 0.1f);

    }
    #region �L�H������
    public AudioSource droneSound;
    void DroneSound()
    {
        droneSound.pitch = 1 + (ourDrone.velocity.magnitude / 100);
    }
    #endregion
    #region �P�_�n���V�]�������P��a�^
    (int, int) angleregion()
    {
        int country = GameObjectScript.country;
        return angleregion_without_country(country);
    }
    #endregion
    #region �P�_�n���V�]��l�^
    (int, int) angleregion_without_country(int country = (int)GameObjectScript.Country.CN)
    {
        float angleL = getVerticalAndHorizontalToAngle(input_H_L, input_V_L);
        float angleR = getVerticalAndHorizontalToAngle(input_H_R, input_V_R);

        if (country == (int)GameObjectScript.Country.JP)
        {
            angleL = getVerticalAndHorizontalToAngle(input_H_R, input_V_L);
            angleR = getVerticalAndHorizontalToAngle(input_H_L, input_V_R);
        }
        else if (country == (int)GameObjectScript.Country.US)
        {
            angleL = getVerticalAndHorizontalToAngle(input_H_R, input_V_R);
            angleR = getVerticalAndHorizontalToAngle(input_H_L, input_V_L);
        }

        int l, r;
        #region �p�⥪�⨤��
        if (angleL >= -22.5f && angleL <= 22.5f)
        {
            l = (int)angleregion_num.up;
        }
        else if (angleL > 22.5f && angleL < 67.5f)
        {
            l = (int)angleregion_num.rightup;
        }
        else if (angleL >= 67.5f && angleL <= 112.5f)
        {
            l = (int)angleregion_num.right;
        }
        else if (angleL > 112.5f && angleL < 157.5f)
        {
            l = (int)angleregion_num.rightdown;
        }
        else if ((angleL >= 157.5f && angleL <= 180f) || (angleL <= -157.5f && angleL >= -180f))
        {
            l = (int)angleregion_num.down;
        }
        else if (angleL > -157.5f && angleL < -112.5f)
        {
            l = (int)angleregion_num.leftdown;
        }
        else if (angleL >= -112.5f && angleL <= -67.5f)
        {
            l = (int)angleregion_num.left;
        }
        else if (angleL > -67.5f && angleL < -22.5f)
        {
            l = (int)angleregion_num.leftup;
        }
        else
        {
            l = (int)angleregion_num.none;
        }
        #endregion
        #region �p��k�⨤��
        if (angleR >= -22.5f && angleR <= 22.5f)
        {
            r = (int)angleregion_num.up;
        }
        else if (angleR > 22.5f && angleR < 67.5f)
        {
            r = (int)angleregion_num.rightup;
        }
        else if (angleR >= 67.5f && angleR <= 112.5f)
        {
            r = (int)angleregion_num.right;
        }
        else if (angleR > 112.5f && angleR < 157.5f)
        {
            r = (int)angleregion_num.rightdown;
        }
        else if ((angleR >= 157.5f && angleR <= 180f) || (angleR <= -157.5f && angleR >= -180f))
        {
            r = (int)angleregion_num.down;
        }
        else if (angleR > -157.5f && angleR < -112.5f)
        {
            r = (int)angleregion_num.leftdown;
        }
        else if (angleR >= -112.5f && angleR <= -67.5f)
        {
            r = (int)angleregion_num.left;
        }
        else if (angleR > -67.5f && angleR < -22.5f)
        {
            r = (int)angleregion_num.leftup;
        }
        else
        {
            r = (int)angleregion_num.none;
        }
        #endregion
        return (l, r);
    }
    #endregion
    #region �ץ���L���q
    private Vector2 FixXY(Vector2 vector2)
    {
        float x = vector2.x;
        float y = vector2.y;
        float temp = 1;
        float max = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
        if (max != 0.0f)
            temp = Mathf.Sqrt(Mathf.Pow(x / max, 2) + Mathf.Pow(y / max, 2));
        return new Vector2(x / temp, y / temp);
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
        if (Physics.Raycast(ray, out hit, 3f + gameObject.transform.localScale.x)) //�g�X�g�u�P�_3��줺�O�_���I���c
        {
            if (hit.transform.tag == "ring" || hit.transform.tag == "NoTrigger" || hit.transform.tag == "OneM" || hit.transform.tag == "Spot") //���i����������
                return distance;
            Collider A = hit.collider;
            Bounds B = myBounds;
            Plane plane;
            Vector3 ptA = B.ClosestPoint(A.transform.position);
            Vector3 closestAtA;
            Vector3 closestAtB;

            #region �p��L�H���P�a�����̪�Z��
            if (hit.transform.tag == "Plane")
            {
                Vector3 temp1 = RandomPointInBounds(A.bounds);
                Vector3 temp2 = RandomPointInBounds(A.bounds);
                Vector3 temp3 = RandomPointInBounds(A.bounds);

                plane = new Plane();
                plane.Set3Points(temp1, temp2, temp3);
                Vector3 ptB = plane.ClosestPointOnPlane(B.center);
                Vector3 ptM = ptA + (ptB - ptA) / 2;
                closestAtA = plane.ClosestPointOnPlane(ptM);
                closestAtB = B.ClosestPoint(ptM);
            }
            #endregion
            #region �p��L�H���P��L���~���̪�Z��
            else
            {
                Vector3 ptB = A.ClosestPoint(B.center);
                Vector3 ptM = ptA + (ptB - ptA) / 2;
                closestAtA = A.ClosestPoint(ptM);
                closestAtB = B.ClosestPoint(ptM);
            }
            #endregion

            distance = Vector3.Distance(closestAtA, closestAtB);
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
            timeCount += Time.deltaTime;
            //Destroy(gameObject);
        }
    }
    #endregion
    #region �p��q���q�q
    void BatteryCount()
    {
        BatteryPowerTimer += Time.deltaTime; //���ۼզ��b��
        if (angleregion_num_L != (int)angleregion_num.none)
        {
            BatteryPowerTimer += Time.deltaTime * 0.3f; //����
        }
        if (angleregion_num_R == (int)angleregion_num.up || angleregion_num_R == (int)angleregion_num.down)
        {
            BatteryPowerTimer += Time.deltaTime * 0.5f; //�k��W�U
        }
        if (angleregion_num_R == (int)angleregion_num.left || angleregion_num_R == (int)angleregion_num.right)
        {
            BatteryPowerTimer += Time.deltaTime * 0.2f; //�k�⥪�k
        }
        if (angleregion_num_R == (int)angleregion_num.rightdown || angleregion_num_R == (int)angleregion_num.rightup || angleregion_num_R == (int)angleregion_num.leftdown || angleregion_num_R == (int)angleregion_num.leftup)
        {
            BatteryPowerTimer += Time.deltaTime * 0.7f; //�k��W�U&���k
        }
        //Debug.Log(BatteryPowerTimer);
    }
    #endregion
}
