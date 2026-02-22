using System;

namespace KooliProjekt.Application.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        public void DebugLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[DEBUG] {message}");
            Console.ResetColor();
        }

        public void ErrorLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }
    }
}
