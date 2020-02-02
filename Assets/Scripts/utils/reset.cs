using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    private void OnMouseUp()
    {

        GameMenager.Instance.ResetGame();
        UIPosHandler.Instance.ResetUI();
    }
}
