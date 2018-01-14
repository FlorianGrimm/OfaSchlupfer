using OfaSchlupfer.AST.ScriptGenerator;

namespace OfaSchlupfer.AST {
    public sealed class Sql90ScriptGenerator : SqlScriptGenerator {
        public Sql90ScriptGenerator()
            : this(new SqlScriptGeneratorOptions()) {
        }

        public Sql90ScriptGenerator(SqlScriptGeneratorOptions options)
            : base(options) {
        }

        internal override SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            ScriptGeneratorSupporter.CheckForNullReference(scriptWriter, "scriptWriter");
            return new Sql90ScriptGeneratorVisitor(options, scriptWriter);
        }
    }
}
