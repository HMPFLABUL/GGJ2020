using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoredUI : MonoBehaviour
{
    [SerializeField]
    RawImage Pos;
    [SerializeField]
    RawImage Rot;
    bool changed=false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !changed)
        {
            if (GameMenager.Instance.mode == GameMenager.Mode.Pos)
            {
                Pos.color = Color.red;
            }
            if (GameMenager.Instance.mode == GameMenager.Mode.Rot)
            {
                Rot.color = Color.red;
            }
            changed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Pos.color = Color.white;
            Rot.color = Color.white;
            changed = false;
        }
    }

}
