namespace Structural.Decorator.Component
{
    public interface ILogger
    {
        int MessageBuffer { get; set; }

        void Log(string message);
    }
}
