using System.Diagnostics;
using System.Text;

namespace prog2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            var watch = new Stopwatch();
            watch.Start();

            for (var i = 0; i < 1000; i++)
            {
                logger.Info("See on informatiivne teade");
                logger.Debug("See on debuggeri teade");
                logger.Warn("See on hoiatus teade");
                logger.Error("See on probleemne teade");
            }

            watch.Stop();
            Debug.WriteLine(watch.Elapsed);
        }
    }

    public interface ILogger
    {
        public void Debug(string message);
        public void Info(string message);
        public void Warn(string message);
        public void Error(string message);
    }

    public abstract class BaseLogger : ILogger
    {
        public virtual void Debug(string message)
        {
            Write("Debug", message);
        }

        public virtual void Error(string message)
        {
            Write("Error", message);
        }

        public virtual void Info(string message)
        {
            Write("Info", message);
        }

        public virtual void Warn(string message)
        {
            Write("Warn", message);
        }

        protected string FormatLog(string logLevel, string message)
        {
            if (message == null)
            {
                return null;
            }

            var builder = new StringBuilder(message.Length + 30);
            builder.Append(DateTime.Now);
            builder.Append(" ");
            builder.Append(logLevel.ToUpper());
            builder.Append(": ");
            builder.AppendLine(message);

            return builder.ToString();
        }

        protected abstract void Write(string logLevel, string message);
    }

    public class NullLogger : BaseLogger
    {
        protected override void Write(string logLevel, string message)
        {
        }
    }

    public class DebugLogger : BaseLogger
    {
        protected override void Write(string logLevel, string message)
        {
            var logMessage = FormatLog(logLevel, message);

            System.Diagnostics.Debug.WriteLine(logMessage);
        }
    }

    public class ConsoleLogger : BaseLogger
    {
        protected override void Write(string logLevel, string message)
        {
            var logMessage = FormatLog(logLevel, message);

    
            var originalColor = Console.ForegroundColor;

            switch (logLevel.ToLower())
            {
                case "warn":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "error":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine(logMessage);
            Console.ForegroundColor = originalColor;
        }
    }

}