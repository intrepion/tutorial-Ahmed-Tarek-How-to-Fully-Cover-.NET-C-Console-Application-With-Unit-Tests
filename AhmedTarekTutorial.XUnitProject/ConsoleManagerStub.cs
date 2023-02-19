using System.Text;
using AhmedTarekTutorial.ClassLibProject;

namespace AhmedTarekTutorial.XUnitProject;

public class ConsoleManagerStub : ConsoleManagerBase
{
    private int m_CurrentOutputEntryNumber;
    private readonly List<string> m_Outputs = new List<string>();

    public event Action<int>? OutputsUpdated;
    public event Action? OutputsCleared;

    public Queue<object> UserInputs { get; } = new Queue<object>();

    public override void Clear()
    {
        m_CurrentOutputEntryNumber++;
        m_Outputs.Clear();
        OnOutputsCleared();
        OnOutputsUpdated(m_CurrentOutputEntryNumber);
    }

    public override ConsoleKeyInfo ReadKey()
    {
        ConsoleKeyInfo result;

        object input;

        if (UserInputs.Count > 0)
        {
            input = UserInputs.Dequeue();
        }
        else
        {
            throw new ArgumentException("No input was presented when an input was expected");
        }

        if (input is ConsoleKeyInfo key)
        {
            result = key;
        }
        else
        {
            throw new ArgumentException("Invalid input was presented when ConsoleKeyInfo was expected");
        }

        return result;
    }

    public override string ReadLine()
    {
        object input;

        if (UserInputs.Count > 0)
        {
            input = UserInputs.Dequeue();
        }
        else
        {
            throw new ArgumentException("No input was presented when an input was expected");
        }

        string result;
        if (input is string str)
        {
            result = str;
            WriteLine(result);
        }
        else
        {
            throw new ArgumentException("Invalid input was presented when String was expected");
        }

        return result;
    }

    public override void Write(string value)
    {
        m_Outputs.Add(value);
        m_CurrentOutputEntryNumber++;
        OnOutputsUpdated(m_CurrentOutputEntryNumber);
    }

    public override void WriteLine(string value)
    {
        m_Outputs.Add(value + "\r\n");
        m_CurrentOutputEntryNumber++;
        OnOutputsUpdated(m_CurrentOutputEntryNumber);
    }

    protected void OnOutputsUpdated(int outputEntryNumber)
    {
        OutputsUpdated?.Invoke(outputEntryNumber);
    }

    protected void OnOutputsCleared()
    {
        OutputsCleared?.Invoke();
    }

    public override string ToString()
    {
        var result = string.Empty;

        if (m_Outputs == null || m_Outputs.Count <= 0) return result;

        var builder = new StringBuilder();

        foreach (var output in m_Outputs)
        {
            builder.Append(output);
        }

        result = builder.ToString();

        return result;
    }
}