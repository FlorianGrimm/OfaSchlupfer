namespace OfaSchlupfer.AST.ScriptGenerator {
    internal class EmptyGenerator : TokenGenerator {
        public EmptyGenerator()
            : base(false) {
        }

        public override void Generate(ScriptWriter writer) {
        }
    }
}
