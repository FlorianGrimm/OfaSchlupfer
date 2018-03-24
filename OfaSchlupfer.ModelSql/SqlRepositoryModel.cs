﻿namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Model; 

    public class SqlRepositoryModelType : ReferenceRepositoryModelType {
        public SqlRepositoryModelType(IServiceProvider serviceProvider) : base(serviceProvider) {
            this.Name = "SPO";
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
    }

    public class SqlRepositoryImplementation : SqlRepositoryModel, IReferenceRepositoryModel {
        public SqlRepositoryImplementation() {
        }

        public string ConnectionString { get; set; }

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