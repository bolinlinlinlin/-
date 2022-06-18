using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.grey;
    public Color32 m_DownColor = Color.white;

    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        // print("Enter");

        m_Image.color = m_HoverColor;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        // print("Exit");

        m_Image.color = new Color(80, 80, 80);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        // print("Down");

        m_Image.color = m_DownColor;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        // print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // print("Click");

        m_Image.color = m_HoverColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
