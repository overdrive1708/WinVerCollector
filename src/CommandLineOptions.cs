namespace WinVerCollector
{
    internal class CommandLineOptions
    {
        [CommandLine.Option('o', "output", Required = false, HelpText = "Output collected version info.")]
        public bool IsOutputRequest { get => _isOutputRequest; set => _isOutputRequest = value; }
        private bool _isOutputRequest = false;

        [CommandLine.Option('s', "show", Required = false, HelpText = "Display collected version info.")]
        public bool IsShowRequest { get => _isShowRequest; set => _isShowRequest = value; }
        private bool _isShowRequest = false;

        [CommandLine.Option('c', "clean", Required = false, HelpText = "Clean database.")]
        public bool IsCleanRequest { get => _isCleanRequest; set => _isCleanRequest = value; }
        private bool _isCleanRequest = false;

        [CommandLine.Option('q', "quiet", Required = false, HelpText = "Do not display processing results.")]
        public bool IsSilentRequest { get => _isSilentRequest; set => _isSilentRequest = value; }
        private bool _isSilentRequest = false;
    }
}
