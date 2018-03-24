namespace OfaSchlupfer.ODataV4 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Model;

    public class ODataV4RepositoryModelType : ReferenceRepositoryModelType {
        public ODataV4RepositoryModelType(IServiceProvider serviceProvider) : base(serviceProvider) {
            this.Name = "ODataV4";
            this.Description = "ODataV4.";
        }
        public override IReferenceRepositoryModel CreateReferenceRepositoryModel() {
            try {
                return this.ServiceProvider.GetRequiredService<ODataV4RepositoryModel>();
            } catch (InvalidOperationException) {
                return new ODataV4RepositoryImplementation();
            }
        }
    }

    public abstract class ODataV4RepositoryModel : ReferenceRepositoryModelBase {
        protected ODataV4RepositoryModel() {
        }
    }

    public class ODataV4RepositoryImplementation : ODataV4RepositoryModel, IReferenceRepositoryModel {
        public ODataV4RepositoryImplementation() {
        }

        public string ConnectionString { get; set; }

        public void ReadSchema() {
        }

        public override List<string> BuildSchema(string metadataContent) {
            throw new NotImplementedException();
        }
    }
}
