using UnityEngine;

namespace CodeBase
{
    public class MinesweeperGame
    {
        private readonly Board _board;

        public MinesweeperGame(Board board) => 
            _board = board;

        public void Open(Vector2Int position)
        {
            if (_board.Contains(position.x, position.y) == false)
                return;

            var cell = _board[position.x, position.y];
            cell.Open();

            if (cell.HasMine) 
                GameOver();
        }
        
        public void Mark(Vector2Int position)
        {
            
        }
        
        private void GameOver()
        {
            Debug.Log("Game Over!");
        }
    }
}