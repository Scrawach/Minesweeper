using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public Cell this[int x, int y]
        {
            get => _cells[x + y * Width];
            set => _cells[x + y * Width] = value;
        }

        public Cell this[Vector2Int position]
        {
            get => this[position.x, position.y];
            set => this[position.x, position.y] = value;
        }

        public IEnumerable<Cell> GetNeighbours(Vector2Int position)
        {
            for (var i = -1; i < 2; i++)
            for (var j = -1; j < 2; j++)
            {
                var x = position.x + i;
                var y = position.y + j;
                
                if (Contains(x, y))
                    yield return this[x, y];
            }
        }

        public bool Contains(int x, int y) =>
            x >= 0 && x < Width && y >= 0 && y < Height;

        public IEnumerator<Cell> GetEnumerator() =>
            _cells.GetTypedEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _cells.GetEnumerator();
    }
}