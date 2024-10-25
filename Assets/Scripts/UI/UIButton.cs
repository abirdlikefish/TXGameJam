using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Pec
{
    public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler,IPointerExitHandler
    {
        public UnityAction OnClick;
        public UnityAction OnHighlight;
        public UnityAction OnExit;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnHighlight?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExit?.Invoke();
        }
    }
}

