public static class ConsoleHelper
{
    public static void ClearScreen()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            Console.WriteLine();
        }
    }
}
