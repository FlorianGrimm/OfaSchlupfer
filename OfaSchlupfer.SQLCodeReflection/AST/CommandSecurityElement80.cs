#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CommandSecurityElement80 : SecurityElement80 {
        public bool All { get; set; }

        public CommandOptions CommandOptions { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
