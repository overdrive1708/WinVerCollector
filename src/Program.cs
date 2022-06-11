using CommandLine;
using System.Reflection;

namespace WinVerCollector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _ = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                    .WithParsed(HandleParseSuccess)
                    .WithNotParsed(HandleParseError);
        }

        private static void HandleParseSuccess(CommandLineOptions opts)
        {
            Assembly assm = Assembly.GetExecutingAssembly();
            string? product = assm?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            string? version = assm?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

            if (opts.IsOutputRequest)
            {
                ConsoleWriteLine(opts.IsSilentRequest, $"Welcome to {product} Ver.{version} !!");
                ConsoleWriteLine(opts.IsSilentRequest, "Now outputting...");
                Database.Output();
                ConsoleWriteLine(opts.IsSilentRequest, "Completed.");
                ConsoleWriteLine(opts.IsSilentRequest, "Please enter any key.");
                ConsoleReadKey(opts.IsSilentRequest);
            }
            else if (opts.IsCleanRequest)
            {
                ConsoleWriteLine(opts.IsSilentRequest, $"Welcome to {product} Ver.{version} !!");
                ConsoleWriteLine(opts.IsSilentRequest, "Now cleaning...");
                Database.Clean();
                ConsoleWriteLine(opts.IsSilentRequest, "Completed.");
                ConsoleWriteLine(opts.IsSilentRequest, "Please enter any key.");
                ConsoleReadKey(opts.IsSilentRequest);
            }
            else
            {
                ConsoleWriteLine(opts.IsSilentRequest, $"Welcome to {product} Ver.{version} !!");
                ConsoleWriteLine(opts.IsSilentRequest, "Now collecting...");
                Database.Collect();
                ConsoleWriteLine(opts.IsSilentRequest, "Completed.");
                ConsoleWriteLine(opts.IsSilentRequest, "Thank you for cooperation.");
                ConsoleWriteLine(opts.IsSilentRequest, "Please enter any key.");
                ConsoleReadKey(opts.IsSilentRequest);
            }
        }

        private static void HandleParseError(IEnumerable<CommandLine.Error> errs)
        {
            // no action.
        }

        private static void ConsoleWriteLine(bool isSilentRequest, string line)
        {
            if (isSilentRequest)
            {
                return;
            }
            Console.WriteLine(line);
        }

        private static void ConsoleReadKey(bool isSilentRequest)
        {
            if (isSilentRequest)
            {
                return;
            }
            Console.ReadKey();
        }
    }
}
