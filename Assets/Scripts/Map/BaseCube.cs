using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCube : MonoBehaviour
{
    // public int groupID = -1;
    private Vector3Int position;
    public Vector3Int Position{ get => position; set {position = value; transform.position = value;}}
    public int Height{get => Mathf.RoundToInt(CameraManager.Instance.GetHeight(Position));}
    private MeshRenderer meshRenderer;
    private static List<Material> materials;

    private int color;
    public int Color
    {
        get => color;
        set
        {
            if(meshRenderer == null)
            {
                // InitMaterial();
                meshRenderer = GetComponent<MeshRenderer>();
                color = value;
                meshRenderer.material = Instantiate(materials[value]);
            }
            else if(value == -1)
            {
                color = 0;
                meshRenderer.material = Instantiate(materials[0]);
                Debug.LogWarning("error: Color is -1");
            }
            else if(color == value)
            {
                
            }
            else if(color != 0)
            {
                // EventManager.Instance.ColorReaction(color + value , Position);
                ColorReactionManager.Instance.InvokeColorReaction(color + value , Position);
                color = 0;
                meshRenderer.material = Instantiate(materials[0]);
            }
            else
            {
                color = value;
                meshRenderer.material = Instantiate(materials[value]);
            }
        }
    }

    public Vector2Int GetCameraSpacePosition()
    {
        return CameraManager.Instance.GetCameraSpacePosition(Position);
    }

    // public void Awake()
    // {
    //     meshRenderer = GetComponent<MeshRenderer>();
    //     // newMaterial = GetComponent<NewMaterial>();
    //     // InitMaterial();
    //     // Color = -1;
    // }

    public static void InitMaterial(List<Material> materialList)
    {
        materials = materialList;
        // newMaterial = GetComponent<NewMaterial>();
        // meshRenderer = GetComponent<MeshRenderer>();
        // materials = new Material[5];
        // materials[0] = Resources.Load<Material>("Material/ColorWhite");
        // materials[1] = Resources.Load<Material>("Material/ColorRed");
        // materials[2] = Resources.Load<Material>("Material/ColorGreen");
        // materials[4] = Resources.Load<Material>("Material/ColorBlue");
    }
    
}
