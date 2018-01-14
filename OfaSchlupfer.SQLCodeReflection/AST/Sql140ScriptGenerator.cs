namespace OfaSchlupfer.AST {
    using OfaSchlupfer.AST.ScriptGenerator;

    public sealed class Sql140ScriptGenerator : SqlScriptGenerator {
        public Sql140ScriptGenerator()
            : this(new SqlScriptGeneratorOptions()) {
        }

        public Sql140ScriptGenerator(SqlScriptGeneratorOptions options)
            : base(options) {
        }

        internal override SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            ScriptGeneratorSupporter.CheckForNullReference(scriptWriter, "scriptWriter");
            return new Sql140ScriptGeneratorVisitor(options, scriptWriter);
        }
    }
}
