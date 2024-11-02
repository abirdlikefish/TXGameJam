using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputManager
{
    public Vector2Int GetInput_move(int playerIndex);
    public Vector3Int GetInput_move_vector3(int playerIndex);
    public bool GetInput_use(int playerIndex);
    // public bool GetInput_IsSelected(int playerIndex);
}
