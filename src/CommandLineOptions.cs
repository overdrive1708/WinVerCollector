namespace WinVerCollector
{
    internal class CommandLineOptions
    {
        [CommandLine.Option('o', "output", Required = false, HelpText = "Output collected version info.")]
        public bool IsOutputRequest { get => _isOutputRequest; set => _isOutputRequest = value; }
        private bool _isOutputRequest = false;

        [CommandLine.Option('c', "clean", Required = false, HelpText = "Clean database.")]
        public bool IsCleanRequest { get => _isCleanRequest; set => _isCleanRequest = value; }
        private bool _isCleanRequest = false;

        [CommandLine.Option('s', "silent", Required = false, HelpText = "Silent mode.")]
        public bool IsSilentRequest { get => _isSilentRequest; set => _isSilentRequest = value; }
        private bool _isSilentRequest = false;
    }
}
