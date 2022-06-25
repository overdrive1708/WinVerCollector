using Microsoft.Win32;
using System.Net;

namespace WinVerCollector
{
    internal class DeviceInfo
    {
        // Registry access configurations.
        private static readonly string _keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        private static readonly string _valueNameOsBuild = "CurrentBuild";
        private static readonly string _valueNameOsProductName = "ProductName";

        public static string GetHostName() => Dns.GetHostName();

        public static string GetUserName() => @$"{Environment.UserDomainName}\{Environment.UserName}";

        public static string? GetProductName() => Registry.GetValue(_keyName, _valueNameOsProductName, "")?.ToString();

        public static string GetVersion()
        {
            // Convert OS Build => Version. e.g. OS Build:19044 => Version:21H2
            string version;

            string? osBuildString = Registry.GetValue(_keyName, _valueNameOsBuild, "")?.ToString();

            if(int.TryParse(osBuildString, out int osBuildNum))
            {
                version = osBuildNum switch
                {
                    10240 => "1507",
                    10586 => "1511",
                    14393 => "1607",
                    15063 => "1703",
                    16299 => "1709",
                    17134 => "1803",
                    17763 => "1809",
                    18362 => "1903",
                    18363 => "1909",
                    19041 => "2004",
                    19042 => "20H2",
                    19043 => "21H1",
                    19044 => "21H2",
                    _ => $"Unknown(OS Build:{osBuildNum})"
                };
            }
            else
            {
                version = "Unknown";
            }

            return version;
        }

        public static void Show()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"HostName:{GetHostName()}");
            Console.WriteLine($"ProductName:{GetProductName()}");
            Console.WriteLine($"Version:{GetVersion()}");
            Console.WriteLine($"UserName:{GetUserName()}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
