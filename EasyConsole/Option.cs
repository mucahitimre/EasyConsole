namespace EasyConsole;

public class Option
{
    public string Name { get; }
    public ConsoleColor? Color { get; private set; }
    public bool IsLast { get; private set; }
    public Action Callback { get; private set; }

    public Option(string name, Action callback, bool isLast = false)
        : this(null, name, callback, isLast)
    {
    }

    public Option(ConsoleColor? color, string name, Action callback, bool isLast = false)
    {
        Name = name;
        Color = color;
        IsLast = isLast;
        Callback = callback;
    }
        
    public override string ToString()
    {
        return Name;
    }
}