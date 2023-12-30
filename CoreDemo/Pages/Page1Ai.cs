using EasyConsole;

namespace CoreDemo.Pages;

internal class Page1Ai : Page
{
    public Page1Ai(ConsoleBase console)
        : base("Page 1Ai", console)
    {
    }

    public override void Display()
    {
        base.Display();

        Output.WriteLine("Hello from Page 1Ai");

        Input.ReadString("Press [Enter] to navigate home");
        ConsoleBase.NavigateHome();
    }
}