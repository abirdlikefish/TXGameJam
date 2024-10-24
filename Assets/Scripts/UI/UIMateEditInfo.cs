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

    public Dropdown dropDown;//TODO 翘课已 之 已经实现了，但是没有显示出来

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
            //将名字中的空格转换为下划线
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
        // H范围为0到1，表示色相全范围
        float hue = Random.Range(0f, 1f);

        // S范围为0.5到1，确保有一定饱和度，避免灰色
        float saturation = Random.Range(0.5f, 1f);

        // V范围为0.7到1，确保颜色比较浅，避免太暗
        float value = Random.Range(0.7f, 1f);

        // 使用HSV转换为RGB颜色
        return Color.HSVToRGB(hue, saturation, value);
    }
}
