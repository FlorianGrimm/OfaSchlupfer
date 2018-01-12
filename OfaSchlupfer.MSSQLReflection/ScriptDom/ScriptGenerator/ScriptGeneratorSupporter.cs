namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;

    internal static class ScriptGeneratorSupporter {
        internal const string EscapedRSquareParen = "]]";

        internal const string EscapedQuote = "\"\"";

        internal const string Quote = "\"";

        private static string[] _typeStrings = new string[240]
        {
            "",
            "",
            "",
            "",
            "add",
            "all",
            "alter",
            "and",
            "any",
            "as",
            "asc",
            "authorization",
            "backup",
            "begin",
            "between",
            "break",
            "browse",
            "bulk",
            "by",
            "cascade",
            "case",
            "check",
            "checkpoint",
            "close",
            "clustered",
            "coalesce",
            "collate",
            "column",
            "commit",
            "compute",
            "constraint",
            "contains",
            "containstable",
            "continue",
            "convert",
            "create",
            "cross",
            "current",
            "current_date",
            "current_time",
            "current_timestamp",
            "current_user",
            "cursor",
            "database",
            "dbcc",
            "deallocate",
            "declare",
            "default",
            "delete",
            "deny",
            "desc",
            "distinct",
            "distributed",
            "double",
            "drop",
            "else",
            "end",
            "errlvl",
            "escape",
            "except",
            "exec",
            "execute",
            "exists",
            "exit",
            "fetch",
            "file",
            "fillfactor",
            "for",
            "foreign",
            "freetext",
            "freetexttable",
            "from",
            "full",
            "function",
            "goto",
            "grant",
            "group",
            "having",
            "holdlock",
            "identity",
            "identity_insert",
            "identitycol",
            "if",
            "in",
            "index",
            "inner",
            "insert",
            "intersect",
            "into",
            "is",
            "join",
            "key",
            "kill",
            "left",
            "like",
            "lineno",
            "national",
            "nocheck",
            "nonclustered",
            "not",
            "null",
            "nullif",
            "of",
            "off",
            "offsets",
            "on",
            "open",
            "opendatasource",
            "openquery",
            "openrowset",
            "openxml",
            "option",
            "or",
            "order",
            "outer",
            "over",
            "percent",
            "plan",
            "primary",
            "print",
            "proc",
            "procedure",
            "public",
            "raiserror",
            "read",
            "readtext",
            "reconfigure",
            "references",
            "replication",
            "restore",
            "restrict",
            "return",
            "revoke",
            "right",
            "rollback",
            "rowcount",
            "rowguidcol",
            "rule",
            "save",
            "schema",
            "select",
            "session_user",
            "set",
            "setuser",
            "shutdown",
            "some",
            "statistics",
            "system_user",
            "table",
            "textsize",
            "then",
            "to",
            "top",
            "tran",
            "transaction",
            "trigger",
            "truncate",
            "tsequal",
            "union",
            "unique",
            "update",
            "updatetext",
            "use",
            "user",
            "values",
            "varying",
            "view",
            "waitfor",
            "when",
            "where",
            "while",
            "with",
            "writetext",
            "disk",
            "precision",
            "external",
            "revert",
            "pivot",
            "unpivot",
            "tablesample",
            "dump",
            "load",
            "merge",
            "stoplist",
            "semantickeyphrasetable",
            "semanticsimilaritytable",
            "semanticsimilaritydetailstable",
            "try_convert",
            "!",
            "%",
            "&",
            "(",
            ")",
            "{",
            "}",
            "*",
            "*=",
            "+",
            ",",
            "-",
            ".",
            "/",
            ":",
            "::",
            ";",
            "<",
            "=",
            "=*",
            ">",
            "^",
            "|",
            "~",
            "+=",
            "-=",
            "/=",
            "%=",
            "&=",
            "|=",
            "^=",
            "go",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        };

        public static int TokenTypeCount {
            get {
                return ScriptGeneratorSupporter._typeStrings.Length;
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public static string GetCasedString(string str, KeywordCasing casing) {
            switch (casing) {
                case KeywordCasing.Lowercase:
                    return str.ToLowerInvariant();
                case KeywordCasing.Uppercase:
                    return str.ToUpperInvariant();
                case KeywordCasing.PascalCase:
                    return ScriptGeneratorSupporter.GetPascalCase(str);
                default:
                    return string.Empty;
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public static string GetPascalCase(string str) {
            str = str.ToLowerInvariant();
            char value = char.ToUpperInvariant(str[0]);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(value);
            stringBuilder.Append(str.Substring(1));
            return stringBuilder.ToString();
        }

        public static string GetLowerCase(TSqlTokenType tokenType) {
            if (tokenType >= TSqlTokenType.None && (int)tokenType < ScriptGeneratorSupporter._typeStrings.Length) {
                string text = ScriptGeneratorSupporter._typeStrings[(int)tokenType];
                if (string.IsNullOrEmpty(text)) {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, SqlScriptGeneratorResource.TokenTypeDoesNotHaveStringRepresentation, new object[1]
                    {
                        tokenType
                    }));
                }
                return text;
            }
            throw new ArgumentOutOfRangeException("tokenType");
        }

        public static string GetUpperCase(TSqlTokenType tokenType) {
            return ScriptGeneratorSupporter.GetLowerCase(tokenType).ToUpperInvariant();
        }

        public static string GetPascalCase(TSqlTokenType tokenType) {
            return ScriptGeneratorSupporter.GetPascalCase(ScriptGeneratorSupporter.GetLowerCase(tokenType));
        }

        public static string GetTokenString(TSqlTokenType tokenType, KeywordCasing casing) {
            switch (casing) {
                case KeywordCasing.Lowercase:
                    return ScriptGeneratorSupporter.GetLowerCase(tokenType);
                case KeywordCasing.Uppercase:
                    return ScriptGeneratorSupporter.GetUpperCase(tokenType);
                case KeywordCasing.PascalCase:
                    return ScriptGeneratorSupporter.GetPascalCase(tokenType);
                default:
                    return string.Empty;
            }
        }

        public static TSqlParserToken CreateWhitespaceToken(int count) {
            string text = new string(' ', count);
            return new TSqlParserToken(TSqlTokenType.WhiteSpace, text);
        }

        internal static void CheckForNullReference(object variable, string variableName) {
            if (variableName == null) {
                throw new ArgumentNullException("variableName");
            }
            if (variable != null) {
                return;
            }
            throw new ArgumentNullException(variableName);
        }
    }
}
