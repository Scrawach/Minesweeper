using System.Collections;
using System.Collections.Generic;

namespace CodeBase
{
    public sealed class Board : IEnumerable<Cell>
    {
        private readonly Cell[] _cells;
        
        public int Width { get; }
        public int Height { get; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new Cell[Width * Height];
        }

        public Cell this[int x, int y] => 
            _cells[x + y * Width];

        public bool Contains(int x, int y) =>
            x >= 0 && x < Width && y >= 0 && y < Height;

        public IEnumerator<Cell> GetEnumerator() =>
            _cells.GetTypedEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _cells.GetEnumerator();
    }
}