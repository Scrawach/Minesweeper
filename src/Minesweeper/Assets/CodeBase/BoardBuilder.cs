using UnityEngine;

namespace CodeBase
{
    public sealed class BoardBuilder
    {
        public Board Build(int width, int height)
        {
            var board = new Board(width, height);
            
            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                board[x, y] = new Cell(new Vector2Int(x, y));

            return board;
        }
    }
}