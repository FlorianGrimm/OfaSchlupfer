using OfaSchlupfer.ScriptDom.ScriptGenerator;

namespace OfaSchlupfer.ScriptDom {
    public sealed class Sql80ScriptGenerator : SqlScriptGenerator {
        public Sql80ScriptGenerator()
            : this(new SqlScriptGeneratorOptions()) {
        }

        public Sql80ScriptGenerator(SqlScriptGeneratorOptions options)
            : base(options) {
        }

        internal override SqlScriptGeneratorVisitor CreateSqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter scriptWriter) {
            ScriptGeneratorSupporter.CheckForNullReference(options, "options");
            ScriptGeneratorSupporter.CheckForNullReference(scriptWriter, "scriptWriter");
            return new Sql80ScriptGeneratorVisitor(options, scriptWriter);
        }
    }
}
