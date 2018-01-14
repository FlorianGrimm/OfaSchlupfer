namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateXmlIndexStatement : IndexStatement {
        private Identifier _xmlColumn;

        private Identifier _secondaryXmlIndexName;

        private SecondaryXmlIndexType _secondaryXmlIndexType;

        public bool Primary { get; set; }

        public Identifier XmlColumn {
            get {
                return this._xmlColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._xmlColumn = value;
            }
        }

        public Identifier SecondaryXmlIndexName {
            get {
                return this._secondaryXmlIndexName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._secondaryXmlIndexName = value;
            }
        }

        public SecondaryXmlIndexType SecondaryXmlIndexType {
            get {
                return this._secondaryXmlIndexType;
            }

            set {
                this._secondaryXmlIndexType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            if (base.OnName != null) {
                base.OnName.Accept(visitor);
            }
            this.XmlColumn?.Accept(visitor);
            this.SecondaryXmlIndexName?.Accept(visitor);
            for (int i = 0, count = base.IndexOptions.Count; i < count; i++) {
                base.IndexOptions[i].Accept(visitor);
            }
        }
    }
}
