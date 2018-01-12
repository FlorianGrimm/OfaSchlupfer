namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SizeFileDeclarationOption : FileDeclarationOption {
        private Literal _size;

        public Literal Size {
            get {
                return this._size;
            }
            set {
                base.UpdateTokenInfo(value);
                this._size = value;
            }
        }

        public MemoryUnit Units { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Size?.Accept(visitor);
        }
    }
}
