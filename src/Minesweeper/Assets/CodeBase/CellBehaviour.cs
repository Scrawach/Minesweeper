using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase
{
    public class CellBehaviour : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
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
        public event Action<Vector2Int> Marked;
        public event Action<Vector2Int> MovesDisplayed;
        public event Action<Vector2Int> DoubleClicked; 

        public void Construct(Vector2Int position) => 
            _position = position;

        public void Click() => 
            Clicked?.Invoke(_position);

        public void Redraw(Cell cell)
        {
            if (cell.IsFlagged)
            {
                _image.sprite = _flagTile;
            }
            else
            {
                _image.sprite = _unknownTile;
            }

            if (cell.IsReveal && cell.HasMine)
            {
                _image.sprite = _bombTile;
            }
            else if (cell.IsReveal)
            {
                _image.sprite = _emptyTile;
                _amountOfMinesText.text = cell.AmountOfMinesAround == 0? "" : cell.AmountOfMinesAround.ToString();
            }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Middle:
                    DoubleClicked?.Invoke(_position);
                    break;
                case PointerEventData.InputButton.Left:
                    Clicked?.Invoke(_position);
                    break;
                case PointerEventData.InputButton.Right:
                    Marked?.Invoke(_position);
                    break;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Middle)
                MovesDisplayed?.Invoke(_position);
        }
    }
}