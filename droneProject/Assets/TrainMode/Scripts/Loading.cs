using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private AsyncOperation async;
    private int curProgressValue = 0;
    public GameObject loadloading;
    public Text Progress;
    public static int loadend = 0;
    // Start is called before the first frame update
    void Start()
    {
        loadend = 0;
    }
    IEnumerator LoadScene()
    {
        //Debug.Log(MainMenu.SceneNumber);
        if (MainMenu.SceneNumber == 0)
            async = SceneManager.LoadSceneAsync("MainMenu");
        else if (MainMenu.SceneNumber == 2)
            async = SceneManager.LoadSceneAsync("TrainMenu");
        else if (MainMenu.SceneNumber == 4)
        {
            MainMenu.SceneCount = 4;
            async = SceneManager.LoadSceneAsync("Eight");
        }
        else if (MainMenu.SceneNumber == 5)
        {
            MainMenu.SceneCount = 5;
            async = SceneManager.LoadSceneAsync("Square");
        }
        else if (MainMenu.SceneNumber == 6)
        {
            MainMenu.SceneCount = 6;
            async = SceneManager.LoadSceneAsync("WayStop");
        }
        else if (MainMenu.SceneNumber == 7)
        {
            MainMenu.SceneCount = 7;
            async = SceneManager.LoadSceneAsync("Interest");
        }
        else if (MainMenu.SceneNumber == 8)
        {
            MainMenu.SceneCount = 8;
            async = SceneManager.LoadSceneAsync("Train_FIve");
        }
        else if (MainMenu.SceneNumber == 9)
        {
            MainMenu.SceneCount = 9;
            async = SceneManager.LoadSceneAsync("Train_FrontBack");
        }
        else if (MainMenu.SceneNumber == 14)
        {
            MainMenu.SceneCount = 14;
            async = SceneManager.LoadSceneAsync("TestMenu");
        }
        else if (MainMenu.SceneNumber == 18)
        {
            MainMenu.SceneCount = 18;
            async = SceneManager.LoadSceneAsync("Misson");
        }
        else if (MainMenu.SceneNumber == 19)
        {
            MainMenu.SceneCount = 19;
            async = SceneManager.LoadSceneAsync("Test_Eight");
        }
        else if (MainMenu.SceneNumber == 20)
        {
            MainMenu.SceneCount = 20;
            async = SceneManager.LoadSceneAsync("Test_Five");
        }
        else if (MainMenu.SceneNumber == 21)
        {
            MainMenu.SceneCount = 21;
            async = SceneManager.LoadSceneAsync("Test_FourDir");
        }
        else if (MainMenu.SceneNumber == 22)
        {
            MainMenu.SceneCount = 22;
            async = SceneManager.LoadSceneAsync("Test_FrontBack");
        }
        else if (MainMenu.SceneNumber == 23)
        {
            MainMenu.SceneCount = 23;
            async = SceneManager.LoadSceneAsync("Test_Interest");
        }
        else if (MainMenu.SceneNumber == 24)
        {
            MainMenu.SceneCount = 24;
            async = SceneManager.LoadSceneAsync("Test_Square");
        }
        async.allowSceneActivation = false;
        yield return async;
    }
    // Update is called once per frame
    void Update()
    {
        if (MainMenu.loadingbool == true)
        {
            Time.timeScale = 1;
            StartCoroutine(LoadScene());
            MainMenu.loadingbool = false;
        }
        if (async == null)
            return;

        int progressValue = 100;
        if (curProgressValue < progressValue)
        {
            curProgressValue++;
            loadend = 1;
            loadloading.SetActive(false);
            loadloading.SetActive(true);
        }
        Progress.text = curProgressValue + "%";
        if (curProgressValue == 100)
        {
            async.allowSceneActivation = true;
            loadend = 2;
            loadloading.SetActive(false);
        }
    }
}
