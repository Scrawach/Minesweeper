namespace CodeBase
{
    public sealed class BoardBuilder
    {
        public Board Build(int width, int height) => 
            new(width, height);
    }
}