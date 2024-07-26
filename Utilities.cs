internal enum Direction
{
    Down = -1,
    Right = 0,
    Up = 1,
}

internal static class KeyPress
{
    internal static Boolean IsUp(ConsoleKeyInfo cki) => cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.W || cki.Key == ConsoleKey.J;
    internal static Boolean IsDown(ConsoleKeyInfo cki) => cki.Key == ConsoleKey.DownArrow || cki.Key == ConsoleKey.S || cki.Key == ConsoleKey.K;
    internal static bool IsRight(ConsoleKeyInfo cki) => cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.D;
    internal static Boolean IsQuit(ConsoleKeyInfo cki) => cki.Key == ConsoleKey.Q || cki.Key == ConsoleKey.Escape;

    internal static Direction Handle(ConsoleKeyInfo key)
    {
        return key switch
        {
            ConsoleKeyInfo k when KeyPress.IsUp(k) => Direction.Up,
            ConsoleKeyInfo k when KeyPress.IsDown(k) => Direction.Down,
            ConsoleKeyInfo k when KeyPress.IsRight(k) => Direction.Right,
            _ => throw new NotImplementedException(),
        };
    }
    internal static void ShowInstructions() => Console.WriteLine("Use Up/Down/Right arrow keys to create a hike. Press Q to quit.");

}

