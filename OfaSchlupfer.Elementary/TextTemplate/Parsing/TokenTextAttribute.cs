using System;

namespace OfaSchlupfer.TextTemplate.Parsing {
    [AttributeUsage(AttributeTargets.Field)]
    internal class TokenTextAttribute : Attribute {
        public TokenTextAttribute(string text) {
            Text = text;
        }

        public string Text { get; }
    }
}