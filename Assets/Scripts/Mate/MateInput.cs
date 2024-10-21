using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateInput : MonoBehaviour
{
    public enum MoveDir
    {
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }

    [SerializeField]
    SerializableDictionary<KeyCode, MoveDir> mate1_key_dir;
    [SerializeField]
    SerializableDictionary<KeyCode, MoveDir> mate2_key_dir;


    MateMover mate1 => MateManager.Instance.curMates[0].GetComponent<MateMover>();
    MateMover mate2 => MateManager.Instance.curMates[1].GetComponent<MateMover>();
    public static Dictionary<MoveDir, Vector3> dir_vec =
        new()
        {
            { MoveDir.LeftUp, new Vector3(0,0, -1) },
            { MoveDir.RightDown, new Vector3(0,0, 1) },
            { MoveDir.LeftDown, new Vector3(1,0, 0) },
            { MoveDir.RightUp, new Vector3(-1,0, 0) },
        };

    [HelpBox("道具按键")]
    public KeyCode mate1_dougu_key;
    public List<KeyCode> mate2_dougu_keys;

    private void Update()
    {
        HandleInput();
    }
    //日本語を　話　ましょう！
    //通る
    public static bool CanTooru(Vector3 nextCenter)
    {
        Vector2Int pos = Vector2Int.RoundToInt(CameraManager.Instance.GetCameraSpacePosition(nextCenter));
        int ret = EventManager.Instance.IsPassable(pos);
        //Debug.Log(nextCenter + " " + pos + " " + ret);
        return ret == 3;
    }
    // EventManager.Instance.IsPassive(new Vector2Int(Mathf.RoundToInt(nextCenter.x), Mathf.RoundToInt(nextCenter.z)));
    void HandleInput()
    {
        foreach (var key in mate1_key_dir.Keys)
        {
            if (Input.GetKey(key))
            {
                Vector3 ultiDelta = InputKeyToDir1(key);
                mate1.InputDir = ultiDelta;
                mate1.SetNextMove(ultiDelta);
                break;
            }
        }
        mate1.Move();
        if(Input.GetKeyDown(mate1_dougu_key))
        {
            mate1.GetComponent<Mate>().OnUseDougu();
        }

        foreach (var key in mate2_key_dir.Keys)
        {
            if (Input.GetKey(key))
            {
                Vector3 ultiDelta = InputKeyToDir2(key);
                mate2.InputDir = ultiDelta;
                mate2.SetNextMove(ultiDelta);
                break;
            }
        }
        mate2.Move();
        foreach (var key in mate2_dougu_keys)
        {
            if(Input.GetKeyDown(key))
            {
                mate2.GetComponent<Mate>().OnUseDougu();
                break;
            }
        }
        

    }
    Vector3 V2ToV3(Vector2Int v2)
    {
        return new(v2.x, 0, v2.y);
    }
    Vector3 InputKeyToDir1(KeyCode key)
    {
        return dir_vec[mate1_key_dir[key]].x * V2ToV3(CameraManager.Instance.GetOffetX())
                    + dir_vec[mate1_key_dir[key]].z * V2ToV3(CameraManager.Instance.GetOffetY());
    }
    Vector3 InputKeyToDir2(KeyCode key)
    {
        return dir_vec[mate2_key_dir[key]].x * V2ToV3(CameraManager.Instance.GetOffetX())
                    + dir_vec[mate2_key_dir[key]].z * V2ToV3(CameraManager.Instance.GetOffetY());
    }
}
