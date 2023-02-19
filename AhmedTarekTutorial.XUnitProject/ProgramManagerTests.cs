using AhmedTarekTutorial.ConsoleProject;

namespace AhmedTarekTutorial.XUnitProject;

public class ProgramManagerTests
{
    private ConsoleManagerStub m_ConsoleManager = null;
    private ProgramManager m_ProgramManager = null;

    public ProgramManagerTests()
    {
        m_ConsoleManager = new ConsoleManagerStub();
        m_ProgramManager = new ProgramManager(m_ConsoleManager);
    }

    [Theory]
    [InlineData("Ahmed")]
    [InlineData("")]
    [InlineData(" ")]
    public void RunWithInputAs1AndName(string name)
    {
        m_ConsoleManager.UserInputs.Enqueue("1");
        m_ConsoleManager.UserInputs.Enqueue(name);
        m_ConsoleManager.UserInputs.Enqueue(new ConsoleKeyInfo());

        var expectedOutput = new List<string>
        {
        "Welcome to my console app\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: ",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n\r\nPress any key to exit... "
        };

        m_ConsoleManager.OutputsUpdated +=
            outputEntryNumber =>
            {
            Assert.Equal(
            expectedOutput[outputEntryNumber - 1],
            m_ConsoleManager.ToString());
            };

        m_ProgramManager.Run();
    }

    [Theory]
    [InlineData("Ahmed")]
    [InlineData("")]
    [InlineData(" ")]
    public void RunWithInputAs2AndName(string name)
    {
        m_ConsoleManager.UserInputs.Enqueue("2");
        m_ConsoleManager.UserInputs.Enqueue(name);
        m_ConsoleManager.UserInputs.Enqueue(new ConsoleKeyInfo());

        var expectedOutput = new List<string>
        {
        "Welcome to my console app\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: ",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\nGoodbye " + name + "\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\nGoodbye " + name + "\r\n\r\n",
        "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\nGoodbye " + name + "\r\n\r\nPress any key to exit... "
        };

        m_ConsoleManager.OutputsUpdated +=
            outputEntryNumber =>
            {
            Assert.Equal(
            expectedOutput[outputEntryNumber - 1],
            m_ConsoleManager.ToString());
            };

        m_ProgramManager.Run();
    }

    [Fact]
    public void RunShouldKeepTheMainMenuWhenInputIsNeither1Nor2()
    {
        m_ConsoleManager.UserInputs.Enqueue("any invalid input 1");
        m_ConsoleManager.UserInputs.Enqueue("any invalid input 2");
        m_ConsoleManager.UserInputs.Enqueue("Exit");

        var expectedOutput = new List<string>
        {
            // initial menu
            "Welcome to my console app\r\n", // outputEntryNumber 1
            "Welcome to my console app\r\n[1] Say Hello?\r\n", // outputEntryNumber 2
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n", // outputEntryNumber 3
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n", // outputEntryNumber 4
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ", // outputEntryNumber 5
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: any invalid input 1\r\n", // outputEntryNumber 6
            // after first trial
            "", // outputEntryNumber 7
            "Welcome to my console app\r\n", // outputEntryNumber 8
            "Welcome to my console app\r\n[1] Say Hello?\r\n", // outputEntryNumber 9
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n", // outputEntryNumber 10
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n", // outputEntryNumber 11
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ", // outputEntryNumber 12
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: any invalid input 2\r\n", // outputEntryNumber 13
            // after second trial
            "", // outputEntryNumber 14
            "Welcome to my console app\r\n", // outputEntryNumber 15
            "Welcome to my console app\r\n[1] Say Hello?\r\n", // outputEntryNumber 16
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n", // outputEntryNumber 17
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n", // outputEntryNumber 18
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ", // outputEntryNumber 19
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: Exit\r\n" // outputEntryNumber 20
        };

        m_ConsoleManager.OutputsUpdated +=
            outputEntryNumber =>
            {
            if (outputEntryNumber - 1 < expectedOutput.Count)
            {
            Assert.Equal(
            expectedOutput[outputEntryNumber - 1],
            m_ConsoleManager.ToString());
            }
            };

        m_ProgramManager.Run();
    }
}
