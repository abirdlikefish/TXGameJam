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
            instance.nodeMap = new Node[200,200];
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
        public int isPassable{
            get{
                int ans = 0;
                if(leftNode.IsEmpty == false && leftNode.type == NodeType.top)
                {
                    ans += 2;
                }
                if(rightNode.IsEmpty == false && rightNode.type == NodeType.top)
                {
                    ans += 1;
                }
                return ans;
                // return (leftNode.type == NodeType.top ? 2 : 0) + (rightNode.type == NodeType.top ? 1 : 0);
                }
            }
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
        DrawGrid_L(cube.GetCameraSpacePosition(), cube, NodeType.top);
        DrawGrid_R(cube.GetCameraSpacePosition(), cube, NodeType.top);
        
        DrawGrid_L(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY(), cube, NodeType.side);
        DrawGrid_R(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY(), cube, NodeType.side);

        DrawGrid_L(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetY(), cube, NodeType.side);
        DrawGrid_R(cube.GetCameraSpacePosition() + CameraManager.Instance.GetOffetX(), cube, NodeType.side);

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

    public int IsPassable(Vector2Int position)
    {
        return nodeMap[position.x, position.y].isPassable;
    }
    
    public BaseCube GetCube_L(Vector2Int position)
    {
        return nodeMap[position.x, position.y].leftNode.cube;
    }
    public BaseCube GetCube_R(Vector2Int position)
    {
        return nodeMap[position.x, position.y].rightNode.cube;
    }
    public List<BaseCube> GetCubes(Vector2Int position)
    {
        List<BaseCube> cubes = new List<BaseCube>();
        cubes.Add(GetCube_L(position));
        cubes.Add(GetCube_R(position));
        cubes.Add(GetCube_L(position + CameraManager.Instance.GetOffetY()));
        cubes.Add(GetCube_R(position + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY()));
        cubes.Add(GetCube_L(position + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY()));
        cubes.Add(GetCube_R(position + CameraManager.Instance.GetOffetX()));
        return cubes;
    }

    public bool IsCubeExposed(Vector2Int position)
    {
        BaseCube isExposed = GetCube_L(position);
        if(isExposed == null)
            return false;
        if(isExposed != GetCube_R(position))
            return false;
        if(isExposed != GetCube_L(position + CameraManager.Instance.GetOffetY()))
            return false;
        if(isExposed != GetCube_R(position + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY()))
            return false;
        if(isExposed != GetCube_L(position + CameraManager.Instance.GetOffetX() + CameraManager.Instance.GetOffetY()))
            return false;
        if(isExposed != GetCube_R(position + CameraManager.Instance.GetOffetX()))
            return false;
        return true;

    }


}
