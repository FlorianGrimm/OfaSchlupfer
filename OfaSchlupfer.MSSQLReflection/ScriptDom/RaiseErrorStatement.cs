using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RaiseErrorStatement : TSqlStatement {
        private ScalarExpression _firstParameter;

        private ScalarExpression _secondParameter;

        private ScalarExpression _thirdParameter;

        private List<ScalarExpression> _optionalParameters = new List<ScalarExpression>();

        private RaiseErrorOptions _raiseErrorOptions;

        public ScalarExpression FirstParameter {
            get {
                return this._firstParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._firstParameter = value;
            }
        }

        public ScalarExpression SecondParameter {
            get {
                return this._secondParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._secondParameter = value;
            }
        }

        public ScalarExpression ThirdParameter {
            get {
                return this._thirdParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._thirdParameter = value;
            }
        }

        public List<ScalarExpression> OptionalParameters {
            get {
                return this._optionalParameters;
            }
        }

        public RaiseErrorOptions RaiseErrorOptions {
            get {
                return this._raiseErrorOptions;
            }

            set {
                this._raiseErrorOptions = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FirstParameter?.Accept(visitor);
            this.SecondParameter?.Accept(visitor);
            this.ThirdParameter?.Accept(visitor);
            for (int i = 0, count = this.OptionalParameters.Count; i < count; i++) {
                this.OptionalParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
