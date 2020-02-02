using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScriptableObjectArchitecture;

public class GameMenager : Singleton<GameMenager>
{
    public bool playerInputActive = true;
    public enum Mode { Pos, Rot };
    public Mode mode;
    public int actualLevel = 0;
    [SerializeField]
    GameEvent nextLvl;
    private void Awake()
    {
        
        Screen.SetResolution(396, 704, false);
        SceneManager.LoadScene(++actualLevel, LoadSceneMode.Additive);
    }
    public void NextLvl()
    {
        Invoke("LoadNext", 1.5f);
    }

    private void LoadNext()
    {
        SceneManager.UnloadSceneAsync(actualLevel);
        SceneManager.LoadScene(++actualLevel, LoadSceneMode.Additive);
    }
    public void PrepareForNextLevel()
    {
        if (actualLevel != 1)
        {
            Invoke("RaiseNxtLvl", 3f);
        }
    }
    void RaiseNxtLvl()
    {
        nextLvl.Raise();
        UIPosHandler.Instance.ResetUI();
    }
    public void ResetGame()
    {
        SceneManager.UnloadSceneAsync(actualLevel);
        actualLevel = 0;
        SceneManager.LoadScene(++actualLevel, LoadSceneMode.Additive);
    }
}
