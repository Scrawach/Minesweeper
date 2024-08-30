using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class CellBehaviour : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        [SerializeField] private Sprite _unknownTile;
        [SerializeField] private Sprite _emptyTile;
        [SerializeField] private Sprite _flagTile;

        private Cell _cell;
        
        public void Construct(Cell cell)
        {
            _cell = cell;
            _cell.Changed += OnCellChanged;
        }

        private void OnDestroy()
        {
            _cell.Changed -= OnCellChanged;
        }

        private void OnCellChanged()
        {
            
        }
    }
}