using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateInput
// public class MateInput : Singleton<MateInput,IMateInput>, IMateInput
{
    public List<KeyCode> Get_mate_dougu_keys(int id)
    {
        return id == 0 ? mate1_dougu_keys : mate2_dougu_keys;
    }
    public Vector3 InputKeyToDir(int id, KeyCode key)
    {
        return CameraDirInWorld(dir_vec[mate_key_dirs[id][key]]);
    }
    public enum MoveDir
    {
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }
    
    public static List<SerializableDictionary<KeyCode, MoveDir>> mate_key_dirs = new()
    {
        new() { { KeyCode.W, MoveDir.LeftUp }, { KeyCode.S, MoveDir.RightDown }, { KeyCode.A, MoveDir.LeftDown }, { KeyCode.D, MoveDir.RightUp } },
        new() { { KeyCode.UpArrow, MoveDir.LeftUp }, { KeyCode.DownArrow, MoveDir.RightDown }, { KeyCode.LeftArrow, MoveDir.LeftDown }, { KeyCode.RightArrow, MoveDir.RightUp } }
    };
    public static Dictionary<MoveDir, Vector3Int> dir_vec =
        new()
        {
            { MoveDir.LeftUp, -CameraManager.Instance.GetOffsetY_vector3() },
            { MoveDir.RightDown, CameraManager.Instance.GetOffsetY_vector3() },
            { MoveDir.LeftDown, CameraManager.Instance.GetOffsetX_vector3() },
            { MoveDir.RightUp, -CameraManager.Instance.GetOffsetX_vector3() },
        };
        // {
        //     { MoveDir.LeftUp, new Vector3(0,0, -1) },
        //     { MoveDir.RightDown, new Vector3(0,0, 1) },
        //     { MoveDir.LeftDown, new Vector3(1,0, 0) },
        //     { MoveDir.RightUp, new Vector3(-1,0, 0) },
        // };
    List<KeyCode> mate1_dougu_keys = new() {KeyCode.Space};
    List<KeyCode> mate2_dougu_keys = new() { KeyCode.Return, KeyCode.KeypadEnter };
    static bool IsPassableLeft(int x)
    {
        return x == 2 || x == 3;
    }
    static bool IsPassableRight(int x)
    {
        return x == 1 || x == 3;
    }
    static Vector3 V2ToV3(Vector2Int v2)
    {
        return new(v2.x, 0, v2.y);
    }
    public static bool CanTooru(Vector3 center)
    {
        Vector2Int pos = MyWorldToScreen(center);
        int ret = MapManager.Instance.IsPassable(pos);
        return ret != 0;
    }
    public static bool CanTooru(Vector3 thisCenter,Vector3 nextCenter)
    {
        Vector2Int pos1 = MyWorldToScreen(thisCenter);
        int ret1 = MapManager.Instance.IsPassable(pos1);
        Vector2Int pos2 = MyWorldToScreen(nextCenter);
        int ret2 = MapManager.Instance.IsPassable(pos2);
        Vector3 delta = nextCenter - thisCenter;
        delta = new Vector3(Mathf.RoundToInt(delta.x), 0, Mathf.RoundToInt(delta.z));
        delta = CameraDirInWorld(delta);
        bool ret;
        if (delta == new Vector3(1, 0, 0) || delta == new Vector3(0, 0, -1))
        {
            ret = IsPassableLeft(ret1) && IsPassableRight(ret2);
        }
        else if (delta == new Vector3(-1, 0, 0) || delta == new Vector3(0, 0, 1))
        {
            ret = IsPassableRight(ret1) && IsPassableLeft(ret2);
        }
        else//delta == Vector3.zero
            ret = true;
        // Debug.Log($"delta : {delta} {thisCenter}{ret1} {nextCenter}{ret2} ret = {ret}");
        return ret;
    }
    public static Vector3 CameraDirInWorld(Vector3 dir)
    {
        return dir.x * V2ToV3(CameraManager.Instance.GetOffsetX()) +
            dir.z * V2ToV3(CameraManager.Instance.GetOffsetY());
    }
    public static Vector2Int MyWorldToScreen(Vector3 pos)
    {
        return Vector2Int.RoundToInt(CameraManager.Instance.GetCameraSpacePosition(pos));
    }
}
