public class Program
{
    public static void Main(string[] args)
    {
        var root = new Folder("Root");
        root.Elements.Add(new File("file1.txt", 1200));
        root.Elements.Add(new File("file2.txt", 3400));

        var sub = new Folder("SubFolder");
        sub.Elements.Add(new File("file3.txt", 5600));
        root.Elements.Add(sub);

        var sizeCalculator = new SizeCalculatorVisitor();
        root.Accept(sizeCalculator);
        Console.WriteLine($"Total size of files: {sizeCalculator.TotalSize} bytes");   
    }
}
