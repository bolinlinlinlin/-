using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestMode : MonoBehaviour
{
    public Button Basic2Kg;
    public Button Basic;
    public Button Back;
    public Button High;
    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = Basic2Kg.GetComponent<Button>();
        btn1.onClick.AddListener(Basic2KgOnClick);
        Button btn2 = Basic.GetComponent<Button>();
        btn2.onClick.AddListener(BasicOnClick);
        Button btn3 = Back.GetComponent<Button>();
        btn3.onClick.AddListener(BackOnClick);
        Button btn4 = High.GetComponent<Button>();
        btn4.onClick.AddListener(HighOnClick);
    }
    private void Basic2KgOnClick()
    {
        SceneManager.LoadScene("TestChoise1");
    }
    private void BasicOnClick()
    {
        SceneManager.LoadScene("TestChoise2");
    }
    private void HighOnClick()
    {
        SceneManager.LoadScene("TestChoise3");
    }
    private void BackOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
