using System;

namespace MainService;
class Program {
    static void Main(string[] args) {
        var prog = new Program();
        // prog.displaySplashArt();
        prog.displayMenu();

        var option = prog.getOptionInput();
        prog.getOptionInstance(option).Run();
    }

    private void displayMenu() {
        Console.WriteLine("Menu goes here");
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
