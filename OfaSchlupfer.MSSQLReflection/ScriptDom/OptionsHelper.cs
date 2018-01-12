namespace OfaSchlupfer.ScriptDom {
    using antlr;
    using OfaSchlupfer.ScriptDom.ScriptGenerator;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal abstract class OptionsHelper<OptionType> where OptionType : struct, IConvertible {
        private class OptionInfo {
            private readonly OptionType _optionValue;

            private readonly TSqlTokenType _tokenId;

            private readonly string _identifier;

            private readonly SqlVersionFlags _validVersions;

            public OptionType Value {
                get {
                    return this._optionValue;
                }
            }

            public OptionInfo(OptionType optionValue, TSqlTokenType tokenId, SqlVersionFlags appliesToVersion) {
                this._optionValue = optionValue;
                this._tokenId = tokenId;
                this._identifier = null;
                this._validVersions = appliesToVersion;
            }

            public OptionInfo(OptionType optionValue, string identifier, SqlVersionFlags validVersions) {
                this._optionValue = optionValue;
                this._tokenId = TSqlTokenType.None;
                this._identifier = identifier;
                this._validVersions = validVersions;
            }

            public void GenerateSource(ScriptWriter writer) {
                if (this._identifier != null) {
                    writer.AddIdentifierWithoutCasing(this._identifier);
                } else {
                    writer.AddKeyword(this._tokenId);
                }
            }

            public bool IsValidIn(SqlVersionFlags version) {
                return (this._validVersions & version) != SqlVersionFlags.None;
            }
        }

        private Dictionary<OptionType, OptionInfo> _optionToOptionInfo = new Dictionary<OptionType, OptionInfo>();

        private Dictionary<string, OptionInfo> _stringToOptionInfo = new Dictionary<string, OptionInfo>(StringComparer.OrdinalIgnoreCase);

        protected void AddOptionMapping(OptionType option, string identifier, SqlVersionFlags validVersions) {
            OptionInfo value = new OptionInfo(option, identifier, validVersions);
            this._optionToOptionInfo.Add(option, value);
            this._stringToOptionInfo.Add(identifier, value);
        }

        protected void AddOptionMapping(OptionType option, TSqlTokenType tokenId, SqlVersionFlags validVersions) {
            OptionInfo value = new OptionInfo(option, tokenId, validVersions);
            this._optionToOptionInfo.Add(option, value);
            this._stringToOptionInfo.Add(ScriptGeneratorSupporter.GetLowerCase(tokenId), value);
        }

        protected void AddOptionMapping(OptionType option, string identifier) {
            this.AddOptionMapping(option, identifier, SqlVersionFlags.TSqlAll);
        }

        protected void AddOptionMapping(OptionType option, TSqlTokenType tokenId) {
            this.AddOptionMapping(option, tokenId, SqlVersionFlags.TSqlAll);
        }

        internal bool IsValidKeyword(IToken token) {
            return this._stringToOptionInfo.ContainsKey(token.getText());
        }

        internal SqlVersionFlags MapSqlVersionToSqlVersionFlags(SqlVersion sqlVersion) {
            switch (sqlVersion) {
                case SqlVersion.Sql80:
                    return SqlVersionFlags.TSql80;
                case SqlVersion.Sql90:
                    return SqlVersionFlags.TSql90;
                case SqlVersion.Sql100:
                    return SqlVersionFlags.TSql100;
                case SqlVersion.Sql110:
                    return SqlVersionFlags.TSql110;
                case SqlVersion.Sql120:
                    return SqlVersionFlags.TSql120;
                case SqlVersion.Sql130:
                    return SqlVersionFlags.TSql130;
                case SqlVersion.Sql140:
                    return SqlVersionFlags.TSql140;
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SqlScriptGeneratorResource.UnknownEnumValue, new object[2]
                    {
                    sqlVersion,
                    "SqlVersion"
                    }), "sqlVersion");
            }
        }

        internal OptionType ParseOption(IToken token, SqlVersionFlags version) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._stringToOptionInfo.TryGetValue(token.getText(), out optionInfo) && optionInfo.IsValidIn(version)) {
                return optionInfo.Value;
            }
            throw this.GetMatchingException(token);
        }

        internal bool TryParseOption(IToken token, SqlVersionFlags version, out OptionType returnValue) {
            return this.TryParseOption(token.getText(), version, out returnValue);
        }

        internal bool TryParseOption(string tokenString, SqlVersionFlags version, out OptionType returnValue) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._stringToOptionInfo.TryGetValue(tokenString, out optionInfo) && optionInfo.IsValidIn(version)) {
                returnValue = optionInfo.Value;
                return true;
            }
            returnValue = default(OptionType);
            return false;
        }

        internal OptionType ParseOption(IToken token) {
            return this.ParseOption(token, SqlVersionFlags.TSqlAll);
        }

        internal bool TryParseOption(IToken token, out OptionType returnValue) {
            return this.TryParseOption(token, SqlVersionFlags.TSqlAll, out returnValue);
        }

        protected virtual TSqlParseErrorException GetMatchingException(IToken token) {
            return TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        internal void GenerateSourceForOption(ScriptWriter writer, OptionType option) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._optionToOptionInfo.TryGetValue(option, out optionInfo)) {
                optionInfo.GenerateSource(writer);
            }
        }

        internal bool TryGenerateSourceForOption(ScriptWriter writer, OptionType option) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._optionToOptionInfo.TryGetValue(option, out optionInfo)) {
                optionInfo.GenerateSource(writer);
                return true;
            }
            return false;
        }

        internal void GenerateCommaSeparatedFlagOptions(ScriptWriter writer, OptionType options) {
            bool flag = true;
            long num = options.ToInt64(CultureInfo.InvariantCulture.NumberFormat);
            foreach (OptionType value in Enum.GetValues(typeof(OptionType))) {
                long num2 = value.ToInt64(CultureInfo.InvariantCulture.NumberFormat);
                if (!value.Equals(default(OptionType)) && (num & num2) == num2) {
                    if (flag) {
                        flag = false;
                    } else {
                        writer.AddKeyword(TSqlTokenType.Comma);
                        writer.AddToken(ScriptGeneratorSupporter.CreateWhitespaceToken(1));
                    }
                    this.GenerateSourceForOption(writer, value);
                }
            }
        }
    }
}
