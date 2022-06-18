using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SpatialTracking;
using Valve.VR;

public class CameraFollowScript : MonoBehaviour
{   
    public Vector3 behindPosition;
    public float angle;
    private Transform ourDrone;
    private int changecam_status;
    
    public SteamVR_ActionSet m_ActionSet;
    public SteamVR_Action_Boolean m_BooleanAction;

    void BoolTest(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
    {
        string scenePath = SceneManager.GetActiveScene().path;
        if (scenePath.StartsWith("Assets/TrainMode/Scenes/") || scenePath.StartsWith("Assets/TestMode/Scenes/"))
        {
            if (UIswitch.showOtherUI == false)
            {
                return;
            }
        }
        changecam_status = (changecam_status + 1) % 3;
    }

    void Start()
    {
        changecam_status = 1;

        m_BooleanAction = SteamVR_Actions._default.Button_A;

        #region Event
        try
        {
            if (MainMenu.hasVRDevice())
            {
                m_BooleanAction[SteamVR_Input_Sources.Any].onStateDown += BoolTest;
                m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        #endregion
    }

    void Update()
    {
        string scenePath = SceneManager.GetActiveScene().path;
        if (scenePath.StartsWith("Assets/TrainMode/Scenes/") || scenePath.StartsWith("Assets/TestMode/Scenes/"))
        {
            if (UIswitch.showOtherUI != false)
            {
                if (Input.GetKeyDown("c"))
                {
                    changecam_status = changecam_status % 2 + 1;
                }
            }
        }

        if (GameObject.FindGameObjectWithTag("Drone") != null)
            ourDrone = GameObject.FindGameObjectWithTag("Drone").transform;
        
        if (SceneManager.GetActiveScene().name == "Test_Square")
        {
            if (TestChoise3.isSquareLight)
                changecam_status = 0;
            else
                changecam_status = 2;
        }
        if (ourDrone != null)
        {
            if (GetComponent<TrackedPoseDriver>() != null)
            {
                GetComponent<TrackedPoseDriver>().trackingType = (TrackedPoseDriver.TrackingType)(-1);

                TrackedPoseDriver.TrackedPose m_PoseSource = GetComponent<TrackedPoseDriver>().poseSource;
                Pose currentPose = new Pose();
                currentPose = Pose.identity;
                PoseDataFlags poseFlags = GetPoseData(m_PoseSource, out currentPose);
                DroneMovementScript droneMovementScript = ourDrone.GetComponent<DroneMovementScript>();
                if (poseFlags != PoseDataFlags.NoData)
                {
                    Pose localPose = TransformPoseByOriginIfNeeded(currentPose);

                    if (changecam_status == 0) //原點
                    {
                        transform.rotation = localPose.rotation;
                        transform.position = new Vector3(droneMovementScript.StartX, droneMovementScript.StartY, droneMovementScript.StartZ) + new Vector3(0, 5.5f, -69);
                    }
                    else
                    {
                        if (changecam_status == 1) //無人機後
                            behindPosition = new Vector3(0, 8, -25);
                        else if (changecam_status == 2) //無人機前
                            behindPosition = new Vector3(0, 1, 2);

                        transform.rotation = Quaternion.Euler(new Vector3(0, ourDrone.eulerAngles.y, 0)) * localPose.rotation;
                        transform.position = ourDrone.transform.TransformPoint(behindPosition);
                    }
                }
                else
                {
                    switch (changecam_status)
                    {
                        case 0: //原點
                            changecam_status = 1;
                            behindPosition = new Vector3(0, 8, -25);
                            break;
                        case 1: //無人機後
                            behindPosition = new Vector3(0, 8, -25);
                            break;
                        case 2: //無人機前
                            behindPosition = new Vector3(0, 1, 2);
                            break;
                    }

                    transform.rotation = Quaternion.Euler(new Vector3(angle, ourDrone.GetComponent<DroneMovementScript>().currentYRotation, 0)); //原始
                    transform.position = ourDrone.transform.TransformPoint(behindPosition);
                }
            }
            else
            {
                switch (changecam_status)
                {
                    case 0: //原點
                        changecam_status = 1;
                        behindPosition = new Vector3(0, 8, -25);
                        break;
                    case 1: //無人機後
                        behindPosition = new Vector3(0, 8, -25);
                        break;
                    case 2: //無人機前
                        behindPosition = new Vector3(0, 1, 2);
                        break;
                }

                transform.rotation = Quaternion.Euler(new Vector3(angle, ourDrone.GetComponent<DroneMovementScript>().currentYRotation, 0)); //原始
                transform.position = ourDrone.transform.TransformPoint(behindPosition);
            }
        }
    }
    PoseDataFlags GetPoseData(TrackedPoseDriver.TrackedPose poseSource, out Pose resultPose)
    {
        return PoseDataSource.GetDataFromSource(poseSource, out resultPose);

    }   

    Pose TransformPoseByOriginIfNeeded(Pose pose)
    {
        if (GetComponent<TrackedPoseDriver>().UseRelativeTransform)
        {
            return pose.GetTransformedBy(GetComponent<TrackedPoseDriver>().originPose);
        }
        else
        {
            return pose;
        }
    }
}
