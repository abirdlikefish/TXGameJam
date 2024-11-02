using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateMachine
{
    void ChangeStateToMainState();
    void ChangeStateToInputNameState();
    void ChangeStateToLevelSelectState();
    void ChangeStateToPlayState();
    int LevelIndex { get; set; }
    void Update();
}
