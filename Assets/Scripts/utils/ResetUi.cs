using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUi : MonoBehaviour
{
    private void OnMouseDown()
    {
        UIPosHandler.Instance.ResetUI();
    }
}
