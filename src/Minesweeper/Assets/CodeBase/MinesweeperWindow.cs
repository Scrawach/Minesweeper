using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class MinesweeperWindow : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _grid;
        [SerializeField] private CellBehaviour _cellPrefab;

        private RectTransform _window;
        private RectTransform _gridRect;


        private void Start()
        {
            _window = GetComponent<RectTransform>();
            _gridRect = _grid.GetComponent<RectTransform>();
            
            Initialize(new Board(3, 8));
        }

        public void Initialize(Board board)
        {
            var cellSize = _grid.cellSize;
            var cellPadding = _grid.padding;
            var cellSpacing = _grid.spacing;
            var sizeDelta = -1 * _gridRect.sizeDelta;

            var desiredBoardWidth = cellPadding.left + cellPadding.right 
                                     + (cellSize.x * board.Width) 
                                     + (cellSpacing.x * (board.Width - 1))
                                     + sizeDelta.x;

            var desiredBoardHeight = (cellPadding.top + cellPadding.bottom)
                                     + (cellSize.y * board.Height)
                                     + (cellSpacing.y * (board.Height - 1))
                                     + sizeDelta.y;
            
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredBoardWidth);
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, desiredBoardHeight);
            
            for (var y = 0; y < board.Height; y++)
            for (var x = 0; x < board.Width; x++)
            {
                Instantiate(_cellPrefab, Vector3.zero, Quaternion.identity, _grid.transform);
            }
        }
    }
}