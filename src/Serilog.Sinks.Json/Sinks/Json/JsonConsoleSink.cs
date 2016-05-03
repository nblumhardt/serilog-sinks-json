using System;
using System.IO;
using Serilog.Events;
using Serilog.Core;
using Serilog.Formatting;

namespace Serilog.Sinks.Json
{
    class JsonConsoleSink : ILogEventSink
    {
        readonly ITextFormatter _textFormatter;

        public JsonConsoleSink(ITextFormatter textFormatter)
        {
            if (textFormatter == null) throw new ArgumentNullException(nameof(textFormatter));
            _textFormatter = textFormatter;
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            var renderSpace = new StringWriter();
            _textFormatter.Format(logEvent, renderSpace);
            Console.Out.Write(renderSpace.ToString());
        }
    }
}
