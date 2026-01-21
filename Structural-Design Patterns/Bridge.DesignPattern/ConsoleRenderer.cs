public class ConsoleRenderer : IRenderer
{
    public void RenderLog(LevelType level, string message)
    {
        System.Console.WriteLine($"{DateTime.Now} , level: {level}, message: {message}");
    }
}
