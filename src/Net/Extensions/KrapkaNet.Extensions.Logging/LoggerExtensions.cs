using Microsoft.Extensions.Logging;

namespace KrapkaNet.Extensions.Logging
{
    public static class LoggerExtensions
    {
        public static void Info(this ILogger logger, string message)
        {
            logger.LogInformation(message);
        }
    }
}