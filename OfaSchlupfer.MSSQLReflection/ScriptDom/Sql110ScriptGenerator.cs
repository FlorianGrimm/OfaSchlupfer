namespace OfaSchlupfer.ScriptDom {
    using OfaSchlupfer.ScriptDom.ScriptGenerator;

    public sealed class Sql110ScriptGenerator : SqlScriptGenerator {
        public Sql110ScriptGenerator()
            : this(new SqlScriptGeneratorOptions()) {
        }

        public Sql110ScriptGenerator(SqlScriptGeneratorOptions options)
            : base(options) {
        }

        internal override SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            ScriptGeneratorSupporter.CheckForNullReference(scriptWriter, "scriptWriter");
            return new Sql110ScriptGeneratorVisitor(options, scriptWriter);
        }
    }
}
