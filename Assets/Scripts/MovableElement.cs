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
        if (movable && GameMenager.Instance.playerInputActive)
            UIPosHandler.Instance.HandleUIRelation(this);

    }
    private void OnMouseDrag()
    {
        if (movable && GameMenager.Instance.playerInputActive)
            UIMovement.Instance.MoveObj();
    }
    private void OnMouseUp()
    {
        if (movable && GameMenager.Instance.playerInputActive)
            UIMovement.Instance.ResetMode();
    }
}


