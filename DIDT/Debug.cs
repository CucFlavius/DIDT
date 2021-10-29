using System;

namespace DIDT
{
    public static class Debug
    {
        private static IProgress<string> _log;

        static int logLine = 0;

        public static void Initialize(IProgress<string> log)
        {
            _log = log;
        }

        public static void Log(string text)
        {
            _log.Report(text);
            logLine++;
        }
    }
}
