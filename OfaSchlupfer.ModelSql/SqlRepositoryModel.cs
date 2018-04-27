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
    using OfaSchlupfer.TextTemplate;
    using OfaSchlupfer.TextTemplate.Runtime;

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

        public virtual ModelSchema ReadSQLSchema(
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors
            ) {
            throw new NotImplementedException();
        }

        [JsonIgnore]
        public ModelSqlDatabase ModelDatabase { get; set; }

        public override IModelBuilderNamingService GetNamingService(MappingModelRepository mappingModelRepository) => new SqlModelBuilderNamingService(mappingModelRepository);

        public override IEntity CreateEntityByExternalTypeName(string externalTypeName) {
#warning TODO
            throw new NotImplementedException();
        }
        public virtual void UpdateTargetSchema(ModelErrors errors) {
        }

        public virtual void GenerateUpdateSchemaSQL(ModelErrors errors, Action<string, string> generatedString) {
        }
    }

    [JsonObject]
    public class SqlRepositoryImplementation : SqlRepositoryModel, IExternalRepositoryModel {
        public SqlRepositoryImplementation() {
        }

        public override string GetRepositoryTypeName() => SqlRepositoryModelType.TypeName;

        public override ModelSchema ReadSQLSchema(
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors
            ) {
            var utility = new MSSQLReflection.Utility() { ConnectionString = this.ConnectionString.Url };
            utility.ReadAll();
            var modelDatabase = utility.ModelDatabase;
            this.ModelDatabase = modelDatabase;

            var modelSchemaBuilder = new SqlModelSchemaBuilder();
            var result = new ModelSchema();
            modelSchemaBuilder.BuildModelSchema(modelDatabase, result, metaModelBuilder, errors);
            this.ModelSchema = result;
            return result;
        }

        public override List<string> BuildSchema(string metadataContent) {
            throw new NotImplementedException();
        }

        public override ModelSchema GetModelSchema(MetaModelBuilder metaModelBuilder, ModelErrors errors) {
            var result = this.ModelSchema;
            if (result is null) {
                var modelDatabase = this.ModelDatabase;
                if (modelDatabase is null) {
                    var utility = new MSSQLReflection.Utility() { ConnectionString = this.ConnectionString.Url };
                    utility.ReadAll();
                    modelDatabase = utility.ModelDatabase;
                    this.ModelDatabase = modelDatabase;
                }
                if (!(modelDatabase is null)) {
                    var modelSchemaBuilder = new SqlModelSchemaBuilder();
                    result = new ModelSchema();
                    modelSchemaBuilder.BuildModelSchema(modelDatabase, result, metaModelBuilder, errors);
                    this.ModelSchema = result;
                }
            }
            return result;
        }

        public override void UpdateTargetSchema(ModelErrors errors) {
            if (this.ModelDatabase is null) {
                errors.AddErrorOrThrow("ModelDatabase is null", this.ModelSchema.Name);
                return;
            }
            this.GenerateUpdateSchemaSQL(errors, (name, sql) => {
                // TODO call sql
            });
        }

        public override void GenerateUpdateSchemaSQL(ModelErrors errors, Action<string, string> generatedString) {
            foreach (var table in this.ModelDatabase.Tables) {
                var templateContext = new TemplateContext();


                var template = OfaSchlupfer.TextTemplate.Template.Parse(@"
CREATE TABLE {{QName}} (
    {{ for column in Columns }}
    {{ if for.first }} {{ else }},{{end}} {{ column.QName }} {{ column.SqlType.QName }} {{ if column.SqlType.Nullable }}NULL{{else}}NOT NULL{{end}}
    {{- end }}
);
");
                

                var scriptObject = new ScriptObject();

                scriptObject.Import(table, null, templateContext.MemberRenamer);
                //var x = table.Columns[0].SqlType.QName;
                templateContext.EnableRelaxedMemberAccess = true;
                templateContext.PushGlobal(scriptObject);
                var result = template.Render(templateContext);
                generatedString($"Table {table.QName}", result);
                templateContext.PopGlobal();
            }
        }
    }
}
