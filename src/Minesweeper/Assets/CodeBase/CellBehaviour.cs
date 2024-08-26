using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase
{
    public class CellBehaviour : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked!");
        }
    }
}