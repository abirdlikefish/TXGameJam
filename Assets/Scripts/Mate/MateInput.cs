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

    private void Update()
    {
        HandleInput();
    }
    //ÈÕ±¾ÕZ¤ò¡¡Ô’¡¡¤Þ¤·¤ç¤¦£¡
    //Í¨¤ë
    public static bool CanTooru(Vector3 nextCenter) => true;// EventManager.Instance.IsPassive(new Vector2Int(Mathf.RoundToInt(nextCenter.x), Mathf.RoundToInt(nextCenter.z)));
    void HandleInput()
    {
        foreach (var key in mate1_key_dir.Keys)
        {
            if (Input.GetKey(key))
            {
                Vector3 ultiDelta = dir_vec[mate1_key_dir[key]].x * V2ToV3( CameraManager.Instance.GetOffetX())
                    + dir_vec[mate1_key_dir[key]].z * V2ToV3(CameraManager.Instance.GetOffetY());
                mate1.SetNextMove(ultiDelta);
                break;
            }
        }
        mate1.Move();
        foreach (var key in mate2_key_dir.Keys)
        {
            if (Input.GetKey(key))
            {
                Vector3 ultiDelta = dir_vec[mate2_key_dir[key]].x * V2ToV3(CameraManager.Instance.GetOffetX())
                    + dir_vec[mate2_key_dir[key]].z * V2ToV3(CameraManager.Instance.GetOffetY());
                mate2.SetNextMove(ultiDelta);
                break;
            }
        }
        mate2.Move();
    }
    Vector3 V2ToV3(Vector2Int v2)
    {
        return new(v2.x, 0, v2.y);
    }
}
