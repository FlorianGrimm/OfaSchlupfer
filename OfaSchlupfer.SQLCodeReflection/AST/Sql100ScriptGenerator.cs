namespace OfaSchlupfer.AST {
    using OfaSchlupfer.AST.ScriptGenerator;

    public sealed class Sql100ScriptGenerator : SqlScriptGenerator {
        public Sql100ScriptGenerator()
            : this(new SqlScriptGeneratorOptions()) {
        }

        public Sql100ScriptGenerator(SqlScriptGeneratorOptions options)
            : base(options) {
        }

        internal override SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            ScriptGeneratorSupporter.CheckForNullReference(scriptWriter, "scriptWriter");
            return new Sql100ScriptGeneratorVisitor(options, scriptWriter);
        }
    }
}
