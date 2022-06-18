using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using UnityEngine.SpatialTracking;
using System;
using UnityEngine.Events;

public class UIswitch : MonoBehaviour
{
    /*public GameObject rRule;
    public GameObject tTimeOut;
    public GameObject gGetOn;
    public GameObject loadloading;
    public GameObject eEnd;
    public GameObject bBadend;
    public Button Next;
    public GameObject next;
    public Button Back2Menu;
    public Button Rule;
    public Button Continue;
    public Button Again;
    public Button BackTrainMenu;
    public Button BackMainMenu;
    public Button endAgain;
    public Button endBackTrainMenu;
    public Button endBackMainMenu;
    public Button BadendAgain;
    public Button BadendBackTrainMenu;
    public Button BadendBackMainMenu;*/
    public static bool shwitch = false;
    private int count = 0;
    private int rulecount = 1;
    public static bool endbool = false;
    public static int EorB = 0;
    public static bool showOtherUI = false;
    string scenePath;
    static DroneMovementScript droneMovementScript;

    public SteamVR_Action_Boolean m_BooleanAction;

    void BoolTest(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
    {
        Pause();
    }

    void Start()
    {
        //loadloading.SetActive(false);
        SetActive("LoadLoading", false);
        //gGetOn.SetActive(true);
        endbool = false;
        shwitch = false;
        EorB = 0;
        showOtherUI = false;
        scenePath = SceneManager.GetActiveScene().path;
        try
        {
            if (MainMenu.hasVRDevice())
            {
                m_BooleanAction = SteamVR_Actions._default.GrabPinch_L;

                #region Event
                if (GameObjectScript.cameraVR != null)
                {
                    if (GameObjectScript.cameraVR.GetComponent<TrackedPoseDriver>() != null)
                    {
                        m_BooleanAction[SteamVR_Input_Sources.Any].onStateDown += BoolTest;
                    }
                }
                #endregion
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        #region ButtonAddListener
        ButtonAddListener("Next", OpenGetOn);
        ButtonAddListener("RuleButton", OpenRule);
        ButtonAddListener("Back2Menu", OpenTimeOut);
        ButtonAddListener("ContinueButton", OpenGetOn);
        ButtonAddListener("AgainButton", Restartgame);
        ButtonAddListener("BackMainMenuButton", Back2MainMenu);
        ButtonAddListener("Wind+", WindPlus);
        ButtonAddListener("Wind-", WindMinus);
        foreach (GameObject gameObject in FindAllObjectByName("BackMenuButton"))
        {
            if (gameObject.GetComponent<Button>() != null)
            {
                if (scenePath.StartsWith("Assets/TrainMode/Scenes/"))
                    gameObject.GetComponent<Button>().onClick.AddListener(Back2TrainMenu);
                else if (scenePath.StartsWith("Assets/TestMode/Scenes/"))
                    gameObject.GetComponent<Button>().onClick.AddListener(Back2TestMenu);
            }
        }
        #endregion
    }

    void OpenTimeOut()
    {
        count = 1;
        // Debug.Log("OpenTimeOut");
    }

    void OpenRule()
    {
        count = 0;
        // Debug.Log("OpenRule");
    }

    void OpenGetOn()
    {
        if (rulecount == 1)
        {
            if (Find("Next") != null) Destroy(Find("Next"));
            if (Find("Back2Menu") != null) Find("Back2Menu").GetComponent<CanvasGroup>().alpha = 1;
            rulecount++;
        }
        count = 1;
        shwitch = true;
        // Debug.Log("OpenGetOn");
    }

    void Restartgame()
    {
        count = 2;
        MainMenu.SceneNumber = MainMenu.SceneCount;

        droneMovementScript.enabled = false;
        //gGetOn.SetActive(false);
        SetActive("Rule", false);
        SetActive("TimeOut", false);
        //loadloading.SetActive(true);
        SetActive("LoadLoading", true);
        MainMenu.loadingbool = true;
        endbool = false;
        // Debug.Log("Restartgame");
    }
    void Back2TrainMenu()
    {
        count = 2;
        MainMenu.SceneNumber = 2;

        droneMovementScript.enabled = false;
        //gGetOn.GetComponent<CanvasGroup>().alpha = 0;
        showOtherUI = false;
        SetActive("Rule", false);
        SetActive("TimeOut", false);
        SetActive("LoadLoading", true);
        MainMenu.loadingbool = true;
        endbool = false;
        // Debug.Log("Back2TrainMenu");
    }
    void Back2TestMenu()
    {
        count = 2;
        MainMenu.SceneNumber = 14;

        droneMovementScript.enabled = false;
        //gGetOn.GetComponent<CanvasGroup>().alpha = 0;
        showOtherUI = false;
        SetActive("Rule", false);
        SetActive("TimeOut", false);
        SetActive("LoadLoading", true);
        MainMenu.loadingbool = true;
        endbool = false;
        // Debug.Log("Back2TestMenu");
    }
    void Back2MainMenu()
    {
        count = 2;
        MainMenu.SceneNumber = 0;

        droneMovementScript.enabled = false;
        //gGetOn.GetComponent<CanvasGroup>().alpha = 0;
        showOtherUI = false;
        SetActive("Rule", false);
        SetActive("TimeOut", false);
        SetActive("LoadLoading", true);
        MainMenu.loadingbool = true;
        endbool = false;
        // Debug.Log("Back2MainMenu");
    }

    void WindPlus()
    {
        if (GameObject.FindGameObjectWithTag("Drone") != null)
        {
            if (GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>() != null)
            {
                if (GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>().wind_count < 100)
                    GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>().wind_count++;
            }
        }
    }

    void WindMinus()
    {
        if (GameObject.FindGameObjectWithTag("Drone") != null)
        {
            if (GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>() != null)
            {
                if (GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>().wind_count > 0)
                    GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>().wind_count--;
            }
        }
    }
    void Update()
    {
        droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        if (Find("WindButtom") != null && GameObject.FindGameObjectWithTag("Drone") != null)
        {
            if (Find("WindButtom").GetComponentInChildren<Text>() != null && GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>() != null)
                Find("WindButtom").GetComponentInChildren<Text>().text = "風量：" + GameObject.FindGameObjectWithTag("Drone").GetComponent<wind_region>().wind_count;
        }
        /*
        Debug.Log("getonalpha = " + gGetOn.GetComponent<CanvasGroup>().alpha);
        Debug.Log("shwitch = " + shwitch);
        Debug.Log("loadend = " + Loading.loadend);
        */
        if (endbool == true)
        {
            // Debug.Log(count);
            //Button H = endAgain.GetComponent<Button>();
            //Button H = Find("AgainButton").GetComponent<Button>();
            //H.onClick.AddListener(Restartgame);
            //ButtonAddListener("AgainButton", Restartgame);

            //Button I = endBackTrainMenu.GetComponent<Button>();
            /*
            foreach (GameObject gameObject in FindAllObjectByName("BackMenuButton"))
            {
                if (gameObject.GetComponent<Button>() != null)
                {
                    if (scenePath.StartsWith("Assets/TrainMode/Scenes/"))
                        gameObject.GetComponent<Button>().onClick.AddListener(Back2TrainMenu);
                    else if (scenePath.StartsWith("Assets/TestMode/Scenes/"))
                        gameObject.GetComponent<Button>().onClick.AddListener(Back2TestMenu);
                }
            }
            */
            /*if (scenePath.StartsWith("Assets/TrainMode/Scenes/"))
                I.onClick.AddListener(Back2TrainMenu);
            else if(scenePath.StartsWith("Assets/TestMode/Scenes/"))
                I.onClick.AddListener(Back2TestMenu);*/

            //Button J = endBackMainMenu.GetComponent<Button>();
            //ButtonAddListener("BackMainMenuButton", Back2MainMenu);

            /*Button K = BadendAgain.GetComponent<Button>();
            K.onClick.AddListener(Restartgame);

            Button L = BadendBackTrainMenu.GetComponent<Button>();
            if (scenePath.StartsWith("Assets/TrainMode/Scenes/"))
                L.onClick.AddListener(Back2TrainMenu);
            else if (scenePath.StartsWith("Assets/TestMode/Scenes/"))
                L.onClick.AddListener(Back2TestMenu);

            Button M = BadendBackMainMenu.GetComponent<Button>();
            M.onClick.AddListener(Back2MainMenu);*/

            //gGetOn.GetComponent<CanvasGroup>().alpha = 0;
            showOtherUI = false;
            SetActive("Rule", false);
            SetActive("TimeOut", false);
            if (EorB == 1)
            {
                SetActive("End", true);
            }
            else if (EorB == 2)
            {
                SetActive("Bad End", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (shwitch == false)
        {
            //gGetOn.GetComponent<CanvasGroup>().alpha = 0;
            showOtherUI = false;
            if (count == 0)
            {
                SetActive("Rule", true);
                SetActive("TimeOut", false);
                /*
                if (rulecount == 1)
                {
                    ButtonAddListener("Next", OpenGetOn);
                }
                else if (rulecount == 2)
                {
                    ButtonAddListener("Back2Menu", OpenTimeOut);
                }
                */
            }
            else if (count == 1)
            {
                SetActive("Rule", false);
                SetActive("TimeOut", true);
                /*
                ButtonAddListener("RuleButton", OpenRule);
                ButtonAddListener("ContinueButton", OpenGetOn);
                ButtonAddListener("AgainButton", Restartgame);
                ButtonAddListener("BackMainMenuButton", Back2MainMenu);
                if (Find("BackMenuButton") != null)
                {
                    Button F = Find("BackMenuButton").GetComponent<Button>();
                    F.onClick.AddListener(Back2TrainMenu);
                    if (scenePath.StartsWith("Assets/TrainMode/Scenes/"))
                        F.onClick.AddListener(Back2TrainMenu);
                    else if (scenePath.StartsWith("Assets/TestMode/Scenes/"))
                        F.onClick.AddListener(Back2TestMenu);
                }
                */
            }
        }
        else
        {
            Time.timeScale = 1;
            if (Loading.loadend == 1)
            {
                //gGetOn.GetComponent<CanvasGroup>().alpha = 0;
                showOtherUI = false;
            }
            else
            {
                if (endbool == false)
                    //gGetOn.GetComponent<CanvasGroup>().alpha = 1;
                    showOtherUI = true;
            }
            SetActive("Rule", false);
            SetActive("TimeOut", false);
        }
    }

    void Pause()
    {
        if (rulecount == 1)
            return;
        DroneMovementScript droneMovementScript = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneMovementScript>();
        if (showOtherUI)
        {
            shwitch = false;
            Time.timeScale = 0;
            droneMovementScript.droneSound.Pause();
        }
        else
        {
            OpenGetOn();
            droneMovementScript.droneSound.UnPause();
        }
    }

    void ButtonAddListener(string name, UnityAction call)
    {
        /*
        GameObject gameObject = Find(name);
        if (gameObject != null)
        {
            if (gameObject.GetComponent<Button>() != null)
                gameObject.GetComponent<Button>().onClick.AddListener(call);
        }
        */
        foreach (GameObject gameObject in FindAllObjectByName(name))
        {
            if (gameObject.GetComponent<Button>() != null)
                gameObject.GetComponent<Button>().onClick.AddListener(call);
        }
    }
    void ButtonsAddListener(string name, UnityAction call)
    {
        foreach (GameObject gameObject in FindAllObjectByName(name))
        {
            if (gameObject.GetComponent<Button>() != null)
                gameObject.GetComponent<Button>().onClick.AddListener(call);
        }
    }

    GameObject Find(string name)
    {
        if (FindAllObjectByName(name).Length == 0)
            return null;
        return FindAllObjectByName(name)[0];
    }

    GameObject[] FindAllObjectByName(string name)
    {
        GameObject[] gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        List<GameObject> gameObjectsList = new List<GameObject>();
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == name)
                gameObjectsList.Add(gameObject);
        }
        return gameObjectsList.ToArray();
    }

    void SetActive(string name, bool b)
    {
        /*
        GameObject gameObject = Find(name);
        if (gameObject != null)
        {
            gameObject.SetActive(b);
        }
        */
        foreach (GameObject gameObject in FindAllObjectByName(name))
        {
            gameObject.SetActive(b);
        }
    }

    public static void End()
    {
        GameObject Drone = GameObject.FindGameObjectWithTag("Drone");
        Drone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;


        UIswitch.endbool = true;
        UIswitch.EorB = 1;
        Time.timeScale = 0;

        droneMovementScript.droneSound.Pause();
        droneMovementScript.start_up = false;
        droneMovementScript.enabled = false;
    }

    public static void BadEnd()
    {
        GameObject Drone = GameObject.FindGameObjectWithTag("Drone");
        Drone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;



        UIswitch.endbool = true;
        UIswitch.EorB = 2;
        Time.timeScale = 0;

        droneMovementScript.droneSound.Pause();
        droneMovementScript.start_up = false;
        droneMovementScript.enabled = false;
    }
}
