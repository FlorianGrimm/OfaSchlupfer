using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UserDataTypeReference : ParameterizedDataTypeReference {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
