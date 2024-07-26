internal class Graph
{
    public char[][] Canvas { get; private set; }
    private int BaseLevel { get; set; }
    public int Height { get; }
    public int Width { get; }

    private readonly char baseline = '_';
    private readonly char Up = '/';
    private readonly char Down = '\\';
    private readonly char Straight = '_';
    private readonly char Cursor = '*';

    public Graph(int height, int width)
    {
        Height = height;
        Width = width;
        Canvas = new char[height][];
        SetCanvas();
        SetBaseLines();
    }

    private void SetCanvas()
    {
        for (int i = 0; i < Height; i++)
        {
            Canvas[i] = new char[Width + 2];
            Array.Fill(Canvas[i], ' ');
        }
    }

    private void SetBaseLines()
    {
        BaseLevel = Height / 2;
        Canvas[BaseLevel][0] = baseline;
        Canvas[BaseLevel][Width + 1] = baseline;
    }

    private void SetCursor(Direction[] hike, int[] path, int maxElevation)
    {
        int lastElevation = Math.Max(-maxElevation, Math.Min(path.LastOrDefault(), maxElevation));
        int cursorRow = BaseLevel - lastElevation;
        Canvas[cursorRow][hike.Length] = Cursor;
    }

    public void SetElevations(Direction[] hike, int[] path)
    {
        int maxElevation = (Height - 1) / 2; 

        for (int i = 0; i < hike.Length; i++)
        {
            int elevation = Math.Max(-maxElevation, Math.Min(path[i], maxElevation));
            int row = BaseLevel - elevation;
            
            char symbol = hike[i] switch
            {
                Direction.Up => Up,
                Direction.Down => Down,
                _ => Straight
            };
            
            Canvas[row][i + 1] = symbol;
        }

        SetCursor(hike, path, maxElevation);
    }

    public char[][] GetCanvas() => Canvas;

}