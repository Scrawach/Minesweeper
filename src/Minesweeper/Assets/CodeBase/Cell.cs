using UnityEngine;

namespace CodeBase
{
    public class Cell
    {
        public int AmountOfMinesAround;
        public bool IsFlagged;
        public bool IsReveal;
        public bool HasMine;

        public Cell(Vector2Int position) => 
            Position = position;

        public Vector2Int Position { get; }
    }
}
