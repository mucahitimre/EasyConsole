using EasyConsole;

namespace CoreDemo.Pages;

internal class InputPage : Page
{
    public InputPage(ConsoleBase console)
        : base("Input", console)
    {
    }

    public override void Display()
    {
        base.Display();

        Fruit input = Input.ReadEnum<Fruit>("Select a fruit");
        Output.WriteLine(ConsoleColor.Green, "You selected {0}", input);

        Input.ReadString("Press [Enter] to navigate home");
        ConsoleBase.NavigateHome();
    }
}

internal enum Fruit
{
    Apple,
    Banana,
    Coconut
}