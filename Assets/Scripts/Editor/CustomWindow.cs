using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
public class CustomWindow : EditorWindow
{
    // 创建一个Vector3Int字段用于输入
    private Vector3Int m_position;
    private Vector3Int m_positionParent;

    // 添加菜单项，打开自定义窗口
    [MenuItem("Window/Custom Cube Adder")]
    public static void ShowWindow()
    {
        // 创建并显示窗口
        GetWindow<CustomWindow>("Cube Adder");
    }

    // 定义窗口中的UI元素
    void OnGUI()
    {
        GUILayout.Label("Add Cube at Position", EditorStyles.boldLabel);

        // 使用IntField让用户输入Vector3Int
        m_position.x = EditorGUILayout.IntField("X", m_position.x);
        m_position.y = EditorGUILayout.IntField("Y", m_position.y);
        m_position.z = EditorGUILayout.IntField("Z", m_position.z);

        m_positionParent.x = EditorGUILayout.IntField("Parent X", m_positionParent.x);
        m_positionParent.y = EditorGUILayout.IntField("Parent Y", m_positionParent.y);
        m_positionParent.z = EditorGUILayout.IntField("Parent Z", m_positionParent.z);

        // 按钮按下时调用AddCube方法
        if (GUILayout.Button("Add Cube"))
        {
            EventManager.Instance.AddCube(m_position);

        }
        //if(GUILayout.Button("Get Cube by curMate0"))
        //{
        //    Vector2Int curMate1ScreenPos = Vector2Int.RoundToInt(CameraManager.Instance.GetCameraSpacePosition(MateManager.Instance.curMates[0].GetComponent<MateMover>().transform.position));

        //    List<BaseCube> cubes = MapManager.Instance.MyCameraSpaceManager.GetCubes(curMate1ScreenPos);

        //}
        if (GUILayout.Button("Remove Cube"))
        {
            EventManager.Instance.RemoveCube(m_position);
        }
    }
}
