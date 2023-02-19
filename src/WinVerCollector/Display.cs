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

        internal static void WriteErrorLine(string line)
        {
            if (!IsSilentRequest)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(line);
                Console.ResetColor();
            }
        }

        internal static void PauseReadKey()
        {
            if (!IsSilentRequest)
            {
                Console.WriteLine(Properties.Resources.MessagePause);
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
                WriteLine($"{Properties.Resources.StringHostName}:{DeviceInfo.GetHostName()}");
                WriteLine($"{Properties.Resources.StringProductName}:{DeviceInfo.GetProductName()}");
                WriteLine($"{Properties.Resources.StringVersion}:{DeviceInfo.GetVersion()}");
                WriteLine($"{Properties.Resources.StringUserName}:{DeviceInfo.GetUserName()}");
                WriteLine("--------------------------------------------------");
            }
        }
    }
}
