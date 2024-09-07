using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase
{
    public class CellBehaviour : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _amountOfMinesText;
        
        [SerializeField] private Sprite _unknownTile;
        [SerializeField] private Sprite _emptyTile;
        [SerializeField] private Sprite _flagTile;
        
        [SerializeField] private Sprite _bombedTile;
        [SerializeField] private Sprite _bombTile;

        private Vector2Int _position;

        public event Action<Vector2Int> Clicked; 

        public void Construct(Vector2Int position) => 
            _position = position;

        public void Click() => 
            Clicked?.Invoke(_position);

        public void Redraw(Cell cell)
        {
            _amountOfMinesText.text = cell.AmountOfMinesAround == 0? "" : cell.AmountOfMinesAround.ToString();

            if (cell.IsFlagged)
            {
                _image.sprite = _flagTile;
            }
            
            if (cell.IsReveal)
            {
                _image.sprite = cell.HasMine ? _bombTile : _emptyTile;
            }
        }
        
        public void OnPointerClick(PointerEventData eventData) =>
            Click();
    }
}