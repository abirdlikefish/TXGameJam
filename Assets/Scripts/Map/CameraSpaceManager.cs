using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpaceManager : ICameraSpaceManager
{
    public static ICameraSpaceManager Init(MapManager mapManager)
    {
        if(instance == null)
        {
            instance = new CameraSpaceManager();
            instance.nodeMap = new Node[100,100];
            instance.mapManager = mapManager;
            return instance;
        }
        else
        {
            Debug.LogWarning("CameraSpaceManager has been initialized");
            return null;
        }
    }
    MapManager mapManager;
    // static Vector3Int[] cameraDirection = new Vector3Int[2]{new Vector3Int(1, 1, 1), new Vector3Int(-1, 1, 1)};
    // static int cameraDirectionIndex;
    static CameraSpaceManager instance;
    enum NodeType
    {
        top,
        side
    }
    struct HalfNode
    {
        public NodeType type;
        public BaseCube cube;
        public bool IsEmpty{get{return cube == null;} }
        // public int Height{get{return cube == null ? -10000000 : (int)Vector3.Dot(cube.Position , cameraDirection[cameraDirectionIndex]); }}
        public int Height{get{ if(cube == null) Debug.Log("error height"); return cube.Height; }}
        public void SetHalfNode(NodeType type, BaseCube cube)
        {
            this.type = type;
            this.cube = cube;
        }
        public void clear()
        {
            cube = null;
        }
    }
    struct Node
    {
        public HalfNode leftNode;
        public HalfNode rightNode;
        public bool isPassable{get{return leftNode.type == NodeType.top && rightNode.type == NodeType.top;}}
    }

    private Node[,] nodeMap;
    public void ClearNodeMap()
    {
        Debug.Log("ClearNodeMap");
        for(int i = 0 ; i < nodeMap.GetLength(0); i++)
        {
            for(int j = 0 ; j < nodeMap.GetLength(1); j++)
            {
                nodeMap[i,j].leftNode.clear();
                nodeMap[i,j].rightNode.clear();
            }
        }
    }
    public void DrawGrid(BaseCube cube)
    {
        // Vector2Int[,] offset = new Vector2Int[2,2]{{Vector2Int.right, Vector2Int.up}, {Vector2Int.up, Vector2Int.left}};
        // Vector3Int mid = cube.Position;
        // mid -= mid.y * cameraDirection[cameraDirectionIndex];
        // Vector2Int pos = new Vector2Int(mid.x, mid.z);
        // Debug.Log("DrawGrid " + pos);

        DrawGrid_L(cube.GetCameraSpacePosition(), cube, NodeType.top);
        DrawGrid_R(cube.GetCameraSpacePosition(), cube, NodeType.top);
        // DrawGrid_L(pos, cube, NodeType.top);
        // DrawGrid_R(pos, cube, NodeType.top);

        // DrawGrid_L(pos + offset[cameraDirectionIndex,0] + offset[cameraDirectionIndex , 1], cube, NodeType.side);
        // DrawGrid_R(pos + offset[cameraDirectionIndex,0] + offset[cameraDirectionIndex , 1], cube, NodeType.side);
        DrawGrid_L(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY(), cube, NodeType.side);
        DrawGrid_R(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY(), cube, NodeType.side);

        DrawGrid_L(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetY(), cube, NodeType.side);
        DrawGrid_R(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetX(), cube, NodeType.side);
        // Debug.Log("show grid");
        // Debug.Log("nodeMap size = " + nodeMap.Count);

    }
    void DrawGrid_L(Vector2Int pos, BaseCube cube , NodeType type)
    {
        HalfNode node = new HalfNode();
        node.SetHalfNode(type, cube);
        if(nodeMap[pos.x , pos.y].leftNode.IsEmpty == false && nodeMap[pos.x , pos.y].leftNode.Height > node.Height)
        {
            
        }
        else
        {
            nodeMap[pos.x , pos.y].leftNode = node;
        }
    }
    void DrawGrid_R(Vector2Int pos, BaseCube cube , NodeType type)
    {
        HalfNode node = new HalfNode();
        node.SetHalfNode(type, cube);
        if(nodeMap[pos.x , pos.y].rightNode.IsEmpty == false && nodeMap[pos.x , pos.y].rightNode.Height > node.Height)
        {
            
        }
        else
        {
            nodeMap[pos.x , pos.y].rightNode = node;
        }
    }

    public bool IsPassable(Vector2Int position)
    {
        return nodeMap[position.x, position.y].isPassable;
    }
    // public void ChangeCameraDirection()
    // {
    //     cameraDirectionIndex = 1^cameraDirectionIndex;
    //     Debug.Log("current camera direction = " + cameraDirectionIndex);
    // }

}
