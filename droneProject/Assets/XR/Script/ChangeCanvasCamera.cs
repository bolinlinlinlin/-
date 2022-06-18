using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SpatialTracking;
using Valve.VR;

public class ChangeCanvasCamera : MonoBehaviour
{
    public new Camera camera;
    public Camera camera2;

    public float UI_scaleFactor, HUD_scaleFactor;
    bool hasAdd;

    public SteamVR_Action_Boolean m_BooleanAction;

    void Start()
    {
        camera = null;
        camera2 = null;
        UI_scaleFactor = 0.6f;
        HUD_scaleFactor = 0.6f;
        hasAdd = false;

        m_BooleanAction = SteamVR_Actions._default.GrabGrip_L;

        Core();
    }

    public void Update()
    {
        ResetHUD();
    }

    void BoolTest(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
    {
        Core();
    }

    async public void Core()
    {
        if (camera == null || camera2 == null)
            await Task.Delay(1000);

        #region Event
        if (GameObjectScript.cameraVR != null && !hasAdd)
        {
            if (GameObjectScript.cameraVR.GetComponent<TrackedPoseDriver>() != null)
            {
                try
                {
                    m_BooleanAction[SteamVR_Input_Sources.Any].onStateDown += BoolTest;
                    hasAdd = true;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
        #endregion

        if (GameObjectScript.cameraVR != null && GameObjectScript.PP_Pointer != null)
        {
            camera = GameObjectScript.cameraVR;
            camera2 = GameObjectScript.PP_Pointer;

            ResetUI();
            ResetHUD();

            camera.GetComponent<Camera>().enabled = false;
            camera.GetComponent<Camera>().enabled = true;
        }
    }

    public Canvas[] FindInActiveObjectsByLayerName(string name)
    {
        int layer = LayerMask.NameToLayer(name);
        List<Canvas> validTransforms = new List<Canvas>();
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].gameObject.layer == layer)
                {
                    if (objs[i].GetComponent<Canvas>() != null)
                        validTransforms.Add(objs[i].GetComponent<Canvas>());
                }
            }
        }
        return validTransforms.ToArray();
    }

    public void ResetUI()
    {
        Canvas[] canvases = FindInActiveObjectsByLayerName("UI");
        foreach (Canvas canvas in canvases)
        {
            canvas.scaleFactor = UI_scaleFactor;
            canvas.worldCamera = camera;
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = camera2;
            Transform transform = canvas.gameObject.transform;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x + 17, transform.rotation.eulerAngles.y, 0));
        }
    }
    public void ResetHUD()
    {
        Canvas[] canvases = FindInActiveObjectsByLayerName("HUD");
        foreach (Canvas canvas in canvases)
        {
            canvas.scaleFactor = HUD_scaleFactor;
            canvas.worldCamera = GameObjectScript.cameraHUD;
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.renderMode = RenderMode.WorldSpace;
        }
    }
}