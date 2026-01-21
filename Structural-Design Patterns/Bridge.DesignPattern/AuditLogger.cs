public class AuditLogger : LogBridge
{
    public AuditLogger(IRenderer renderer)
    {
        Renderer = renderer;
    }
    public override void RenderProcess(string message)
    {
        Renderer!.RenderLog(LevelType.Audit, message);
    }
}