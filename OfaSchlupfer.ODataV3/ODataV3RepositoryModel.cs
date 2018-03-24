namespace OfaSchlupfer.ODataV3 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using Microsoft.Data.Edm;
    using Microsoft.Data.Edm.Csdl;

    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Model;

    public class ODataV3RepositoryModelType : ReferenceRepositoryModelType {
        public ODataV3RepositoryModelType(IServiceProvider serviceProvider) : base(serviceProvider) {
            this.Name = "ODataV3";
            this.Description = "ODataV3.";
        }
        public override IReferenceRepositoryModel CreateReferenceRepositoryModel() {
            try {
                return this.ServiceProvider.GetRequiredService<ODataV3RepositoryModel>();
            } catch (InvalidOperationException) {
                return new ODataV3RepositoryImplementation();
            }
        }
    }

    public abstract class ODataV3RepositoryModel : ReferenceRepositoryModelBase {
        protected ODataV3RepositoryModel() {
        }


    }

    public class ODataV3RepositoryImplementation : ODataV3RepositoryModel, IReferenceRepositoryModel {
        public ODataV3RepositoryImplementation() {
        }

        public string ConnectionString { get; set; }

        public void ReadSchema(string content) {
            //Microsoft.Data.Edm.Csdl.CsdlReader.TryParse()
            //System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();

            using (var reader = System.Xml.XmlReader.Create(new System.IO.StringReader(content))) {
                var edmModel = EdmxReader.Parse(reader);
                //edmModel.EntityContainers();
            }
        }

        public override List<string> BuildSchema(string metadataContent) {
            throw new NotImplementedException();
        }
    }
}
