using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pointer : MonoBehaviour
{
    public float m_DefaultLength;
    public GameObject m_Dot;
    public VRInputModule m_InputModule;
    public Material m_Material;

    private LineRenderer m_LineRenderer = null;

    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLine();
    }
    private void UpdateLine()
    {
        PointerEventData data = null;
        // Use default or distance
        GameObject m_EventSystem = GameObject.Find("EventSystem");
        if (m_EventSystem != null)
        {
            m_InputModule = m_EventSystem.GetComponent<VRInputModule>();
            if (m_InputModule == null)
                return;
        }
        else
            return;
        data = m_InputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 99999 ? m_DefaultLength : data.pointerCurrentRaycast.distance;
        if (data.pointerCurrentRaycast.gameObject != null)
        {
            // Debug.Log("data.pointerCurrentRaycast.distance: " + data.pointerCurrentRaycast.distance);
            // Debug.Log(data.pointerCurrentRaycast.gameObject);
        }

        // Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        // Default
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        //Or based on hit
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        string scenePath = SceneManager.GetActiveScene().path;
        if (((scenePath.StartsWith("Assets/TrainMode/Scenes/") || scenePath.StartsWith("Assets/TestMode/Scenes/")) && UIswitch.showOtherUI == true) || scenePath.StartsWith("Assets/TeachMode/Scenes/"))
        {
            m_Dot.SetActive(false);
            // m_Material.color = Color.clear;
            m_LineRenderer.startColor = Color.clear;
            m_LineRenderer.endColor = Color.clear;
        }
        else
        {
            m_Dot.SetActive(true);
            // m_Material.color = Color.white;
            m_LineRenderer.startColor = Color.white;
            m_LineRenderer.endColor = Color.white;
        }
        // Set position of the dot
        m_Dot.transform.position = endPosition;

        // Set linerenderer
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        /*
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);
        return hit;
        */

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, m_DefaultLength);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.name == "Dot")
                continue;
            else
                return hits[i];
        }
        return new RaycastHit();
    }
}
