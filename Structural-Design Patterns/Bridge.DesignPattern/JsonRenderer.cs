using System.Text.Json;

public class JsonRenderer : IRenderer
{
    public void RenderLog(LevelType level, string message)
    {
        var obj = new {time = DateTime.Now, level = level, message = message};
        var jsonObj = JsonSerializer.Serialize(obj);
        System.Console.WriteLine(jsonObj);
    }
}
