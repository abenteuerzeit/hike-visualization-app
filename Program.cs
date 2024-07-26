List<Direction> directions = [];
int maxWidth = Console.WindowWidth / 2;
int maxHeight = Console.WindowHeight / 2 - 3;


void ProcessHike(Hike hikeObj)
{
    hikeObj.Draw();
    (int min, int max) = hikeObj.GetElevationMinMax();
    if (max > maxHeight || min < -maxHeight) directions.Clear();
}


while (true)
{
    Console.Clear();
    if (directions.Count == 0)
    {
        KeyPress.ShowInstructions();
    }
    else
    {
        ProcessHike(new Hike([.. directions]));
    }

    ConsoleKeyInfo key = Console.ReadKey(true);
    if (KeyPress.IsQuit(key)) break;

    try
    {
        directions.Add(KeyPress.Handle(key));
    }
    catch
    {
        Console.WriteLine(key.KeyChar);
        Thread.Sleep(1000);
    }

    if (directions.Count >= maxWidth) directions.Clear();
}
