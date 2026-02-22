namespace KooliProjekt.Application.Infrastructure.Logging
{
    public interface ILogger
    {
        public void DebugLog(string message);
        public void ErrorLog(string message);
    }
}
