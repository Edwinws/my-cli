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

        while (true) {
            prog.displayMenu();

            try {
                int? option = prog.menuService.getOptionInput();
                Console.WriteLine(option);
                if (option == null) {
                    continue;
                }
                var optionInstance = prog.menuService.getOptionInstance((int)option);
                optionInstance.Run();
            } catch (Exception e) {
                printError(e.Message);
            }
        }
    }

    private void displayMenu() {
        string[] menu = this.menuService.getMenuItems();

        for (int i = 0; i < menu.Count(); i++) {
            Console.WriteLine($"{i + 1}. {menu[i]}");
        }
    }

    private static void printError(string errorMessage) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {errorMessage}");
        Console.ResetColor();
    }
}
