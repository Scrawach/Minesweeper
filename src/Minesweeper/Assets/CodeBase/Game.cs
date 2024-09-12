using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
    public class Game
    {
        private readonly BoardBuilder _builder;
        
        private Board _board;

        public Game(BoardBuilder builder) => 
            _builder = builder;

        public Board Board => _board;
        
        public void Start(int width, int height) => 
            _board = _builder.Build(width, height);

        public void Open(Vector2Int position)
        {
            if (_board.Contains(position.x, position.y) == false)
                return;

            var cell = _board[position.x, position.y];
            cell.IsReveal = true;

            if (cell.HasMine) 
                GameOver();
            else
                CascadeOpen(position);
        }
        
        public void Mark(Vector2Int position)
        {
            _board[position].IsFlagged = !_board[position].IsFlagged;
        }
        
        private void GameOver()
        {
            Debug.Log("Game Over!");
        }

        public void OpenArea(Vector2Int position)
        {
            Debug.Log($"OPEN AREA!");
        }

        private void CascadeOpen(Vector2Int startPosition)
        {
            foreach (var neighbour in GetNeighbours(startPosition))
            {
                if (neighbour.AmountOfMinesAround == 0 && !neighbour.HasMine && !neighbour.IsReveal)
                {
                    neighbour.IsReveal = true;
                    CascadeOpen(neighbour.Position);
                }
            }
        }

        private IEnumerable<Cell> GetNeighbours(Vector2Int position)
        {
            for (var x = position.x - 1; x < position.x + 2; x++)
            for (var y = position.y - 1; y < position.y + 2; y++)
            {
                if (_board.Contains(x, y))
                {
                    yield return _board[x, y];
                }
            }
        }
    }
}