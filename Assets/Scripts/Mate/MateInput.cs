using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateInput : Singleton<MateInput>
{
    public enum MoveDir
    {
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }
    public List<SerializableDictionary<KeyCode, MoveDir>> mate_key_dirs;

    public static Dictionary<MoveDir, Vector3> dir_vec =
        new()
        {
            { MoveDir.LeftUp, new Vector3(0,0, -1) },
            { MoveDir.RightDown, new Vector3(0,0, 1) },
            { MoveDir.LeftDown, new Vector3(1,0, 0) },
            { MoveDir.RightUp, new Vector3(-1,0, 0) },
        };

    public List<KeyCode> Get_mate_dougu_keys(int id)
    {
        return id == 0 ? mate1_dougu_keys : mate2_dougu_keys;
    }

    [HelpBox("道具按键")]
    public List<KeyCode> mate1_dougu_keys;
    public List<KeyCode> mate2_dougu_keys;


    static bool IsPassableLeft(int x)
    {
        return x == 2 || x == 3;
    }
    static bool IsPassableRight(int x)
    {
        return x == 1 || x == 3;
    }
    //日本語を　話し　ましょう！
    //通る
    public static bool CanTooruY0(Vector3 thisCenter,Vector3 nextCenter)
    {
        Vector2Int pos1 = MyWorldToScreen(thisCenter);
        int ret1 = EventManager.Instance.IsPassable(pos1);
        Vector2Int pos2 = MyWorldToScreen(nextCenter);
        int ret2 = EventManager.Instance.IsPassable(pos2);
        Vector3 delta = nextCenter - thisCenter;
        delta = new Vector3(Mathf.RoundToInt(delta.x), 0, Mathf.RoundToInt(delta.z));
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
        //Debug.Log($"delta : {delta} {thisCenter}{ret1} {nextCenter}{ret2} ret = {ret}");
        return ret;
    }
    public static bool CanTooruY0(Vector3 nextCenter)
    {
        Vector2Int pos = MyWorldToScreen(nextCenter);
        int ret = EventManager.Instance.IsPassable(pos);
        bool can1 = DeliConfig.tooruTest ? ret != 0 : ret == 3;

        //Debug.Log(nextCenter + " " + pos + " " + ret);
        return can1;
    }
    static Vector3 V2ToV3(Vector2Int v2)
    {
        return new(v2.x, 0, v2.y);
    }
    public Vector3 InputKeyToDir(int id,KeyCode key)
    {
        return CameraDirInWorld(dir_vec[mate_key_dirs[id][key]]);
    }
    public static Vector3 CameraDirInWorld(Vector3 dir)
    {
        return dir.x * V2ToV3(CameraManager.Instance.GetOffetX()) +
            dir.z * V2ToV3(CameraManager.Instance.GetOffetY());
    }
    public static Vector2Int MyWorldToScreen(Vector3 pos)
    {
        return Vector2Int.RoundToInt(CameraManager.Instance.GetCameraSpacePosition(pos));
    }
}
