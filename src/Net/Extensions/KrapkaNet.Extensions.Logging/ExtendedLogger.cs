using Microsoft.Extensions.Logging;

namespace KrapkaNet.Extensions.Logging
{
    public class ExtendedLogger<T>: Logger<T>, IExtendedLogger
    {
        public ExtendedLogger(ILoggerFactory factory) : base(factory)
        {
        }

        public string TraceId { get; set; }
    }
}