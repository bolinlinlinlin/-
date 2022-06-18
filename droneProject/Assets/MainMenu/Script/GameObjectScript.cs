using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SpatialTracking;

public class GameObjectScript : MonoBehaviour
{
    public enum Country : int
    {
        CN,
        US,
        JP
    }

    public static int country;
    public static bool hasDrone;
    public static Camera cameraVR;
    public static Camera cameraHUD;
    public static Camera cameraUI;
    public static Camera PP_Pointer;
    void Start()
    {
        country = (int)Country.CN;
        SceneManager.activeSceneChanged += ChangedActiveScene;
        isNoVRDevice();
    }

    void Update()
    {
        try
        {
            hasDrone = GameObject.FindGameObjectWithTag("Drone");
            if (GameObject.FindGameObjectWithTag("VRCamera") != null)
                cameraVR = GameObject.FindGameObjectWithTag("VRCamera").GetComponent<Camera>();
            if (cameraVR != null)
            {
                if (hasDrone)
                    cameraVR.GetComponent<CameraFollowScript>().enabled = true;
                else
                {
                    cameraVR.GetComponent<CameraFollowScript>().enabled = false;
                    if (cameraVR.GetComponent<TrackedPoseDriver>() != null)
                    {
                        cameraVR.GetComponent<TrackedPoseDriver>().trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
                    }
                }
            }

            if (GameObject.Find("Camera (HUD)") != null)
                cameraHUD = GameObject.Find("Camera (HUD)").GetComponent<Camera>();
            if (GameObject.Find("Camera (UI)") != null)
                cameraUI = GameObject.Find("Camera (UI)").GetComponent<Camera>();
            if (GameObject.Find("PP_Pointer") != null)
                PP_Pointer = GameObject.Find("PP_Pointer").GetComponent<Camera>();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        isNoVRDevice();
        if (GetComponent<ChangeCanvasCamera>().enabled)
            GetComponent<ChangeCanvasCamera>().ResetUI();
    }

    private void isNoVRDevice()
    {
        // Debug.LogFormat("MainMenu.hasVRDevice: {0}", MainMenu.hasVRDevice());
        GameObject m_EventSystem = GameObject.Find("EventSystem");
        if (MainMenu.hasVRDevice())
        {
            GameObject m_MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (m_MainCamera != null)
            {
                m_MainCamera.SetActive(false);
            }
            if (m_EventSystem != null)
            {
                if (m_EventSystem.GetComponent<VRInputModule>() == null)
                    m_EventSystem.AddComponent<VRInputModule>();
                else
                    m_EventSystem.GetComponent<VRInputModule>().enabled = true;
            }
            GetComponent<ChangeCanvasCamera>().enabled = true;
            GetComponent<ChangeCanvasCamera>().Core();
        }
        else
        {
            if (m_EventSystem != null)
            {
                if (m_EventSystem.GetComponent<VRInputModule>() != null)
                    m_EventSystem.GetComponent<VRInputModule>().enabled = false;
            }
            GetComponent<ChangeCanvasCamera>().enabled = false;
        }
    }
}
