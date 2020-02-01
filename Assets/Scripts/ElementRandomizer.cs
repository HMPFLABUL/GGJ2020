using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using System;

public class ElementRandomizer : MonoBehaviour
{
    [SerializeField]
    Vector2Variable posYRange;
    [SerializeField]
    Vector2Variable posXRange;
    [SerializeField]
    FloatVariable posStep;
    [SerializeField]
    FloatVariable rotStep;

    List<MovableElement> elements;

    private void Awake()
    {
        elements = new List<MovableElement>(GetComponentsInChildren<MovableElement>());
        
    }

    public void Randomize()
    {
        if(elements==null)
            elements = new List<MovableElement>(GetComponentsInChildren<MovableElement>());

        foreach (MovableElement e in elements)
        {
            if (e.movable)
            {
                //pos
                e.transform.parent.transform.position =
                    new Vector3(UnityEngine.Random.Range((int)(posXRange.Value.x * (1 / posStep)), (int)(posXRange.Value.y * (1 / posStep))) * posStep,
                    UnityEngine.Random.Range((int)(posYRange.Value.x * (1 / posStep)), (int)(posYRange.Value.y * (1 / posStep))) * posStep,
                    e.transform.parent.transform.position.z);
                //rot
                e.transform.Rotate(new Vector3(0f, 0f, 1f), UnityEngine.Random.Range((int)0, (int)(360 / rotStep)) * rotStep);
            }
        }
    }
}
