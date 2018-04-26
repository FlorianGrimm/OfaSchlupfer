namespace OfaSchlupfer.ModelOData {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Rest;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.ModelOData.ODataAccess;
    using OfaSchlupfer.ModelOData.Edm;
    using OfaSchlupfer.SPO;

    public class ODataRepositoryModelType : ExternalRepositoryModelType {
        public const string ModelTypeName = "OData";

        public ODataRepositoryModelType(IServiceProvider serviceProvider) : base(serviceProvider) {
            this.Name = ODataRepositoryModelType.ModelTypeName;
            this.Description = "Read access to OData sources.";
        }

        public override IExternalRepositoryModel CreateExternalRepositoryModel() {

            try {
                return this.ServiceProvider.GetRequiredService<ODataRepository>();
            } catch (InvalidOperationException) {
                //return new ODataRepositoryImplementation(this.ServiceProvider.GetRequiredService<ISharePointOnlineClientFactory>());
                //var clientFactory = this.HttpClientDispatcherFactory ?? this.ServiceProvider.GetService<IHttpClientDispatcherFactory>();
                return new ODataRepositoryImplementation();
            }
        }
    }

    public abstract class ODataRepository : ExternalRepositoryModelBase {
        protected EdmxModel _EdmxModel;
        //protected IHttpClientDispatcherFactory _ClientFactory;
        //protected IHttpClientCredentials _HttpClientCredentials;
        protected IHttpServiceClient _ServiceClient;
        protected ODataRepository(
            ) {
        }

        [System.Diagnostics.DebuggerStepThrough]
        public override string GetRepositoryTypeName() => ODataRepositoryModelType.ModelTypeName;

        public RepositoryConnectionString ConnectionString { get; set; }

        public EdmxModel EdmxModel {
            get {
                return this._EdmxModel;
            }
            set {
                this.ThrowIfFrozen();
                this._EdmxModel = value;
            }
        }

        public virtual EdmxModel GetEdmxModel() {
            if (!(this._EdmxModel is null)) { return this._EdmxModel; }
            if (this.ModelDefinition is null) {
                return null;
            }
            {
                var edmReader = new EdmReader();
                using (var sr = new System.IO.StringReader(this.ModelDefinition.MetaData)) {
                    var edmxModel = edmReader.Read(sr, true, null);
                    this.EdmxModel = edmxModel;
                }
            }
            return this.EdmxModel;
        }

        public override ModelSchema GetModelSchema(MetaModelBuilder metaModelBuilder, ModelErrors errors) {
            var result = this.ModelSchema;
            if (result is null) {
                if (this._EdmxModel != null) {
                    var builder = new EdmxModelSchemaBuilder();
                    result = new ModelSchema();
                    builder.Build(this._EdmxModel, result, metaModelBuilder, errors);
#warning result.Freeze();
                    this.ModelSchema = result;
                }
            }
            return result;
        }


        public virtual void SetConnectionString(RepositoryConnectionString connectionString, string suffix) {
            if (string.IsNullOrEmpty(suffix)) {
                this.ConnectionString = connectionString;
            } else {
                this.ConnectionString = connectionString.CreateWithSuffix(suffix);
            }
        }

        public virtual IHttpServiceClient GetHttpServiceClient() {
            var result = this._ServiceClient;
            if (result == null) {
                lock (this) {
                    result = this._ServiceClient;
                    if (result == null) {
                        var baseUri = new Uri(this.ConnectionString.GetUrlNormalized());
#warning TODO ServiceClientCredentialsFactory
                        ServiceClientCredentials credentials = new SharePointOnlineServiceClientCredentials(this.ConnectionString, null);
                        result = new ODataServiceClient(baseUri, credentials, null);
                        this._ServiceClient = result;
                    }
                }
            }
            return result;
        }

        public abstract string GetUrlMetadata();
        public abstract Task<string> GetMetadataAsync();
    }

    public class ODataRepositoryImplementation : ODataRepository, IExternalRepositoryModel {

        //  https://m365x235962.sharepoint.com/sites/pwa/_api/projectserver
        // https://code.msdn.microsoft.com/office/Invoke-SharePoint-REST-API-078a0638/sourcecode?fileId=136158&pathId=613790383

        public ODataRepositoryImplementation(
            //IHttpClientDispatcherFactory clientFactory
            ) : base() {
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

        public override /*async*/ Task<string> GetMetadataAsync() {
            //this._SharePointOnlineCredentialsFactory.Create
            var client = this.GetHttpServiceClient();
            var requestUrl = this.GetUrlMetadata();
            Todo.Later("GetMetadataAsync");
            throw new NotImplementedException("GetMetadataAsync");
            //var t = client.GetAsStringAsync(
            //    requestUrl,
            //    (httpClient) => {
            //        httpClient.DefaultRequestHeaders.Accept.Clear();
            //        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
            //    },
            //    null);
            //string result;
            //try {
            //    result = await t;
            //} catch (Exception err) {
            //    throw err;
            //}
            //return result;
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

        public override IEntity CreateEntityByExternalTypeName(string externalTypeName) {
            //return this.EdmxModel.CreateEntityByExternalTypeName(externalTypeName);
#warning            IServiceProvider serviceProvider

            //   var complexType = this.ModelSchema.FindComplexType(externalTypeName);

            //this.ModelSchema.FindEntity(externalTypeName);
            throw new NotImplementedException("CreateEntityByExternalTypeName");
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
