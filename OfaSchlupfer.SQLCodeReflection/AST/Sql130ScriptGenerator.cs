using OfaSchlupfer.AST.ScriptGenerator;

namespace OfaSchlupfer.AST {
    public sealed class Sql130ScriptGenerator : SqlScriptGenerator {
        public Sql130ScriptGenerator()
            : this(new SqlScriptGeneratorOptions()) {
        }

        public Sql130ScriptGenerator(SqlScriptGeneratorOptions options)
            : base(options) {
        }

        internal override SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            ScriptGeneratorSupporter.CheckForNullReference(scriptWriter, "scriptWriter");
            return new Sql130ScriptGeneratorVisitor(options, scriptWriter);
        }
    }
}
