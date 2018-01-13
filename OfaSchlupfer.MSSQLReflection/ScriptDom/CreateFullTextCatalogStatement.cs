namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateFullTextCatalogStatement : FullTextCatalogStatement, IAuthorization {
        private Identifier _fileGroup;

        private Literal _path;

        private bool _isDefault;

        private Identifier _owner;

        public Identifier FileGroup {
            get {
                return this._fileGroup;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileGroup = value;
            }
        }

        public Literal Path {
            get {
                return this._path;
            }

            set {
                this.UpdateTokenInfo(value);
                this._path = value;
            }
        }

        public bool IsDefault {
            get {
                return this._isDefault;
            }
            set {
                this._isDefault = value;
            }
        }

        public Identifier Owner {
            get {
                return this._owner;
            }

            set {
                this.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.FileGroup?.Accept(visitor);
            this.Path?.Accept(visitor);
            for (int i = 0, count = base.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            this.Owner?.Accept(visitor);
        }
    }
}
