namespace EasyConsole;

public abstract class MenuPage : Page
{
    private Menu Menu { get; set; }

    protected MenuPage(string title, ConsoleBase consoleBase, params Option[] options)
        : base(title, consoleBase)
    {
        Menu = new Menu();

        foreach (var option in options)
        {
            Menu.Add(option);
        }
    }

    public override void Display()
    {
        base.Display();

        if (ConsoleBase.NavigationEnabled && !Menu.Contains("Go back"))
        {
            Menu.Add(new Option(ConsoleColor.Cyan ,"Go back", () => { ConsoleBase.NavigateBack(); }));
        }

        Menu.Display();
    }

    protected override void AddHomeOption()
    {
        if (ConsoleBase.NavigationEnabled && !Menu.Contains("Go home"))
        {
            Menu.Add(new Option(ConsoleColor.DarkCyan ,"Go home", () => { ConsoleBase.NavigateHome(); }, true));
        }
    }
}