using System.Diagnostics;

namespace EasyConsole;

public abstract class ConsoleBase
{
    private string Title { get; set; }

    public bool BreadcrumbHeader { get; private set; }

    protected Page CurrentPage => (History.Any()) ? History.Peek() : null;

    private Dictionary<Type, Page> Pages { get; set; }

    public Stack<Page> History { get; private set; }

    public bool NavigationEnabled => History.Count > 1;

    protected ConsoleBase(string title, bool breadcrumbHeader)
    {
        Title = title;
        Pages = new Dictionary<Type, Page>();
        History = new Stack<Page>();
        BreadcrumbHeader = breadcrumbHeader;
    }

    public virtual void Run()
    {
        try
        {
            Console.Title = Title;

            if (CurrentPage == null) 
            {
                throw new ArgumentNullException(nameof(CurrentPage), "CurrentPage is null. Did you forget to call SetPage<>()?");    
            }
                
            CurrentPage.Display();
        }
        catch (Exception e)
        {
            Output.WriteLine(ConsoleColor.Red, e.ToString());
        }
        finally
        {
            if (Debugger.IsAttached)
            {
                Input.ReadString("Press [Enter] to exit");
            }
        }
    }

    protected void AddPage(Page page)
    {
        var pageType = page.GetType();

        if (Pages.ContainsKey(pageType))
            Pages[pageType] = page;
        else
            Pages.Add(pageType, page);
    }

    public void NavigateHome()
    {
        while (History.Count > 1)
            History.Pop();
        
        // Console.Clear();
        CreateDivide();
        CurrentPage.Display();
    }

    protected T SetPage<T>() where T : Page
    {
        var pageType = typeof(T);

        if (CurrentPage != null && CurrentPage.GetType() == pageType)
            return CurrentPage as T;

        // leave the current page

        // select the new page
        if (!Pages.TryGetValue(pageType, out var nextPage))
            throw new KeyNotFoundException("The given page \"{0}\" was not present in the program".Format(pageType));

        // enter the new page
        History.Push(nextPage);

        return CurrentPage as T;
    }

    public T NavigateTo<T>() 
        where T : Page
    {
        SetPage<T>();

        // Console.Clear();
        CreateDivide();
        CurrentPage.Display();
        return CurrentPage as T;
    }

    public Page NavigateBack()
    {
        History.Pop();

        // Console.Clear();
        CreateDivide();
        CurrentPage.Display();
        return CurrentPage;
    }
    
    private static void CreateDivide()
    {
        Console.Clear();
        //Output.WriteLine(ConsoleColor.Gray, "-----------------------------------------------------------------------------------------------------------");
    }
}