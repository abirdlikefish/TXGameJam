using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPosition : BasePlayState
{
    public override void Enter()
    {
        Debug.Log("SelectPosition Enter");
        base.Enter();

        // ShowCube(SaveManager.Instance.GetLevelNum());
        red_tp = Resources.Load<Material>("Material/selectCube_r");
        green_tp = Resources.Load<Material>("Material/selectCube_g");
        player0.SetActive(true);
        player1.SetActive(true);
        isSelected_0 = false;
        isSelected_1 = false;
        player0.transform.position = CameraManager.Instance.GetOffsetX_vector3() * 3;
        player1.transform.position = -CameraManager.Instance.GetOffsetX_vector3() * 3;
        ChangeColor(player0);
        ChangeColor(player1);
    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("SelectLevelState Exit");
        player0.SetActive(false);
        player1.SetActive(false);
        isSelected_0 = false;
        isSelected_1 = false;
    }

    public override void Update()
    {
        
        base.Update();
        if(Time.time - lastMoveTime_0 > moveInterval && InputManager.Instance.GetInput_move(0) != Vector2Int.zero)
        {
            lastMoveTime_0 = Time.time;
            player0.transform.position = Vector3Int.RoundToInt(player0.transform.position) + InputManager.Instance.GetInput_move_vector3(0);
            // Vector3Int nextPos = Vector3Int.RoundToInt(player0.transform.position) + InputManager.Instance.GetInput_move_vector3(0);
            // if(GetLevelIndex(nextPos) != -1)
            // {
            //     player0.transform.position = nextPos;
            // }
            ChangeColor(player0);
            isSelected_0 = false;
        }
        if(Time.time - lastMoveTime_1 > moveInterval && InputManager.Instance.GetInput_move(1) != Vector2Int.zero)
        {
            lastMoveTime_1 = Time.time;
            player1.transform.position = Vector3Int.RoundToInt(player0.transform.position) + InputManager.Instance.GetInput_move_vector3(1);
            // Vector3Int nextPos = Vector3Int.RoundToInt(player1.transform.position) + InputManager.Instance.GetInput_move_vector3(1);
            // if(GetLevelIndex(nextPos) != -1)
            // {
            //     player1.transform.position = nextPos;
            // }
            ChangeColor(player0);
            isSelected_1 = false;
        }
        if(InputManager.Instance.GetInput_use(0) && GetLevelIndex(Vector3Int.RoundToInt(player0.transform.position)) > 0)
        {
            isSelected_0 = GetLevelIndex(Vector3Int.RoundToInt(player0.transform.position));
        }
        if(InputManager.Instance.GetInput_use(1) && GetLevelIndex(Vector3Int.RoundToInt(player1.transform.position)) > 0)
        {
            isSelected_1 = GetLevelIndex(Vector3Int.RoundToInt(player1.transform.position));
        }
        if(isSelected_0 > 0 && isSelected_1 == isSelected_0)
        {
            Debug.Log("select level " + isSelected_0);
        }

        
    }

    GameObject player0;
    GameObject player1;
    // List<BaseCube> cubeList ;
    float lastMoveTime_0;
    float lastMoveTime_1;
    float moveInterval = 0.3f;

    bool isSelected_0;
    bool isSelected_1;

    Material red_tp;
    Material green_tp;
    // Material green;

    private void ShowCube(int levelCnt)
    {
        int offsetX = 0;
        // int factor = -1;
        Vector3Int pos ;
        for(int i = 1 ; i <= levelCnt ; i++)
        {
            int factor = (i & 1) == 1 ? -1 : 1;
            int factorY = ((i / 2) & 1) == 1 ? -1 : 1;
            
            offsetX ++;
            pos = offsetX * CameraManager.Instance.GetOffsetX_vector3() * factor;
            MapManager.Instance.AddCube(pos, 10);

            offsetX ++;
            pos = offsetX * CameraManager.Instance.GetOffsetX_vector3() * factor;
            MapManager.Instance.AddCube(pos, 10);

            pos += factorY * CameraManager.Instance.GetOffsetY_vector3();
            MapManager.Instance.AddCube(pos, 10 + levelCnt);
        }
    }

    private void ChangeColor(GameObject player)
    {
        Vector3Int pos = Vector3Int.RoundToInt(player.transform.position);
        int levelIndex = GetLevelIndex(pos);
        if(levelIndex == 0)
        {
            player.GetComponent<MeshRenderer>().material = red_tp;
        }
        else if(levelIndex > 0)
        {
            player.GetComponent<MeshRenderer>().material = green_tp;
        }
    }

    private bool Judge(Vector3Int position)
    {
        MapManager.Instance.IsPassable(position);
        
        BaseCube midCube = MapManager.Instance.GetCube(position) ;
        if(midCube == null)
        {
            return -1;
        }
        else
        {
            return midCube.Color - 10;
        }
    }

    public override void Init(GameStateMachine gameStateMachine)
    {
        base.Init(gameStateMachine);
        player0 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube0"));
        player1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube1"));
        player0.SetActive(false);
        player1.SetActive(false);

    }

}
