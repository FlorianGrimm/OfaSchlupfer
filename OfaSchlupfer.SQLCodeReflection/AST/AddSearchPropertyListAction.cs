namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AddSearchPropertyListAction : SearchPropertyListAction {
        private StringLiteral _propertyName;

        private StringLiteral _guid;

        private IntegerLiteral _id;

        private StringLiteral _description;

        public StringLiteral PropertyName {
            get {
                return this._propertyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._propertyName = value;
            }
        }

        public StringLiteral Guid {
            get {
                return this._guid;
            }

            set {
                this.UpdateTokenInfo(value);
                this._guid = value;
            }
        }

        public IntegerLiteral Id {
            get {
                return this._id;
            }

            set {
                this.UpdateTokenInfo(value);
                this._id = value;
            }
        }

        public StringLiteral Description {
            get {
                return this._description;
            }

            set {
                this.UpdateTokenInfo(value);
                this._description = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.PropertyName?.Accept(visitor);
            this.Guid?.Accept(visitor);
            this.Id?.Accept(visitor);
            this.Description?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
