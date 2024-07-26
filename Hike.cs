internal class Hike
{
    private Direction[] Directions { get; }
    private int Length { get; }
    public int Peaks { get; private set; }
    public int Valleys { get; private set; }
    public int CurrentLevel { get; private set; }


    public Hike(Direction[] directions, int totalPeaks = 0, int totalValleys = 0)
    {
        Directions = directions;
        Length = directions.Length;
        CalculateStatistics();
    }

    private void CalculateStatistics()
    {
        Peaks = 0;
        Valleys = 0;
        CurrentLevel = 0;
        Direction? previousDirection = null;

        foreach (var direction in Directions)
        {
            if (previousDirection.HasValue && previousDirection != direction)
            {
                switch (direction)
                {
                    case Direction.Up when previousDirection != Direction.Right:
                        Valleys++;
                        break;
                    case Direction.Down when previousDirection != Direction.Right:
                        Peaks++;
                        break;
                    default:
                        break;
                }
            }

            CurrentLevel += (int)direction;
            previousDirection = direction;
        }
    }

    private void DisplayStatistics()
    {
        Console.WriteLine($"Current Peaks: {Peaks}");
        Console.WriteLine($"Current Valleys: {Valleys}");
        Console.WriteLine($"Current Level: {CurrentLevel} ({(CurrentLevel > 0 ? "above" : CurrentLevel < 0 ? "below" : "at")} baseline)");
    }


    private int[] GetOffset()
    {
        int level = 0;
        return Directions
            .Select(d => level += (int)d)
            .ToArray();
    }

    public (int, int) GetElevationMinMax()
    {
        int[] path = GetOffset();
        return (path.Min(), path.Max());
    }

    private Graph Render()
    {
        (int min, int max) = GetElevationMinMax();
        int height = Math.Max(Math.Abs(min), Math.Abs(max)) * 2 + 3;
        Graph graph = new(height, Length + 1);
        graph.SetElevations(Directions, GetOffset());
        return graph;
    }

    

    public void Draw(char separator = ' ')
    {
        DisplayStatistics();
        Render().GetCanvas().ToList().ForEach(row => Console.WriteLine(string.Join(separator, row)));
    }
}