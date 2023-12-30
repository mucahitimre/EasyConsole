using EasyConsole;

namespace CoreDemo.Pages;

internal class Page1A : MenuPage
{
    public Page1A(ConsoleBase console)
        : base("Page 1A", console,
            new Option("Page 1Ai", () => console.NavigateTo<Page1Ai>()))
    {
    }
}