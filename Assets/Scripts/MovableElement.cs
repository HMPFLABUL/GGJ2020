using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MovableElement : MonoBehaviour
{
    [HideInInspector]
    public Transform papa;
    
    public bool movable = true;


    private void Awake()
    {
        papa = transform.parent;
    }
    private void OnMouseDown()
    {
        if (movable)
            UIPosHandler.Instance.HandleUIRelation(this);

    }
    private void OnMouseDrag()
    {
        if (movable)
            UIMovement.Instance.MoveObj();
    }
    private void OnMouseUp()
    {
        if (movable)
            UIMovement.Instance.ResetMode();
    }
}


