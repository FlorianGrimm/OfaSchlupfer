#pragma warning disable SA1516
#pragma warning disable SA1600

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    public class Copier : ScriptDom.TSqlConcreteFragmentVisitor {
        public static D Copy<D>(ScriptDom.TSqlFragment sqlFragment)
            where D : SqlNode {
            if (sqlFragment == null) { return null; }
            var c = new Copier(sqlFragment);
            sqlFragment.Accept(c);
            return (D)c.Result;
        }

        public static void CopyList<S, D>(List<D> dst, IList<S> src)
            where S : ScriptDom.TSqlFragment
            where D : SqlNode {
            foreach (var batch in src) {
                var r = Copy<D>(batch);
                if (r != null) {
                    dst.Add(r);
                }
            }
        }

        private ScriptDom.TSqlFragment sqlFragment;
        public SqlNode Result;
        public Copier(ScriptDom.TSqlFragment sqlFragment) { this.sqlFragment = sqlFragment; }

        public override void ExplicitVisit(ScriptDom.AdHocDataSource node) { }
        public override void ExplicitVisit(ScriptDom.AdHocTableReference node) { }
        public override void ExplicitVisit(ScriptDom.AddAlterFullTextIndexAction node) { }
        public override void ExplicitVisit(ScriptDom.AddFileSpec node) { }
        public override void ExplicitVisit(ScriptDom.AddMemberAlterRoleAction node) { }
        public override void ExplicitVisit(ScriptDom.AddSearchPropertyListAction node) { }
        public override void ExplicitVisit(ScriptDom.AddSignatureStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlgorithmKeyOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterApplicationRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterAssemblyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterAsymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterAuthorizationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterAvailabilityGroupAction node) { }
        public override void ExplicitVisit(ScriptDom.AlterAvailabilityGroupFailoverAction node) { }
        public override void ExplicitVisit(ScriptDom.AlterAvailabilityGroupFailoverOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterAvailabilityGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterBrokerPriorityStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterCertificateStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterColumnAlterFullTextIndexAction node) { }
        public override void ExplicitVisit(ScriptDom.AlterColumnEncryptionKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterCredentialStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterCryptographicProviderStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseAddFileGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseAddFileStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseAuditSpecificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseCollateStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseEncryptionKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseModifyFileGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseModifyFileStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseModifyNameStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseRebuildLogStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseRemoveFileGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseRemoveFileStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseScopedConfigurationClearStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseScopedConfigurationSetStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseSetStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterDatabaseTermination node) { }
        public override void ExplicitVisit(ScriptDom.AlterEndpointStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterEventSessionStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterExternalDataSourceStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterExternalResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterFederationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterFullTextCatalogStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterFullTextIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterFullTextStopListStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterFunctionStatement node) { this.Result = new AlterFunctionStatement(node); }
        public override void ExplicitVisit(ScriptDom.AlterIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterLoginAddDropCredentialStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterLoginEnableDisableStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterLoginOptionsStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterMessageTypeStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterPartitionFunctionStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterPartitionSchemeStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterProcedureStatement node) { this.Result = new AlterProcedureStatement(node); }
        public override void ExplicitVisit(ScriptDom.AlterQueueStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterRemoteServiceBindingStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterResourceGovernorStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterRouteStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterSchemaStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterSearchPropertyListStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterSecurityPolicyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterSequenceStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerAuditSpecificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerAuditStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationBufferPoolExtensionOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationDiagnosticsLogOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationHadrClusterOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationSetHadrClusterStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationSetSoftNumaStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationSoftNumaOption node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerConfigurationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServerRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServiceMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterServiceStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterSymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableAddTableElementStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableAlterColumnStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableAlterIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableAlterPartitionStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableChangeTrackingModificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableConstraintModificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableDropTableElement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableDropTableElementStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableFileTableNamespaceStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableRebuildStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableSetStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableSwitchStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTableTriggerModificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterTriggerStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterUserStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterViewStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterWorkloadGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.AlterXmlSchemaCollectionStatement node) { }
        public override void ExplicitVisit(ScriptDom.ApplicationRoleOption node) { }
        public override void ExplicitVisit(ScriptDom.AssemblyEncryptionSource node) { }
        public override void ExplicitVisit(ScriptDom.AssemblyName node) { }
        public override void ExplicitVisit(ScriptDom.AssemblyOption node) { }
        public override void ExplicitVisit(ScriptDom.AssignmentSetClause node) { this.Result = new AssignmentSetClause(node); }
        public override void ExplicitVisit(ScriptDom.AsymmetricKeyCreateLoginSource node) { }
        public override void ExplicitVisit(ScriptDom.AtTimeZoneCall node) { }
        public override void ExplicitVisit(ScriptDom.AuditActionGroupReference node) { }
        public override void ExplicitVisit(ScriptDom.AuditActionSpecification node) { }
        public override void ExplicitVisit(ScriptDom.AuditGuidAuditOption node) { }
        public override void ExplicitVisit(ScriptDom.AuditSpecificationPart node) { }
        public override void ExplicitVisit(ScriptDom.AuditTarget node) { }
        public override void ExplicitVisit(ScriptDom.AuthenticationEndpointProtocolOption node) { }
        public override void ExplicitVisit(ScriptDom.AuthenticationPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.AutoCleanupChangeTrackingOptionDetail node) { }
        public override void ExplicitVisit(ScriptDom.AutoCreateStatisticsDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.AutomaticTuningCreateIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.AutomaticTuningDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.AutomaticTuningDropIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.AutomaticTuningForceLastGoodPlanOption node) { }
        public override void ExplicitVisit(ScriptDom.AutomaticTuningMaintainIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.AutomaticTuningOption node) { }
        public override void ExplicitVisit(ScriptDom.AvailabilityModeReplicaOption node) { }
        public override void ExplicitVisit(ScriptDom.AvailabilityReplica node) { }
        public override void ExplicitVisit(ScriptDom.BackupCertificateStatement node) { }
        public override void ExplicitVisit(ScriptDom.BackupDatabaseStatement node) { }
        public override void ExplicitVisit(ScriptDom.BackupEncryptionOption node) { }
        public override void ExplicitVisit(ScriptDom.BackupMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.BackupOption node) { }
        public override void ExplicitVisit(ScriptDom.BackupRestoreFileInfo node) { }
        public override void ExplicitVisit(ScriptDom.BackupServiceMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.BackupTransactionLogStatement node) { }
        public override void ExplicitVisit(ScriptDom.BackwardsCompatibleDropIndexClause node) { }
        public override void ExplicitVisit(ScriptDom.BeginConversationTimerStatement node) { }
        public override void ExplicitVisit(ScriptDom.BeginDialogStatement node) { }
        public override void ExplicitVisit(ScriptDom.BeginEndAtomicBlockStatement node) { }
        public override void ExplicitVisit(ScriptDom.BeginEndBlockStatement node) { this.Result = new BeginEndBlockStatement(node); }
        public override void ExplicitVisit(ScriptDom.BeginTransactionStatement node) { this.Result = new BeginTransactionStatement(node); }
        public override void ExplicitVisit(ScriptDom.BinaryExpression node) { this.Result = new BinaryExpression(node); }
        public override void ExplicitVisit(ScriptDom.BinaryLiteral node) { this.Result = new BinaryLiteral(node); }
        public override void ExplicitVisit(ScriptDom.BinaryQueryExpression node) { this.Result = new BinaryQueryExpression(node); }
        public override void ExplicitVisit(ScriptDom.BooleanBinaryExpression node) { this.Result = new BooleanBinaryExpression(node); }
        public override void ExplicitVisit(ScriptDom.BooleanComparisonExpression node) { this.Result = new BooleanComparisonExpression(node); }
        public override void ExplicitVisit(ScriptDom.BooleanExpressionSnippet node) { this.Result = new BooleanExpressionSnippet(node); }
        public override void ExplicitVisit(ScriptDom.BooleanIsNullExpression node) { this.Result = new BooleanIsNullExpression(node); }
        public override void ExplicitVisit(ScriptDom.BooleanNotExpression node) { this.Result = new BooleanNotExpression(node); }
        public override void ExplicitVisit(ScriptDom.BooleanParenthesisExpression node) { this.Result = new BooleanParenthesisExpression(node); }
        public override void ExplicitVisit(ScriptDom.BooleanTernaryExpression node) { this.Result = new BooleanTernaryExpression(node); }
        public override void ExplicitVisit(ScriptDom.BoundingBoxParameter node) { }
        public override void ExplicitVisit(ScriptDom.BoundingBoxSpatialIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.BreakStatement node) { this.Result = new BreakStatement(node); }
        public override void ExplicitVisit(ScriptDom.BrokerPriorityParameter node) { }
        public override void ExplicitVisit(ScriptDom.BrowseForClause node) { this.Result = new BrowseForClause(node); }
        public override void ExplicitVisit(ScriptDom.BuiltInFunctionTableReference node) { this.Result = new BuiltInFunctionTableReference(node); }
        public override void ExplicitVisit(ScriptDom.BulkInsertOption node) { }
        public override void ExplicitVisit(ScriptDom.BulkInsertStatement node) { }
        public override void ExplicitVisit(ScriptDom.BulkOpenRowset node) { }
        public override void ExplicitVisit(ScriptDom.CastCall node) { this.Result = new CastCall(node); }
        public override void ExplicitVisit(ScriptDom.CellsPerObjectSpatialIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.CertificateCreateLoginSource node) { }
        public override void ExplicitVisit(ScriptDom.CertificateOption node) { }
        public override void ExplicitVisit(ScriptDom.ChangeRetentionChangeTrackingOptionDetail node) { }
        public override void ExplicitVisit(ScriptDom.ChangeTableChangesTableReference node) { }
        public override void ExplicitVisit(ScriptDom.ChangeTableVersionTableReference node) { }
        public override void ExplicitVisit(ScriptDom.ChangeTrackingDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.ChangeTrackingFullTextIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.CharacterSetPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.CheckConstraintDefinition node) { }
        public override void ExplicitVisit(ScriptDom.CheckpointStatement node) { }
        public override void ExplicitVisit(ScriptDom.ChildObjectName node) { this.Result = new ChildObjectName(node); }
        public override void ExplicitVisit(ScriptDom.CloseCursorStatement node) { this.Result = new CloseCursorStatement(node); }
        public override void ExplicitVisit(ScriptDom.CloseMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CloseSymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CoalesceExpression node) { this.Result = new CoalesceExpression(node); }
        public override void ExplicitVisit(ScriptDom.ColumnDefinition node) { this.Result = new ColumnDefinition(node); }
        public override void ExplicitVisit(ScriptDom.ColumnDefinitionBase node) { this.Result = new ColumnDefinitionBase(node); }
        public override void ExplicitVisit(ScriptDom.ColumnEncryptionAlgorithmNameParameter node) { }
        public override void ExplicitVisit(ScriptDom.ColumnEncryptionAlgorithmParameter node) { }
        public override void ExplicitVisit(ScriptDom.ColumnEncryptionDefinition node) { }
        public override void ExplicitVisit(ScriptDom.ColumnEncryptionKeyNameParameter node) { }
        public override void ExplicitVisit(ScriptDom.ColumnEncryptionKeyValue node) { }
        public override void ExplicitVisit(ScriptDom.ColumnEncryptionTypeParameter node) { }
        public override void ExplicitVisit(ScriptDom.ColumnMasterKeyNameParameter node) { }
        public override void ExplicitVisit(ScriptDom.ColumnMasterKeyPathParameter node) { }
        public override void ExplicitVisit(ScriptDom.ColumnMasterKeyStoreProviderNameParameter node) { }
        public override void ExplicitVisit(ScriptDom.ColumnReferenceExpression node) { this.Result = new ColumnReferenceExpression(node); }
        public override void ExplicitVisit(ScriptDom.ColumnStorageOptions node) { }
        public override void ExplicitVisit(ScriptDom.ColumnWithSortOrder node) { this.Result = new ColumnWithSortOrder(node); }
        public override void ExplicitVisit(ScriptDom.CommandSecurityElement80 node) { }
        public override void ExplicitVisit(ScriptDom.CommitTransactionStatement node) { this.Result = new CommitTransactionStatement(node); }
        public override void ExplicitVisit(ScriptDom.CommonTableExpression node) { this.Result = new CommonTableExpression(node); }
        public override void ExplicitVisit(ScriptDom.CompositeGroupingSpecification node) { this.Result = new CompositeGroupingSpecification(node); }
        public override void ExplicitVisit(ScriptDom.CompressionDelayIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.CompressionEndpointProtocolOption node) { }
        public override void ExplicitVisit(ScriptDom.CompressionPartitionRange node) { }
        public override void ExplicitVisit(ScriptDom.ComputeClause node) { this.Result = new ComputeClause(node); }
        public override void ExplicitVisit(ScriptDom.ComputeFunction node) { this.Result = new ComputeFunction(node); }
        public override void ExplicitVisit(ScriptDom.ContainmentDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.ContinueStatement node) { this.Result = new ContinueStatement(node); }
        public override void ExplicitVisit(ScriptDom.ContractMessage node) { }
        public override void ExplicitVisit(ScriptDom.ConvertCall node) { this.Result = new ConvertCall(node); }
        public override void ExplicitVisit(ScriptDom.CreateAggregateStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateApplicationRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateAssemblyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateAsymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateAvailabilityGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateBrokerPriorityStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateCertificateStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateColumnEncryptionKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateColumnMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateColumnStoreIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateContractStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateCredentialStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateCryptographicProviderStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateDatabaseAuditSpecificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateDatabaseEncryptionKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateDatabaseStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateDefaultStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateEndpointStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateEventNotificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateEventSessionStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateExternalDataSourceStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateExternalFileFormatStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateExternalResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateExternalTableStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateFederationStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateFullTextCatalogStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateFullTextIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateFullTextStopListStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateFunctionStatement node) { this.Result = new CreateFunctionStatement(node); }
        public override void ExplicitVisit(ScriptDom.CreateIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateLoginStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateMessageTypeStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateOrAlterFunctionStatement node) { this.Result = new CreateOrAlterFunctionStatement(node); }
        public override void ExplicitVisit(ScriptDom.CreateOrAlterProcedureStatement node) { this.Result = new CreateOrAlterProcedureStatement(node); }
        public override void ExplicitVisit(ScriptDom.CreateOrAlterTriggerStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateOrAlterViewStatement node) { this.Result = new CreateOrAlterViewStatement(node); }
        public override void ExplicitVisit(ScriptDom.CreatePartitionFunctionStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreatePartitionSchemeStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateProcedureStatement node) { this.Result = new CreateProcedureStatement(node); }
        public override void ExplicitVisit(ScriptDom.CreateQueueStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateRemoteServiceBindingStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateRouteStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateRuleStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSchemaStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSearchPropertyListStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSecurityPolicyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSelectiveXmlIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSequenceStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateServerAuditSpecificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateServerAuditStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateServerRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateServiceStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSpatialIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateStatisticsStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateSynonymStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateTableStatement node) { this.Result = new CreateTableStatement(node); }
        public override void ExplicitVisit(ScriptDom.CreateTriggerStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateTypeTableStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateTypeUddtStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateTypeUdtStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateUserStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateViewStatement node) { this.Result = new CreateViewStatement(node); }
        public override void ExplicitVisit(ScriptDom.CreateWorkloadGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateXmlIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreateXmlSchemaCollectionStatement node) { }
        public override void ExplicitVisit(ScriptDom.CreationDispositionKeyOption node) { }
        public override void ExplicitVisit(ScriptDom.CryptoMechanism node) { }
        public override void ExplicitVisit(ScriptDom.CubeGroupingSpecification node) { }
        public override void ExplicitVisit(ScriptDom.CursorDefaultDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.CursorDefinition node) { this.Result = new CursorDefinition(node); }
        public override void ExplicitVisit(ScriptDom.CursorId node) { this.Result = new CursorId(node); }
        public override void ExplicitVisit(ScriptDom.CursorOption node) { }
        public override void ExplicitVisit(ScriptDom.DataCompressionOption node) { }
        public override void ExplicitVisit(ScriptDom.DataModificationTableReference node) { this.Result = new DataModificationTableReference(node); }
        public override void ExplicitVisit(ScriptDom.DataTypeSequenceOption node) { }
        public override void ExplicitVisit(ScriptDom.DatabaseAuditAction node) { }
        public override void ExplicitVisit(ScriptDom.DatabaseConfigurationClearOption node) { }
        public override void ExplicitVisit(ScriptDom.DatabaseConfigurationSetOption node) { }
        public override void ExplicitVisit(ScriptDom.DatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.DbccNamedLiteral node) { }
        public override void ExplicitVisit(ScriptDom.DbccOption node) { }
        public override void ExplicitVisit(ScriptDom.DbccStatement node) { }
        public override void ExplicitVisit(ScriptDom.DeallocateCursorStatement node) { /*this.Result = new DeallocateCursorStatement(node); */ }
        public override void ExplicitVisit(ScriptDom.DeclareCursorStatement node) { this.Result = new DeclareCursorStatement(node); }
        public override void ExplicitVisit(ScriptDom.DeclareTableVariableBody node) { this.Result = new DeclareTableVariableBody(node); }
        public override void ExplicitVisit(ScriptDom.DeclareTableVariableStatement node) { this.Result = new DeclareTableVariableStatement(node); }
        public override void ExplicitVisit(ScriptDom.DeclareVariableElement node) { this.Result = new DeclareVariableElement(node); }
        public override void ExplicitVisit(ScriptDom.DeclareVariableStatement node) { this.Result = new DeclareVariableStatement(node); }
        public override void ExplicitVisit(ScriptDom.DefaultConstraintDefinition node) { this.Result = new DefaultConstraintDefinition(node); }
        public override void ExplicitVisit(ScriptDom.DefaultLiteral node) { this.Result = new DefaultLiteral(node); }
        public override void ExplicitVisit(ScriptDom.DelayedDurabilityDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.DeleteMergeAction node) { this.Result = new DeleteMergeAction(node); }
        public override void ExplicitVisit(ScriptDom.DeleteSpecification node) { this.Result = new DeleteSpecification(node); }
        public override void ExplicitVisit(ScriptDom.DeleteStatement node) { this.Result = new DeleteStatement(node); }
        public override void ExplicitVisit(ScriptDom.DenyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DenyStatement80 node) { }
        public override void ExplicitVisit(ScriptDom.DeviceInfo node) { }
        public override void ExplicitVisit(ScriptDom.DiskStatement node) { }
        public override void ExplicitVisit(ScriptDom.DiskStatementOption node) { }
        public override void ExplicitVisit(ScriptDom.DropAggregateStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropAlterFullTextIndexAction node) { }
        public override void ExplicitVisit(ScriptDom.DropApplicationRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropAssemblyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropAsymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropAvailabilityGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropBrokerPriorityStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropCertificateStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropClusteredConstraintMoveOption node) { }
        public override void ExplicitVisit(ScriptDom.DropClusteredConstraintStateOption node) { }
        public override void ExplicitVisit(ScriptDom.DropClusteredConstraintValueOption node) { }
        public override void ExplicitVisit(ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption node) { }
        public override void ExplicitVisit(ScriptDom.DropColumnEncryptionKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropColumnMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropContractStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropCredentialStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropCryptographicProviderStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropDatabaseAuditSpecificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropDatabaseEncryptionKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropDatabaseStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropDefaultStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropEndpointStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropEventNotificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropEventSessionStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropExternalDataSourceStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropExternalFileFormatStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropExternalResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropExternalTableStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropFederationStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropFullTextCatalogStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropFullTextIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropFullTextStopListStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropFunctionStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropIndexClause node) { }
        public override void ExplicitVisit(ScriptDom.DropIndexStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropMemberAlterRoleAction node) { }
        public override void ExplicitVisit(ScriptDom.DropMessageTypeStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropPartitionFunctionStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropPartitionSchemeStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropProcedureStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropQueueStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropRemoteServiceBindingStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropRouteStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropRuleStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropSchemaStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropSearchPropertyListAction node) { }
        public override void ExplicitVisit(ScriptDom.DropSearchPropertyListStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropSecurityPolicyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropSequenceStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropServerAuditSpecificationStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropServerAuditStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropServerRoleStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropServiceStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropSignatureStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropStatisticsStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropSymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropSynonymStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropTableStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropTriggerStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropTypeStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropUserStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropViewStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropWorkloadGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.DropXmlSchemaCollectionStatement node) { }
        public override void ExplicitVisit(ScriptDom.DurabilityTableOption node) { }
        public override void ExplicitVisit(ScriptDom.EnableDisableTriggerStatement node) { }
        public override void ExplicitVisit(ScriptDom.EnabledDisabledPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.EncryptedValueParameter node) { }
        public override void ExplicitVisit(ScriptDom.EncryptionPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.EndConversationStatement node) { }
        public override void ExplicitVisit(ScriptDom.EndpointAffinity node) { }
        public override void ExplicitVisit(ScriptDom.EventDeclaration node) { }
        public override void ExplicitVisit(ScriptDom.EventDeclarationCompareFunctionParameter node) { }
        public override void ExplicitVisit(ScriptDom.EventDeclarationSetParameter node) { }
        public override void ExplicitVisit(ScriptDom.EventGroupContainer node) { }
        public override void ExplicitVisit(ScriptDom.EventNotificationObjectScope node) { }
        public override void ExplicitVisit(ScriptDom.EventRetentionSessionOption node) { }
        public override void ExplicitVisit(ScriptDom.EventSessionObjectName node) { }
        public override void ExplicitVisit(ScriptDom.EventSessionStatement node) { }
        public override void ExplicitVisit(ScriptDom.EventTypeContainer node) { }
        public override void ExplicitVisit(ScriptDom.ExecutableProcedureReference node) { this.Result = new ExecutableProcedureReference(node); }
        public override void ExplicitVisit(ScriptDom.ExecutableStringList node) { this.Result = new ExecutableStringList(node); }
        public override void ExplicitVisit(ScriptDom.ExecuteAsClause node) { this.Result = new ExecuteAsClause(node); }
        public override void ExplicitVisit(ScriptDom.ExecuteAsFunctionOption node) { }
        public override void ExplicitVisit(ScriptDom.ExecuteAsProcedureOption node) { }
        public override void ExplicitVisit(ScriptDom.ExecuteAsStatement node) { this.Result = new ExecuteAsStatement(node); }
        public override void ExplicitVisit(ScriptDom.ExecuteAsTriggerOption node) { }
        public override void ExplicitVisit(ScriptDom.ExecuteContext node) { this.Result = new ExecuteContext(node); }
        public override void ExplicitVisit(ScriptDom.ExecuteInsertSource node) { this.Result = new ExecuteInsertSource(node); }
        public override void ExplicitVisit(ScriptDom.ExecuteOption node) { }
        public override void ExplicitVisit(ScriptDom.ExecuteParameter node) { this.Result = new ExecuteParameter(node); }
        public override void ExplicitVisit(ScriptDom.ExecuteSpecification node) { }
        public override void ExplicitVisit(ScriptDom.ExecuteStatement node) { this.Result = new ExecuteStatement(node); }
        public override void ExplicitVisit(ScriptDom.ExistsPredicate node) { this.Result = new ExistsPredicate(node); }
        public override void ExplicitVisit(ScriptDom.ExpressionCallTarget node) { this.Result = new ExpressionCallTarget(node); }
        public override void ExplicitVisit(ScriptDom.ExpressionGroupingSpecification node) { this.Result = new ExpressionGroupingSpecification(node); }
        public override void ExplicitVisit(ScriptDom.ExpressionWithSortOrder node) { this.Result = new ExpressionWithSortOrder(node); }
        public override void ExplicitVisit(ScriptDom.ExternalDataSourceLiteralOrIdentifierOption node) { }
        public override void ExplicitVisit(ScriptDom.ExternalFileFormatContainerOption node) { }
        public override void ExplicitVisit(ScriptDom.ExternalFileFormatLiteralOption node) { }
        public override void ExplicitVisit(ScriptDom.ExternalFileFormatUseDefaultTypeOption node) { }
        public override void ExplicitVisit(ScriptDom.ExternalResourcePoolAffinitySpecification node) { }
        public override void ExplicitVisit(ScriptDom.ExternalResourcePoolParameter node) { }
        public override void ExplicitVisit(ScriptDom.ExternalResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.ExternalTableColumnDefinition node) { }
        public override void ExplicitVisit(ScriptDom.ExternalTableDistributionOption node) { }
        public override void ExplicitVisit(ScriptDom.ExternalTableLiteralOrIdentifierOption node) { }
        public override void ExplicitVisit(ScriptDom.ExternalTableRejectTypeOption node) { }
        public override void ExplicitVisit(ScriptDom.ExternalTableReplicatedDistributionPolicy node) { }
        public override void ExplicitVisit(ScriptDom.ExternalTableRoundRobinDistributionPolicy node) { }
        public override void ExplicitVisit(ScriptDom.ExternalTableShardedDistributionPolicy node) { }
        public override void ExplicitVisit(ScriptDom.ExtractFromExpression node) { this.Result = new ExtractFromExpression(node); }
        public override void ExplicitVisit(ScriptDom.FailoverModeReplicaOption node) { }
        public override void ExplicitVisit(ScriptDom.FederationScheme node) { }
        public override void ExplicitVisit(ScriptDom.FetchCursorStatement node) { this.Result = new FetchCursorStatement(node); }
        public override void ExplicitVisit(ScriptDom.FetchType node) { this.Result = new FetchType(node); }
        public override void ExplicitVisit(ScriptDom.FileDeclaration node) { }
        public override void ExplicitVisit(ScriptDom.FileDeclarationOption node) { }
        public override void ExplicitVisit(ScriptDom.FileEncryptionSource node) { }
        public override void ExplicitVisit(ScriptDom.FileGroupDefinition node) { }
        public override void ExplicitVisit(ScriptDom.FileGroupOrPartitionScheme node) { }
        public override void ExplicitVisit(ScriptDom.FileGrowthFileDeclarationOption node) { }
        public override void ExplicitVisit(ScriptDom.FileNameFileDeclarationOption node) { }
        public override void ExplicitVisit(ScriptDom.FileStreamDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.FileStreamOnDropIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.FileStreamOnTableOption node) { }
        public override void ExplicitVisit(ScriptDom.FileStreamRestoreOption node) { }
        public override void ExplicitVisit(ScriptDom.FileTableCollateFileNameTableOption node) { }
        public override void ExplicitVisit(ScriptDom.FileTableConstraintNameTableOption node) { }
        public override void ExplicitVisit(ScriptDom.FileTableDirectoryTableOption node) { }
        public override void ExplicitVisit(ScriptDom.ForceSeekTableHint node) { }
        public override void ExplicitVisit(ScriptDom.ForeignKeyConstraintDefinition node) { }
        public override void ExplicitVisit(ScriptDom.FromClause node) { this.Result = new FromClause(node); }
        public override void ExplicitVisit(ScriptDom.FullTextCatalogAndFileGroup node) { }
        public override void ExplicitVisit(ScriptDom.FullTextIndexColumn node) { }
        public override void ExplicitVisit(ScriptDom.FullTextPredicate node) { }
        public override void ExplicitVisit(ScriptDom.FullTextStopListAction node) { }
        public override void ExplicitVisit(ScriptDom.FullTextTableReference node) { }
        public override void ExplicitVisit(ScriptDom.FunctionCall node) { this.Result = new FunctionCall(node); }
        public override void ExplicitVisit(ScriptDom.FunctionCallSetClause node) { this.Result = new FunctionCallSetClause(node); }
        public override void ExplicitVisit(ScriptDom.FunctionOption node) { }
        public override void ExplicitVisit(ScriptDom.GeneralSetCommand node) { this.Result = new GeneralSetCommand(node); }
        public override void ExplicitVisit(ScriptDom.GenericConfigurationOption node) { }
        public override void ExplicitVisit(ScriptDom.GetConversationGroupStatement node) { }
        public override void ExplicitVisit(ScriptDom.GlobalFunctionTableReference node) { this.Result = new GlobalFunctionTableReference(node); }
        public override void ExplicitVisit(ScriptDom.GlobalVariableExpression node) { this.Result = new GlobalVariableExpression(node); }
        public override void ExplicitVisit(ScriptDom.GoToStatement node) { this.Result = new GoToStatement(node); }
        public override void ExplicitVisit(ScriptDom.GrandTotalGroupingSpecification node) { this.Result = new GrandTotalGroupingSpecification(node); }
        public override void ExplicitVisit(ScriptDom.GrantStatement node) { }
        public override void ExplicitVisit(ScriptDom.GrantStatement80 node) { }
        public override void ExplicitVisit(ScriptDom.GraphMatchExpression node) { }
        public override void ExplicitVisit(ScriptDom.GraphMatchPredicate node) { }
        public override void ExplicitVisit(ScriptDom.GridParameter node) { }
        public override void ExplicitVisit(ScriptDom.GridsSpatialIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.GroupByClause node) { this.Result = new GroupByClause(node); }
        public override void ExplicitVisit(ScriptDom.GroupingSetsGroupingSpecification node) { this.Result = new GroupingSetsGroupingSpecification(node); }
        public override void ExplicitVisit(ScriptDom.HadrAvailabilityGroupDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.HadrDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.HavingClause node) { this.Result = new HavingClause(node); }
        public override void ExplicitVisit(ScriptDom.IIfCall node) { this.Result = new IIfCall(node); }
        public override void ExplicitVisit(ScriptDom.IPv4 node) { }
        public override void ExplicitVisit(ScriptDom.Identifier node) { this.Result = new Identifier(node); }
        public override void ExplicitVisit(ScriptDom.IdentifierAtomicBlockOption node) { }
        public override void ExplicitVisit(ScriptDom.IdentifierDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.IdentifierLiteral node) { this.Result = new IdentifierLiteral(node); }
        public override void ExplicitVisit(ScriptDom.IdentifierOrScalarExpression node) { this.Result = new IdentifierOrScalarExpression(node); }
        public override void ExplicitVisit(ScriptDom.IdentifierOrValueExpression node) { this.Result = new IdentifierOrValueExpression(node); }
        public override void ExplicitVisit(ScriptDom.IdentifierPrincipalOption node) { }
        public override void ExplicitVisit(ScriptDom.IdentifierSnippet node) { this.Result = new IdentifierSnippet(node); }
        public override void ExplicitVisit(ScriptDom.IdentityFunctionCall node) { this.Result = new IdentityFunctionCall(node); }
        public override void ExplicitVisit(ScriptDom.IdentityOptions node) { this.Result = new IdentityOptions(node); }
        public override void ExplicitVisit(ScriptDom.IdentityValueKeyOption node) { }
        public override void ExplicitVisit(ScriptDom.IfStatement node) { this.Result = new IfStatement(node); }
        public override void ExplicitVisit(ScriptDom.IgnoreDupKeyIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.InPredicate node) { this.Result = new InPredicate(node); }
        public override void ExplicitVisit(ScriptDom.IndexDefinition node) { }
        public override void ExplicitVisit(ScriptDom.IndexExpressionOption node) { }
        public override void ExplicitVisit(ScriptDom.IndexStateOption node) { }
        public override void ExplicitVisit(ScriptDom.IndexTableHint node) { }
        public override void ExplicitVisit(ScriptDom.IndexType node) { }
        public override void ExplicitVisit(ScriptDom.InlineDerivedTable node) { this.Result = new InlineDerivedTable(node); }
        public override void ExplicitVisit(ScriptDom.InlineResultSetDefinition node) { this.Result = new InlineResultSetDefinition(node); }
        public override void ExplicitVisit(ScriptDom.InsertBulkColumnDefinition node) { }
        public override void ExplicitVisit(ScriptDom.InsertBulkStatement node) { }
        public override void ExplicitVisit(ScriptDom.InsertMergeAction node) { this.Result = new InsertMergeAction(node); }
        public override void ExplicitVisit(ScriptDom.InsertSpecification node) { this.Result = new InsertSpecification(node); }
        public override void ExplicitVisit(ScriptDom.InsertStatement node) { this.Result = new InsertStatement(node); }
        public override void ExplicitVisit(ScriptDom.IntegerLiteral node) { this.Result = new IntegerLiteral(node); }
        public override void ExplicitVisit(ScriptDom.InternalOpenRowset node) { }
        public override void ExplicitVisit(ScriptDom.JoinParenthesisTableReference node) { this.Result = new JoinParenthesisTableReference(node); }
        public override void ExplicitVisit(ScriptDom.JsonForClause node) { this.Result = new JsonForClause(node); }
        public override void ExplicitVisit(ScriptDom.JsonForClauseOption node) { }
        public override void ExplicitVisit(ScriptDom.KeySourceKeyOption node) { }
        public override void ExplicitVisit(ScriptDom.KillQueryNotificationSubscriptionStatement node) { }
        public override void ExplicitVisit(ScriptDom.KillStatement node) { }
        public override void ExplicitVisit(ScriptDom.KillStatsJobStatement node) { }
        public override void ExplicitVisit(ScriptDom.LabelStatement node) { this.Result = new LabelStatement(node); }
        public override void ExplicitVisit(ScriptDom.LeftFunctionCall node) { this.Result = new LeftFunctionCall(node); }
        public override void ExplicitVisit(ScriptDom.LikePredicate node) { this.Result = new LikePredicate(node); }
        public override void ExplicitVisit(ScriptDom.LineNoStatement node) { }
        public override void ExplicitVisit(ScriptDom.ListenerIPEndpointProtocolOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralAtomicBlockOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralAuditTargetOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralAvailabilityGroupOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralBulkInsertOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralEndpointProtocolOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralOptimizerHint node) { }
        public override void ExplicitVisit(ScriptDom.LiteralOptionValue node) { }
        public override void ExplicitVisit(ScriptDom.LiteralPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralPrincipalOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralRange node) { this.Result = new LiteralRange(node); }
        public override void ExplicitVisit(ScriptDom.LiteralReplicaOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralSessionOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralStatisticsOption node) { }
        public override void ExplicitVisit(ScriptDom.LiteralTableHint node) { }
        public override void ExplicitVisit(ScriptDom.LockEscalationTableOption node) { }
        public override void ExplicitVisit(ScriptDom.LoginTypePayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.LowPriorityLockWaitAbortAfterWaitOption node) { }
        public override void ExplicitVisit(ScriptDom.LowPriorityLockWaitMaxDurationOption node) { }
        public override void ExplicitVisit(ScriptDom.LowPriorityLockWaitTableSwitchOption node) { }
        public override void ExplicitVisit(ScriptDom.MaxDispatchLatencySessionOption node) { }
        public override void ExplicitVisit(ScriptDom.MaxDopConfigurationOption node) { }
        public override void ExplicitVisit(ScriptDom.MaxDurationOption node) { }
        public override void ExplicitVisit(ScriptDom.MaxLiteral node) { this.Result = new MaxLiteral(node); }
        public override void ExplicitVisit(ScriptDom.MaxRolloverFilesAuditTargetOption node) { }
        public override void ExplicitVisit(ScriptDom.MaxSizeAuditTargetOption node) { }
        public override void ExplicitVisit(ScriptDom.MaxSizeDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.MaxSizeFileDeclarationOption node) { }
        public override void ExplicitVisit(ScriptDom.MemoryOptimizedTableOption node) { }
        public override void ExplicitVisit(ScriptDom.MemoryPartitionSessionOption node) { }
        public override void ExplicitVisit(ScriptDom.MergeActionClause node) { this.Result = new MergeActionClause(node); }
        public override void ExplicitVisit(ScriptDom.MergeSpecification node) { this.Result = new MergeSpecification(node); }
        public override void ExplicitVisit(ScriptDom.MergeStatement node) { this.Result = new MergeStatement(node); }
        public override void ExplicitVisit(ScriptDom.MethodSpecifier node) { this.Result = new MethodSpecifier(node); }
        public override void ExplicitVisit(ScriptDom.MirrorToClause node) { }
        public override void ExplicitVisit(ScriptDom.MoneyLiteral node) { this.Result = new MoneyLiteral(node); }
        public override void ExplicitVisit(ScriptDom.MoveConversationStatement node) { }
        public override void ExplicitVisit(ScriptDom.MoveRestoreOption node) { }
        public override void ExplicitVisit(ScriptDom.MoveToDropIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.MultiPartIdentifier node) { this.Result = new MultiPartIdentifier(node); }
        public override void ExplicitVisit(ScriptDom.MultiPartIdentifierCallTarget node) { this.Result = new MultiPartIdentifierCallTarget(node); }
        public override void ExplicitVisit(ScriptDom.NameFileDeclarationOption node) { }
        public override void ExplicitVisit(ScriptDom.NamedTableReference node) { this.Result = new NamedTableReference(node); }
        public override void ExplicitVisit(ScriptDom.NextValueForExpression node) { this.Result = new NextValueForExpression(node); }
        public override void ExplicitVisit(ScriptDom.NullIfExpression node) { this.Result = new NullIfExpression(node); }
        public override void ExplicitVisit(ScriptDom.NullLiteral node) { this.Result = new NullLiteral(node); }
        public override void ExplicitVisit(ScriptDom.NullableConstraintDefinition node) { this.Result = new NullableConstraintDefinition(node); }
        public override void ExplicitVisit(ScriptDom.NumericLiteral node) { this.Result = new NumericLiteral(node); }
        public override void ExplicitVisit(ScriptDom.OdbcConvertSpecification node) { /*this.Result = new OdbcConvertSpecification(node);*/ }
        public override void ExplicitVisit(ScriptDom.OdbcFunctionCall node) { /*this.Result = new OdbcFunctionCall(node);*/ }
        public override void ExplicitVisit(ScriptDom.OdbcLiteral node) { /*this.Result = new OdbcLiteral(node);*/ }
        public override void ExplicitVisit(ScriptDom.OdbcQualifiedJoinTableReference node) { /*this.Result = new OdbcQualifiedJoinTableReference(node);*/ }
        public override void ExplicitVisit(ScriptDom.OffsetClause node) { this.Result = new OffsetClause(node); }
        public override void ExplicitVisit(ScriptDom.OnFailureAuditOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffAssemblyOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffAtomicBlockOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffAuditTargetOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffDialogOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffFullTextCatalogOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffOptionValue node) { }
        public override void ExplicitVisit(ScriptDom.OnOffPrimaryConfigurationOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffPrincipalOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffRemoteServiceBindingOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffSessionOption node) { }
        public override void ExplicitVisit(ScriptDom.OnOffStatisticsOption node) { }
        public override void ExplicitVisit(ScriptDom.OnlineIndexLowPriorityLockWaitOption node) { }
        public override void ExplicitVisit(ScriptDom.OnlineIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.OpenCursorStatement node) { this.Result = new OpenCursorStatement(node); }
        public override void ExplicitVisit(ScriptDom.OpenJsonTableReference node) { this.Result = new OpenJsonTableReference(node); }
        public override void ExplicitVisit(ScriptDom.OpenMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.OpenQueryTableReference node) { }
        public override void ExplicitVisit(ScriptDom.OpenRowsetTableReference node) { }
        public override void ExplicitVisit(ScriptDom.OpenSymmetricKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.OpenXmlTableReference node) { this.Result = new OpenXmlTableReference(node); }
        public override void ExplicitVisit(ScriptDom.OptimizeForOptimizerHint node) { this.Result = new OptimizeForOptimizerHint(node); }
        public override void ExplicitVisit(ScriptDom.OptimizerHint node) { this.Result = new OptimizerHint(node); }
        public override void ExplicitVisit(ScriptDom.OrderBulkInsertOption node) { }
        public override void ExplicitVisit(ScriptDom.OrderByClause node) { this.Result = new OrderByClause(node); }
        public override void ExplicitVisit(ScriptDom.OrderIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.OutputClause node) { this.Result = new OutputClause(node); }
        public override void ExplicitVisit(ScriptDom.OutputIntoClause node) { this.Result = new OutputIntoClause(node); }
        public override void ExplicitVisit(ScriptDom.OverClause node) { this.Result = new OverClause(node); }
        public override void ExplicitVisit(ScriptDom.PageVerifyDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.ParameterizationDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.ParameterlessCall node) { this.Result = new ParameterlessCall(node); }
        public override void ExplicitVisit(ScriptDom.ParenthesisExpression node) { this.Result = new ParenthesisExpression(node); }
        public override void ExplicitVisit(ScriptDom.ParseCall node) { this.Result = new ParseCall(node); }
        public override void ExplicitVisit(ScriptDom.PartitionFunctionCall node) { }
        public override void ExplicitVisit(ScriptDom.PartitionParameterType node) { }
        public override void ExplicitVisit(ScriptDom.PartitionSpecifier node) { }
        public override void ExplicitVisit(ScriptDom.PartnerDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.PasswordAlterPrincipalOption node) { }
        public override void ExplicitVisit(ScriptDom.PasswordCreateLoginSource node) { }
        public override void ExplicitVisit(ScriptDom.Permission node) { }
        public override void ExplicitVisit(ScriptDom.PermissionSetAssemblyOption node) { }
        public override void ExplicitVisit(ScriptDom.PivotedTableReference node) { this.Result = new PivotedTableReference(node); }
        public override void ExplicitVisit(ScriptDom.PortsEndpointProtocolOption node) { }
        public override void ExplicitVisit(ScriptDom.PredicateSetStatement node) { this.Result = new PredicateSetStatement(node); }
        public override void ExplicitVisit(ScriptDom.PrimaryRoleReplicaOption node) { }
        public override void ExplicitVisit(ScriptDom.PrincipalOption node) { }
        public override void ExplicitVisit(ScriptDom.PrintStatement node) { this.Result = new PrintStatement(node); }
        public override void ExplicitVisit(ScriptDom.Privilege80 node) { }
        public override void ExplicitVisit(ScriptDom.PrivilegeSecurityElement80 node) { }
        public override void ExplicitVisit(ScriptDom.ProcedureOption node) { }
        public override void ExplicitVisit(ScriptDom.ProcedureParameter node) { this.Result = new ProcedureParameter(node); }
        public override void ExplicitVisit(ScriptDom.ProcedureReference node) { this.Result = new ProcedureReference(node); }
        public override void ExplicitVisit(ScriptDom.ProcedureReferenceName node) { this.Result = new ProcedureReferenceName(node); }
        public override void ExplicitVisit(ScriptDom.ProcessAffinityRange node) { }
        public override void ExplicitVisit(ScriptDom.ProviderEncryptionSource node) { }
        public override void ExplicitVisit(ScriptDom.ProviderKeyNameKeyOption node) { }
        public override void ExplicitVisit(ScriptDom.QualifiedJoin node) { this.Result = new QualifiedJoin(node); }
        public override void ExplicitVisit(ScriptDom.QueryDerivedTable node) { this.Result = new QueryDerivedTable(node); }
        public override void ExplicitVisit(ScriptDom.QueryParenthesisExpression node) { this.Result = new QueryParenthesisExpression(node); }
        public override void ExplicitVisit(ScriptDom.QuerySpecification node) { this.Result = new QuerySpecification(node); }
        public override void ExplicitVisit(ScriptDom.QueryStoreCapturePolicyOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreDataFlushIntervalOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreDesiredStateOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreIntervalLengthOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreMaxPlansPerQueryOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreMaxStorageSizeOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreSizeCleanupPolicyOption node) { }
        public override void ExplicitVisit(ScriptDom.QueryStoreTimeCleanupPolicyOption node) { }
        public override void ExplicitVisit(ScriptDom.QueueDelayAuditOption node) { }
        public override void ExplicitVisit(ScriptDom.QueueExecuteAsOption node) { }
        public override void ExplicitVisit(ScriptDom.QueueOption node) { }
        public override void ExplicitVisit(ScriptDom.QueueProcedureOption node) { }
        public override void ExplicitVisit(ScriptDom.QueueStateOption node) { }
        public override void ExplicitVisit(ScriptDom.QueueValueOption node) { }
        public override void ExplicitVisit(ScriptDom.RaiseErrorLegacyStatement node) { this.Result = new RaiseErrorLegacyStatement(node); }
        public override void ExplicitVisit(ScriptDom.RaiseErrorStatement node) { this.Result = new RaiseErrorStatement(node); }
        public override void ExplicitVisit(ScriptDom.ReadOnlyForClause node) { this.Result = new ReadOnlyForClause(node); }
        public override void ExplicitVisit(ScriptDom.ReadTextStatement node) { this.Result = new ReadTextStatement(node); }
        public override void ExplicitVisit(ScriptDom.RealLiteral node) { this.Result = new RealLiteral(node); }
        public override void ExplicitVisit(ScriptDom.ReceiveStatement node) { }
        public override void ExplicitVisit(ScriptDom.ReconfigureStatement node) { }
        public override void ExplicitVisit(ScriptDom.RecoveryDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.RemoteDataArchiveAlterTableOption node) { }
        public override void ExplicitVisit(ScriptDom.RemoteDataArchiveDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.RemoteDataArchiveDbCredentialSetting node) { }
        public override void ExplicitVisit(ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting node) { }
        public override void ExplicitVisit(ScriptDom.RemoteDataArchiveDbServerSetting node) { }
        public override void ExplicitVisit(ScriptDom.RemoteDataArchiveTableOption node) { }
        public override void ExplicitVisit(ScriptDom.RenameAlterRoleAction node) { }
        public override void ExplicitVisit(ScriptDom.ResampleStatisticsOption node) { }
        public override void ExplicitVisit(ScriptDom.ResourcePoolAffinitySpecification node) { }
        public override void ExplicitVisit(ScriptDom.ResourcePoolParameter node) { }
        public override void ExplicitVisit(ScriptDom.ResourcePoolStatement node) { }
        public override void ExplicitVisit(ScriptDom.RestoreMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.RestoreOption node) { }
        public override void ExplicitVisit(ScriptDom.RestoreServiceMasterKeyStatement node) { }
        public override void ExplicitVisit(ScriptDom.RestoreStatement node) { }
        public override void ExplicitVisit(ScriptDom.ResultColumnDefinition node) { this.Result = new ResultColumnDefinition(node); }
        public override void ExplicitVisit(ScriptDom.ResultSetDefinition node) { this.Result = new ResultSetDefinition(node); }
        public override void ExplicitVisit(ScriptDom.ResultSetsExecuteOption node) { }
        public override void ExplicitVisit(ScriptDom.RetentionPeriodDefinition node) { }
        public override void ExplicitVisit(ScriptDom.ReturnStatement node) { this.Result = new ReturnStatement(node); }
        public override void ExplicitVisit(ScriptDom.RevertStatement node) { }
        public override void ExplicitVisit(ScriptDom.RevokeStatement node) { }
        public override void ExplicitVisit(ScriptDom.RevokeStatement80 node) { }
        public override void ExplicitVisit(ScriptDom.RightFunctionCall node) { this.Result = new RightFunctionCall(node); }
        public override void ExplicitVisit(ScriptDom.RolePayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.RollbackTransactionStatement node) { this.Result = new RollbackTransactionStatement(node); }
        public override void ExplicitVisit(ScriptDom.RollupGroupingSpecification node) { this.Result = new RollupGroupingSpecification(node); }
        public override void ExplicitVisit(ScriptDom.RouteOption node) { }
        public override void ExplicitVisit(ScriptDom.RowValue node) { this.Result = new RowValue(node); }
        public override void ExplicitVisit(ScriptDom.SaveTransactionStatement node) { this.Result = new SaveTransactionStatement(node); }
        public override void ExplicitVisit(ScriptDom.ScalarExpressionDialogOption node) { }
        public override void ExplicitVisit(ScriptDom.ScalarExpressionRestoreOption node) { }
        public override void ExplicitVisit(ScriptDom.ScalarExpressionSequenceOption node) { }
        public override void ExplicitVisit(ScriptDom.ScalarExpressionSnippet node) { this.Result = new ScalarExpressionSnippet(node); }
        public override void ExplicitVisit(ScriptDom.ScalarFunctionReturnType node) { this.Result = new ScalarFunctionReturnType(node); }
        public override void ExplicitVisit(ScriptDom.ScalarSubquery node) { this.Result = new ScalarSubquery(node); }
        public override void ExplicitVisit(ScriptDom.SchemaDeclarationItem node) { this.Result = new SchemaDeclarationItem(node); }
        public override void ExplicitVisit(ScriptDom.SchemaDeclarationItemOpenjson node) { this.Result = new SchemaDeclarationItemOpenjson(node); }
        public override void ExplicitVisit(ScriptDom.SchemaObjectFunctionTableReference node) { this.Result = new SchemaObjectFunctionTableReference(node); }
        public override void ExplicitVisit(ScriptDom.SchemaObjectName node) { this.Result = new SchemaObjectName(node); }
        public override void ExplicitVisit(ScriptDom.SchemaObjectNameOrValueExpression node) { this.Result = new SchemaObjectNameOrValueExpression(node); }
        public override void ExplicitVisit(ScriptDom.SchemaObjectNameSnippet node) { this.Result = new SchemaObjectNameSnippet(node); }
        public override void ExplicitVisit(ScriptDom.SchemaObjectResultSetDefinition node) { this.Result = new SchemaObjectResultSetDefinition(node); }
        public override void ExplicitVisit(ScriptDom.SchemaPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.SearchPropertyListFullTextIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.SearchedCaseExpression node) { }
        public override void ExplicitVisit(ScriptDom.SearchedWhenClause node) { }
        public override void ExplicitVisit(ScriptDom.SecondaryRoleReplicaOption node) { }
        public override void ExplicitVisit(ScriptDom.SecurityPolicyOption node) { }
        public override void ExplicitVisit(ScriptDom.SecurityPredicateAction node) { }
        public override void ExplicitVisit(ScriptDom.SecurityPrincipal node) { }
        public override void ExplicitVisit(ScriptDom.SecurityTargetObject node) { }
        public override void ExplicitVisit(ScriptDom.SecurityTargetObjectName node) { }
        public override void ExplicitVisit(ScriptDom.SecurityUserClause80 node) { }
        public override void ExplicitVisit(ScriptDom.SelectFunctionReturnType node) { this.Result = new SelectFunctionReturnType(node); }
        public override void ExplicitVisit(ScriptDom.SelectInsertSource node) { this.Result = new SelectInsertSource(node); }
        public override void ExplicitVisit(ScriptDom.SelectScalarExpression node) { this.Result = new SelectScalarExpression(node); }
        public override void ExplicitVisit(ScriptDom.SelectSetVariable node) { this.Result = new SelectSetVariable(node); }
        public override void ExplicitVisit(ScriptDom.SelectStarExpression node) { this.Result = new SelectStarExpression(node); }
        public override void ExplicitVisit(ScriptDom.SelectStatement node) { this.Result = new SelectStatement(node); }
        public override void ExplicitVisit(ScriptDom.SelectStatementSnippet node) { this.Result = new SelectStatementSnippet(node); }
        public override void ExplicitVisit(ScriptDom.SelectiveXmlIndexPromotedPath node) { }
        public override void ExplicitVisit(ScriptDom.SemanticTableReference node) { this.Result = new SemanticTableReference(node); }
        public override void ExplicitVisit(ScriptDom.SendStatement node) { }
        public override void ExplicitVisit(ScriptDom.SequenceOption node) { }
        public override void ExplicitVisit(ScriptDom.ServiceContract node) { }
        public override void ExplicitVisit(ScriptDom.SessionTimeoutPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.SetCommandStatement node) { this.Result = new SetCommandStatement(node); }
        public override void ExplicitVisit(ScriptDom.SetErrorLevelStatement node) { this.Result = new SetErrorLevelStatement(node); }
        public override void ExplicitVisit(ScriptDom.SetFipsFlaggerCommand node) { }
        public override void ExplicitVisit(ScriptDom.SetIdentityInsertStatement node) { this.Result = new SetIdentityInsertStatement(node); }
        public override void ExplicitVisit(ScriptDom.SetOffsetsStatement node) { this.Result = new SetOffsetsStatement(node); }
        public override void ExplicitVisit(ScriptDom.SetRowCountStatement node) { this.Result = new SetRowCountStatement(node); }
        public override void ExplicitVisit(ScriptDom.SetSearchPropertyListAlterFullTextIndexAction node) { }
        public override void ExplicitVisit(ScriptDom.SetStatisticsStatement node) { }
        public override void ExplicitVisit(ScriptDom.SetStopListAlterFullTextIndexAction node) { }
        public override void ExplicitVisit(ScriptDom.SetTextSizeStatement node) { /*this.Result = new SetTextSizeStatement(node); */ }
        public override void ExplicitVisit(ScriptDom.SetTransactionIsolationLevelStatement node) { this.Result = new SetTransactionIsolationLevelStatement(node); }
        public override void ExplicitVisit(ScriptDom.SetUserStatement node) { }
        public override void ExplicitVisit(ScriptDom.SetVariableStatement node) { this.Result = new SetVariableStatement(node); }
        public override void ExplicitVisit(ScriptDom.ShutdownStatement node) { }
        public override void ExplicitVisit(ScriptDom.SimpleAlterFullTextIndexAction node) { }
        public override void ExplicitVisit(ScriptDom.SimpleCaseExpression node) { this.Result = new SimpleCaseExpression(node); }
        public override void ExplicitVisit(ScriptDom.SimpleWhenClause node) { this.Result = new SimpleWhenClause(node); }
        public override void ExplicitVisit(ScriptDom.SizeFileDeclarationOption node) { }
        public override void ExplicitVisit(ScriptDom.SoapMethod node) { }
        public override void ExplicitVisit(ScriptDom.SourceDeclaration node) { }
        public override void ExplicitVisit(ScriptDom.SpatialIndexRegularOption node) { }
        public override void ExplicitVisit(ScriptDom.SqlCommandIdentifier node) { this.Result = new SqlCommandIdentifier(node); }
        public override void ExplicitVisit(ScriptDom.SqlDataTypeReference node) { this.Result = new SqlDataTypeReference(node); }
        public override void ExplicitVisit(ScriptDom.StateAuditOption node) { }
        public override void ExplicitVisit(ScriptDom.StatementList node) { this.Result = new StatementList(node); }
        public override void ExplicitVisit(ScriptDom.StatementListSnippet node) { this.Result = new StatementListSnippet(node); }
        public override void ExplicitVisit(ScriptDom.StatisticsOption node) { }
        public override void ExplicitVisit(ScriptDom.StatisticsPartitionRange node) { }
        public override void ExplicitVisit(ScriptDom.StopListFullTextIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.StopRestoreOption node) { }
        public override void ExplicitVisit(ScriptDom.StringLiteral node) { this.Result = new StringLiteral(node); }
        public override void ExplicitVisit(ScriptDom.SubqueryComparisonPredicate node) { this.Result = new SubqueryComparisonPredicate(node); }
        public override void ExplicitVisit(ScriptDom.SystemTimePeriodDefinition node) { }
        public override void ExplicitVisit(ScriptDom.SystemVersioningTableOption node) { }
        public override void ExplicitVisit(ScriptDom.TSEqualCall node) { this.Result = new TSEqualCall(node); }
        public override void ExplicitVisit(ScriptDom.TSqlBatch node) { this.Result = new SqlBatch(node); }
        public override void ExplicitVisit(ScriptDom.TSqlFragmentSnippet node) { this.Result = new TSqlFragmentSnippet(node); }
        public override void ExplicitVisit(ScriptDom.TSqlScript node) { this.Result = new SqlScript(node); }
        public override void ExplicitVisit(ScriptDom.TSqlStatementSnippet node) { this.Result = new TSqlStatementSnippet(node); }
        public override void ExplicitVisit(ScriptDom.TableClusteredIndexType node) { this.Result = new TableClusteredIndexType(node); }
        public override void ExplicitVisit(ScriptDom.TableDataCompressionOption node) { }
        public override void ExplicitVisit(ScriptDom.TableDefinition node) { this.Result = new TableDefinition(node); }
        public override void ExplicitVisit(ScriptDom.TableDistributionOption node) { }
        public override void ExplicitVisit(ScriptDom.TableHashDistributionPolicy node) { }
        public override void ExplicitVisit(ScriptDom.TableHint node) { }
        public override void ExplicitVisit(ScriptDom.TableHintsOptimizerHint node) { }
        public override void ExplicitVisit(ScriptDom.TableIndexOption node) { }
        public override void ExplicitVisit(ScriptDom.TableNonClusteredIndexType node) { this.Result = new TableNonClusteredIndexType(node); }
        public override void ExplicitVisit(ScriptDom.TablePartitionOption node) { }
        public override void ExplicitVisit(ScriptDom.TablePartitionOptionSpecifications node) { }
        public override void ExplicitVisit(ScriptDom.TableReplicateDistributionPolicy node) { }
        public override void ExplicitVisit(ScriptDom.TableRoundRobinDistributionPolicy node) { }
        public override void ExplicitVisit(ScriptDom.TableSampleClause node) { }
        public override void ExplicitVisit(ScriptDom.TableValuedFunctionReturnType node) { this.Result = new TableValuedFunctionReturnType(node); }
        public override void ExplicitVisit(ScriptDom.TargetDeclaration node) { }
        public override void ExplicitVisit(ScriptDom.TargetRecoveryTimeDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.TemporalClause node) { }
        public override void ExplicitVisit(ScriptDom.ThrowStatement node) { this.Result = new ThrowStatement(node); }
        public override void ExplicitVisit(ScriptDom.TopRowFilter node) { this.Result = new TopRowFilter(node); }
        public override void ExplicitVisit(ScriptDom.TriggerAction node) { }
        public override void ExplicitVisit(ScriptDom.TriggerObject node) { }
        public override void ExplicitVisit(ScriptDom.TriggerOption node) { }
        public override void ExplicitVisit(ScriptDom.TruncateTableStatement node) { this.Result = new TruncateTableStatement(node); }
        public override void ExplicitVisit(ScriptDom.TryCastCall node) { this.Result = new TryCastCall(node); }
        public override void ExplicitVisit(ScriptDom.TryCatchStatement node) { this.Result = new TryCatchStatement(node); }
        public override void ExplicitVisit(ScriptDom.TryConvertCall node) { this.Result = new TryConvertCall(node); }
        public override void ExplicitVisit(ScriptDom.TryParseCall node) { this.Result = new TryParseCall(node); }
        public override void ExplicitVisit(ScriptDom.UnaryExpression node) { this.Result = new UnaryExpression(node); }
        public override void ExplicitVisit(ScriptDom.UniqueConstraintDefinition node) { this.Result = new UniqueConstraintDefinition(node); }
        public override void ExplicitVisit(ScriptDom.UnpivotedTableReference node) { this.Result = new UnpivotedTableReference(node); }
        public override void ExplicitVisit(ScriptDom.UnqualifiedJoin node) { this.Result = new UnqualifiedJoin(node); }
        public override void ExplicitVisit(ScriptDom.UpdateCall node) { this.Result = new UpdateCall(node); }
        public override void ExplicitVisit(ScriptDom.UpdateForClause node) { this.Result = new UpdateForClause(node); }
        public override void ExplicitVisit(ScriptDom.UpdateMergeAction node) { this.Result = new UpdateMergeAction(node); }
        public override void ExplicitVisit(ScriptDom.UpdateSpecification node) { this.Result = new UpdateSpecification(node); }
        public override void ExplicitVisit(ScriptDom.UpdateStatement node) { this.Result = new UpdateStatement(node); }
        public override void ExplicitVisit(ScriptDom.UpdateStatisticsStatement node) { }
        public override void ExplicitVisit(ScriptDom.UpdateTextStatement node) { this.Result = new UpdateTextStatement(node); }
        public override void ExplicitVisit(ScriptDom.UseFederationStatement node) { }
        public override void ExplicitVisit(ScriptDom.UseHintList node) { this.Result = new UseHintList(node); }
        public override void ExplicitVisit(ScriptDom.UseStatement node) { }
        public override void ExplicitVisit(ScriptDom.UserDataTypeReference node) { this.Result = new UserDataTypeReference(node); }
        public override void ExplicitVisit(ScriptDom.UserDefinedTypeCallTarget node) { this.Result = new UserDefinedTypeCallTarget(node); }
        public override void ExplicitVisit(ScriptDom.UserDefinedTypePropertyAccess node) { this.Result = new UserDefinedTypePropertyAccess(node); }
        public override void ExplicitVisit(ScriptDom.UserLoginOption node) { }
        public override void ExplicitVisit(ScriptDom.UserRemoteServiceBindingOption node) { }
        public override void ExplicitVisit(ScriptDom.ValuesInsertSource node) { this.Result = new ValuesInsertSource(node); }
        public override void ExplicitVisit(ScriptDom.VariableMethodCallTableReference node) { this.Result = new VariableMethodCallTableReference(node); }
        public override void ExplicitVisit(ScriptDom.VariableReference node) { this.Result = new VariableReference(node); }
        public override void ExplicitVisit(ScriptDom.VariableTableReference node) { this.Result = new VariableTableReference(node); }
        public override void ExplicitVisit(ScriptDom.VariableValuePair node) { this.Result = new VariableValuePair(node); }
        public override void ExplicitVisit(ScriptDom.ViewOption node) { }
        public override void ExplicitVisit(ScriptDom.WaitAtLowPriorityOption node) { }
        public override void ExplicitVisit(ScriptDom.WaitForStatement node) { this.Result = new WaitForStatement(node); }
        public override void ExplicitVisit(ScriptDom.WhereClause node) { this.Result = new WhereClause(node); }
        public override void ExplicitVisit(ScriptDom.WhileStatement node) { this.Result = new WhileStatement(node); }
        public override void ExplicitVisit(ScriptDom.WindowDelimiter node) { this.Result = new WindowDelimiter(node); }
        public override void ExplicitVisit(ScriptDom.WindowFrameClause node) { this.Result = new WindowFrameClause(node); }
        public override void ExplicitVisit(ScriptDom.WindowsCreateLoginSource node) { }
        public override void ExplicitVisit(ScriptDom.WithCtesAndXmlNamespaces node) { this.Result = new WithCtesAndXmlNamespaces(node); }
        public override void ExplicitVisit(ScriptDom.WithinGroupClause node) { this.Result = new WithinGroupClause(node); }
        public override void ExplicitVisit(ScriptDom.WitnessDatabaseOption node) { }
        public override void ExplicitVisit(ScriptDom.WorkloadGroupImportanceParameter node) { }
        public override void ExplicitVisit(ScriptDom.WorkloadGroupResourceParameter node) { }
        public override void ExplicitVisit(ScriptDom.WriteTextStatement node) { this.Result = new WriteTextStatement(node); }
        public override void ExplicitVisit(ScriptDom.WsdlPayloadOption node) { }
        public override void ExplicitVisit(ScriptDom.XmlDataTypeReference node) { this.Result = new XmlDataTypeReference(node); }
        public override void ExplicitVisit(ScriptDom.XmlForClause node) { this.Result = new XmlForClause(node); }
        public override void ExplicitVisit(ScriptDom.XmlForClauseOption node) { }
        public override void ExplicitVisit(ScriptDom.XmlNamespaces node) { this.Result = new XmlNamespaces(node); }
        public override void ExplicitVisit(ScriptDom.XmlNamespacesAliasElement node) { this.Result = new XmlNamespacesAliasElement(node); }
        public override void ExplicitVisit(ScriptDom.XmlNamespacesDefaultElement node) { this.Result = new XmlNamespacesDefaultElement(node); }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        public override string ToString() {
            return base.ToString();
        }
    }
}
