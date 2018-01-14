using OfaSchlupfer.AST.ScriptGenerator;

namespace OfaSchlupfer.AST {
    public sealed class Sql120ScriptGenerator : SqlScriptGenerator {
        public Sql120ScriptGenerator()
            : this(new SqlScriptGeneratorOptions()) {
        }

        public Sql120ScriptGenerator(SqlScriptGeneratorOptions options)
            : base(options) {
        }

        internal override SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            ScriptGeneratorSupporter.CheckForNullReference(scriptWriter, "scriptWriter");
            return new Sql120ScriptGeneratorVisitor(options, scriptWriter);
        }
    }
}
