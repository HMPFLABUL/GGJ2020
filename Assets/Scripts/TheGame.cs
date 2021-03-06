﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using DG.Tweening;
public class TheGame : MonoBehaviour
{
    [SerializeField]
    GameEvent Win;
    bool over = false;
    List<MovableElement> elements;
    [SerializeField]
    ElementRandomizer rr;
    private void Awake()
    {
        UIPosHandler.Instance.ResetUI();
        GameMenager.Instance.playerInputActive = true;
        if (rr != null)
            rr.Randomize();
        over = false;
        elements = new List<MovableElement>(GetComponentsInChildren<MovableElement>());
    }

    private void LateUpdate()
    {
        WinCheck();
        
    }

    private void WinCheck()
    {
        if (!over)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (new Vector3((int)elements[i].transform.localEulerAngles.x, (int)elements[i].transform.localEulerAngles.y, (int)elements[i].transform.localEulerAngles.z) != new Vector3(0f, 0f, 0f))
                    return;
            }
            for (int i = 1; i < elements.Count; i++)
            {
                if (elements[0].transform.parent.transform.position != elements[i].transform.parent.transform.position)
                    return;
            }
            Win.Raise();
            transform.DOShakeScale(.4f, .1f, 10, 1, false);
            GameMenager.Instance.playerInputActive = false;
            over = true;
        }
    }
}
