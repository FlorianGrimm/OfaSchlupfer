namespace OfaSchlupfer.ScriptDom {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using OfaSchlupfer.ScriptDom.ScriptGenerator;
    using OfaSchlupfer.ScriptDom.Versioning;

    public abstract class SqlScriptGenerator {
        private SqlScriptGeneratorOptions _options;

        public SqlScriptGeneratorOptions Options {
            get {
                return this._options;
            }
        }

        protected SqlScriptGenerator(SqlScriptGeneratorOptions options) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            this._options = options;
        }

        public void GenerateScript(TSqlFragment scriptFragment, out string script) {
            StringBuilder stringBuilder = new StringBuilder();
            using (StringWriter writer = new StringWriter(stringBuilder, CultureInfo.InvariantCulture)) {
                this.GenerateScript(scriptFragment, writer);
            }
            script = stringBuilder.ToString();
        }

        public void GenerateScript(TSqlFragment scriptFragment, out string script, out IList<ParseError> versioningErrors) {
            StringBuilder stringBuilder = new StringBuilder();
            VersioningVisitor versioningVisitor = new VersioningVisitor(this._options);
            this.VersionCheck(scriptFragment, versioningVisitor);
            versioningErrors = versioningVisitor.GetErrors();
            using (StringWriter writer = new StringWriter(stringBuilder, CultureInfo.InvariantCulture)) {
                this.GenerateScript(scriptFragment, writer);
            }
            script = stringBuilder.ToString();
        }

        public void GenerateScript(TSqlFragment scriptFragment, TextWriter writer) {
            ScriptGeneratorSupporter.CheckForNullReference(scriptFragment, "scriptFragment");
            ScriptGeneratorSupporter.CheckForNullReference(writer, "writer");
            if (scriptFragment == null) {
                throw new ArgumentException(SqlScriptGeneratorResource.ScriptDomTreeTypeNotSupported, "scriptFragment");
            }
            ScriptWriter scriptWriter = this.WriteScript(scriptFragment);
            scriptWriter.WriteTo(writer);
        }

        public List<TSqlParserToken> GenerateTokens(TSqlFragment scriptFragment) {
            ScriptGeneratorSupporter.CheckForNullReference(scriptFragment, "scriptFragment");
            ScriptWriter scriptWriter = this.WriteScript(scriptFragment);
            var list = new List<TSqlParserToken>();
            scriptWriter.WriteTo(list);
            return list;
        }

        internal abstract SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter);

        private ScriptWriter WriteScript(TSqlFragment scriptFragment) {
            ScriptWriter scriptWriter = new ScriptWriter(this._options);
            SqlScriptGeneratorVisitor visitor = this.CreateSqlScriptGeneratorVisitor(this._options, scriptWriter);
            scriptFragment.Accept(visitor);
            return scriptWriter;
        }

        private void VersionCheck(TSqlFragment scriptFragment, VersioningVisitor versioningVisitor) {
            ScriptGeneratorSupporter.CheckForNullReference(scriptFragment, "scriptFragment");
            scriptFragment.Accept(versioningVisitor);
        }
    }
}
