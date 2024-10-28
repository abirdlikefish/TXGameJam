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
