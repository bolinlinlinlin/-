using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    // Start is called before the first frame update

    public Button CNButtom;
    public Button USButtom;
    public Button JPButtom;
    public Button BackButtom;

    public RawImage CNsel;
    public Text CNtext;
    public RawImage USsel;
    public Text UStext;
    public RawImage JPsel;
    public Text JPtext;

    void Start()
    {
        Button btn1 = CNButtom.GetComponent<Button>();
        btn1.onClick.AddListener(CNOnClick);

        Button btn2 = USButtom.GetComponent<Button>();
        btn2.onClick.AddListener(USOnClick);

        Button btn3 = JPButtom.GetComponent<Button>();
        btn3.onClick.AddListener(JPOnClick);

        Button btn4 = BackButtom.GetComponent<Button>();
        btn4.onClick.AddListener(BackOnClick);

        switch (GameObjectScript.country)
        {
            case (int)GameObjectScript.Country.CN:
                CNOnClick();
                break;
            case (int)GameObjectScript.Country.US:
                USOnClick();
                break;
            case (int)GameObjectScript.Country.JP:
                JPOnClick();
                break;
        }
    }

    private void CNOnClick()
    {
        GameObjectScript.country = (int)GameObjectScript.Country.CN;

        CNButtom.gameObject.SetActive(false);
        JPButtom.gameObject.SetActive(true);
        USButtom.gameObject.SetActive(true);
        CNsel.gameObject.SetActive(true);
        CNtext.gameObject.SetActive(true);
        USsel.gameObject.SetActive(false);
        UStext.gameObject.SetActive(false);
        JPsel.gameObject.SetActive(false);
        JPtext.gameObject.SetActive(false);
    }    
    private void USOnClick()
    {
        GameObjectScript.country = (int)GameObjectScript.Country.US;

        CNButtom.gameObject.SetActive(true);
        JPButtom.gameObject.SetActive(true);
        USButtom.gameObject.SetActive(false);
        CNsel.gameObject.SetActive(false);
        CNtext.gameObject.SetActive(false);
        USsel.gameObject.SetActive(true);
        UStext.gameObject.SetActive(true);
        JPsel.gameObject.SetActive(false);
        JPtext.gameObject.SetActive(false);
    }
    private void JPOnClick()
    {
        GameObjectScript.country = (int)GameObjectScript.Country.JP;

        CNButtom.gameObject.SetActive(true);
        JPButtom.gameObject.SetActive(false);
        USButtom.gameObject.SetActive(true);
        CNsel.gameObject.SetActive(false);
        CNtext.gameObject.SetActive(false);
        USsel.gameObject.SetActive(false);
        UStext.gameObject.SetActive(false);
        JPsel.gameObject.SetActive(true);
        JPtext.gameObject.SetActive(true);
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
