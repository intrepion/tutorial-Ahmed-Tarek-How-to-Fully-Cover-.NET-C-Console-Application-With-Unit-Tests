using AhmedTarekTutorial.ClassLibProject;

namespace AhmedTarekTutorial.ClassLibProject;

public interface IProgramManager
{
    void Run();
}

public abstract class ProgramManagerBase : IProgramManager
{
    public abstract void Run();
}

public class ProgramManager : ProgramManagerBase
{
    private readonly IConsoleManager m_ConsoleManager;

    public ProgramManager(IConsoleManager consoleManager)
    {
        m_ConsoleManager = consoleManager;
    }

    public override void Run()
    {
        string input;

        do
        {
            m_ConsoleManager.WriteLine("Welcome to my console app");
            m_ConsoleManager.WriteLine("[1] Say Hello?");
            m_ConsoleManager.WriteLine("[2] Say Goodbye?");
            m_ConsoleManager.WriteLine("");
            m_ConsoleManager.Write("Please enter a valid choice: ");

            input = m_ConsoleManager.ReadLine();

            if (input == "1" || input == "2")
            {
                m_ConsoleManager.Write("Please enter your name: ");
                var name = m_ConsoleManager.ReadLine();

                if (input == "1")
                {
                    m_ConsoleManager.WriteLine("Hello " + name);
                }
                else
                {
                    m_ConsoleManager.WriteLine("Goodbye " + name);
                }

                m_ConsoleManager.WriteLine("");
                m_ConsoleManager.Write("Press any key to exit... ");
                m_ConsoleManager.ReadKey();
            }
            else
            {
                m_ConsoleManager.Clear();
            }
        }
        while (input != "1" && input != "2" && input != "Exit");
    }
}
