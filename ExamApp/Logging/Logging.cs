using System.Diagnostics;
using System.IO;

namespace ExamApp
{
    public class Logging : ILogging
    {
        public void Debug(string message)
        {
            string filepath = "<FilePath>";
            File.WriteAllText(filepath,message);
        }

        public void Error(string message)
        {
            Trace.TraceError(message);
        }

        public void Info(string message)
        {
            string filepath = "<FilePath>";
            File.WriteAllText(filepath, message);
        }

        public void Warning(string message)
        {
            Trace.TraceError(message);
        }
    }
}
