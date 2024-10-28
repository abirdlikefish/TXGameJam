using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMateEditInfo:MonoBehaviour
{
    int mateId;
    public Image mateBase;
    public Text mateName;
    public Text mateNameInputHolder;
    public Text mateNameInput;

    public Text mateWinCountC;
    public Text mateWinCount;


    public Dropdown dropDown;

    public Image mateNameBG;

    string editName = null;
    Color editColor = Color.clear;
    public void SetMateId(int id)
    {
        mateId = id;   
    }
    public void OnEditChangeColor()
    {
        editColor = RandomColor();
        MateData mateData = MateManager.Instance.CreateMate(mateName.text,editColor);
        MateManager.Instance.curMates[mateId].mateData = mateData;
        UIMateEditor.Instance.ShowMate(mateData, mateId);
    }
    public void OnEditChangeName()
    {
        editName = mateNameInput.text == "" ? mateNameInputHolder.text : mateNameInput.text;
        MateData mateData = MateManager.Instance.CreateMate(editName, mateName.color);
        MateManager.Instance.curMates[mateId].mateData = mateData;
        UIMateEditor.Instance.ShowMate(mateData, mateId);
        mateNameBG.color = new Color(mateName.color.r, mateName.color.g, mateName.color.b,
            mateNameBG.color.a);
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
