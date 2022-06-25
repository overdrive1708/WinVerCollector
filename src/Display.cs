using System.Reflection;

namespace WinVerCollector
{
    internal class Display
    {
        static private bool _isSilentRequest = false;
        static public bool IsSilentRequest { get => _isSilentRequest; set => _isSilentRequest = value; }

        internal static void WriteLine(string line)
        {
            if (!IsSilentRequest)
            {
                Console.WriteLine(line);
            }
        }

        internal static void PauseReadKey()
        {
            if (!IsSilentRequest)
            {
                Console.WriteLine("Please enter any key.");
                _ = Console.ReadKey();
            }
        }

        internal static void ShowWelcomeMessage()
        {
            if (!IsSilentRequest)
            {
                Assembly assm = Assembly.GetExecutingAssembly();
                string? product = assm?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
                string? version = assm?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

                WriteLine($"Welcome to {product} Ver.{version} !!");
            }
        }

        internal static void ShowDeviceInfo()
        {
            if (!IsSilentRequest)
            {
                WriteLine("--------------------------------------------------");
                WriteLine($"HostName:{DeviceInfo.GetHostName()}");
                WriteLine($"ProductName:{DeviceInfo.GetProductName()}");
                WriteLine($"Version:{DeviceInfo.GetVersion()}");
                WriteLine($"UserName:{DeviceInfo.GetUserName()}");
                WriteLine("--------------------------------------------------");
            }
        }
    }
}
