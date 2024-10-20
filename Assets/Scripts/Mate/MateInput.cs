using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateInput : Singleton<MateInput>,IInit
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


    public Mate mate1;
    public Mate mate2;
    public Dictionary<MoveDir, Vector3> dir_vec;

    public void Initialize()
    {
        dir_vec = new()
        {
            { MoveDir.LeftUp, new Vector3(0,0, -1) },
            { MoveDir.RightDown, new Vector3(0,0, 1) },
            { MoveDir.LeftDown, new Vector3(1,0, 0) },
            { MoveDir.RightUp, new Vector3(-1,0, 0) },
        };
    }
    private void Update()
    {
        HandleInput();
    }
    //ÈÕ±¾ÕZ¤ò¡¡Ô’¡¡¤Þ¤·¤ç¤¦£¡
    public bool canTooru = true;
    public bool CanTooru(Vector3 nextCenter) => canTooru;//Í¨¤ë
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
        mate1.Move1();
        foreach (var key in mate2_key_dir.Keys)
        {
            if (Input.GetKey(key))
            {
            }
        }
    }
    Vector3 V2ToV3(Vector2Int v2)
    {
        return new(v2.x, 0, v2.y);
    }
}
