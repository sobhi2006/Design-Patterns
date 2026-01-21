public class ErrorLogger : LogBridge
{
    public ErrorLogger(IRenderer renderer)
    {
        Renderer = renderer;
    }
    public override void RenderProcess(string message)
    {
        Renderer!.RenderLog(LevelType.Error, message);
    }
}
