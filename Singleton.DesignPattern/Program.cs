using System.Data;

namespace Singleton.DesignPattern;

public class Program
{
    static void Main(string[] args)
    {
        var config1 = JwtSettingsLazyManual.GetConfiguration();
        var config2 = JwtSettingsLazyManual.GetConfiguration();

        // var config1 = JwtSettingsLazyAttr.GetConfiguration();
        // var config2 = JwtSettingsLazyAttr.GetConfiguration();

        // var config1 = JwtSettingsEager.GetConfiguration();
        // var config2 = JwtSettingsEager.GetConfiguration();

        Console.WriteLine(ReferenceEquals(config1, config2)); // True
    }
}

