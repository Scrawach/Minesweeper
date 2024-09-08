using UnityEngine;

namespace CodeBase
{
    public sealed class BoardBuilder
    {
        private const int TargetAmountOfMines = 10;
        
        public Board Build(int width, int height)
        {
            var board = new Board(width, height);
            
            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                board[x, y] = new Cell(new Vector2Int(x, y));

            return GenerateMines(board);
        }

        public Board GenerateMines(Board board)
        {
            var mines = 0;

            while (mines != TargetAmountOfMines)
            {
                var x = Random.Range(0, board.Width);
                var y = Random.Range(0, board.Height);
                
                if (board[x, y].HasMine)
                    continue;

                board[x, y].HasMine = true;
                mines++;
            }

            return board;
        }
    }
}