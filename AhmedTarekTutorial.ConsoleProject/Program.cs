using Ninject;
using System.Reflection;

namespace AhmedTarekTutorial.ConsoleProject;

class Program
{
    private static IProgramManager? m_ProgramManager;

    static void Main(string[] args)
    {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());

        m_ProgramManager = kernel.Get<IProgramManager>();
        m_ProgramManager.Run();
    }
}
