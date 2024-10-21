using UnityEngine;
using UnityEditor;

public class CustomWindow : EditorWindow
{
    // ����һ��Vector3Int�ֶ���������
    private Vector3Int m_position;

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

        // ��ť����ʱ����AddCube����
        if (GUILayout.Button("Add Cube"))
        {
            EventManager.Instance.AddCube(m_position);
        }
        if (GUILayout.Button("Remove Cube"))
        {
            EventManager.Instance.RemoveCube(m_position);
        }
    }
}
