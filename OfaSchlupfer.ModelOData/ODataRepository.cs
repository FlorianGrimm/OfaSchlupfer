namespace OfaSchlupfer.ModelOData {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Model;
    using Microsoft.Extensions.DependencyInjection;
    using OfaSchlupfer.ModelOData.SPO;
    using OfaSchlupfer.HttpAccess;

    public class ODataRepositoryModelType : ReferenceRepositoryModelType {
        public ODataRepositoryModelType(IServiceProvider serviceProvider) : base(serviceProvider) {
            this.Name = "OData";
            this.Description = "Read access to OData sources.";
        }

        public override IReferenceRepositoryModel CreateReferenceRepositoryModel() {
            try {
                return this.ServiceProvider.GetRequiredService<ODataRepository>();
            } catch (InvalidOperationException) {
                return new ODataRepositoryImplementation(this.ServiceProvider.GetRequiredService<ISharePointOnlineClientFactory>());
            }
        }
    }

    public abstract class ODataRepository : ReferenceRepositoryModelBase {
        protected ODataRepository() { }

        public RepositoryConnectionString ConnectionString { get; set; }
        
        public virtual void SetConnectionString(RepositoryConnectionString connectionString, string suffix) {
            if (string.IsNullOrEmpty(suffix)) {
                this.ConnectionString = connectionString;
            } else {
                this.ConnectionString = connectionString.CreateSuffix(suffix);
            }
        }

        public virtual void x() {
        }

        public abstract string GetUrlMetadata();
        public abstract Task<string> GetMetadataAsync();
        //public IEdmModel EdmModel { get; set; }
    }

    public class ODataRepositoryImplementation : ODataRepository, IReferenceRepositoryModel {
        //  https://m365x235962.sharepoint.com/sites/pwa/_api/projectserver
        // https://code.msdn.microsoft.com/office/Invoke-SharePoint-REST-API-078a0638/sourcecode?fileId=136158&pathId=613790383
        private IHttpClientFactory _ClientFactory;
        // IODataClientFactory

        public ODataRepositoryImplementation(
            IHttpClientFactory clientFactory
            ) {
            this._ClientFactory = clientFactory;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public override string GetUrlMetadata() {
            var url = this.ConnectionString?.GetUrlNormalized();
            if (string.IsNullOrEmpty(url)) {
                return null;
            } else {
                return $"{url}/$metadata";
            }
        }

        public override async Task<string> GetMetadataAsync() {
            //this._SharePointOnlineCredentialsFactory.Create
#warning HERE
            var client = this._ClientFactory.CreateHttpClient(this.ConnectionString, null);
            var requestUrl = this.GetUrlMetadata();
            var t = client.GetAsStringAsync(
                requestUrl,
                (httpClient) => {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                },
                null);
            string result;
            try {
                result = await t;
            } catch (Exception err) {
                throw err;
            }
            return result;
        }

        public override List<string> BuildSchema(string metadataContent) {
            var result = new List<string>();
#if no
            try {
                var modelDefinition = new ModelDefinition() {
                    MetaData = metadataContent,
                    Kind = "OData"
                };

                var modelSchema = new ModelSchema();

                var builder = new ODataModelBuilder();
                builder.ModelDefinition = modelDefinition;
                builder.ModelSchema = modelSchema;
                result = builder.Build();

                // https://github.com/OData/odata.net/blob/master/src/CodeGen/ODataT4CodeGenerator.ttinclude
                this.EdmModel = builder.EdmModel;
                this.ModelSchema = modelSchema;
                this.ModelDefinition = modelDefinition;

            } catch (Exception error) {
                result.Add(error.ToString());
            }
#endif
            return result;
        }

        /*
        public static string GetCsdlFormWeb(Uri requestUrl, Action<System.Net.WebClient> setOptions = null) {
            if (requestUrl == null) {
                return null;
            }

            using (var client = new System.Net.WebClient()) {
                client.Headers[System.Net.HttpRequestHeader.Accept] = "application/xml";
                if (setOptions != null) {
                    setOptions(client);
                }
                return client.DownloadString(requestUrl);
            }
        }
        */
    }
}
