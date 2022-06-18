using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TrainMenu : MonoBehaviour
{
    public GameObject loadloadingTrain;
    public Button Back2MainMenu;
    public Button WayStop;
    public Button Square;
    public Button Eight;
    public Button Interest;
    public Button Five;
    public Button FrontBack;
    public bool isLock = false;

    void Start()
    {
        //loadloadingTrain.SetActive(false);
        isLock = false;

        Back2MainMenu.onClick.AddListener(delegate { OnClick(Back2MainMenu); });
        WayStop.onClick.AddListener(delegate { OnClick(WayStop); });
        Square.onClick.AddListener(delegate { OnClick(Square); });
        Eight.onClick.AddListener(delegate { OnClick(Eight); });
        Interest.onClick.AddListener(delegate { OnClick(Interest); });
        Five.onClick.AddListener(delegate { OnClick(Five); });
        FrontBack.onClick.AddListener(delegate { OnClick(FrontBack); });
    }

    void OnClick(Button sender)
    {
        if (isLock)
            return;

        if (sender == Back2MainMenu)
        {
            MainMenu.SceneNumber = 0;
        }
        if (sender == WayStop)
        {
            MainMenu.SceneNumber = 6;
        }
        if (sender == Square)
        {
            MainMenu.SceneNumber = 5;
        }
        if (sender == Eight)
        {
            MainMenu.SceneNumber = 4;
        }
        if (sender == Interest)
        {
            MainMenu.SceneNumber = 7;
        }
        if (sender == Five)
        {
            MainMenu.SceneNumber = 8;
        }
        if (sender == FrontBack)
        {
            MainMenu.SceneNumber = 9;
        }
        MainMenu.loadingbool = true;
        //loadloadingTrain.SetActive(true);

        isLock = true;
    }
}
