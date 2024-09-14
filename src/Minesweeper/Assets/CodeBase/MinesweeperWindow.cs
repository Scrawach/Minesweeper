using System;
using System.Collections.Generic;
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
        private Dictionary<Vector2Int, CellBehaviour> _views;

        private void Awake()
        {
            _window = GetComponent<RectTransform>();
            _gridRect = _grid.GetComponent<RectTransform>();
        }

        private void Start()
        {
            _game = new Game(new BoardBuilder());
            _game.Start(6, 6);
            Initialize(_game.Board);
        }

        public void Initialize(Board board)
        {
            FitWindowForBoardWith(board.Width, board.Height);
            _views = new Dictionary<Vector2Int, CellBehaviour>(board.Width * board.Height);

            foreach (var cell in board)
            {
                var cellBehaviour = Instantiate(_cellPrefab, Vector3.zero, Quaternion.identity, _grid.transform);
                cellBehaviour.Clicked += OnCellClicked;
                cellBehaviour.Marked += OnMarkClicked;
                cellBehaviour.DoubleClicked += OnDoubleClicked;
                cellBehaviour.MovesDisplayed += OnMovesDisplayed;
                cellBehaviour.MovesUndisplayed += OnMovesUndisplayed;
                cellBehaviour.Construct(cell.Position);
                _views[cell.Position] = cellBehaviour;
            }
        }

        private void OnMovesUndisplayed(Vector2Int position)
        {
            foreach (var neighbour in _game.Board.GetNeighbours(position)) 
                _views[neighbour.Position].UndisplayAsEmpty();
        }

        private void OnMovesDisplayed(Vector2Int position)
        {
            foreach (var neighbour in _game.Board.GetNeighbours(position)) 
                _views[neighbour.Position].DisplayAsEmpty();
        }

        private void OnCellClicked(Vector2Int position)
        {
            Debug.Log($"{position}");
            _game.Open(position);

            foreach (var cell in _game.Board)
            {
                _views[cell.Position].Redraw(cell);
            }
        }

        private void OnMarkClicked(Vector2Int position)
        {
            _game.Mark(position);
            
            foreach (var cell in _game.Board)
            {
                _views[cell.Position].Redraw(cell);
            }
        }

        private void OnDoubleClicked(Vector2Int position)
        {
            _game.OpenArea(position);
            
            foreach (var cell in _game.Board)
            {
                _views[cell.Position].Redraw(cell);
            }
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