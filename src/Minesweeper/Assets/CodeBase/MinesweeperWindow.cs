using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase
{
    public class MinesweeperWindow : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GridLayoutGroup _grid;
        [SerializeField] private CellBehaviour _cellPrefab;

        private RectTransform _window;
        private RectTransform _gridRect;

        private Game _game;

        private void Awake()
        {
            _window = GetComponent<RectTransform>();
            _gridRect = _grid.GetComponent<RectTransform>();
        }

        private void Start() => 
            Initialize(new BoardBuilder().Build(6, 6));

        public void Initialize(Board board)
        {
            _game = new Game(board);
            FitWindowForBoardWith(board.Width, board.Height);

            for (var y = 0; y < board.Height; y++)
            for (var x = 0; x < board.Width; x++)
            {
                var cell = board[x, y];
                var cellBehaviour = Instantiate(_cellPrefab, Vector3.zero, Quaternion.identity, _grid.transform);
                cellBehaviour.Clicked += OnCellClicked;
                cellBehaviour.Construct(cell.Position);
            }
        }

        private void OnCellClicked(Vector2Int position)
        {
            _game.Open(position);
            
            
        }

        private void FitWindowForBoardWith(int width, int height)
        {
            var size = _grid.cellSize;
            var padding = _grid.padding;
            var spacing = _grid.spacing;
            var sizeDelta = _gridRect.sizeDelta;

            var desiredBoardWidth = (padding.left + padding.right)
                                    + size.x * width
                                    + spacing.x * (width - 1)
                                    - sizeDelta.x;

            var desiredBoardHeight = padding.top + padding.bottom
                                     + size.y * height
                                     + spacing.y * (height - 1)
                                     - sizeDelta.y;
            
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredBoardWidth);
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, desiredBoardHeight);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log($"{_grid.transform.position}");
            Debug.Log($"Clicked at {eventData.pointerClick}");
        }
    }
}