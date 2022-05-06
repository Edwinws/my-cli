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

        var option = prog.menuService.getOptionInput();
        prog.menuService.getOptionInstance(option).Run();
    }

    private void displayMenu() {
        string[] menu = this.menuService.getMenuItems();

        for (int i = 0; i < menu.Count(); i++) {
            Console.WriteLine($"{i + 1}. {menu[i]}");
        }
    }
}
