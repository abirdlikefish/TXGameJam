using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputManager
{
    public Vector2Int GetInput_move(int playerIndex);
    public bool GetInput_use(int playerIndex);
}
