namespace OfaSchlupfer.CollaborationTests {
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json.Serialization;
    using Xunit.Abstractions;

    public class XunitTraceWriter : ITraceWriter {
        private ITestOutputHelper output;

        public XunitTraceWriter(ITestOutputHelper output) {
            this.output = output;
            this.LevelFilter = TraceLevel.Verbose;
        }

        public TraceLevel LevelFilter {
            get;set;
        }

        public void Trace(TraceLevel level, string message, Exception ex) {
            if (ex is null) {
                output.WriteLine($"{level} - {message}");
            } else {
                output.WriteLine($"{level} - {message} - {ex.ToString()}");
            }
        }
    }
}