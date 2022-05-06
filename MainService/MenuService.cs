using System;

namespace MainService;
public class MenuService {
    protected Dictionary<string, string> menu = new Dictionary<string, string> {
        {"FileReadWrite1", "File Reading / Writing example" },
        {"ApiCall", "Calling an API"},
    };

    public string[] getMenuItems() {
        return menu.Select(x => $"{x.Key} - {x.Value}").ToArray();
    }

    public IConsoleOption? getOptionInstance(int option) {
        Type? type = Type.GetType(menu.ElementAt(option - 1).Key);
        if (type == null) {
            throw new Exception($"Failed to instantiate {menu.ElementAt(option - 1).Key} class.");
        }
        var instance = (IConsoleOption?)Activator.CreateInstance(type!);
        return instance!;
    }

    public string getOptionInput() {
        Console.Write("Select a menu item: ");
        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine();

        return key.KeyChar.ToString();
    }
}

