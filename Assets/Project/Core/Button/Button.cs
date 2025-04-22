using UnityEngine.EventSystems; 
using UnityEngine;
using System;

namespace Buttons
{
    public abstract class Button : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnClickEvent;
        public abstract void Init(); 

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
        }
    }
}