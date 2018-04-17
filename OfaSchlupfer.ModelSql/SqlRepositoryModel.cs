namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.Model;

    public class SqlRepositoryModelType : ReferenceRepositoryModelType {
        public const string TypeName = "SQL";

        public SqlRepositoryModelType(
            IServiceProvider serviceProvider
            //IHttpClientDispatcherFactory httpClientDispatcherFactory
            ) : base(serviceProvider) {
            this.Name = TypeName;
            this.Description = "Read access to ShrePointOnline sources.";
        }
        public override IReferenceRepositoryModel CreateReferenceRepositoryModel() {
            try {
                return this.ServiceProvider.GetRequiredService<SqlRepositoryModel>();
            } catch (InvalidOperationException) {
                return new SqlRepositoryImplementation();
            }
        }
    }

    public abstract class SqlRepositoryModel : ReferenceRepositoryModelBase {
        protected SqlRepositoryModel() {
        }

        public override IEntity CreateEntityByExternalTypeName(string externalTypeName) {
#warning TODO
            throw new NotImplementedException();
        }
    }

    public class SqlRepositoryImplementation : SqlRepositoryModel, IReferenceRepositoryModel {
        public SqlRepositoryImplementation() {
        }

        public string ConnectionString { get; set; }

        public override string GetModelTypeName() => SqlRepositoryModelType.TypeName;

        public void ReadSchema() {
            var utility = new MSSQLReflection.Utility() { ConnectionString = this.ConnectionString };
            utility.ReadAll();
            var modelDatabase = utility.ModelDatabase;
            // modelDatabase.Tables.Values.Where(tbl=>tbl.Schema==)
        }

        public override List<string> BuildSchema(string metadataContent) {
            throw new NotImplementedException();
        }
    }
}
