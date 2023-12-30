namespace EasyConsole;

public class Menu
{
    private IList<Option> Options { get; set; } = new List<Option>();

    public void Display()
    {
        var lasts = Options.Where(w => w.IsLast).ToList();
        var different = Options.Except(lasts).ToList();
        different.AddRange(lasts);
        Options = different;
            
        for (var i = 0; i < Options.Count; i++)
        {
            var item = Options[i];

            if (item.Color == null)
            {
                Console.WriteLine("{0}. {1}", i + 1, item.Name);
            }
            else
            {
                Output.WriteLine(item.Color.Value, $"{i + 1}. {item.Name}");
            }
        }

        var choice = Input.ReadInt("Choose an option:", min: 1, max: Options.Count);

        Options[choice - 1].Callback();
    }

    public Menu Add(string option, Action callback)
    {
        return Add(new Option(option, callback));
    }

    public Menu Add(Option option)
    {
        Options.Add(option);

        return this;
    }

    public bool Contains(string option)
    {
        return Options.FirstOrDefault((op) => op.Name.Equals(option)) != null;
    }
}