public abstract class LogBridge
{
    protected IRenderer? Renderer;

    public abstract void RenderProcess(string message);
}
