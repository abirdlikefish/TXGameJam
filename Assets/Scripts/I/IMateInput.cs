using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMateInput
{
    public List<KeyCode> Get_mate_dougu_keys(int id);
    public Vector3 InputKeyToDir(int id, KeyCode key);
}
