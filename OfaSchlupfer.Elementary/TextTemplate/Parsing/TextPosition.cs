using System;

namespace OfaSchlupfer.TextTemplate.Parsing {
    public struct TextPosition : IEquatable<TextPosition> {
        public static readonly TextPosition Eof = new TextPosition(-1, -1, -1);   

        public TextPosition(int offset, int line, int column) {
            Offset = offset;
            Column = column;
            Line = line;
        }

        public int Offset { get; set; }

        public int Column { get; set; }

        public int Line { get; set; }

        public TextPosition NextColumn(int offset = 1) {
            return new TextPosition(Offset + offset, Line, Column + offset);
        }

        public TextPosition NextLine(int offset = 1) {
            return new TextPosition(Offset + offset, Line + offset, 0);
        }

        public override string ToString() {
            return $"({Offset}:{Line},{Column})";
        }

        public string ToStringSimple() {
            return $"{Line+1},{Column+1}";
        }

        public bool Equals(TextPosition other) {
            return Offset == other.Offset && Column == other.Column && Line == other.Line;
        }

        public override bool Equals(object obj) {
            if (obj is null) return false;
            return obj is TextPosition && Equals((TextPosition) obj);
        }

        public override int GetHashCode() {
            return Offset;
        }

        public static bool operator ==(TextPosition left, TextPosition right) {
            return left.Equals(right);
        }

        public static bool operator !=(TextPosition left, TextPosition right) {
            return !left.Equals(right);
        }
    }
}