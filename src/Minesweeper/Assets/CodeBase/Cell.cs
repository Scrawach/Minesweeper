using System;

namespace CodeBase
{
    public class Cell
    {
        public int AmountOfMinesAround;
        public bool IsFlagged;
        public bool IsReveal;
        public bool HasMine;

        public event Action Changed;

        public void Open()
        {
            IsReveal = true;
            Changed?.Invoke();
        }
    }
}
