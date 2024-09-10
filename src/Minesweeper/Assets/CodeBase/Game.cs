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
    }
}