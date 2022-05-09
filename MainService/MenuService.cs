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

    public IConsoleOption getOptionInstance(int option) {
        Type? type;

        try {
            type = Type.GetType(menu.ElementAt(option - 1).Key);
        } catch (ArgumentOutOfRangeException) {
            throw new Exception($"{option} is not a valid option.");
        }

        if (type == null) {
            throw new Exception($"Failed to instantiate {menu.ElementAt(option - 1).Key} class.");
        }

        var instance = (IConsoleOption?)Activator.CreateInstance(type!);
        if (instance == null) {
            throw new Exception($"Failed to instantiate {menu.ElementAt(option - 1).Key} class.");
        }

        return instance;
    }

    public int? getOptionInput() {
        Console.Write("Select a menu item: ");
        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine();

        try {
            var optionInput = Int32.Parse(key.KeyChar.ToString());
            return optionInput;
        } catch (FormatException) {
            throw new Exception(key.KeyChar.ToString() + " is not a valid option input.");
        };
    }
}

