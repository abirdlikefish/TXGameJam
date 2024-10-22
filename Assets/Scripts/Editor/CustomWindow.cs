using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
public class CustomWindow : EditorWindow
{
    // ����һ��Vector3Int�ֶ���������
    private Vector3Int m_position;
    private Vector3Int m_positionParent;

    // ��Ӳ˵�����Զ��崰��
    [MenuItem("Window/Custom Cube Adder")]
    public static void ShowWindow()
    {
        // ��������ʾ����
        GetWindow<CustomWindow>("Cube Adder");
    }

    // ���崰���е�UIԪ��
    void OnGUI()
    {
        GUILayout.Label("Add Cube at Position", EditorStyles.boldLabel);

        // ʹ��IntField���û�����Vector3Int
        m_position.x = EditorGUILayout.IntField("X", m_position.x);
        m_position.y = EditorGUILayout.IntField("Y", m_position.y);
        m_position.z = EditorGUILayout.IntField("Z", m_position.z);

        m_positionParent.x = EditorGUILayout.IntField("Parent X", m_positionParent.x);
        m_positionParent.y = EditorGUILayout.IntField("Parent Y", m_positionParent.y);
        m_positionParent.z = EditorGUILayout.IntField("Parent Z", m_positionParent.z);

        // ��ť����ʱ����AddCube����
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
