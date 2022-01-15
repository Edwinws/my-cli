using System.Runtime.Remoting;

namespace MyCli;
class Program {
    static void Main(string[] args) {
        var prog = new Program();
        // prog.displaySplashArt();
        prog.getOptionInstance().Run();
    }

    private IConsoleOption getOptionInstance() {
        var classMapping = new Dictionary<string, string>() {
            {"FileReadWrite1", "FileReadWrite1"},
        };

        Type? type = Type.GetType("FileReadWrite1");
        if (type == null) {
            throw new Exception("Class is invalid.");
        }
        var instance = (IConsoleOption?)Activator.CreateInstance(type!);

        return instance!;
    }
}
