using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestChoise3 : MonoBehaviour
{
    public Button Square;
    public Button Eight;
    public Button SquareLight;
    public Button SquareAim;
    public Button Interest;
    public Button Mission;
    public Button Back;

    public static bool isSquareLight;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = Square.GetComponent<Button>();
        btn1.onClick.AddListener(SquareOnClick);
        Button btn2 = Eight.GetComponent<Button>();
        btn2.onClick.AddListener(EightOnClick);
        Button btn3 = SquareLight.GetComponent<Button>();
        btn3.onClick.AddListener(SquareLightOnClick);
        Button btn4 = SquareAim.GetComponent<Button>();
        btn4.onClick.AddListener(SquareAimOnClick);
        Button btn5 = Interest.GetComponent<Button>();
        btn5.onClick.AddListener(InterestOnClick);
        Button btn6 = Mission.GetComponent<Button>();
        btn6.onClick.AddListener(MissionOnClick);
        Button btn7 = Back.GetComponent<Button>();
        btn7.onClick.AddListener(BackOnClick);
    }

    private void BackOnClick()
    {
        SceneManager.LoadScene("TestMenu");
    }

    private void SquareOnClick()
    {
        MainMenu.SceneNumber = 24;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_Square");
    }
    private void EightOnClick()
    {
        MainMenu.SceneNumber = 19;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_Eight");
    }
    private void SquareLightOnClick()
    {
        MainMenu.SceneNumber = 24;
        MainMenu.loadingbool = true;
        isSquareLight = true;
        //SceneManager.LoadScene("Test_Square");
    }
    private void SquareAimOnClick()
    {
        MainMenu.SceneNumber = 24;
        MainMenu.loadingbool = true;
        isSquareLight = false;
        //SceneManager.LoadScene("Test_Square");
    }
    private void InterestOnClick()
    {
        MainMenu.SceneNumber = 23;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_Interest");
    }
    private void MissionOnClick()
    {
        MainMenu.SceneNumber = 18;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Misson");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
