using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory
{
    private static CubeFactory instance;
    public static CubeFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CubeFactory();
                instance.Init();
            }
            return instance;
        }
    }

    private void Init()
    {
        prefab_cube = Resources.Load<GameObject>("Prefabs/Cube");
        cubePool = new List<BaseCube>();

        List<Material> materials = new List<Material>(50);
        materials[0] = Resources.Load<Material>("Material/ColorWhite");
        materials[1] = Resources.Load<Material>("Material/ColorRed");
        materials[2] = Resources.Load<Material>("Material/ColorGreen");
        materials[4] = Resources.Load<Material>("Material/ColorBlue");

        materials[10] = Resources.Load<Material>("Material/blue_base");
        materials[11] = Resources.Load<Material>("Material/blue_num1");
        materials[12] = Resources.Load<Material>("Material/blue_num2");
        materials[13] = Resources.Load<Material>("Material/blue_num3");
        materials[14] = Resources.Load<Material>("Material/blue_num4");
        materials[15] = Resources.Load<Material>("Material/blue_num5");
        materials[16] = Resources.Load<Material>("Material/blue_num6");
        materials[17] = Resources.Load<Material>("Material/blue_num7");
        materials[18] = Resources.Load<Material>("Material/blue_num8");
        materials[19] = Resources.Load<Material>("Material/blue_num9");

        BaseCube.InitMaterial(materials);
    }
    private GameObject prefab_cube ;
    private List<BaseCube> cubePool ;

    public BaseCube CreateCube(Vector3Int position , int color = 0)
    {
        if(cubePool.Count > 0)
        {
            BaseCube cube = cubePool[cubePool.Count - 1];
            cubePool.RemoveAt(cubePool.Count - 1);
            cube.gameObject.SetActive(true);
            cube.Position = position;
            cube.Color = color;
            return cube;
        }
        else
        {
            GameObject go = GameObject.Instantiate(prefab_cube);
            BaseCube cube = go.GetComponent<BaseCube>();
            cube.Position = position;
            cube.Color = color;
            return cube;
        }
    }

    public void DestroyCube(BaseCube cube)
    {
        cube.gameObject.SetActive(false);
        cubePool.Add(cube);
    }


}
