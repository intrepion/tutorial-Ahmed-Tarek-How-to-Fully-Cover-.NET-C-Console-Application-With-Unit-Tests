var input = string.Empty;

do
{
    Console.WriteLine("Welcome to my console app");
    Console.WriteLine("[1] Say Hello?");
    Console.WriteLine("[2] Say Goodbye?");
    Console.WriteLine("");
    Console.Write("Please enter a valid choice: ");

    input = Console.ReadLine();

    if (input == "1" || input == "2")
    {
        Console.Write("Please enter your name: ");
        
        string name = Console.ReadLine();

        if (input == "1")
        {
            Console.WriteLine("Hello " + name);
        }
        else
        {
            Console.WriteLine("Goodbye " + name);
        }

        Console.WriteLine("");
        Console.Write("Press any key to exit... ");
        Console.ReadKey();
    }
    else
    {
        Console.Clear();
    }
}
while (input != "1" && input != "2");
