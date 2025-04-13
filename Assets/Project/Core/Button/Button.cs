using UnityEngine.EventSystems; 
using UnityEngine;
using System;

namespace Buttons
{
    public abstract class Button : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnClickEvent;
        public abstract void Init();
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
        }
    }
}