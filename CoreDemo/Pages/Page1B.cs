using EasyConsole;

namespace CoreDemo.Pages;

internal class Page1B : Page
{
    public Page1B(ConsoleBase console)
        : base("Page 1B", console)
    {
    }

    public override void Display()
    {
        base.Display();

        Output.WriteLine("Hello from Page 1B");

        Input.ReadString("Press [Enter] to navigate home");
        ConsoleBase.NavigateHome();
    }
}