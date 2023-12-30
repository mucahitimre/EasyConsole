using EasyConsole;

namespace CoreDemo.Pages;

internal class Page2 : Page
{
    public Page2(ConsoleBase console)
        : base("Page 2", console)
    {
    }

    public override void Display()
    {
        base.Display();

        Output.WriteLine("Hello from Page 2");

        Input.ReadString("Press [Enter] to navigate home");
        ConsoleBase.NavigateHome();
    }
}