using System;
using System.Text;

namespace OfaSchlupfer.TextTemplate.Parsing {
    public class LogMessage {
        public LogMessage(ParserMessageType type, SourceSpan span, string message) {
            Type = type;
            Span = span;
            Message = message;
        }

        public ParserMessageType Type { get; set; }

        public SourceSpan Span { get; set; }

        public string Message { get; set; }

        public override string ToString() {
            var builder = new StringBuilder();
            builder.Append(Span.ToStringSimple());
            builder.Append(" : ");
            builder.Append(Type.ToString().ToLowerInvariant());
            builder.Append(" : ");
            if (Message != null) {
                builder.Append(Message);
            }
            return builder.ToString();
        }
    }

    public enum ParserMessageType {
        Error,

        Warning,
    }
}