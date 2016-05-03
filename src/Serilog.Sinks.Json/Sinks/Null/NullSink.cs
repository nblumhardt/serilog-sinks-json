using Serilog.Core;
using Serilog.Events;

namespace Serilog.Sinks.Null
{
    class NullSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
        }
    }
}

