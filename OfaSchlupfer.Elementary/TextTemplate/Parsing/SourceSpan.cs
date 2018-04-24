namespace OfaSchlupfer.TextTemplate.Parsing {
    /// <summary>
    /// Defines the precise source location.
    /// </summary>
    public struct SourceSpan {
        public SourceSpan(string fileName, TextPosition start, TextPosition end) {
            FileName = fileName;
            Start = start;
            End = end;
        }

        public string FileName { get; set; }

        public TextPosition Start { get; set; }

        public TextPosition End { get; set; }

        public override string ToString() {
            return $"{FileName}({Start})-({End})";
        }

        public string ToStringSimple() {
            return $"{FileName}({Start.ToStringSimple()})";
        }
    }
}