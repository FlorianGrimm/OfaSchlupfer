#pragma warning disable SA1402
#pragma warning disable SA1600
#pragma warning disable SA1649

namespace OfaSchlupfer.AST {
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
            this.Suboptions.Accept(visitor);
        }
    }

    [System.Serializable]
    public class AlterServerConfigurationBufferPoolExtensionOption
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
    public class AlterServerConfigurationDiagnosticsLogOption : TSqlFragment {
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

        public bool IsLocal { get; set; }

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
    public class AssemblyOption : TSqlFragment {
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

        public bool TryCertificateFirst { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Certificate?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class AutoCreateStatisticsDatabaseOption : OnOffDatabaseOption {
        public bool HasIncremental { get; set; }

        public OptionState IncrementalState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AutomaticTuningCreateIndexOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class AutomaticTuningDatabaseOption : DatabaseOption {
        public AutomaticTuningState AutomaticTuningState { get; set; }

        public List<AutomaticTuningOption> Options { get; } = new List<AutomaticTuningOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Options.Accept(visitor);
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
        public AvailabilityGroupOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class AvailabilityModeReplicaOption : AvailabilityReplicaOption {
        public AvailabilityModeOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class AvailabilityReplicaOption : TSqlFragment {
        public AvailabilityReplicaOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class BackupEncryptionOption : BackupOption {
        public EncryptionAlgorithm Algorithm { get; set; }

        public CryptoMechanism Encryptor { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class BackupOption : TSqlFragment {
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
        public List<BoundingBoxParameter> BoundingBoxParameters { get; } = new List<BoundingBoxParameter>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.BoundingBoxParameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public class BulkInsertOption : TSqlFragment {
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
        private Literal _value;

        public CertificateOptionKinds Kind { get; set; }

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
        public OptionState OptionState { get; set; }

        public List<ChangeTrackingOptionDetail> Details { get; } = new List<ChangeTrackingOptionDetail>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Details.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class ChangeTrackingFullTextIndexOption : FullTextIndexOption {
        public ChangeTrackingOption Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CharacterSetPayloadOption : PayloadOption {
        public bool IsSql { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CompressionDelayIndexOption : IndexOption {
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

        public CompressionDelayTimeUnit TimeUnit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class CompressionEndpointProtocolOption : EndpointProtocolOption {
        public bool IsEnabled { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ContainmentDatabaseOption : DatabaseOption {
        public ContainmentOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CreationDispositionKeyOption : KeyOption {
        public bool IsCreateNew { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CursorDefaultDatabaseOption : DatabaseOption {
        public bool IsLocal { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class CursorOption : TSqlFragment {
        public CursorOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class DatabaseConfigurationClearOption : TSqlFragment {
        public DatabaseConfigClearOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class DatabaseConfigurationSetOption : TSqlFragment {
        public DatabaseConfigSetOptionKind OptionKind { get; set; }

        public Identifier GenericOptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class DatabaseOption : TSqlFragment {

        public DatabaseOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class DataCompressionOption : IndexOption {
        public DataCompressionLevel CompressionLevel { get; set; }

        public List<CompressionPartitionRange> PartitionRanges { get; } = new List<CompressionPartitionRange>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PartitionRanges.Accept(visitor);
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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class DbccOption : TSqlFragment {
        public DbccOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class DelayedDurabilityDatabaseOption : DatabaseOption {
        public DelayedDurabilityOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class DialogOption : TSqlFragment {
        public DialogOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class DiskStatementOption : TSqlFragment {
        private IdentifierOrValueExpression _value;

        public DiskStatementOptionKind OptionKind { get; set; }

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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OptionValue?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class DropClusteredConstraintOption : TSqlFragment {
        public DropClusteredConstraintOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class DropClusteredConstraintStateOption : DropClusteredConstraintOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OptionValue?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class DropClusteredConstraintWaitAtLowPriorityLockOption : DropClusteredConstraintOption {
        public List<LowPriorityLockWaitOption> Options { get; } = new List<LowPriorityLockWaitOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Options.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class DurabilityTableOption : TableOption {
        public DurabilityTableOptionKind DurabilityTableOptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class EnabledDisabledPayloadOption : PayloadOption {
        public bool IsEnabled { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class EncryptionPayloadOption : PayloadOption {
        public EndpointEncryptionSupport EncryptionSupport { get; set; }

        public EncryptionAlgorithmPreference AlgorithmPartOne { get; set; }

        public EncryptionAlgorithmPreference AlgorithmPartTwo { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class EndpointProtocolOption : TSqlFragment {
        public EndpointProtocolOptions Kind { get; set; }
    }

    [System.Serializable]
    public sealed class EventRetentionSessionOption : SessionOption {
        public EventSessionEventRetentionModeType Value { get; set; }

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
    public class ExecuteOption : TSqlFragment {
        public ExecuteOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class ExternalDataSourceOption : TSqlFragment {
        public ExternalDataSourceOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class ExternalFileFormatContainerOption : ExternalFileFormatOption {
        public List<ExternalFileFormatOption> Suboptions { get; } = new List<ExternalFileFormatOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Suboptions.Accept(visitor);
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
        public ExternalFileFormatOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class ExternalFileFormatUseDefaultTypeOption : ExternalFileFormatOption {
        public ExternalFileFormatUseDefaultType ExternalFileFormatUseDefaultType { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ExternalTableDistributionOption : ExternalTableOption {
        public ExternalTableDistributionPolicy Value { get; set; }

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
        public ExternalTableOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class ExternalTableRejectTypeOption : ExternalTableOption {
        public ExternalTableRejectType Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class FailoverModeReplicaOption : AvailabilityReplicaOption {
        public FailoverModeOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class FileDeclarationOption : TSqlFragment {
        public FileDeclarationOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class FileGrowthFileDeclarationOption : FileDeclarationOption {
        private Literal _growthIncrement;

        public Literal GrowthIncrement {
            get {
                return this._growthIncrement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._growthIncrement = value;
            }
        }

        public MemoryUnit Units { get; set; }

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
        private Literal _directoryName;

        public NonTransactedFileStreamAccess? NonTransactedAccess { get; set; }

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
        public FullTextCatalogOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public abstract class FullTextIndexOption : TSqlFragment {
        public FullTextIndexOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public class FunctionOption : TSqlFragment {
        public FunctionOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class GenericConfigurationOption : DatabaseConfigurationSetOption {
        public IdentifierOrScalarExpression GenericOptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class GridsSpatialIndexOption : SpatialIndexOption {
        public List<GridParameter> GridParameters { get; } = new List<GridParameter>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.GridParameters.Accept(visitor);
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
    public class HadrDatabaseOption : DatabaseOption {
        public HadrDatabaseOptionKind HadrOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class IdentifierAtomicBlockOption : AtomicBlockOption {
        public Identifier Value { get; set; }

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
        public IndexOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public class IndexStateOption : IndexOption {

        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    internal interface IPasswordChangeOption {
        Literal EncryptionPassword { get; set; }

        Literal DecryptionPassword { get; set; }
    }

    [System.Serializable]
    public sealed class JsonForClauseOption : ForClause {
        private Literal _value;

        public JsonForClauseOptions OptionKind { get; set; }

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
        public KeyOptionKind OptionKind { get; set; }
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
        private Literal _iPv6;

        private IPv4 _iPv4PartOne;

        private IPv4 _iPv4PartTwo;

        public bool IsAll { get; set; }

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
            this.IPv6?.Accept(visitor);
            this.IPv4PartOne?.Accept(visitor);
            this.IPv4PartTwo?.Accept(visitor);
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

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public MemoryUnit Unit { get; set; }

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
        public LockEscalationMethod Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class LoginTypePayloadOption : PayloadOption {
        public bool IsWindows { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class LowPriorityLockWaitAbortAfterWaitOption : LowPriorityLockWaitOption {
        public AbortAfterWaitType AbortAfterWait { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class LowPriorityLockWaitMaxDurationOption : LowPriorityLockWaitOption {
        private Literal _maxDuration;

        public Literal MaxDuration {
            get {
                return this._maxDuration;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxDuration = value;
            }
        }

        public TimeUnit? Unit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxDuration?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class LowPriorityLockWaitOption : TSqlFragment {
        public LowPriorityLockWaitOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class LowPriorityLockWaitTableSwitchOption : TableSwitchOption {
        public List<LowPriorityLockWaitOption> Options { get; } = new List<LowPriorityLockWaitOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Options.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxDispatchLatencySessionOption : SessionOption {
        public bool IsInfinite { get; set; }

        public Literal Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class MaxDopConfigurationOption : DatabaseConfigurationSetOption {
        public Literal Value { get; set; }

        public bool Primary { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class MaxDurationOption : IndexOption {
        private Literal _maxDuration;

        public Literal MaxDuration {
            get {
                return this._maxDuration;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxDuration = value;
            }
        }

        public TimeUnit? Unit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxDuration?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxRolloverFilesAuditTargetOption : AuditTargetOption {
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

        public bool IsUnlimited { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxSizeAuditTargetOption : AuditTargetOption {
        private Literal _size;

        private MemoryUnit _unit;

        public bool IsUnlimited { get; set; }

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

        public Literal MaxSize {
            get {
                return this._maxSize;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxSize = value;
            }
        }

        public MemoryUnit Units { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxSize?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MaxSizeFileDeclarationOption : FileDeclarationOption {
        private Literal _maxSize;

        public Literal MaxSize {
            get {
                return this._maxSize;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxSize = value;
            }
        }

        public MemoryUnit Units { get; set; }

        public bool Unlimited { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MaxSize?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class MemoryOptimizedTableOption : TableOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class MemoryPartitionSessionOption : SessionOption {
        public EventSessionMemoryPartitionModeType Value { get; set; }

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

        public IdentifierOrValueExpression LogicalFileName {
            get {
                return this._logicalFileName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._logicalFileName = value;
            }
        }

        public bool IsNewName { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LogicalFileName?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class OnFailureAuditOption : AuditOption {
        public AuditFailureActionType OnFailureAction { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnlineIndexLowPriorityLockWaitOption : TSqlFragment {
        public List<LowPriorityLockWaitOption> Options { get; } = new List<LowPriorityLockWaitOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
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
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffAtomicBlockOption : AtomicBlockOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffAuditTargetOption : AuditTargetOption {
        public OptionState Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class OnOffDatabaseOption : DatabaseOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffDialogOption : DialogOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffFullTextCatalogOption : FullTextCatalogOption {
        public OptionState OptionState { get; set; }

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
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class OnOffSessionOption : SessionOption {
        public OptionState OptionState { get; set; }

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
            this.Columns.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class OrderIndexOption : IndexOption {
        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class PageVerifyDatabaseOption : DatabaseOption {
        public PageVerifyDatabaseOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ParameterizationDatabaseOption : DatabaseOption {
        public bool IsSimple { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class PartnerDatabaseOption : DatabaseOption {
        private Literal _partnerServer;

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

        public PartnerDatabaseOptionKind PartnerOption { get; set; }

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
        public PayloadOptionKinds Kind { get; set; }
    }

    [System.Serializable]
    public sealed class PermissionSetAssemblyOption : AssemblyOption {
        public PermissionSetOption PermissionSetOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class PortsEndpointProtocolOption : EndpointProtocolOption {
        public PortTypes PortTypes { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class PrimaryRoleReplicaOption : AvailabilityReplicaOption {
        public AllowConnectionsOptionKind AllowConnections { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class PrincipalOption : TSqlFragment {
        public PrincipalOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class ProcedureOption : TSqlFragment {
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
        public QueryStoreCapturePolicyOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class QueryStoreDatabaseOption : DatabaseOption {
        public bool Clear { get; set; }

        public bool ClearAll { get; set; }

        public OptionState OptionState { get; set; }

        public List<QueryStoreOption> Options { get; } = new List<QueryStoreOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Options.Accept(visitor);
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
        public QueryStoreDesiredStateOptionKind Value { get; set; }

        public bool OperationModeSpecified { get; set; }

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
        public QueryStoreOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class QueryStoreSizeCleanupPolicyOption : QueryStoreOption {
        public QueryStoreSizeCleanupPolicyOptionKind Value { get; set; }

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
    public class QueueOption : TSqlFragment {
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
        public OptionState OptionState { get; set; }

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
        public RecoveryDatabaseOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class RemoteDataArchiveAlterTableOption : TableOption {
        private FunctionCall _filterPredicate;

        public RdaTableOption RdaTableOption { get; set; }

        public MigrationState MigrationState { get; set; }

        public bool IsMigrationStateSpecified { get; set; }

        public bool IsFilterPredicateSpecified { get; set; }

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
        public OptionState OptionState { get; set; }

        public List<RemoteDataArchiveDatabaseSetting> Settings { get; } = new List<RemoteDataArchiveDatabaseSetting>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Settings.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class RemoteDataArchiveTableOption : TableOption {
        public RdaTableOption RdaTableOption { get; set; }

        public MigrationState MigrationState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class RemoteServiceBindingOption : TSqlFragment {
        public RemoteServiceBindingOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class ResampleStatisticsOption : StatisticsOption {

        public List<StatisticsPartitionRange> Partitions { get; } = new List<StatisticsPartitionRange>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Partitions.Accept(visitor);
        }
    }

    [System.Serializable]
    public class RestoreOption : TSqlFragment {

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
            this.Definitions.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class RolePayloadOption : PayloadOption {
        public DatabaseMirroringEndpointRole Role { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class RouteOption : TSqlFragment {
        private Literal _literal;

        public RouteOptionKind OptionKind { get; set; }

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
    public class ScalarExpressionRestoreOption : RestoreOption {
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
        public bool IsStandard { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class SearchPropertyListFullTextIndexOption : FullTextIndexOption {
        private Identifier _propertyListName;

        public bool IsOff { get; set; }

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
        public AllowConnectionsOptionKind AllowConnections { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class SecurityPolicyOption : TSqlFragment {
        public SecurityPolicyOptionKind OptionKind { get; set; }

        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class SequenceOption : TSqlFragment {
        public SequenceOptionKind OptionKind { get; set; }

        public bool NoValue { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class SessionOption : TSqlFragment {
        public SessionOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class SessionTimeoutPayloadOption : PayloadOption {
        private Literal _timeout;

        public bool IsNever { get; set; }

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
        public OptionState Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public class StatisticsOption : TSqlFragment {
        public StatisticsOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class StopListFullTextIndexOption : FullTextIndexOption {
        private Identifier _stopListName;

        public bool IsOff { get; set; }

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

        public bool IsStopAt { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Mark?.Accept(visitor);
            this.After?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class SystemVersioningTableOption : TableOption {
        private SchemaObjectName _historyTable;

        private RetentionPeriodDefinition _retentionPeriod;

        public OptionState OptionState { get; set; }

        public OptionState ConsistencyCheckEnabled { get; set; }

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
        public TableDistributionPolicy Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class TableIndexOption : TableOption {
        public TableIndexType Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public abstract class TableOption : TSqlFragment {
        public TableOptionKind OptionKind { get; set; }
    }

    [System.Serializable]
    public sealed class TablePartitionOption : TableOption {
        private TablePartitionOptionSpecifications _partitionOptionSpecs;

        public Identifier PartitionColumn { get; set; }

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
        public TableSwitchOptionKind OptionKind { get; set; }
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
    public class TriggerOption : TSqlFragment {
        public TriggerOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class UserLoginOption : TSqlFragment {
        private Identifier _identifier;

        public UserLoginOptionType UserLoginOptionType { get; set; }

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
        public ViewOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class WaitAtLowPriorityOption : IndexOption {
        public List<LowPriorityLockWaitOption> Options { get; } = new List<LowPriorityLockWaitOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Options.Accept(visitor);
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
        private Literal _value;

        public bool IsNone { get; set; }

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