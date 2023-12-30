using EasyConsole;

namespace CoreDemo.Pages;

internal class Page1 : MenuPage
{
    public Page1(ConsoleBase console)
        : base("Page 1", console,
            new Option("Page 1A", () => console.NavigateTo<Page1A>()),
            new Option("Page 1B", () => console.NavigateTo<Page1B>()))
    {
    }
}