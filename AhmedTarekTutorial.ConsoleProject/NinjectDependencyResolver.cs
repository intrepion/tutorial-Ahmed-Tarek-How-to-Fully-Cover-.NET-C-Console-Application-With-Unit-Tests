using Ninject.Modules;

namespace AhmedTarekTutorial.ConsoleProject;

public class NinjectDependencyResolver : NinjectModule
{
    public override void Load()
    {
        Bind<IConsoleManager>().To<ConsoleManager>();
        Bind<IProgramManager>().To<ProgramManager>();
    }
}
