namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateSelectiveXmlIndexStatement : IndexStatement {
        private Identifier _xmlColumn;

        private XmlNamespaces _xmlNamespaces;

        private Identifier _usingXmlIndexName;

        private Identifier _pathName;

        public bool IsSecondary { get; set; }

        public Identifier XmlColumn {
            get {
                return this._xmlColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._xmlColumn = value;
            }
        }

        public List<SelectiveXmlIndexPromotedPath> PromotedPaths { get; } = new List<SelectiveXmlIndexPromotedPath>();

        public XmlNamespaces XmlNamespaces {
            get {
                return this._xmlNamespaces;
            }

            set {
                this.UpdateTokenInfo(value);
                this._xmlNamespaces = value;
            }
        }

        public Identifier UsingXmlIndexName {
            get {
                return this._usingXmlIndexName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._usingXmlIndexName = value;
            }
        }

        public Identifier PathName {
            get {
                return this._pathName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._pathName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.OnName?.Accept(visitor);
            this.XmlColumn?.Accept(visitor);
            this.PromotedPaths.Accept(visitor);
            this.XmlNamespaces?.Accept(visitor);
            this.UsingXmlIndexName?.Accept(visitor);
            this.PathName?.Accept(visitor);
            this.IndexOptions.Accept(visitor);
        }
    }
}
