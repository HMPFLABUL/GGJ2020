using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : Singleton<GameMenager>
{
    bool playerInputActive = true;
    public enum Mode { Pos, Rot };
    public Mode mode;
}
