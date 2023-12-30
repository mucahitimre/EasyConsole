namespace EasyConsole;

public abstract class Page
{
    private string Title { get; set; }

    protected ConsoleBase ConsoleBase { get; set; }

    protected Page(string title, ConsoleBase consoleBase)
    {
        Title = title;
        ConsoleBase = consoleBase;
    }

    public virtual void Display()
    {
        if (ConsoleBase.History.Count > 1 && ConsoleBase.BreadcrumbHeader)
        {
            string breadcrumb = null;
            foreach (var title in ConsoleBase.History.Select((page) => page.Title).Reverse())
            {
                breadcrumb += title + " > ";
            }

            if (breadcrumb != null)
            {
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);
                Console.WriteLine(breadcrumb);
            }
        }
        else
        {
            Console.WriteLine(Title);
        }
        Console.WriteLine("---");
    }

    protected virtual void AddHomeOption()
    {
        Input.ReadString("Press [Enter] to navigate home");
        ConsoleBase.NavigateHome();
    }
}