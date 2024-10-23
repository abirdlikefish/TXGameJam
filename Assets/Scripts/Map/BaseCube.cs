using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCube : MonoBehaviour
{
    public int groupID = -1;
    private Vector3Int position;
    public Vector3Int Position{ get => position; set {position = value; transform.position = value;}}
    public int Height{get => Mathf.RoundToInt(CameraManager.Instance.GetDepth(Position));}
    private int color;
    public int Color
    {
        get => color;
        // set => color = value;
        set
        {
            if(color != 0)
            {
                EventManager.Instance.ColorReaction(color + value , Position);
                color = 0;
            }
            else
            {
                color = value;
            }
        }
    }

    public Vector2Int GetCameraSpacePosition()
    {
        return CameraManager.Instance.GetCameraSpacePosition(Position);
    }
    
}
