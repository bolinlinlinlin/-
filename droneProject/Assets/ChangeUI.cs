using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SpatialTracking;
using Valve.VR;

public class ChangeUI : MonoBehaviour
{
    enum UI
    {
        MainUI,
        AppUI,
    }
    public int changeui_status;
    int[] ui_status;
    CanvasGroup[] canvasGroupArray;
    public SteamVR_Action_Boolean m_BooleanAction;

    void BoolTest(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
    {
        if (ui_status.Length >= 0)
        {
            if (ui_status.Length > 0)
            {
                if (SceneManager.GetActiveScene().name == "Test_Square")
                {
                    if (TestChoise3.isSquareLight)
                        changeui_status = 0;
                }
                changeui_status = (changeui_status + 1) % (ui_status.Length);
                for (int i = 0; i < ui_status.Length; i++)
                {
                    if (i == changeui_status)
                        ui_status[i] = 1;
                    else
                        ui_status[i] = 0;
                }
            }
        }
    }

    void Start()
    {
        ui_status = new int[0];

        m_BooleanAction = SteamVR_Actions._default.Button_X;

        #region Event
        try
        {
            if (GameObjectScript.cameraVR != null)
            {
                if (GameObjectScript.cameraVR.GetComponent<TrackedPoseDriver>() != null)
                {
                    m_BooleanAction[SteamVR_Input_Sources.Any].onStateDown += BoolTest;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        #endregion

        string[] uiName = { "MainUI", "AppUI" };

        List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();

        foreach (string n in uiName)
        {
            GameObject g = GameObject.FindGameObjectWithTag(n);
            if (g != null)
            {
                if (g.GetComponent<CanvasGroup>() == null)
                    g.AddComponent<CanvasGroup>();
                canvasGroupList.Add(g.GetComponent<CanvasGroup>());
            }
        }
        canvasGroupArray = canvasGroupList.ToArray();
        ui_status = new int[canvasGroupArray.Length];
        if (ui_status.Length > 0)
            ui_status[0] = 1;
    }

    void Update()
    {
        // Debug.Log("ui_status.Length:" + ui_status.Length);
        if (ui_status.Length >= 0)
        {
            if (ui_status.Length > 0)
            {
                if (Input.GetKeyDown("v"))
                    changeui_status = (changeui_status + 1) % (ui_status.Length);
                if(SceneManager.GetActiveScene().name == "Test_Square")
                {
                    if(TestChoise3.isSquareLight)
                        changeui_status = 0;
                }
                for (int i = 0; i < ui_status.Length; i++)
                {
                    if (i == changeui_status)
                        ui_status[i] = 1;
                    else
                        ui_status[i] = 0;
                }
            }
            for (int i = 0; i < canvasGroupArray.Length; i++)
            {
                string scenePath = SceneManager.GetActiveScene().path;

                if (scenePath.StartsWith("Assets/TrainMode/Scenes/") || scenePath.StartsWith("Assets/TestMode/Scenes/"))
                {
                    if (UIswitch.showOtherUI == false)
                    {
                        canvasGroupArray[i].alpha = 0;
                        continue;
                    }
                }
                canvasGroupArray[i].alpha = ui_status[i];
            }
        }
    }
}
