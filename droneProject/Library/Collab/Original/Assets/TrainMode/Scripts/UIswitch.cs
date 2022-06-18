using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIswitch : MonoBehaviour
{
    public GameObject rRule;
    public GameObject tTimeOut;
    public GameObject gGetOn;
    public GameObject loadloading;
    public GameObject eEnd;
    public static bool shwitch = false;
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
    private int count = 0;
    private int rulecount = 1;
    public static bool endbool = false;
    // Start is called before the first frame update
    void Start()
    {
        loadloading.SetActive(false);
    }

    void OpenTimeOut()
    {
        count = 1;
    }

    void OpenRule()
    {
        count = 0;
    }

    void OpenGetOn()
    {
        if (rulecount == 1)
        {
            Destroy(next);
            Back2Menu.GetComponent<CanvasGroup>().alpha = 1;
            rulecount++;
        }
        count = 1;
        shwitch = true;
    }

    void Restartgame()
    {
        count = 2;
        if (MainMenu.SceneCount == 4)
            MainMenu.SceneNumber = 4;
        else if (MainMenu.SceneCount == 5)
            MainMenu.SceneNumber = 5;
        else if (MainMenu.SceneCount == 6)
            MainMenu.SceneNumber = 6;
        else if (MainMenu.SceneCount == 7)
            MainMenu.SceneNumber = 7;
        gGetOn.GetComponent<CanvasGroup>().alpha = 0;
        rRule.SetActive(false);
        tTimeOut.SetActive(false);
        loadloading.SetActive(true);
        MainMenu.loadingbool = true;
        endbool = false;
    }
    void Back2TrainMenu()
    {
        count = 2;
        MainMenu.SceneNumber = 2;
        gGetOn.GetComponent<CanvasGroup>().alpha = 0;
        rRule.SetActive(false);
        tTimeOut.SetActive(false);
        loadloading.SetActive(true);
        MainMenu.loadingbool = true;
        endbool = false;
    }
    void Back2MainMenu()
    {
        count = 2;
        MainMenu.SceneNumber = 0;
        gGetOn.GetComponent<CanvasGroup>().alpha = 0;
        rRule.SetActive(false);
        tTimeOut.SetActive(false);
        loadloading.SetActive(true);
        MainMenu.loadingbool = true;
        endbool = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (endbool == true)
        {
            Debug.Log(count);

            Button H = endAgain.GetComponent<Button>();
            H.onClick.AddListener(Restartgame);

            Button I = endBackTrainMenu.GetComponent<Button>();
            I.onClick.AddListener(Back2TrainMenu);

            Button J = endBackMainMenu.GetComponent<Button>();
            J.onClick.AddListener(Back2MainMenu);

            gGetOn.GetComponent<CanvasGroup>().alpha = 0;
            rRule.SetActive(false);
            tTimeOut.SetActive(false);
            loadloading.SetActive(false);
            eEnd.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shwitch = false;
        }

        if (shwitch == false)
        {
            Time.timeScale = 0;
            gGetOn.GetComponent<CanvasGroup>().alpha = 0;
            if (count == 0)
            {
                rRule.SetActive(true);
                tTimeOut.SetActive(false);
                if (rulecount == 1)
                {
                    Button A = Next.GetComponent<Button>();
                    A.onClick.AddListener(OpenGetOn);
                }
                else if (rulecount == 2)
                {
                    Button B = Back2Menu.GetComponent<Button>();
                    B.onClick.AddListener(OpenTimeOut);
                }
            }
            else if (count == 1)
            {
                rRule.SetActive(false);
                tTimeOut.SetActive(true);

                Button C = Rule.GetComponent<Button>();
                C.onClick.AddListener(OpenRule);

                Button D = Continue.GetComponent<Button>();
                D.onClick.AddListener(OpenGetOn);

                Button E = Again.GetComponent<Button>();
                E.onClick.AddListener(Restartgame);

                Button F = BackTrainMenu.GetComponent<Button>();
                F.onClick.AddListener(Back2TrainMenu);

                Button G = BackMainMenu.GetComponent<Button>();
                G.onClick.AddListener(Back2MainMenu);
            }
        }
        else
        {
            Time.timeScale = 1;
            gGetOn.GetComponent<CanvasGroup>().alpha = 1;
            rRule.SetActive(false);
            tTimeOut.SetActive(false);
        }
        
    }
    GameObject Find(string name)
    {
        return GameObject.Find(name);
    }
}
