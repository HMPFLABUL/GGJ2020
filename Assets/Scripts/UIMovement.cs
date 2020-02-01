using ScriptableObjectArchitecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIMovement : Singleton<UIMovement>
{
    public MovableElement activeElement;
    public FloatVariable posStep;
    public FloatVariable rotStep;
    bool modeSet = false;
    [SerializeField]
    float mouseRotOffset = .35f;
    float actualAngle;

    private void OnMouseDown()
    {
        CheckMode();
    }

    public void CheckMode()
    {
        if (Vector2.Distance(activeElement.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < mouseRotOffset)
            GameMenager.Instance.mode = GameMenager.Mode.Pos;
        else
        {
            GameMenager.Instance.mode = GameMenager.Mode.Rot;
            actualAngle = CalculateAngle();

        }
    }

    private float CalculateAngle()
    {
        var p1 = activeElement.transform.position;
        var p2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2.Angle(activeElement.middlePoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        return Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 180 / Mathf.PI;
    }

    private void OnMouseDrag()
    {
        MoveObj();

    }

    public void MoveObj()
    {
        if (GameMenager.Instance.mode == GameMenager.Mode.Pos)
        {
            ChangePos();
        }
        else if (GameMenager.Instance.mode == GameMenager.Mode.Rot)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        var newAngle = CalculateAngle();
        
        
        


        while (actualAngle + rotStep < newAngle)
        {
            actualAngle += rotStep;
            activeElement.transform.Rotate(new Vector3(0f, 0f, 1f), rotStep);
        }
        while (actualAngle - rotStep > newAngle)
        {
            actualAngle -= rotStep;
            activeElement.transform.Rotate(new Vector3(0f, 0f, 1f), -rotStep);
        }

    }

    private void ChangePos()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > activeElement.transform.position.x + posStep)
        {
            activeElement.papa.transform.position = new Vector3(activeElement.papa.transform.position.x + posStep, activeElement.papa.transform.position.y, activeElement.papa.transform.position.z);
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < activeElement.transform.position.x - posStep)
        {
            activeElement.papa.transform.position = new Vector3(activeElement.papa.transform.position.x - posStep, activeElement.papa.transform.position.y, activeElement.papa.transform.position.z);
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > activeElement.transform.position.y + posStep)
        {
            activeElement.papa.transform.position = new Vector3(activeElement.papa.transform.position.x, activeElement.papa.transform.position.y + posStep, activeElement.papa.transform.position.z);
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < activeElement.transform.position.y - posStep)
        {
            activeElement.papa.transform.position = new Vector3(activeElement.papa.transform.position.x, activeElement.papa.transform.position.y - posStep, activeElement.papa.transform.position.z);
        }
        transform.position = activeElement.transform.position;
    }

    void SetMode(Vector3 midPos)
    {
        if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), midPos) < mouseRotOffset)
        {
            GameMenager.Instance.mode = GameMenager.Mode.Pos;
        }
        else
            GameMenager.Instance.mode = GameMenager.Mode.Rot;
    }
    public void ResetMode()
    {
        modeSet = false;
    }
}
