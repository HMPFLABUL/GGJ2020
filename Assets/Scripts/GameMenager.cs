using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : Singleton<GameMenager>
{
    bool playerInputActive = true;
    public enum Mode { Pos, Rot };
    public Mode mode;

    private void Awake()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
