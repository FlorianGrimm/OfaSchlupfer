#pragma warning disable SA1402
#pragma warning disable SA1600
#pragma warning disable SA1649

namespace OfaSchlupfer.ScriptDom {
    using System;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlgorithmKeyOption : KeyOption {
        public EncryptionAlgorithm Algorithm { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AlterAvailabilityGroupFailoverOption : TSqlFragment {
        private FailoverActionOptionKind _optionKind;

        private Literal _value;

        public FailoverActionOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class AlterServerConfigurationBufferPoolExtensionContainerOption : AlterServerConfigurationBufferPoolExtensionOption {
        public List<AlterServerConfigurationBufferPoolExtensionOption> Suboptions { get; } = new List<AlterServerConfigurationBufferPoolExtensionOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var suboptions = this.Suboptions;
            for (int i = 0, count = suboptions.Count; i < count; i++) {
                suboptions[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public /**/ class AlterServerConfigurationBufferPoolExtensionOption 
        : TSqlFragment {
        private OptionValue _optionValue;

        public AlterServerConfigurationBufferPoolExtensionOptionKind OptionKind { get; set; }

        public OptionValue OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class AlterServerConfigurationBufferPoolExtensionSizeOption : AlterServerConfigurationBufferPoolExtensionOption {

        public MemoryUnit SizeUnit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AlterServerConfigurationDiagnosticsLogMaxSizeOption : AlterServerConfigurationDiagnosticsLogOption {
        public MemoryUnit SizeUnit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class AlterServerConfigurationDiagnosticsLogOption : TSqlFragment {
        private OptionValue _optionValue;

        public AlterServerConfigurationDiagnosticsLogOptionKind OptionKind { get; set; }

        public OptionValue OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class AlterServerConfigurationFailoverClusterPropertyOption : TSqlFragment {
        private AlterServerConfigurationFailoverClusterPropertyOptionKind _optionKind;

        private OptionValue _optionValue;

        public AlterServerConfigurationFailoverClusterPropertyOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public OptionValue OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class AlterServerConfigurationHadrClusterOption : TSqlFragment {
        private AlterServerConfigurationHadrClusterOptionKind _optionKind;

        private OptionValue _optionValue;

        private bool _isLocal;

        public AlterServerConfigurationHadrClusterOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public OptionValue OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public bool IsLocal {
            get {
                return this._isLocal;
            }

            set {
                this._isLocal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class AlterServerConfigurationSoftNumaOption : TSqlFragment {
        private AlterServerConfigurationSoftNumaOptionKind _optionKind;

        private OptionValue _optionValue;

        public AlterServerConfigurationSoftNumaOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public OptionValue OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class ApplicationRoleOption : TSqlFragment {
        private ApplicationRoleOptionKind _optionKind;

        private IdentifierOrValueExpression _value;

        public ApplicationRoleOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public IdentifierOrValueExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public /**/ class AssemblyOption : TSqlFragment {
        private AssemblyOptionKind _optionKind;

        public AssemblyOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class AtomicBlockOption : TSqlFragment {
        private AtomicBlockOptionKind _optionKind;

        public AtomicBlockOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class AuditGuidAuditOption : AuditOption {
        private Literal _guid;

        public Literal Guid {
            get {
                return this._guid;
            }

            set {
                this.UpdateTokenInfo(value);
                this._guid = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Guid?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class AuditOption : TSqlFragment {
        private AuditOptionKind _optionKind;

        public AuditOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public abstract class AuditTargetOption : TSqlFragment {
        private AuditTargetOptionKind _optionKind;

        public AuditTargetOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class AuthenticationEndpointProtocolOption : EndpointProtocolOption {
        private AuthenticationTypes _authenticationTypes;

        public AuthenticationTypes AuthenticationTypes {
            get {
                return this._authenticationTypes;
            }

            set {
                this._authenticationTypes = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AuthenticationPayloadOption : PayloadOption {
        private AuthenticationProtocol _protocol;

        private Identifier _certificate;

        private bool _tryCertificateFirst;

        public AuthenticationProtocol Protocol {
            get {
                return this._protocol;
            }

            set {
                this._protocol = value;
            }
        }

        public Identifier Certificate {
            get {
                return this._certificate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._certificate = value;
            }
        }

        public bool TryCertificateFirst {
            get {
                return this._tryCertificateFirst;
            }

            set {
                this._tryCertificateFirst = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Certificate?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class AutoCreateStatisticsDatabaseOption : OnOffDatabaseOption {
        private bool _hasIncremental;

        private OptionState _incrementalState;

        public bool HasIncremental {
            get {
                return this._hasIncremental;
            }

            set {
                this._hasIncremental = value;
            }
        }

        public OptionState IncrementalState {
            get {
                return this._incrementalState;
            }

            set {
                this._incrementalState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AutomaticTuningCreateIndexOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AutomaticTuningDatabaseOption : DatabaseOption {
        private AutomaticTuningState _automaticTuningState;

        private List<AutomaticTuningOption> _options = new List<AutomaticTuningOption>();

        public AutomaticTuningState AutomaticTuningState {
            get {
                return this._automaticTuningState;
            }

            set {
                this._automaticTuningState = value;
            }
        }

        public List<AutomaticTuningOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class AutomaticTuningDropIndexOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AutomaticTuningForceLastGoodPlanOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AutomaticTuningMaintainIndexOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class AutomaticTuningOption : TSqlFragment {
        public AutomaticTuningOptionKind OptionKind { get; set; }

        public AutomaticTuningOptionState Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class AvailabilityGroupOption : TSqlFragment {
        private AvailabilityGroupOptionKind _optionKind;

        public AvailabilityGroupOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class AvailabilityModeReplicaOption : AvailabilityReplicaOption {
        private AvailabilityModeOptionKind _value;

        public AvailabilityModeOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class AvailabilityReplicaOption : TSqlFragment {
        private AvailabilityReplicaOptionKind _optionKind;

        public AvailabilityReplicaOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class BackupEncryptionOption : BackupOption {
        public EncryptionAlgorithm Algorithm { get; set; }

        public CryptoMechanism Encryptor { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class BackupOption : TSqlFragment {
        private ScalarExpression _value;

        public BackupOptionKind OptionKind { get; set; }

        public ScalarExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class BoundingBoxSpatialIndexOption : SpatialIndexOption {
        private List<BoundingBoxParameter> _boundingBoxParameters = new List<BoundingBoxParameter>();

        public List<BoundingBoxParameter> BoundingBoxParameters {
            get {
                return this._boundingBoxParameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.BoundingBoxParameters.Count; i < count; i++) {
                this.BoundingBoxParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public /**/ class BulkInsertOption : TSqlFragment {
        public BulkInsertOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CellsPerObjectSpatialIndexOption : SpatialIndexOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class CertificateOption : TSqlFragment {
        private CertificateOptionKinds _kind;

        private Literal _value;

        public CertificateOptionKinds Kind {
            get {
                return this._kind;
            }

            set {
                this._kind = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class ChangeTrackingDatabaseOption : DatabaseOption {
        private OptionState _optionState;

        private List<ChangeTrackingOptionDetail> _details = new List<ChangeTrackingOptionDetail>();

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public List<ChangeTrackingOptionDetail> Details {
            get {
                return this._details;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Details.Count; i < count; i++) {
                this.Details[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class ChangeTrackingFullTextIndexOption : FullTextIndexOption {
        private ChangeTrackingOption _value;

        public ChangeTrackingOption Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CharacterSetPayloadOption : PayloadOption {
        private bool _isSql;

        public bool IsSql {
            get {
                return this._isSql;
            }

            set {
                this._isSql = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CompressionDelayIndexOption : IndexOption {
        private ScalarExpression _expression;

        private CompressionDelayTimeUnit _timeUnit;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public CompressionDelayTimeUnit TimeUnit {
            get {
                return this._timeUnit;
            }

            set {
                this._timeUnit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class CompressionEndpointProtocolOption : EndpointProtocolOption {
        private bool _isEnabled;

        public bool IsEnabled {
            get {
                return this._isEnabled;
            }

            set {
                this._isEnabled = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ContainmentDatabaseOption : DatabaseOption {
        private ContainmentOptionKind _value;

        public ContainmentOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CreationDispositionKeyOption : KeyOption {
        private bool _isCreateNew;

        public bool IsCreateNew {
            get {
                return this._isCreateNew;
            }

            set {
                this._isCreateNew = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CursorDefaultDatabaseOption : DatabaseOption {
        private bool _isLocal;

        public bool IsLocal {
            get {
                return this._isLocal;
            }

            set {
                this._isLocal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CursorOption : TSqlFragment {
        private CursorOptionKind _optionKind;

        public CursorOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class DatabaseConfigurationClearOption : TSqlFragment {
        private DatabaseConfigClearOptionKind _optionKind;

        public DatabaseConfigClearOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public abstract class DatabaseConfigurationSetOption : TSqlFragment {
        public DatabaseConfigSetOptionKind OptionKind { get; set; }

        public Identifier GenericOptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }
    }

    [System.Serializable]
    public /**/ class DatabaseOption : TSqlFragment {

        public DatabaseOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }
    [System.Serializable]
    public sealed class DataCompressionOption : IndexOption {
        private DataCompressionLevel _compressionLevel;

        private List<CompressionPartitionRange> _partitionRanges = new List<CompressionPartitionRange>();

        public DataCompressionLevel CompressionLevel {
            get {
                return this._compressionLevel;
            }

            set {
                this._compressionLevel = value;
            }
        }

        public List<CompressionPartitionRange> PartitionRanges {
            get {
                return this._partitionRanges;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            int i = 0;
            for (int count = this.PartitionRanges.Count; i < count; i++) {
                this.PartitionRanges[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class DataTypeSequenceOption : SequenceOption {
        private DataTypeReference _dataType;

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.DataType != null) {
                this.DataType.Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class DbccOption : TSqlFragment {
        private DbccOptionKind _optionKind;

        public DbccOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class DelayedDurabilityDatabaseOption : DatabaseOption {
        private DelayedDurabilityOptionKind _value;

        public DelayedDurabilityOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public abstract class DialogOption : TSqlFragment {
        private DialogOptionKind _optionKind;

        public DialogOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class DiskStatementOption : TSqlFragment {
        private DiskStatementOptionKind _optionKind;

        private IdentifierOrValueExpression _value;

        public DiskStatementOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public IdentifierOrValueExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Value != null) {
                this.Value.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class DropClusteredConstraintMoveOption : DropClusteredConstraintOption {
        private FileGroupOrPartitionScheme _optionValue;

        public FileGroupOrPartitionScheme OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.OptionValue != null) {
                this.OptionValue.Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public abstract class DropClusteredConstraintOption : TSqlFragment {
        private DropClusteredConstraintOptionKind _optionKind;

        public DropClusteredConstraintOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class DropClusteredConstraintStateOption : DropClusteredConstraintOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class DropClusteredConstraintValueOption : DropClusteredConstraintOption {
        private Literal _optionValue;

        public Literal OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.OptionValue != null) {
                this.OptionValue.Accept(visitor);
            }
        }
    }
    [System.Serializable]
    public sealed class DropClusteredConstraintWaitAtLowPriorityLockOption : DropClusteredConstraintOption {
        private List<LowPriorityLockWaitOption> _options = new List<LowPriorityLockWaitOption>();

        public List<LowPriorityLockWaitOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            int i = 0;
            for (int count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class DurabilityTableOption : TableOption {
        private DurabilityTableOptionKind _durabilityTableOptionKind;

        public DurabilityTableOptionKind DurabilityTableOptionKind {
            get {
                return this._durabilityTableOptionKind;
            }

            set {
                this._durabilityTableOptionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class EnabledDisabledPayloadOption : PayloadOption {
        private bool _isEnabled;

        public bool IsEnabled {
            get {
                return this._isEnabled;
            }

            set {
                this._isEnabled = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

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

    [System.Serializable]
    public abstract class EndpointProtocolOption : TSqlFragment {
        private EndpointProtocolOptions _kind;

        public EndpointProtocolOptions Kind {
            get {
                return this._kind;
            }

            set {
                this._kind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class EventRetentionSessionOption : SessionOption {
        private EventSessionEventRetentionModeType _value;

        public EventSessionEventRetentionModeType Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ExecuteAsFunctionOption : FunctionOption {
        private ExecuteAsClause _executeAs;

        public ExecuteAsClause ExecuteAs {
            get {
                return this._executeAs;
            }

            set {
                this.UpdateTokenInfo(value);
                this._executeAs = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);


        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ExecuteAs?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class ExecuteAsProcedureOption : ProcedureOption {
        private ExecuteAsClause _executeAs;

        public ExecuteAsClause ExecuteAs {
            get {
                return this._executeAs;
            }

            set {
                this.UpdateTokenInfo(value);
                this._executeAs = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ExecuteAs?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class ExecuteAsTriggerOption : TriggerOption {
        private ExecuteAsClause _executeAsClause;

        public ExecuteAsClause ExecuteAsClause {
            get {
                return this._executeAsClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._executeAsClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);


        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ExecuteAsClause?.Accept(visitor);
        }
    }

    [System.Serializable]
    public /**/ class ExecuteOption : TSqlFragment {
        public ExecuteOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class ExternalDataSourceLiteralOrIdentifierOption : ExternalDataSourceOption {
        private IdentifierOrValueExpression _value;

        public IdentifierOrValueExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.Value != null) {
                this.Value.Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public abstract class ExternalDataSourceOption : TSqlFragment {
        private ExternalDataSourceOptionKind _optionKind;

        public ExternalDataSourceOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class ExternalFileFormatContainerOption : ExternalFileFormatOption {
        private List<ExternalFileFormatOption> _suboptions = new List<ExternalFileFormatOption>();

        public List<ExternalFileFormatOption> Suboptions {
            get {
                return this._suboptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Suboptions.Count; i < count; i++) {
                this.Suboptions[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class ExternalFileFormatLiteralOption : ExternalFileFormatOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class ExternalFileFormatOption : TSqlFragment {
        private ExternalFileFormatOptionKind _optionKind;

        public ExternalFileFormatOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class ExternalFileFormatUseDefaultTypeOption : ExternalFileFormatOption {
        private ExternalFileFormatUseDefaultType _externalFileFormatUseDefaultType;

        public ExternalFileFormatUseDefaultType ExternalFileFormatUseDefaultType {
            get {
                return this._externalFileFormatUseDefaultType;
            }

            set {
                this._externalFileFormatUseDefaultType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ExternalTableDistributionOption : ExternalTableOption {
        private ExternalTableDistributionPolicy _value;

        public ExternalTableDistributionPolicy Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ExternalTableLiteralOrIdentifierOption : ExternalTableOption {
        private IdentifierOrValueExpression _value;

        public IdentifierOrValueExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class ExternalTableOption : TSqlFragment {
        private ExternalTableOptionKind _optionKind;

        public ExternalTableOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class ExternalTableRejectTypeOption : ExternalTableOption {
        private ExternalTableRejectType _value;

        public ExternalTableRejectType Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class FailoverModeReplicaOption : AvailabilityReplicaOption {
        public FailoverModeOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class FileDeclarationOption : TSqlFragment {
        public FileDeclarationOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class FileGrowthFileDeclarationOption : FileDeclarationOption {
        private Literal _growthIncrement;

        private MemoryUnit _units;

        public Literal GrowthIncrement {
            get {
                return this._growthIncrement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._growthIncrement = value;
            }
        }

        public MemoryUnit Units {
            get {
                return this._units;
            }

            set {
                this._units = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.GrowthIncrement?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileNameFileDeclarationOption : FileDeclarationOption {
        private Literal _oSFileName;

        public Literal OSFileName {
            get {
                return this._oSFileName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._oSFileName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OSFileName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileStreamDatabaseOption : DatabaseOption {
        private NonTransactedFileStreamAccess? _nonTransactedAccess;

        private Literal _directoryName;

        public NonTransactedFileStreamAccess? NonTransactedAccess {
            get {
                return this._nonTransactedAccess;
            }

            set {
                this._nonTransactedAccess = value;
            }
        }

        public Literal DirectoryName {
            get {
                return this._directoryName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._directoryName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DirectoryName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileStreamOnDropIndexOption : IndexOption, IFileStreamSpecifier {
        private IdentifierOrValueExpression _fileStreamOn;

        public IdentifierOrValueExpression FileStreamOn {
            get {
                return this._fileStreamOn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileStreamOn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileStreamOn?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileStreamOnTableOption : TableOption {
        private IdentifierOrValueExpression _value;

        public IdentifierOrValueExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileStreamRestoreOption : RestoreOption {
        private FileStreamDatabaseOption _fileStreamOption;

        public FileStreamDatabaseOption FileStreamOption {
            get {
                return this._fileStreamOption;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileStreamOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileStreamOption?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileTableCollateFileNameTableOption : TableOption {
        private Identifier _value;

        public Identifier Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileTableConstraintNameTableOption : TableOption {
        private Identifier _value;

        public Identifier Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class FileTableDirectoryTableOption : TableOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class FullTextCatalogOption : TSqlFragment {
        private FullTextCatalogOptionKind _optionKind;

        public FullTextCatalogOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public abstract class FullTextIndexOption : TSqlFragment {
        private FullTextIndexOptionKind _optionKind;

        public FullTextIndexOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public /**/ class FunctionOption : TSqlFragment {
        public FunctionOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class GenericConfigurationOption : DatabaseConfigurationSetOption {
        private IdentifierOrScalarExpression _genericOptionState;

        public IdentifierOrScalarExpression GenericOptionState {
            get {
                return this._genericOptionState;
            }

            set {
                this._genericOptionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class GridsSpatialIndexOption : SpatialIndexOption {
        private List<GridParameter> _gridParameters = new List<GridParameter>();

        public List<GridParameter> GridParameters {
            get {
                return this._gridParameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.GridParameters.Count; i < count; i++) {
                this.GridParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class HadrAvailabilityGroupDatabaseOption : HadrDatabaseOption {
        private Identifier _groupName;

        public Identifier GroupName {
            get {
                return this._groupName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._groupName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.GroupName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public /**/ class HadrDatabaseOption : DatabaseOption {
        public HadrDatabaseOptionKind HadrOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class IdentifierAtomicBlockOption : AtomicBlockOption {
        private Identifier _value;

        public Identifier Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class IdentifierDatabaseOption : DatabaseOption {
        private Identifier _value;

        public Identifier Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class IdentifierPrincipalOption : PrincipalOption {
        private Identifier _identifier;

        public Identifier Identifier {
            get {
                return this._identifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Identifier?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class IdentityValueKeyOption : KeyOption {
        private Literal _identityPhrase;

        public Literal IdentityPhrase {
            get {
                return this._identityPhrase;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identityPhrase = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.IdentityPhrase?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class IgnoreDupKeyIndexOption : IndexStateOption {
        public bool? SuppressMessagesOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class IndexExpressionOption : IndexOption {
        private ScalarExpression _expression;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class IndexOption : TSqlFragment {
        private IndexOptionKind _optionKind;

        public IndexOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public /**/ class IndexStateOption : IndexOption {

        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    internal interface IPasswordChangeOption {
        Literal EncryptionPassword {
            get;
            set;
        }

        Literal DecryptionPassword {
            get;
            set;
        }
    }

    [System.Serializable]
    public sealed class JsonForClauseOption : ForClause {
        private JsonForClauseOptions _optionKind;

        private Literal _value;

        public JsonForClauseOptions OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public abstract class KeyOption : TSqlFragment {
        private KeyOptionKind _optionKind;

        public KeyOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class KeySourceKeyOption : KeyOption {
        private Literal _passPhrase;

        public Literal PassPhrase {
            get {
                return this._passPhrase;
            }

            set {
                this.UpdateTokenInfo(value);
                this._passPhrase = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PassPhrase?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class ListenerIPEndpointProtocolOption : EndpointProtocolOption {
        private bool _isAll;

        private Literal _iPv6;

        private IPv4 _iPv4PartOne;

        private IPv4 _iPv4PartTwo;

        public bool IsAll {
            get {
                return this._isAll;
            }

            set {
                this._isAll = value;
            }
        }

        public Literal IPv6 {
            get {
                return this._iPv6;
            }

            set {
                this.UpdateTokenInfo(value);
                this._iPv6 = value;
            }
        }

        public IPv4 IPv4PartOne {
            get {
                return this._iPv4PartOne;
            }

            set {
                this.UpdateTokenInfo(value);
                this._iPv4PartOne = value;
            }
        }

        public IPv4 IPv4PartTwo {
            get {
                return this._iPv4PartTwo;
            }

            set {
                this.UpdateTokenInfo(value);
                this._iPv4PartTwo = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.IPv6 != null) {
                this.IPv6.Accept(visitor);
            }
            if (this.IPv4PartOne != null) {
                this.IPv4PartOne.Accept(visitor);
            }
            if (this.IPv4PartTwo != null) {
                this.IPv4PartTwo.Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class LiteralAtomicBlockOption : AtomicBlockOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralAuditTargetOption : AuditTargetOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralAvailabilityGroupOption : AvailabilityGroupOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralBulkInsertOption : BulkInsertOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralDatabaseOption : DatabaseOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralEndpointProtocolOption : EndpointProtocolOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralPayloadOption : PayloadOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralPrincipalOption : PrincipalOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralReplicaOption : AvailabilityReplicaOption {
        private Literal _value;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralSessionOption : SessionOption {
        private Literal _value;

        private MemoryUnit _unit;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public MemoryUnit Unit {
            get {
                return this._unit;
            }

            set {
                this._unit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LiteralStatisticsOption : StatisticsOption {
        private Literal _literal;

        public Literal Literal {
            get {
                return this._literal;
            }

            set {
                this.UpdateTokenInfo(value);
                this._literal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Literal?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class LockEscalationTableOption : TableOption {
        private LockEscalationMethod _value;

        public LockEscalationMethod Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class LoginTypePayloadOption : PayloadOption {
        private bool _isWindows;

        public bool IsWindows {
            get {
                return this._isWindows;
            }

            set {
                this._isWindows = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class LowPriorityLockWaitAbortAfterWaitOption : LowPriorityLockWaitOption {
        private AbortAfterWaitType _abortAfterWait;

        public AbortAfterWaitType AbortAfterWait {
            get {
                return this._abortAfterWait;
            }

            set {
                this._abortAfterWait = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class LowPriorityLockWaitMaxDurationOption : LowPriorityLockWaitOption {
        private Literal _maxDuration;

        private TimeUnit? _unit;

        public Literal MaxDuration {
            get {
                return this._maxDuration;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxDuration = value;
            }
        }

        public TimeUnit? Unit {
            get {
                return this._unit;
            }

            set {
                this._unit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxDuration?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class LowPriorityLockWaitOption : TSqlFragment {
        private LowPriorityLockWaitOptionKind _optionKind;

        public LowPriorityLockWaitOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class LowPriorityLockWaitTableSwitchOption : TableSwitchOption {
        private List<LowPriorityLockWaitOption> _options = new List<LowPriorityLockWaitOption>();

        public List<LowPriorityLockWaitOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class MaxDispatchLatencySessionOption : SessionOption {
        private bool _isInfinite;

        private Literal _value;

        public bool IsInfinite {
            get {
                return this._isInfinite;
            }

            set {
                this._isInfinite = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class MaxDopConfigurationOption : DatabaseConfigurationSetOption {
        public Literal Value { get; set; }

        public bool Primary { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class MaxDurationOption : IndexOption {
        private Literal _maxDuration;

        private TimeUnit? _unit;

        public Literal MaxDuration {
            get {
                return this._maxDuration;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxDuration = value;
            }
        }

        public TimeUnit? Unit {
            get {
                return this._unit;
            }

            set {
                this._unit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxDuration?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxRolloverFilesAuditTargetOption : AuditTargetOption {
        private Literal _value;

        private bool _isUnlimited;

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public bool IsUnlimited {
            get {
                return this._isUnlimited;
            }

            set {
                this._isUnlimited = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxSizeAuditTargetOption : AuditTargetOption {
        private bool _isUnlimited;

        private Literal _size;

        private MemoryUnit _unit;

        public bool IsUnlimited {
            get {
                return this._isUnlimited;
            }

            set {
                this._isUnlimited = value;
            }
        }

        public Literal Size {
            get {
                return this._size;
            }

            set {
                this.UpdateTokenInfo(value);
                this._size = value;
            }
        }

        public MemoryUnit Unit {
            get {
                return this._unit;
            }

            set {
                this._unit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Size?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxSizeDatabaseOption : DatabaseOption {
        private Literal _maxSize;

        private MemoryUnit _units;

        public Literal MaxSize {
            get {
                return this._maxSize;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxSize = value;
            }
        }

        public MemoryUnit Units {
            get {
                return this._units;
            }

            set {
                this._units = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxSize?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxSizeFileDeclarationOption : FileDeclarationOption {
        private Literal _maxSize;

        private MemoryUnit _units;

        private bool _unlimited;

        public Literal MaxSize {
            get {
                return this._maxSize;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxSize = value;
            }
        }

        public MemoryUnit Units {
            get {
                return this._units;
            }

            set {
                this._units = value;
            }
        }

        public bool Unlimited {
            get {
                return this._unlimited;
            }

            set {
                this._unlimited = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxSize?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MemoryOptimizedTableOption : TableOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class MemoryPartitionSessionOption : SessionOption {
        private EventSessionMemoryPartitionModeType _value;

        public EventSessionMemoryPartitionModeType Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class MoveRestoreOption : RestoreOption {
        private ValueExpression _logicalFileName;

        private ValueExpression _oSFileName;

        public ValueExpression LogicalFileName {
            get {
                return this._logicalFileName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._logicalFileName = value;
            }
        }

        public ValueExpression OSFileName {
            get {
                return this._oSFileName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._oSFileName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LogicalFileName?.Accept(visitor);
            this.OSFileName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MoveToDropIndexOption : IndexOption {
        private FileGroupOrPartitionScheme _moveTo;

        public FileGroupOrPartitionScheme MoveTo {
            get {
                return this._moveTo;
            }

            set {
                this.UpdateTokenInfo(value);
                this._moveTo = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MoveTo?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class NameFileDeclarationOption : FileDeclarationOption {
        private IdentifierOrValueExpression _logicalFileName;

        private bool _isNewName;

        public IdentifierOrValueExpression LogicalFileName {
            get {
                return this._logicalFileName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._logicalFileName = value;
            }
        }

        public bool IsNewName {
            get {
                return this._isNewName;
            }

            set {
                this._isNewName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LogicalFileName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class OnFailureAuditOption : AuditOption {
        private AuditFailureActionType _onFailureAction;

        public AuditFailureActionType OnFailureAction {
            get {
                return this._onFailureAction;
            }

            set {
                this._onFailureAction = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnlineIndexLowPriorityLockWaitOption : TSqlFragment {
        private List<LowPriorityLockWaitOption> _options = new List<LowPriorityLockWaitOption>();

        public List<LowPriorityLockWaitOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class OnlineIndexOption : IndexStateOption {
        private OnlineIndexLowPriorityLockWaitOption _lowPriorityLockWaitOption;

        public OnlineIndexLowPriorityLockWaitOption LowPriorityLockWaitOption {
            get {
                return this._lowPriorityLockWaitOption;
            }

            set {
                this.UpdateTokenInfo(value);
                this._lowPriorityLockWaitOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LowPriorityLockWaitOption?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class OnOffAssemblyOption : AssemblyOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffAtomicBlockOption : AtomicBlockOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffAuditTargetOption : AuditTargetOption {
        private OptionState _value;

        public OptionState Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class OnOffDatabaseOption : DatabaseOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffDialogOption : DialogOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffFullTextCatalogOption : FullTextCatalogOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffPrimaryConfigurationOption : DatabaseConfigurationSetOption {
        public DatabaseConfigurationOptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffPrincipalOption : PrincipalOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffRemoteServiceBindingOption : RemoteServiceBindingOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffSessionOption : SessionOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffStatisticsOption : StatisticsOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
    
    [System.Serializable]
    public sealed class OrderBulkInsertOption : BulkInsertOption {
        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();

        public bool IsUnique { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class OrderIndexOption : IndexOption {
        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class PageVerifyDatabaseOption : DatabaseOption {
        private PageVerifyDatabaseOptionKind _value;

        public PageVerifyDatabaseOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ParameterizationDatabaseOption : DatabaseOption {
        private bool _isSimple;

        public bool IsSimple {
            get {
                return this._isSimple;
            }

            set {
                this._isSimple = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class PartnerDatabaseOption : DatabaseOption {
        private Literal _partnerServer;

        private PartnerDatabaseOptionKind _partnerOption;

        private Literal _timeout;

        public Literal PartnerServer {
            get {
                return this._partnerServer;
            }

            set {
                this.UpdateTokenInfo(value);
                this._partnerServer = value;
            }
        }

        public PartnerDatabaseOptionKind PartnerOption {
            get {
                return this._partnerOption;
            }

            set {
                this._partnerOption = value;
            }
        }

        public Literal Timeout {
            get {
                return this._timeout;
            }

            set {
                this.UpdateTokenInfo(value);
                this._timeout = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PartnerServer?.Accept(visitor);
            this.Timeout?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class PasswordAlterPrincipalOption : PrincipalOption {
        private Literal _password;

        private Literal _oldPassword;

        public Literal Password {
            get {
                return this._password;
            }

            set {
                this.UpdateTokenInfo(value);
                this._password = value;
            }
        }

        public Literal OldPassword {
            get {
                return this._oldPassword;
            }

            set {
                this.UpdateTokenInfo(value);
                this._oldPassword = value;
            }
        }

        public bool MustChange { get; set; }

        public bool Unlock { get; set; }

        public bool Hashed { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Password?.Accept(visitor);
            this.OldPassword?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class PayloadOption : TSqlFragment {
        private PayloadOptionKinds _kind;

        public PayloadOptionKinds Kind {
            get {
                return this._kind;
            }

            set {
                this._kind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class PermissionSetAssemblyOption : AssemblyOption {
        private PermissionSetOption _permissionSetOption;

        public PermissionSetOption PermissionSetOption {
            get {
                return this._permissionSetOption;
            }

            set {
                this._permissionSetOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class PortsEndpointProtocolOption : EndpointProtocolOption {
        private PortTypes _portTypes;

        public PortTypes PortTypes {
            get {
                return this._portTypes;
            }

            set {
                this._portTypes = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class PrimaryRoleReplicaOption : AvailabilityReplicaOption {
        private AllowConnectionsOptionKind _allowConnections;

        public AllowConnectionsOptionKind AllowConnections {
            get {
                return this._allowConnections;
            }

            set {
                this._allowConnections = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class PrincipalOption : TSqlFragment {
        public PrincipalOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class ProcedureOption : TSqlFragment {
        public ProcedureOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ProviderKeyNameKeyOption : KeyOption {
        private Literal _keyName;

        public Literal KeyName {
            get {
                return this._keyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._keyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.KeyName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueryStoreCapturePolicyOption : QueryStoreOption {
        private QueryStoreCapturePolicyOptionKind _value;

        public QueryStoreCapturePolicyOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class QueryStoreDatabaseOption : DatabaseOption {
        private bool _clear;

        private bool _clearAll;

        private OptionState _optionState;

        private List<QueryStoreOption> _options = new List<QueryStoreOption>();

        public bool Clear {
            get {
                return this._clear;
            }

            set {
                this._clear = value;
            }
        }

        public bool ClearAll {
            get {
                return this._clearAll;
            }

            set {
                this._clearAll = value;
            }
        }

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public List<QueryStoreOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class QueryStoreDataFlushIntervalOption : QueryStoreOption {
        private Literal _flushInterval;

        public Literal FlushInterval {
            get {
                return this._flushInterval;
            }

            set {
                this.UpdateTokenInfo(value);
                this._flushInterval = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FlushInterval?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueryStoreDesiredStateOption : QueryStoreOption {
        private QueryStoreDesiredStateOptionKind _value;

        private bool _operationModeSpecified;

        public QueryStoreDesiredStateOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public bool OperationModeSpecified {
            get {
                return this._operationModeSpecified;
            }

            set {
                this._operationModeSpecified = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class QueryStoreIntervalLengthOption : QueryStoreOption {
        private Literal _statsIntervalLength;

        public Literal StatsIntervalLength {
            get {
                return this._statsIntervalLength;
            }

            set {
                this.UpdateTokenInfo(value);
                this._statsIntervalLength = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StatsIntervalLength?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueryStoreMaxPlansPerQueryOption : QueryStoreOption {
        private Literal _maxPlansPerQuery;

        public Literal MaxPlansPerQuery {
            get {
                return this._maxPlansPerQuery;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxPlansPerQuery = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxPlansPerQuery?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueryStoreMaxStorageSizeOption : QueryStoreOption {
        private Literal _maxQdsSize;

        public Literal MaxQdsSize {
            get {
                return this._maxQdsSize;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxQdsSize = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxQdsSize?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class QueryStoreOption : TSqlFragment {
        private QueryStoreOptionKind _optionKind;

        public QueryStoreOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class QueryStoreSizeCleanupPolicyOption : QueryStoreOption {
        private QueryStoreSizeCleanupPolicyOptionKind _value;

        public QueryStoreSizeCleanupPolicyOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class QueryStoreTimeCleanupPolicyOption : QueryStoreOption {
        private Literal _staleQueryThreshold;

        public Literal StaleQueryThreshold {
            get {
                return this._staleQueryThreshold;
            }

            set {
                this.UpdateTokenInfo(value);
                this._staleQueryThreshold = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StaleQueryThreshold?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueueDelayAuditOption : AuditOption {
        private Literal _delay;

        public Literal Delay {
            get {
                return this._delay;
            }

            set {
                this.UpdateTokenInfo(value);
                this._delay = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Delay?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueueExecuteAsOption : QueueOption {
        private ExecuteAsClause _optionValue;

        public ExecuteAsClause OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OptionValue?.Accept(visitor);
        }
    }

    [System.Serializable]
    public /**/ class QueueOption : TSqlFragment {
        public QueueOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class QueueProcedureOption : QueueOption {
        private SchemaObjectName _optionValue;

        public SchemaObjectName OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OptionValue?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueueStateOption : QueueOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class QueueValueOption : QueueOption {
        private ValueExpression _optionValue;

        public ValueExpression OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OptionValue?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class RecoveryDatabaseOption : DatabaseOption {
        private RecoveryDatabaseOptionKind _value;

        public RecoveryDatabaseOptionKind Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class RemoteDataArchiveAlterTableOption : TableOption {
        private RdaTableOption _rdaTableOption;

        private MigrationState _migrationState;

        private bool _isMigrationStateSpecified;

        private bool _isFilterPredicateSpecified;

        private FunctionCall _filterPredicate;

        public RdaTableOption RdaTableOption {
            get {
                return this._rdaTableOption;
            }

            set {
                this._rdaTableOption = value;
            }
        }

        public MigrationState MigrationState {
            get {
                return this._migrationState;
            }

            set {
                this._migrationState = value;
            }
        }

        public bool IsMigrationStateSpecified {
            get {
                return this._isMigrationStateSpecified;
            }

            set {
                this._isMigrationStateSpecified = value;
            }
        }

        public bool IsFilterPredicateSpecified {
            get {
                return this._isFilterPredicateSpecified;
            }

            set {
                this._isFilterPredicateSpecified = value;
            }
        }

        public FunctionCall FilterPredicate {
            get {
                return this._filterPredicate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._filterPredicate = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FilterPredicate?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class RemoteDataArchiveDatabaseOption : DatabaseOption {
        private OptionState _optionState;

        private List<RemoteDataArchiveDatabaseSetting> _settings = new List<RemoteDataArchiveDatabaseSetting>();

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public List<RemoteDataArchiveDatabaseSetting> Settings {
            get {
                return this._settings;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Settings.Count; i < count; i++) {
                this.Settings[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class RemoteDataArchiveTableOption : TableOption {
        private RdaTableOption _rdaTableOption;

        private MigrationState _migrationState;

        public RdaTableOption RdaTableOption {
            get {
                return this._rdaTableOption;
            }

            set {
                this._rdaTableOption = value;
            }
        }

        public MigrationState MigrationState {
            get {
                return this._migrationState;
            }

            set {
                this._migrationState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class RemoteServiceBindingOption : TSqlFragment {
        private RemoteServiceBindingOptionKind _optionKind;

        public RemoteServiceBindingOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }
    
    [System.Serializable]
    public sealed class ResampleStatisticsOption : StatisticsOption {

        public List<StatisticsPartitionRange> Partitions { get; } = new List<StatisticsPartitionRange>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var partitions = this.Partitions;
            for (int i = 0, count = partitions.Count; i < count; i++) {
                partitions[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public /**/ class RestoreOption : TSqlFragment {

        public RestoreOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
    
    [System.Serializable]
    public sealed class ResultSetsExecuteOption : ExecuteOption {
        public ResultSetsOptionKind ResultSetsOptionKind { get; set; }

        public List<ResultSetDefinition> Definitions { get; } = new List<ResultSetDefinition>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var definitions = this.Definitions;
            for (int i = 0, count = definitions.Count; i < count; i++) {
                definitions[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class RolePayloadOption : PayloadOption {
        private DatabaseMirroringEndpointRole _role;

        public DatabaseMirroringEndpointRole Role {
            get {
                return this._role;
            }

            set {
                this._role = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class RouteOption : TSqlFragment {
        private RouteOptionKind _optionKind;

        private Literal _literal;

        public RouteOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public Literal Literal {
            get {
                return this._literal;
            }

            set {
                this.UpdateTokenInfo(value);
                this._literal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Literal?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class ScalarExpressionDialogOption : DialogOption {
        private ScalarExpression _value;

        public ScalarExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public /**/ class ScalarExpressionRestoreOption : RestoreOption {
        private ScalarExpression _value;

        public ScalarExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class ScalarExpressionSequenceOption : SequenceOption {
        private ScalarExpression _optionValue;

        public ScalarExpression OptionValue {
            get {
                return this._optionValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OptionValue?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class SchemaPayloadOption : PayloadOption {
        private bool _isStandard;

        public bool IsStandard {
            get {
                return this._isStandard;
            }

            set {
                this._isStandard = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class SearchPropertyListFullTextIndexOption : FullTextIndexOption {
        private bool _isOff;

        private Identifier _propertyListName;

        public bool IsOff {
            get {
                return this._isOff;
            }

            set {
                this._isOff = value;
            }
        }

        public Identifier PropertyListName {
            get {
                return this._propertyListName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._propertyListName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PropertyListName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class SecondaryRoleReplicaOption : AvailabilityReplicaOption {
        private AllowConnectionsOptionKind _allowConnections;

        public AllowConnectionsOptionKind AllowConnections {
            get {
                return this._allowConnections;
            }

            set {
                this._allowConnections = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class SecurityPolicyOption : TSqlFragment {
        private SecurityPolicyOptionKind _optionKind;

        private OptionState _optionState;

        public SecurityPolicyOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class SequenceOption : TSqlFragment {
        public SequenceOptionKind OptionKind { get; set; }

        public bool NoValue { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class SessionOption : TSqlFragment {
        private SessionOptionKind _optionKind;

        public SessionOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class SessionTimeoutPayloadOption : PayloadOption {
        private bool _isNever;

        private Literal _timeout;

        public bool IsNever {
            get {
                return this._isNever;
            }

            set {
                this._isNever = value;
            }
        }

        public Literal Timeout {
            get {
                return this._timeout;
            }

            set {
                this.UpdateTokenInfo(value);
                this._timeout = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Timeout?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class SizeFileDeclarationOption : FileDeclarationOption {
        private Literal _size;

        public Literal Size {
            get {
                return this._size;
            }

            set {
                this.UpdateTokenInfo(value);
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

    [System.Serializable]
    public abstract class SpatialIndexOption : TSqlFragment { }

    [System.Serializable]
    public sealed class SpatialIndexRegularOption : SpatialIndexOption {
        private IndexOption _option;

        public IndexOption Option {
            get {
                return this._option;
            }

            set {
                this.UpdateTokenInfo(value);
                this._option = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Option?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class StateAuditOption : AuditOption {
        private OptionState _value;

        public OptionState Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public /**/ class StatisticsOption : TSqlFragment {
        public StatisticsOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class StopListFullTextIndexOption : FullTextIndexOption {
        private bool _isOff;

        private Identifier _stopListName;

        public bool IsOff {
            get {
                return this._isOff;
            }

            set {
                this._isOff = value;
            }
        }

        public Identifier StopListName {
            get {
                return this._stopListName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._stopListName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StopListName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class StopRestoreOption : RestoreOption {
        private ValueExpression _mark;

        private ValueExpression _after;

        private bool _isStopAt;

        public ValueExpression Mark {
            get {
                return this._mark;
            }

            set {
                this.UpdateTokenInfo(value);
                this._mark = value;
            }
        }

        public ValueExpression After {
            get {
                return this._after;
            }

            set {
                this.UpdateTokenInfo(value);
                this._after = value;
            }
        }

        public bool IsStopAt {
            get {
                return this._isStopAt;
            }

            set {
                this._isStopAt = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Mark?.Accept(visitor);
            this.After?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class SystemVersioningTableOption : TableOption {
        private OptionState _optionState;

        private OptionState _consistencyCheckEnabled;

        private SchemaObjectName _historyTable;

        private RetentionPeriodDefinition _retentionPeriod;

        public OptionState OptionState {
            get {
                return this._optionState;
            }

            set {
                this._optionState = value;
            }
        }

        public OptionState ConsistencyCheckEnabled {
            get {
                return this._consistencyCheckEnabled;
            }

            set {
                this._consistencyCheckEnabled = value;
            }
        }

        public SchemaObjectName HistoryTable {
            get {
                return this._historyTable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._historyTable = value;
            }
        }

        public RetentionPeriodDefinition RetentionPeriod {
            get {
                return this._retentionPeriod;
            }

            set {
                this.UpdateTokenInfo(value);
                this._retentionPeriod = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.HistoryTable?.Accept(visitor);
            this.RetentionPeriod?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class TableDataCompressionOption : TableOption {
        private DataCompressionOption _dataCompressionOption;

        public DataCompressionOption DataCompressionOption {
            get {
                return this._dataCompressionOption;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataCompressionOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataCompressionOption?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class TableDistributionOption : TableOption {
        private TableDistributionPolicy _value;

        public TableDistributionPolicy Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class TableIndexOption : TableOption {
        private TableIndexType _value;

        public TableIndexType Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class TableOption : TSqlFragment {
        private TableOptionKind _optionKind;

        public TableOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class TablePartitionOption : TableOption {
        private Identifier _partitionColumn;

        private TablePartitionOptionSpecifications _partitionOptionSpecs;

        public Identifier PartitionColumn {
            get {
                return this._partitionColumn;
            }

            set {
                this._partitionColumn = value;
            }
        }

        public TablePartitionOptionSpecifications PartitionOptionSpecs {
            get {
                return this._partitionOptionSpecs;
            }

            set {
                this.UpdateTokenInfo(value);
                this._partitionOptionSpecs = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PartitionOptionSpecs?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class TableSwitchOption : TSqlFragment {
        private TableSwitchOptionKind _optionKind;

        public TableSwitchOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }
    }

    [System.Serializable]
    public sealed class TargetRecoveryTimeDatabaseOption : DatabaseOption {
        private Literal _recoveryTime;

        public Literal RecoveryTime {
            get {
                return this._recoveryTime;
            }

            set {
                this.UpdateTokenInfo(value);
                this._recoveryTime = value;
            }
        }

        public TimeUnit Unit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.RecoveryTime?.Accept(visitor);
        }
    }

    [System.Serializable]
    public /**/ class TriggerOption : TSqlFragment {
        public TriggerOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class UserLoginOption : TSqlFragment {
        private UserLoginOptionType _userLoginOptionType;

        private Identifier _identifier;

        public UserLoginOptionType UserLoginOptionType {
            get {
                return this._userLoginOptionType;
            }

            set {
                this._userLoginOptionType = value;
            }
        }

        public Identifier Identifier {
            get {
                return this._identifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class UserRemoteServiceBindingOption : RemoteServiceBindingOption {
        private Identifier _user;

        public Identifier User {
            get {
                return this._user;
            }

            set {
                this.UpdateTokenInfo(value);
                this._user = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.User?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class ViewOption : TSqlFragment {
        private ViewOptionKind _optionKind;

        public ViewOptionKind OptionKind {
            get {
                return this._optionKind;
            }

            set {
                this._optionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class WaitAtLowPriorityOption : IndexOption {
        private List<LowPriorityLockWaitOption> _options = new List<LowPriorityLockWaitOption>();

        public List<LowPriorityLockWaitOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }

    [System.Serializable]
    public sealed class WitnessDatabaseOption : DatabaseOption {
        private Literal _witnessServer;

        public Literal WitnessServer {
            get {
                return this._witnessServer;
            }

            set {
                this.UpdateTokenInfo(value);
                this._witnessServer = value;
            }
        }

        public bool IsOff { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.WitnessServer?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class WsdlPayloadOption : PayloadOption {
        private bool _isNone;

        private Literal _value;

        public bool IsNone {
            get {
                return this._isNone;
            }

            set {
                this._isNone = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class XmlForClauseOption : ForClause {
        private Literal _value;

        public XmlForClauseOptions OptionKind { get; set; }

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}