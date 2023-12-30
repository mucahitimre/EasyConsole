namespace EasyConsole;

public static class Output
{
    public static void WriteLine(ConsoleColor color, string format, params object[] args)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(format, args);
        Console.ResetColor();
    }

    public static void WriteLine(ConsoleColor color, string value)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(value);
        Console.ResetColor();
    }

    public static void WriteLine(string format, params object[] args)
    {
        Console.WriteLine(format, args);
    }
        
    public static void Write(string format, params object[] args)
    {
        Console.Write(format, args);
    }

    public static void DisplayPrompt(string format, params object[] args)
    {
        format = format.Trim() + " ";
        Console.Write(format, args);
    }
    
    public static void DisplayPrompt(ConsoleColor color, string format, params object[] args)
    {
        Console.ForegroundColor = color;
        format = format.Trim() + " ";
        Console.Write(format, args);
    }
}