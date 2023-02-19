namespace AhmedTarekTutorial.ClassLibProject;

public interface IConsoleManager
{
    void Clear();
    ConsoleKeyInfo ReadKey();
    string ReadLine();
    void Write(string value);
    void WriteLine(string value);
}

public abstract class ConsoleManagerBase : IConsoleManager
{
    public abstract void Clear();
    public abstract ConsoleKeyInfo ReadKey();
    public abstract string ReadLine();
    public abstract void Write(string value);
    public abstract void WriteLine(string value);
}

public class ConsoleManager : ConsoleManagerBase
{
    public override void Clear()
    {
        Console.Clear();
    }

    public override ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    public override string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public override void Write(string value)
    {
        Console.Write(value);
    }

    public override void WriteLine(string value)
    {
        Console.WriteLine(value);
    }
}
