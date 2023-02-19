namespace WinVerCollector
{
    internal class CommandLineOptions
    {
        [CommandLine.Option('o', "output", Required = false, HelpText = "HelpTextOutput", ResourceType = typeof(Properties.Resources))]
        public bool IsOutputRequest { get => _isOutputRequest; set => _isOutputRequest = value; }
        private bool _isOutputRequest = false;

        [CommandLine.Option('s', "show", Required = false, HelpText = "HelpTextShow", ResourceType = typeof(Properties.Resources))]
        public bool IsShowRequest { get => _isShowRequest; set => _isShowRequest = value; }
        private bool _isShowRequest = false;

        [CommandLine.Option('c', "clean", Required = false, HelpText = "HelpTextClean", ResourceType = typeof(Properties.Resources))]
        public bool IsCleanRequest { get => _isCleanRequest; set => _isCleanRequest = value; }
        private bool _isCleanRequest = false;

        [CommandLine.Option('q', "quiet", Required = false, HelpText = "HelpTextQuiet", ResourceType = typeof(Properties.Resources))]
        public bool IsSilentRequest { get => _isSilentRequest; set => _isSilentRequest = value; }
        private bool _isSilentRequest = false;

        [CommandLine.Option('v', "verbose", Required = false, HelpText = "HelpTextVerbose", ResourceType = typeof(Properties.Resources))]
        public bool IsVerboseRequest { get => _isVerboseRequest; set => _isVerboseRequest = value; }
        private bool _isVerboseRequest = false;
    }
}
