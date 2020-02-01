using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPosHandler : Singleton<UIPosHandler>
{
    bool isUIon = false;
    public Transform UI;


   


    private void Update()
    {
        if(!isUIon && UI.gameObject.activeInHierarchy)
        {
            UI.gameObject.SetActive(false);
        }
    }
    public void HandleUIRelation(MovableElement activeElem)
    {
        if (!isUIon)
        {
            isUIon = true;
        }
        if(!UI.gameObject.activeInHierarchy)
            UI.gameObject.SetActive(true);
        UI.position = activeElem.transform.position;
        UIMovement.Instance.activeElement = activeElem;
        UIMovement.Instance.CheckMode();
    }

    

    
}
