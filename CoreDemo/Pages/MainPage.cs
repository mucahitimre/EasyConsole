using EasyConsole;

namespace CoreDemo.Pages;

internal class MainPage : MenuPage
{
    public MainPage(ConsoleBase console)
        : base("Main Page", console,
            new Option("Page 1", () => console.NavigateTo<Page1>()),
            new Option("Page 2", () => console.NavigateTo<Page2>()),
            new Option("Input", () => console.NavigateTo<InputPage>()))
    {
    }
}