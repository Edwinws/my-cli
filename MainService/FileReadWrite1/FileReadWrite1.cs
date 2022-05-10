/// <summary>
/// Checks (and creates) the storage folder, and simply write and read from a file contained within
/// </summary>
class FileReadWrite1 : IConsoleOption {
    string storageFolder;

    public FileReadWrite1() {
        string[] paths = {
            // e.g: /Users/edwinws/Documents/repositories/my-cli
            Directory.GetCurrentDirectory(),
            "MainService",
            "FileReadWrite1",
            "storage"
        };
        this.storageFolder = Path.Combine(paths);
    }

    public void Run() {
        this.prepareStorageFolder();
        this.writeFile();
        this.readFile();
        this.cleanUpFile();
    }

    private void prepareStorageFolder() {
        Console.WriteLine("Checking if storage folder exists...");
        var directoryExists = Directory.Exists(this.storageFolder);
        if (!directoryExists) {
            Console.WriteLine("Storage folder does not exist; creating...");
            Directory.CreateDirectory(this.storageFolder);
        }

        Console.WriteLine($"Storage folder {this.storageFolder} exists.");
    }

    private void writeFile() {
        var path = Path.Combine(this.storageFolder, "File.txt");
        var textToWrite = "Lorem Ipsum";

        Console.WriteLine($"Writing the text \"{textToWrite}\" into {path}...");
        File.WriteAllText(path, textToWrite);
    }

    private void readFile() {
        var path = Path.Combine(this.storageFolder, "File.txt");

        Console.WriteLine($"Reading {path}...");
        Console.WriteLine("File Contents: " + File.ReadAllText(path));
    }

    private void cleanUpFile() {
        Console.WriteLine("Deleting generated file...");
        File.Delete(Path.Combine(this.storageFolder, "File.txt"));
    }
}
