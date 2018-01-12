using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FullTextCatalogAndFileGroup : TSqlFragment {
        private Identifier _catalogName;

        private Identifier _fileGroupName;

        private bool _fileGroupIsFirst;

        public Identifier CatalogName {
            get {
                return this._catalogName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._catalogName = value;
            }
        }

        public Identifier FileGroupName {
            get {
                return this._fileGroupName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileGroupName = value;
            }
        }

        public bool FileGroupIsFirst {
            get {
                return this._fileGroupIsFirst;
            }

            set {
                this._fileGroupIsFirst = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.CatalogName?.Accept(visitor);
            this.FileGroupName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
