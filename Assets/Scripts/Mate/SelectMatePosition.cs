using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMatePosition : MonoBehaviour
{

    public static SelectMatePosition Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SelectMatePosition").AddComponent<SelectMatePosition>();
                // instance = new SelectMatePosition();
                instance.mate0 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube0"));
                instance.mate1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SelectMateCube1"));
                instance.mate0.SetActive(false);
                instance.mate1.SetActive(false);
                instance.gameObject.SetActive(false);
                instance.Position0 = Vector2Int.right;
                instance.Position1 = Vector2Int.left;
                instance.meshRenderer0 = instance.mate0.GetComponent<MeshRenderer>();
                instance.meshRenderer1 = instance.mate1.GetComponent<MeshRenderer>();

                instance.redColor = new Color(1, 0, 0, 0.5f);
                instance.greenColor = new Color(0, 1, 0, 0.5f);
                // instance.mate0.transform.position = new Vector3(instance.position0.x, 0, instance.position0.y);
                // instance.mate1.transform.position = new Vector3(instance.position1.x, 0, instance.position1.y);
            }
            return instance;
        }
    }
    private static SelectMatePosition instance;
    int levelIndex;
    GameObject mate0;
    GameObject mate1;
    Vector2Int position0;
    Vector2Int position1;
    Vector2Int Position0 { get => position0; set { position0 = value; mate0.transform.position = new Vector3(value.x, 0, value.y); } }
    Vector2Int Position1 { get => position1; set { position1 = value; mate1.transform.position = new Vector3(value.x, 0, value.y); } }
    MeshRenderer meshRenderer0;
    MeshRenderer meshRenderer1;
    // Color redColor0;
    // Color redColor1;
    // Color greenColor0;
    // Color greenColor1;
    Color redColor;
    Color greenColor;

    bool isReady0;
    bool isReady1;

    private void Update()
    {
        if(isReady0 == false)
        {    
            if(Input.GetKeyDown(KeyCode.A))
            {
                Position0 += CameraManager.Instance.GetOffetX();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position0.x, 0, Position0.y))) == 3)
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
                Position0 -= CameraManager.Instance.GetOffetX();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position0.x, 0, Position0.y))) == 3)
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
                Position0 -= CameraManager.Instance.GetOffetY();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position0.x, 0, Position0.y))) == 3)
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
                Position0 += CameraManager.Instance.GetOffetY();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position0.x, 0, Position0.y))) == 3)
                {
                    meshRenderer0.material.color = greenColor;
                }
                else
                {
                    meshRenderer0.material.color = redColor;
                }
            }
            if(Input.GetKeyDown(KeyCode.Space)&& EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position0.x, 0, Position0.y))) == 3)
            {
                isReady0 = true;
                meshRenderer0.material.color = greenColor;
            }
        }
        if(isReady1 == false)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Position1 += CameraManager.Instance.GetOffetX();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position1.x, 0, Position1.y))) == 3)
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
                Position1 -= CameraManager.Instance.GetOffetX();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position1.x, 0, Position1.y))) == 3)
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
                Position1 -= CameraManager.Instance.GetOffetY();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position1.x, 0, Position1.y))) == 3)
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
                Position1 += CameraManager.Instance.GetOffetY();
                if(EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position1.x, 0, Position1.y))) == 3)
                {
                    meshRenderer1.material.color = greenColor;
                }
                else
                {
                    meshRenderer1.material.color = redColor;
                }
            }
            if(Input.GetKeyDown(KeyCode.KeypadEnter) && EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(Position1.x, 0, Position1.y))) == 3)
            {
                isReady1 = true;
                meshRenderer1.material.color = greenColor;
            }
        }
        if(isReady0 && isReady1)
        {
            Exit();
            
            EventManager.Instance.EnterTinyLevel(levelIndex);
        }
    }

    public void EnterTinyLevel(int levelIndex)
    {
        this.levelIndex = levelIndex;
        isReady0 = false;
        isReady1 = false;
        Position0 = Vector2Int.right;
        Position1 = Vector2Int.left;
        meshRenderer0.material.color = redColor;
        meshRenderer1.material.color = redColor;
        mate0.SetActive(true);
        mate1.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Exit()
    {
        mate0.SetActive(false);
        mate1.SetActive(false);
        gameObject.SetActive(false);
    }

    public void AddListener()
    {
        EventManager.Instance.EnterTinyLevelEvent_bef += EnterTinyLevel;
    }

}
