using System;
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


        private void Awake()
        {
            _window = GetComponent<RectTransform>();
            _gridRect = _grid.GetComponent<RectTransform>();
        }

        private void Start() => 
            Initialize(new Board(3, 8));

        public void Initialize(Board board)
        {
            FitWindowForBoardWith(board.Width, board.Height);

            for (var y = 0; y < board.Height; y++)
            for (var x = 0; x < board.Width; x++)
            {
                Instantiate(_cellPrefab, Vector3.zero, Quaternion.identity, _grid.transform);
            }
        }

        private void FitWindowForBoardWith(int width, int height)
        {
            var cellSize = _grid.cellSize;
            var cellPadding = _grid.padding;
            var cellSpacing = _grid.spacing;
            var sizeDelta = _gridRect.sizeDelta;

            var desiredBoardWidth = (cellPadding.left + cellPadding.right)
                                    + cellSize.x * width
                                    + cellSpacing.x * (width - 1)
                                    - sizeDelta.x;

            var desiredBoardHeight = cellPadding.top + cellPadding.bottom
                                     + cellSize.y * height
                                     + cellSpacing.y * (height - 1)
                                     - sizeDelta.y;
            
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredBoardWidth);
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, desiredBoardHeight);
        }
    }
}