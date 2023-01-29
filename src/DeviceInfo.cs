using Microsoft.Win32;
using System.Net;
using System.Management;

namespace WinVerCollector
{
    internal class DeviceInfo
    {
        // Registry access configurations.
        private static readonly string _keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        private static readonly string _valueNameOsBuild = "CurrentBuild";

        public static string GetHostName() => Dns.GetHostName();

        public static string GetUserName() => @$"{Environment.UserDomainName}\{Environment.UserName}";

        public static string GetProductName()
        {
            string? productName = Properties.Resources.StringUnknown;

            ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                productName = mo["Caption"]?.ToString();
            }

            return productName;
        }

        public static string GetVersion()
        {
            // Convert OS Build => Version. e.g. OS Build:19044 => Version:21H2
            string version;

            string? osBuildString = Registry.GetValue(_keyName, _valueNameOsBuild, "")?.ToString();

            if(int.TryParse(osBuildString, out int osBuildNum))
            {
                if (GetProductName().Contains("Windows 10"))
                {
                    version = ConvertWin10BuildToVersion(osBuildNum);
                }
                else if (GetProductName().Contains("Windows 11"))
                {
                    version = ConvertWin11BuildToVersion(osBuildNum);
                }
                else
                {
                    version = Properties.Resources.StringUnknown;
                }
            }
            else
            {
                version = Properties.Resources.StringUnknown;
            }

            return version;
        }

        private static string ConvertWin10BuildToVersion(int osBuildNum)
        {
            string version = osBuildNum switch
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
                _ => $"{Properties.Resources.StringUnknown}(OS Build:{osBuildNum})"
            };

            return version;
        }

        private static string ConvertWin11BuildToVersion(int osBuildNum)
        {
            string version = osBuildNum switch
            {
                22000 => "21H2",
                22621 => "22H2",
                _ => $"{Properties.Resources.StringUnknown}(OS Build:{osBuildNum})"
            };

            return version;
        }
    }
}
