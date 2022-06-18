using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestChoise2 : MonoBehaviour
{
    public Button Back;
    public Button FourDir;
    public Button Eight;
    public Button FrontBack;
    public Button Five;
    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = Eight.GetComponent<Button>();
        btn1.onClick.AddListener(EightOnClick);
        Button btn2 = FrontBack.GetComponent<Button>();
        btn2.onClick.AddListener(FrontBackOnClick);
        Button btn3 = Back.GetComponent<Button>();
        btn3.onClick.AddListener(BackOnClick);
        Button btn4 = FourDir.GetComponent<Button>();
        btn4.onClick.AddListener(FourDirOnClick);
        Button btn5 = Five.GetComponent<Button>();
        btn5.onClick.AddListener(FiveOnClick);
    }

    private void BackOnClick()
    {
        SceneManager.LoadScene("TestMenu");
    }

    private void EightOnClick()
    {
        MainMenu.SceneNumber = 19;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_Eight");
    }

    private void FourDirOnClick()
    {
        MainMenu.SceneNumber = 21;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_FourDir");
    }
    private void FrontBackOnClick()
    {
        MainMenu.SceneNumber = 22;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_FrontBack");
    }
    private void FiveOnClick()
    {
        MainMenu.SceneNumber = 20;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_Five");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
