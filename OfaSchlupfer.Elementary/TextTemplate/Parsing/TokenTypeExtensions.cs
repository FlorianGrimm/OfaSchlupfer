using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OfaSchlupfer.TextTemplate.Helpers;

namespace OfaSchlupfer.TextTemplate.Parsing {
    public static class TokenTypeExtensions {
        private static readonly Dictionary<TokenType, string> TokenTexts = new Dictionary<TokenType, string>();

        static TokenTypeExtensions() {
            foreach (var field in typeof(TokenType).GetTypeInfo().GetDeclaredFields().Where(field => field.IsPublic && field.IsStatic)) {
                var tokenText = field.GetCustomAttribute<TokenTextAttribute>();
                if (tokenText != null) {
                    var type = (TokenType) field.GetValue(null);
                    TokenTexts.Add(type, tokenText.Text);
                }
            }
        }

        public static bool HasText(this TokenType type) {
            return TokenTexts.ContainsKey(type);
        }

        public static string ToText(this TokenType type) {
            string value;
            TokenTexts.TryGetValue(type, out value);
            return value;
        }
    }
}