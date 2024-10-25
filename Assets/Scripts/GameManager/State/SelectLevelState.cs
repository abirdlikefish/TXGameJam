using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelState : BaseState
{
    public override void Enter()
    {
        Debug.Log("SelectLevelState Enter");
        base.Enter();
        EventManager.Instance.ExitStateEvent += Exit;
        Show(SaveManager.Instance.GetLevelNum());
        mate0.SetActive(true);
        mate1.SetActive(true);
        
        Position0 = offset_0;
        Position1 = offset_1;
        meshRenderer0.material.color = redColor;
        meshRenderer1.material.color = redColor;
        // EventManager.Instance.ShowInputNameUI();
    }
    
    GameObject mate0;
    GameObject mate1;
    Vector2Int position0;
    Vector2Int position1;
    Vector2Int Position0 { get => position0; set { position0 = value; mate0.transform.position = new Vector3(value.x, 1, value.y); } }
    Vector2Int Position1 { get => position1; set { position1 = value; mate1.transform.position = new Vector3(value.x, 1, value.y); } }
    MeshRenderer meshRenderer0;
    MeshRenderer meshRenderer1;
    Color redColor;
    Color greenColor;
    Color selectedGreenColor;

    private List<Material> materialList;



    GameObject cube_normal;
    GameObject cube_w;
    GameObject cube_a;
    GameObject cube_s;
    GameObject cube_d;
    GameObject cube_up;
    GameObject cube_down;
    GameObject cube_left;
    GameObject cube_right;
    Vector2Int offset_0;
    Vector2Int offset_1;

#region position define

    Vector2Int position_normal;
    Vector2Int Position_Normal
    {
        get => position_normal;
        set
        {
            position_normal = value;
            cube_normal.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }

    Vector2Int position_w;
    Vector2Int Position_W
    {
        get => position_w;
        set
        {
            position_w = value;
            cube_w.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
    Vector2Int position_a;
    Vector2Int Position_A
    {
        get => position_a;
        set
        {
            position_a = value;
            cube_a.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
    Vector2Int position_s;
    Vector2Int Position_S
    {
        get => position_s;
        set
        {
            position_s = value;
            cube_s.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
    Vector2Int position_d;
    Vector2Int Position_D
    {
        get => position_d;
        set
        {
            position_d = value;
            cube_d.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
    Vector2Int position_up;
    Vector2Int Position_Up
    {
        get => position_up;
        set
        {
            position_up = value;
            cube_up.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
    Vector2Int position_down;
    Vector2Int Position_Down
    {
        get => position_down;
        set
        {
            position_down = value;
            cube_down.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
    Vector2Int position_left;
    Vector2Int Position_Left
    {
        get => position_left;
        set
        {
            position_left = value;
            cube_left.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
    Vector2Int position_right;
    Vector2Int Position_Right
    {
        get => position_right;
        set
        {
            position_right = value;
            cube_right.transform.position = new Vector3(value.x, 0 ,value.y);
        }
    }
#endregion

    GameObject parentCube;
    List<GameObject> cubeList_normal;
    public void Init()
    {
        
        materialList = new List<Material>();
        materialList.Add(Resources.Load<Material>("Prefabs/LevelSelectCube/Material/Materials/theblue"));
        for(int i = 1 ; i <= 9 ; i ++)
        {
            materialList.Add(Resources.Load<Material>("Prefabs/LevelSelectCube/Material/Materials/theblue " + i.ToString()));
        }


        parentCube = new GameObject("ParentCube");
        // cube_normal = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal"));
        cube_w = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_W") , parentCube.transform);
        cube_a = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_A") , parentCube.transform);
        cube_s = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_S") , parentCube.transform);
        cube_d = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_D") , parentCube.transform);
        cube_up = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Up") , parentCube.transform);
        cube_down = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Down"), parentCube.transform);
        cube_left = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Left"), parentCube.transform);
        cube_right = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Right"), parentCube.transform);
        offset_0 = Vector2Int.zero + CameraManager.Instance.GetOffsetX() * 0 - CameraManager.Instance.GetOffsetY() * 2;
        offset_1 = Vector2Int.zero + CameraManager.Instance.GetOffsetX() * 0 + CameraManager.Instance.GetOffsetY() * 2;
        Position_W = offset_0 - CameraManager.Instance.GetOffsetY();
        Position_A = offset_0 + CameraManager.Instance.GetOffsetX();
        Position_S = offset_0 + CameraManager.Instance.GetOffsetY();
        Position_D = offset_0 - CameraManager.Instance.GetOffsetX();
        Position_Up = offset_1 - CameraManager.Instance.GetOffsetY();
        Position_Down = offset_1 + CameraManager.Instance.GetOffsetY();
        Position_Left = offset_1 + CameraManager.Instance.GetOffsetX();
        Position_Right = offset_1 - CameraManager.Instance.GetOffsetX();

        cubeList_normal = new List<GameObject>();
        Vector2Int beginPosition = (offset_0 + offset_1)/2;
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(offset_0) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(offset_1) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition) , Quaternion.identity ));

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*2) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*2 + CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[5].GetComponent<MeshRenderer>().material = materialList[1];

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*2) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*2 - CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[8].GetComponent<MeshRenderer>().material = materialList[2];

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*3) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*4) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*4 - CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[11].GetComponent<MeshRenderer>().material = materialList[3];

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*3) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*4) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*4 + CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[14].GetComponent<MeshRenderer>().material = materialList[4];

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*5) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*6) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*6 + CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[17].GetComponent<MeshRenderer>().material = materialList[5];

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*5) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*6) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*6 - CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[20].GetComponent<MeshRenderer>().material = materialList[6];

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*7) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*8) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*8 - CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[23].GetComponent<MeshRenderer>().material = materialList[7];

        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*7) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*8) , Quaternion.identity ));
        cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition - CameraManager.Instance.GetOffsetX()*8 + CameraManager.Instance.GetOffsetY()),Quaternion.identity ));
        cubeList_normal[26].GetComponent<MeshRenderer>().material = materialList[8];

        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*9) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*10) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*10 + CameraManager.Instance.GetOffsetY()),Quaternion.identity ));

        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*11) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*12) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*12 - CameraManager.Instance.GetOffsetY()),Quaternion.identity ));

        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*13) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*14) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*14 + CameraManager.Instance.GetOffsetY()),Quaternion.identity ));

        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*15) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*16) , Quaternion.identity ));
        // cubeList_normal.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LevelSelectCube/Cube_Normal") , GetV3(beginPosition + CameraManager.Instance.GetOffsetX()*16 - CameraManager.Instance.GetOffsetY()),Quaternion.identity ));

        Hide();


        mate0 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube0"));
        mate1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube1"));
        mate0.SetActive(false);
        mate1.SetActive(false);
        Position0 = offset_0;
        Position1 = offset_1;
        meshRenderer0 = mate0.GetComponent<MeshRenderer>();
        meshRenderer1 = mate1.GetComponent<MeshRenderer>();
        meshRenderer0.material.color = redColor;
        meshRenderer1.material.color = redColor;

        redColor = new Color(1, 0, 0, 0.5f);
        greenColor = new Color(0, 1, 0, 0.5f);
        selectedGreenColor = new Color(0, 1, 0, 1);
    }
    
    private Vector3Int GetV3(Vector2Int v2)
    {
        return new Vector3Int(v2.x, 0, v2.y);
    }

    private void Show(int levelNum)
    {
        levelNum --;
        parentCube.SetActive(true);
        for(int i = 0 ; i <= levelNum ; i++)
        {
            cubeList_normal[i*3].SetActive(true);
            cubeList_normal[i*3+1].SetActive(true);
            cubeList_normal[i*3+2].SetActive(true);
        }
    }

    private void Hide()
    {
        parentCube.SetActive(false);
        foreach(var cube in cubeList_normal)
        {
            cube.SetActive(false);
        }
    }







    public override void Update()
    {
        base.Update();
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     EventManager.Instance.ExitState(0);
        // }
        // else if(Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     EventManager.Instance.ExitState(1);
        // }


        
        if(Input.GetKeyDown(KeyCode.A))
        {
            Position0 += CameraManager.Instance.GetOffsetX();
            if(IsPassable(Position0) != 0)
            {
                meshRenderer0.material.color = greenColor;
            }
            else
            {
                meshRenderer0.material.color = redColor;
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            Position0 -= CameraManager.Instance.GetOffsetX();
            if(IsPassable(Position0) != 0)
            {
                meshRenderer0.material.color = greenColor;
            }
            else
            {
                meshRenderer0.material.color = redColor;
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Position0 -= CameraManager.Instance.GetOffsetY();
            if(IsPassable(Position0) != 0)
            {
                meshRenderer0.material.color = greenColor;
            }
            else
            {
                meshRenderer0.material.color = redColor;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Position0 += CameraManager.Instance.GetOffsetY();
            if(IsPassable(Position0) != 0)
            {
                meshRenderer0.material.color = greenColor;
            }
            else
            {
                meshRenderer0.material.color = redColor;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Position1 += CameraManager.Instance.GetOffsetX();
            if(IsPassable(Position1) != 0)
            {
                meshRenderer1.material.color = greenColor;
            }
            else
            {
                meshRenderer1.material.color = redColor;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Position1 -= CameraManager.Instance.GetOffsetX();
            if(IsPassable(Position1) != 0)
            {
                meshRenderer1.material.color = greenColor;
            }
            else
            {
                meshRenderer1.material.color = redColor;
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Position1 -= CameraManager.Instance.GetOffsetY();
            if(IsPassable(Position1) != 0)
            {
                meshRenderer1.material.color = greenColor;
            }
            else
            {
                meshRenderer1.material.color = redColor;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Position1 += CameraManager.Instance.GetOffsetY();
            if(IsPassable(Position1) != 0)
            {
                meshRenderer1.material.color = greenColor;
            }
            else
            {
                meshRenderer1.material.color = redColor;
            }
        }

        if(Position0 == Position1)
        {
            int num = IsPassable(Position0);
            if(num != 0)
            {
                meshRenderer0.material.color = selectedGreenColor;
                meshRenderer1.material.color = selectedGreenColor;
                EventManager.Instance.ExitState(num);
            }
        }


    }

    private int IsPassable(Vector2Int position)
    {
        // Vector2Int position = new Vector2Int(midPosition.x, midPosition.z);
        if(position.x % 2 != 0)
            return 0;
        if(position.x > 0)
        {
            position.x /= 2;
            if(position.x % 2 == 1 )
            {
                if(position.y != 1)
                {
                    return 0;
                }
            }
            else
            {
                if(position.y != -1)
                {
                    return 0;
                }
            }
            return position.x * 2 - 1;
        }
        else
        {
            position.x = -position.x / 2;
            if(position.x % 2 == 1 )
            {
                if(position.y != -1)
                {
                    return 0;
                }
            }
            else
            {
                if(position.y != 1)
                {
                    return 0;
                }
            }
            return position.x * 2;
        }
    }

    public override void Exit(int num)
    {
        mate0.SetActive(false);
        mate1.SetActive(false);
        base.Exit(num);
        EventManager.Instance.ExitStateEvent -= Exit;
        if(num == 0)
        {
            gameStateMachine.ChangeState(gameStateMachine.mainState);
        }
        else
        {
            EventManager.Instance.EnterLevel(num);

        }

        // else if(num == 1)
        // {
        //     EventManager.Instance.EnterLevel(1);
        // }
        // else
        // {
        //     Debug.LogWarning("SelectLevelState Exit Error");
        // }
    }
}