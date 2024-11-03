using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelSelectState : BaseState
{
    public override void Enter()
    {
        Debug.Log("SelectLevelState Enter");
        base.Enter();

        ShowCube(SaveManager.Instance.GetLevelNum() - 1);

        for(int i = 0 ; i < 2 ; i ++)
        {
            playList[i].SetActive(true);
            SetPosition(i , Vector3Int.zero);
            isSelectedList[i] = 0;
            ChangeColor(i);
        }
        SetPosition(0 , -CameraManager.Instance.GetOffsetY_vector3() * 3);
        SetPosition(1 , CameraManager.Instance.GetOffsetY_vector3() * 3);
        // player0.SetActive(true);
        // player1.SetActive(true);
        // isSelected_0 = 0;
        // isSelected_1 = 0;
        // player0.transform.position = -CameraManager.Instance.GetOffsetY_vector3() * 2;
        // player1.transform.position = CameraManager.Instance.GetOffsetY_vector3() * 2;
        // ChangeColor(player0);
        // ChangeColor(player1);
    }
    public override void Exit()
    {
        Debug.Log("SelectLevelState Exit");
        base.Exit();
        for(int i = 0 ; i < 2 ; i ++)
        {
            playList[i].SetActive(false);
        }
        // player0.SetActive(false);
        // player1.SetActive(false);
        // isSelected_0 = 0;
        // isSelected_1 = 0;
        MapManager.Instance.RemoveCube_all();
    }

    public override void Update()
    {
        
        base.Update();
        
        for(int i = 0 ; i < 2 ; i ++)
        {
            // if(Time.time - lastMoveTimeList[i] > moveInterval && InputManager.Instance.GetInput_move(i) != Vector2Int.zero)
            if(Time.time - lastMoveTimeList[i] > moveInterval )
            if( InputManager.Instance.GetInput_move(i) != Vector2Int.zero)
            {
                lastMoveTimeList[i] = Time.time;
                Vector3Int nextPos = positionList[i] + InputManager.Instance.GetInput_move_vector3(i);
                if(GetLevelIndex(nextPos) != -1)
                    SetPosition(i , nextPos);
                ChangeColor(i);
                isSelectedList[i] = 0;
            }

            if(InputManager.Instance.GetInput_use(i) && GetLevelIndex(positionList[i]) > 0)
            {
                isSelectedList[i] = GetLevelIndex(positionList[i]);
                meshRendererList[i].material = green;
            }
            
            if(isSelectedList[0] > 0 && isSelectedList[0] == isSelectedList[1])
            {
                // Debug.Log("select level " + isSelected_0);
                GameStateMachine.Instance.LevelIndex = isSelectedList[0];
                GameStateMachine.Instance.ChangeStateToPlayState();
            }
        // if(InputManager.Instance.GetInput_use(1) && GetLevelIndex(Vector3Int.RoundToInt(player1.transform.position)) > 0)
        // {
        //     isSelected_1 = GetLevelIndex(Vector3Int.RoundToInt(player1.transform.position));
        //     player1.GetComponent<MeshRenderer>().material = green;
        // }
        // if(isSelected_0 > 0 && isSelected_1 == isSelected_0)
        // {
        //     // Debug.Log("select level " + isSelected_0);
        //     GameStateMachine.Instance.LevelIndex = isSelected_0;
        //     GameStateMachine.Instance.ChangeStateToPlayState();
        // }
        }


        // if(Time.time - lastMoveTime_0 > moveInterval && InputManager.Instance.GetInput_move(0) != Vector2Int.zero)
        // {
        //     lastMoveTime_0 = Time.time;
        //     Vector3Int nextPos = Vector3Int.RoundToInt(player0.transform.position) + InputManager.Instance.GetInput_move_vector3(0);
        //     if(GetLevelIndex(nextPos) != -1)
        //     {
        //         player0.transform.position = nextPos;
        //     }
        //     ChangeColor(player0);
        //     isSelected_0 = 0;
        // }
        // if(Time.time - lastMoveTime_1 > moveInterval && InputManager.Instance.GetInput_move(1) != Vector2Int.zero)
        // {
        //     lastMoveTime_1 = Time.time;
        //     Vector3Int nextPos = Vector3Int.RoundToInt(player1.transform.position) + InputManager.Instance.GetInput_move_vector3(1);
        //     if(GetLevelIndex(nextPos) != -1)
        //     {
        //         player1.transform.position = nextPos;
        //     }
        //     ChangeColor(player0);
        //     isSelected_1 = 0;
        // }
        // if(InputManager.Instance.GetInput_use(0) && GetLevelIndex(Vector3Int.RoundToInt(player0.transform.position)) > 0)
        // {
        //     isSelected_0 = GetLevelIndex(Vector3Int.RoundToInt(player0.transform.position));
        //     player0.GetComponent<MeshRenderer>().material = green;
        // }
        // if(InputManager.Instance.GetInput_use(1) && GetLevelIndex(Vector3Int.RoundToInt(player1.transform.position)) > 0)
        // {
        //     isSelected_1 = GetLevelIndex(Vector3Int.RoundToInt(player1.transform.position));
        //     player1.GetComponent<MeshRenderer>().material = green;
        // }
        // if(isSelected_0 > 0 && isSelected_1 == isSelected_0)
        // {
        //     // Debug.Log("select level " + isSelected_0);
        //     GameStateMachine.Instance.LevelIndex = isSelected_0;
        //     GameStateMachine.Instance.ChangeStateToPlayState();
        // }

        
    }

    List<GameObject> playList;
    List<Vector3Int> positionList;
    List<MeshRenderer> meshRendererList;
    List<int> isSelectedList;
    List<float> lastMoveTimeList;

    float moveInterval = 0.2f;
    void SetPosition(int playerIndex , Vector3Int position)
    {
        playList[playerIndex].transform.position = position + Vector3Int.up;
        positionList[playerIndex] = position;
    }

    // GameObject player0;
    // GameObject player1;
    // // List<BaseCube> cubeList ;
    // float lastMoveTime_0;
    // float lastMoveTime_1;
    // float moveInterval = 0.3f;

    // int isSelected_0;
    // int isSelected_1;

    Material red_tp;
    Material green_tp;
    Material green;
    // Material green;

    private void ShowCube(int levelCnt)
    {
        for(int i = -3 ; i <= 3 ; i++)
        {
            MapManager.Instance.AddCube(i * CameraManager.Instance.GetOffsetY_vector3(), 10);
        }
        MapManager.Instance.AddCube(CameraManager.Instance.GetOffsetY_vector3() * 2 + CameraManager.Instance.GetOffsetX_vector3(), 10);
        MapManager.Instance.AddCube(CameraManager.Instance.GetOffsetY_vector3() * 2 - CameraManager.Instance.GetOffsetX_vector3(), 10);
        MapManager.Instance.AddCube(CameraManager.Instance.GetOffsetY_vector3() * -2 + CameraManager.Instance.GetOffsetX_vector3(), 10);
        MapManager.Instance.AddCube(CameraManager.Instance.GetOffsetY_vector3() * -2 - CameraManager.Instance.GetOffsetX_vector3(), 10);

        int offsetX = 0;
        Vector3Int pos ;
        for(int i = 1 ; i <= levelCnt ; i++)
        {
            int factor = (i & 1) == 1 ? -1 : 1;
            int factorY = ((i / 2) & 1) == 1 ? -1 : 1;

            if(i != 1)
            {
                Vector3Int midPos = (offsetX) * CameraManager.Instance.GetOffsetX_vector3() * factor;
                MapManager.Instance.AddCube(midPos, 10);
                
                midPos = (offsetX - 1) * CameraManager.Instance.GetOffsetX_vector3() * factor;
                MapManager.Instance.AddCube(midPos, 10);

                midPos = (offsetX - 2) * CameraManager.Instance.GetOffsetX_vector3() * factor;
                MapManager.Instance.AddCube(midPos, 10);
            }
            
            offsetX ++;
            pos = offsetX * CameraManager.Instance.GetOffsetX_vector3() * factor;
            MapManager.Instance.AddCube(pos, 10);
            
            offsetX ++;
            pos = offsetX * CameraManager.Instance.GetOffsetX_vector3() * factor;
            MapManager.Instance.AddCube(pos, 10);

            offsetX ++;
            pos = offsetX * CameraManager.Instance.GetOffsetX_vector3() * factor;
            MapManager.Instance.AddCube(pos, 10);

            pos += factorY * CameraManager.Instance.GetOffsetY_vector3();
            MapManager.Instance.AddCube(pos, 10 + i);
        }
    }

    // private void ChangeColor(GameObject player)
    private void ChangeColor(int playerIndex)
    {
        // Vector3Int pos = Vector3Int.RoundToInt(player.transform.position);
        // int levelIndex = GetLevelIndex(pos);
        int levelIndex = GetLevelIndex(positionList[playerIndex]);
        if(levelIndex == 0)
        {
            meshRendererList[playerIndex].material = red_tp;
            // player.GetComponent<MeshRenderer>().material = red_tp;
        }
        else if(levelIndex > 0)
        {
            meshRendererList[playerIndex].material = green_tp;
            // player.GetComponent<MeshRenderer>().material = green_tp;
        }
    }

    private int GetLevelIndex(Vector3Int position)
    {
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
        // base.Init(gameStateMachine);
        // player0 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube0"));
        // player1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube1"));
        // player0.SetActive(false);
        // player1.SetActive(false);

        playList = new List<GameObject>();
        positionList = new List<Vector3Int>();
        meshRendererList = new List<MeshRenderer>();
        isSelectedList = new List<int>();
        lastMoveTimeList = new List<float>();
        for(int i = 0 ; i < 2 ; i ++)
        {
            playList.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube0")));
            positionList.Add(Vector3Int.zero);
            meshRendererList.Add(playList[i].GetComponent<MeshRenderer>());
            isSelectedList.Add(0);
            playList[i].SetActive(false);
            lastMoveTimeList.Add(0);
        }



        red_tp = Resources.Load<Material>("Material/selectCube_r_tp");
        green_tp = Resources.Load<Material>("Material/selectCube_g_tp");
        green = Resources.Load<Material>("Material/selectCube_g");

    }
}
