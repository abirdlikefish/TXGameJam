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

    public bool canTooru;
    void HandleInput()
    {
        mate1.SetMove(Vector3.zero, false);
        foreach (var key in mate1_key_dir.Keys)
        {
            if (Input.GetKey(key))
            {
                //CameraManager.Instance.GetOffetX();
                mate1.SetMove(dir_vec[mate1_key_dir[key]],canTooru);
                
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

}
