namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.MSSQLReflection.Model;

    public class SqlRepositoryModelType : ExternalRepositoryModelType {
        public const string TypeName = "SQL";

        public SqlRepositoryModelType(
            IServiceProvider serviceProvider
            //IHttpClientDispatcherFactory httpClientDispatcherFactory
            ) : base(serviceProvider) {
            this.Name = TypeName;
            this.Description = "Read access to ShrePointOnline sources.";
        }
        public override IExternalRepositoryModel CreateExternalRepositoryModel() {
            try {
                return this.ServiceProvider.GetRequiredService<SqlRepositoryModel>();
            } catch (InvalidOperationException) {
                return new SqlRepositoryImplementation();
            }
        }
    }

    public abstract class SqlRepositoryModel : ExternalRepositoryModelBase {
        protected SqlRepositoryModel() {
        }

        [JsonProperty]
        public RepositoryConnectionString ConnectionString { get; set; }

        public virtual void ReadSQLSchema(
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors
            ) { }

        [JsonIgnore]
        public ModelSqlDatabase ModelDatabase { get; set; }


        public override IEntity CreateEntityByExternalTypeName(string externalTypeName) {
#warning TODO
            throw new NotImplementedException();
        }
    }

    [JsonObject]
    public class SqlRepositoryImplementation : SqlRepositoryModel, IExternalRepositoryModel {
        public SqlRepositoryImplementation() {
        }
        
        public override string GetRepositoryTypeName() => SqlRepositoryModelType.TypeName;

        public override void ReadSQLSchema(
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors
            ) {
            var utility = new MSSQLReflection.Utility() { ConnectionString = this.ConnectionString.Url };
            utility.ReadAll();
            var modelDatabase = utility.ModelDatabase;
            this.ModelDatabase = modelDatabase;

            var modelSchemaBuilder = new SQLSModelSchemaBuilder();
            var modelSchema = new ModelSchema();            
            modelSchemaBuilder.Build(modelDatabase, modelSchema, metaModelBuilder, errors);
            this.ModelSchema = modelSchema;

            // modelDatabase.Tables.Values.Where(tbl=>tbl.Schema==)
        }

        public override List<string> BuildSchema(string metadataContent) {
            throw new NotImplementedException();
        }

        public override ModelSchema GetModelSchema(MetaModelBuilder metaModelBuilder, ModelErrors errors) {
            throw new NotImplementedException();
        }
    }
}
