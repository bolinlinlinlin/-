using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using Valve.VR;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public Button TeachButtom;
    public Button TrainingButtom;
    public Button TestButtom;
    public Button SetButtom;
    public Button ExitButtom;
    public static int SceneNumber = 0;
    public static int SceneCount = 0;
    public static bool loadingbool = false;

    public GameObject GameObjectprefab;
    public GameObject CameraRigprefab;
    public GameObject CameraRig;
    static bool isHaveClone = false;

    private void Awake()
    {
        if (!isHaveClone)
        {
            isHaveClone = true;

            GameObject clone = (GameObject)GameObject.Instantiate(GameObjectprefab);
            GameObject.DontDestroyOnLoad(clone);

            if (hasVRDevice())
            {
                CameraRig = GameObject.FindGameObjectWithTag("VRDevices");

                if (!CameraRig)
                    CameraRig = (GameObject)GameObject.Instantiate(CameraRigprefab);
                GameObject.DontDestroyOnLoad(CameraRig);
            }
        }
    }

    void Start()
    {
        Button btn1 = TeachButtom.GetComponent<Button>();
        btn1.onClick.AddListener(TeachOnClick);

        Button btn2 = TrainingButtom.GetComponent<Button>();
        btn2.onClick.AddListener(TrainingOnOnClick);

        Button btn3 = TestButtom.GetComponent<Button>();
        btn3.onClick.AddListener(TestOnOnClick);

        Button btn4 = SetButtom.GetComponent<Button>();
        btn4.onClick.AddListener(SetOnOnClick);

        Button btn5 = ExitButtom.GetComponent<Button>();
        btn5.onClick.AddListener(ExitOnOnClick);
    }

    private void TrainingOnOnClick()
    {
        SceneManager.LoadScene("TrainMenu");
    }

    private void TeachOnClick()
    {
        SceneManager.LoadScene("TeachMode");
    }

    private void TestOnOnClick()
    {
        SceneManager.LoadScene("TestMenu");
    }
    private void SetOnOnClick()
    {
        SceneManager.LoadScene("Setting");
    }
    private void ExitOnOnClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool hasVRDevice()
    {
        List<XRDisplaySubsystem> displaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances<XRDisplaySubsystem>(displaySubsystems);
        if (displaySubsystems.Count != 0)
            return true;
        return false;
    }
}
