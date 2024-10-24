using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIMateEditInfo:MonoBehaviour
{
    public int Id => name[name.Length^1] - '0';
    public Image mateBase;
    public Text mateName;
    public Text mateNameInputHolder;
    public Text mateNameInput;

    public Text mateWinCountC;
    public Text mateWinCount;


    public Button btConfirmEdit;

    public Dropdown dropDown;//TODO �̿��� ֮ �Ѿ�ʵ���ˣ�����û����ʾ����

    string editName = null;
    Color editColor = Color.clear;
    public void OnEditChangeColor()
    {
        editColor = RandomColor();
        MateData mateData = MateManager.Instance.CreateMate(mateName.text,editColor);
        UIMateEditor.Instance.ShowMate(mateData, this);
    }
    public void OnEditChangeName()
    {
        if(mateNameInput.text == "")
        {
            editName = mateNameInputHolder.text;
        }
        else
        {
            editName = mateNameInput.text;
            //�������еĿո�ת��Ϊ�»���
            editName = editName.Replace(" ", "_");
            mateNameInput.text = editName;
        }
        MateData mateData = MateManager.Instance.CreateMate(editName, mateName.color);
        UIMateEditor.Instance.ShowMate(mateData, this);
    }

    public void OnEditDropdownValueChanged()
    {
        mateNameInput.text = dropDown.captionText.text;
        OnEditChangeName();
    }

    Color RandomColor()
    {
        // H��ΧΪ0��1����ʾɫ��ȫ��Χ
        float hue = Random.Range(0f, 1f);

        // S��ΧΪ0.5��1��ȷ����һ�����Ͷȣ������ɫ
        float saturation = Random.Range(0.5f, 1f);

        // V��ΧΪ0.7��1��ȷ����ɫ�Ƚ�ǳ������̫��
        float value = Random.Range(0.7f, 1f);

        // ʹ��HSVת��ΪRGB��ɫ
        return Color.HSVToRGB(hue, saturation, value);
    }
}
