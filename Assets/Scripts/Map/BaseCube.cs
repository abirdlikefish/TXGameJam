using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCube : MonoBehaviour
{
    private Vector3Int position;
    public Vector3Int Position{ get => position; set {position = value; transform.position = value;}}
    public int Height{get => Mathf.RoundToInt(CameraManager.Instance.GetDepth(Position));}

    public Vector2Int GetCameraSpacePosition()
    {
        Vector3Int mid = Vector3Int.RoundToInt(CameraManager.Instance.GetCameraSpacePosition(Position));
        return new Vector2Int(mid.x, mid.z);
    }
}
