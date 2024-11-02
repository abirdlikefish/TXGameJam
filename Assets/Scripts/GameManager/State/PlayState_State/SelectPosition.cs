using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPosition : BasePlayState
{
    public override void Enter()
    {
        Debug.Log("SelectPosition Enter");
        base.Enter();

        for(int i = 0 ; i < 2 ; i ++)
        {
            playList[i].SetActive(true);
            SetPosition(i , Vector3Int.zero);
            isSelectedList[i] = false;
            ChangeColor(i);
        }
        // ShowCube(SaveManager.Instance.GetLevelNum());
        // player0.SetActive(true);
        // player1.SetActive(true);
        // isSelected_0 = false;
        // isSelected_1 = false;
        // player0.transform.position = CameraManager.Instance.GetOffsetX_vector3() * 3;
        // player1.transform.position = -CameraManager.Instance.GetOffsetX_vector3() * 3;
        // ChangeColor(player0);
        // ChangeColor(player1);
    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("SelectLevelState Exit");
        for(int i = 0 ; i < 2 ; i ++)
        {
            playList[i].SetActive(false);
        }
        // player0.SetActive(false);
        // player1.SetActive(false);
        // isSelected_0 = false;
        // isSelected_1 = false;
    }

    public override void Update()
    {
        
        base.Update();
        for(int i = 0 ; i < 2 ; i ++)
        {
            if(Time.time - lastMoveTimeList[i] > moveInterval && InputManager.Instance.GetInput_move(i) != Vector2Int.zero)
            {
                lastMoveTimeList[i] = Time.time;
                SetPosition(i , positionList[i] + InputManager.Instance.GetInput_move_vector3(i));
                playList[i].transform.position = Vector3Int.RoundToInt(playList[i].transform.position) + InputManager.Instance.GetInput_move_vector3(i);
                ChangeColor(i);
                isSelectedList[i] = false;
            }

            if(InputManager.Instance.GetInput_use(i) && Judge(positionList[i]))
            {
                isSelectedList[i] = true;
                meshRendererList[i].material = green;
            }
        }

        // if(Time.time - lastMoveTime_0 > moveInterval && InputManager.Instance.GetInput_move(0) != Vector2Int.zero)
        // {
        //     lastMoveTime_0 = Time.time;

        //     player0.transform.position = Vector3Int.RoundToInt(player0.transform.position) + InputManager.Instance.GetInput_move_vector3(0);
        //     ChangeColor(player0);
        //     isSelected_0 = false;
        // }
        // if(Time.time - lastMoveTime_1 > moveInterval && InputManager.Instance.GetInput_move(1) != Vector2Int.zero)
        // {
        //     lastMoveTime_1 = Time.time;
        //     player1.transform.position = Vector3Int.RoundToInt(player0.transform.position) + InputManager.Instance.GetInput_move_vector3(1);
        //     ChangeColor(player0);
        //     isSelected_1 = false;
        // }
        // if(InputManager.Instance.GetInput_use(0) && Judge(Vector3Int.RoundToInt(player0.transform.position)))
        // {
        //     isSelected_0 = true;
        //     player0.GetComponent<MeshRenderer>().material = green;

        // }
        // if(InputManager.Instance.GetInput_use(1) && Judge(Vector3Int.RoundToInt(player1.transform.position)))
        // {
        //     isSelected_1 = true;
        //     player1.GetComponent<MeshRenderer>().material = green;
        // }
        bool flag = true;
        for(int i = 0 ; i < 2 ; i++)
        {
            flag = flag && isSelectedList[i];
        }
        if(flag)
        {
            for(int i = 0 ; i < 2 ; i++)
            {
                SetPosition(i , Vector3Int.RoundToInt(positionList[i]));
            }
            // MateManager.Instance.SetMatePos(0 , player0.transform.position);
            // MateManager.Instance.SetMatePos(1 , player1.transform.position);
            playState.ChangePlayState(playState.playing);
        }

        
    }

    List<GameObject> playList;
    List<Vector3Int> positionList;
    List<MeshRenderer> meshRendererList;
    List<bool> isSelectedList;
    List<float> lastMoveTimeList;
    float moveInterval = 0.3f;
    void SetPosition(int playerIndex , Vector3Int position)
    {
        playList[playerIndex].transform.position = position + Vector3Int.up;
        positionList[playerIndex] = position;
    }


    // GameObject player0;
    // GameObject player1;

    // Vector3Int position0;
    // Vector3Int Position0
    // {
    //     get => position0;
    //     set
    //     {
    //         position0 = value;
    //         player0.transform.position = value + Vector3Int.up;
    //     }
    // }

    // List<BaseCube> cubeList ;
    // float lastMoveTime_0;
    // float lastMoveTime_1;

    // bool isSelected_0;
    // bool isSelected_1;

    Material red_tp;
    Material green_tp;
    Material green;

    // private void ShowCube(int levelCnt)
    // {
    //     int offsetX = 0;
    //     // int factor = -1;
    //     Vector3Int pos ;
    //     for(int i = 1 ; i <= levelCnt ; i++)
    //     {
    //         int factor = (i & 1) == 1 ? -1 : 1;
    //         int factorY = ((i / 2) & 1) == 1 ? -1 : 1;
            
    //         offsetX ++;
    //         pos = offsetX * CameraManager.Instance.GetOffsetX_vector3() * factor;
    //         MapManager.Instance.AddCube(pos, 10);

    //         offsetX ++;
    //         pos = offsetX * CameraManager.Instance.GetOffsetX_vector3() * factor;
    //         MapManager.Instance.AddCube(pos, 10);

    //         pos += factorY * CameraManager.Instance.GetOffsetY_vector3();
    //         MapManager.Instance.AddCube(pos, 10 + levelCnt);
    //     }
    // }

    private void ChangeColor(int playerIndex)
    {
        // Vector3Int pos = Vector3Int.RoundToInt(player.transform.position);
        // int levelIndex = GetLevelIndex(pos);

        if(Judge(positionList[playerIndex]))
        {
            meshRendererList[playerIndex].material = green_tp;
            // player.GetComponent<MeshRenderer>().material = green_tp;
        }
        else
        {
            meshRendererList[playerIndex].material = red_tp;
            // player.GetComponent<MeshRenderer>().material = red_tp;

        }

        // if(levelIndex == 0)
        // {
        //     player.GetComponent<MeshRenderer>().material = red_tp;
        // }
        // else if(levelIndex > 0)
        // {
        //     player.GetComponent<MeshRenderer>().material = green_tp;
        // }
    }

    private bool Judge(Vector3Int position)
    {
        return MapManager.Instance.IsPassable(position) == 3;
        // if(MapManager.Instance.IsPassable(position) == 3)
        
        // BaseCube midCube = MapManager.Instance.GetCube(position) ;
        // if(midCube == null)
        // {
        //     return -1;
        // }
        // else
        // {
        //     return midCube.Color - 10;
        // }
    }

    public override void Init(PlayState playState)
    {
        playList = new List<GameObject>();
        positionList = new List<Vector3Int>();
        meshRendererList = new List<MeshRenderer>();
        isSelectedList = new List<bool>();
        base.Init(playState);
        for(int i = 0 ; i < 2 ; i ++)
        {
            playList.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube0")));
            positionList.Add(Vector3Int.zero);
            meshRendererList.Add(playList[i].GetComponent<MeshRenderer>());
            isSelectedList.Add(false);
            playList[i].SetActive(false);
        }
        // player0 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube0"));
        // player1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube1"));
        // player0.SetActive(false);
        // player1.SetActive(false);
        red_tp = Resources.Load<Material>("Material/selectCube_r_tp");
        green_tp = Resources.Load<Material>("Material/selectCube_g_tp");
        green = Resources.Load<Material>("Material/selectCube_g");

    }

}
