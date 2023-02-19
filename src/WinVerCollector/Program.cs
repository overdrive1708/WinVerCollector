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
                Display.WriteLine(Properties.Resources.MessageNowOutputting);
                Database.Output();
                Display.WriteLine(Properties.Resources.MessageComplete);
            }
            else if (opts.IsShowRequest)
            {
                Display.WriteLine(Properties.Resources.MessageNowOutputting);
                Database.Show();
                Display.WriteLine(Properties.Resources.MessageComplete);
            }
            else if (opts.IsCleanRequest)
            {
                Display.WriteLine(Properties.Resources.MessageNowCleaning);
                Database.Clean();
                Display.WriteLine(Properties.Resources.MessageComplete);
            }
            else
            {
                Display.WriteLine(Properties.Resources.MessageNowCollecting);
                Database.Collect();
                if (opts.IsVerboseRequest)
                {
                    Display.ShowDeviceInfo();
                }
                Display.WriteLine(Properties.Resources.MessageComplete);
                Display.WriteLine(Properties.Resources.MessageThanks);
            }
            Display.PauseReadKey();
        }

        private static void HandleParseError(IEnumerable<CommandLine.Error> errs)
        {
            // no action.
        }
    }
}
