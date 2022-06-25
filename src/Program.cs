using CommandLine;

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
            Display.IsSilentRequest = opts.IsSilentRequest;

            Display.ShowWelcomeMessage();

            if (opts.IsOutputRequest)
            {
                Display.WriteLine("Now outputting...");
                Database.Output();
                Display.WriteLine("Completed.");
            }
            else if (opts.IsShowRequest)
            {
                Database.Show();
            }
            else if (opts.IsCleanRequest)
            {
                Display.WriteLine("Now cleaning...");
                Database.Clean();
                Display.WriteLine("Completed.");
            }
            else
            {
                Display.WriteLine("Now collecting...");
                Database.Collect();
                if (opts.IsVerboseRequest)
                {
                    Display.ShowDeviceInfo();
                }
                Display.WriteLine("Completed.");
                Display.WriteLine("Thank you for cooperation.");
            }
            Display.PauseReadKey();
        }

        private static void HandleParseError(IEnumerable<CommandLine.Error> errs)
        {
            // no action.
        }
    }
}
