using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase
{
    public class CellBehaviour : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _image;
        
        [SerializeField] private Sprite _unknownTile;
        [SerializeField] private Sprite _emptyTile;
        [SerializeField] private Sprite _flagTile;

        private Vector2Int _position;

        public event Action<Vector2Int> Clicked; 

        public void Construct(Vector2Int position) => 
            _position = position;

        public void Click() => 
            Clicked?.Invoke(_position);

        public void Redraw(Cell cell)
        {
            
        }
        
        public void OnPointerClick(PointerEventData eventData) =>
            Click();
    }
}