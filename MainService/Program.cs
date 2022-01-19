using System;

namespace MainService;
class Program {
    protected readonly MenuService menuService;

    public Program(MenuService menuService) {
        this.menuService = menuService;
    }
    static void Main(string[] args) {
        var prog = new Program(new MenuService());
        // prog.displaySplashArt();
        prog.displayMenu();

        var option = prog.getOptionInput();
        prog.getOptionInstance(option).Run();
    }

    private void displayMenu() {
        string[] menu = this.menuService.getMenuItems();

        for (int i = 0; i < menu.Count(); i++) {
            Console.WriteLine($"{i + 1}. {menu[i]}");
        }
    }

    private int getOptionInput() {
        return 0;
    }

    private IConsoleOption getOptionInstance(int option) {
        string[] classMapping = {
            "FileReadWrite1",
        };

        Type? type = Type.GetType(classMapping[option]);
        var instance = (IConsoleOption?)Activator.CreateInstance(type!);

        return instance!;
    }
}
