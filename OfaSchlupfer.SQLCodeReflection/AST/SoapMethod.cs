namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SoapMethod : PayloadOption {
        private Literal _alias;

        private Literal _namespace;

        private SoapMethodAction _action;

        private Literal _name;

        private SoapMethodFormat _format;

        private SoapMethodSchemas _schema;

        public Literal Alias {
            get {
                return this._alias;
            }

            set {
                this.UpdateTokenInfo(value);
                this._alias = value;
            }
        }

        public Literal Namespace {
            get {
                return this._namespace;
            }

            set {
                this.UpdateTokenInfo(value);
                this._namespace = value;
            }
        }

        public SoapMethodAction Action {
            get {
                return this._action;
            }

            set {
                this._action = value;
            }
        }

        public Literal Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SoapMethodFormat Format {
            get {
                return this._format;
            }

            set {
                this._format = value;
            }
        }

        public SoapMethodSchemas Schema {
            get {
                return this._schema;
            }

            set {
                this._schema = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Alias?.Accept(visitor);
            this.Namespace?.Accept(visitor);
            this.Name?.Accept(visitor);
        }
    }
}
