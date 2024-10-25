using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIDropdown : MonoBehaviour, IPointerClickHandler
{
    private Dropdown dropdown;
    public Text mateName;
    public Image ItemBG;
    public Image ScrollBar;
    public Image Handle;

    private List<string> oldList = new List<string>();
    private List<string> newList = new List<string>();

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        oldList.Clear();
        newList.Clear();
        
        for(int i=0;i<dropdown.options.Count;i++)
        {
            oldList.Add(dropdown.options[i].text);
        }

        for(int i=0;i< MateManager.Instance.mateDatas.Count;i++)
        {
            string option =  MateManager.Instance.mateDatas[i].name;
            if(!oldList.Contains(option))
            {
                newList.Add(option);
            }
        }
        dropdown.AddOptions(newList);

        for (int i = 0; i < dropdown.options.Count; i++)
        {
            if (dropdown.options[i].text.Equals(mateName.text))
            {
                dropdown.value = i;
                break;
            }
        }

        //¸Ä±äÑÕÉ«
        ItemBG.color = mateName.color;
        ScrollBar.color = mateName.color;
        Handle.color = mateName.color;
    }

    
}
