using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestChoise1 : MonoBehaviour
{
    public Button Square;
    public Button Back;
    public Button FourDir;
    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = Square.GetComponent<Button>();
        btn1.onClick.AddListener(SquareOnClick);
        Button btn2 = FourDir.GetComponent<Button>();
        btn2.onClick.AddListener(FourDirOnClick);
        Button btn3 = Back.GetComponent<Button>();
        btn3.onClick.AddListener(BackOnClick);
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

    private void FourDirOnClick()
    {
        MainMenu.SceneNumber = 21;
        MainMenu.loadingbool = true;
        //SceneManager.LoadScene("Test_FourDir");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
