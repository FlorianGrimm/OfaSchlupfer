using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EncryptionPayloadOption : PayloadOption {
        private EndpointEncryptionSupport _encryptionSupport;

        private EncryptionAlgorithmPreference _algorithmPartOne;

        private EncryptionAlgorithmPreference _algorithmPartTwo;

        public EndpointEncryptionSupport EncryptionSupport {
            get {
                return this._encryptionSupport;
            }
            set {
                this._encryptionSupport = value;
            }
        }

        public EncryptionAlgorithmPreference AlgorithmPartOne {
            get {
                return this._algorithmPartOne;
            }
            set {
                this._algorithmPartOne = value;
            }
        }

        public EncryptionAlgorithmPreference AlgorithmPartTwo {
            get {
                return this._algorithmPartTwo;
            }
            set {
                this._algorithmPartTwo = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
