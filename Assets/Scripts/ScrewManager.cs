using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrewManager : MonoBehaviour
{

    [SerializeField] private GameObject screw1;

    [SerializeField] private GameObject screw2;
    [SerializeField] private GameObject screw3;
    [SerializeField] private GameObject screw4;
    
    public UnityEvent m_MyEvent;


    Camera cam;



    void Start()
    {
        cam = Camera.main;
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();

        m_MyEvent.AddListener(StartEngineSplitting);

    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition; 
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.name == "EngineBack")
                {
                    return;
                }
                hit.transform.gameObject.SetActive(false);
            }
        }
        
        if (!screw1.activeSelf)
        {
            if (!screw2.activeSelf)
            {
                if (!screw3.activeSelf)
                {
                    if (!screw4.activeSelf)
                    {
                        m_MyEvent.Invoke();

                    }
                }
            }
        }
    }

    void StartEngineSplitting()
    {
        Debug.Log("true");
        
    }

    

    
}
