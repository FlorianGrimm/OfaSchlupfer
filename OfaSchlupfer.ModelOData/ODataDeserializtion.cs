namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.ModelOData.Edm;

    public class ODataDeserializtion {
        private const string PropertyName__metadata = "__metadata";
        private const string PropertyName_d = "d";
        private const string PropertyName_results = "results";
        private const string PropertyName_id = "id";
        private const string PropertyName_uri = "uri";
        private const string PropertyName_type = "type";

        //public readonly ODataResponce oDataResponce;
        public readonly ODataQueryRequest oDataRequest;
        //public readonly EdmxModel edmxModel;
        public readonly ODataServiceClient oDataClient;

        //public ODataDeserializtion(ODataResponce oDataResponce, ODataQueryRequest oDataRequest, EdmxModel edmxModel) {
        //    this.oDataResponce = oDataResponce;
        //    this.oDataRequest = oDataRequest;
        //    this.edmxModel = edmxModel;
        //}

        public ODataDeserializtion(ODataQueryRequest oDataRequest, ODataServiceClient oDataClient) {
            this.oDataRequest = oDataRequest;
            this.oDataClient = oDataClient;
        }

        public object Deserialize(string responceContentString) {
            var settings = new JsonSerializerSettings();

            var jsonResponce = JsonConvert.DeserializeObject(responceContentString, settings);
            if (jsonResponce is Newtonsoft.Json.Linq.JObject jsonRoot) {
                if (jsonRoot.Type == Newtonsoft.Json.Linq.JTokenType.Object) {
                    var jsonProperty = jsonRoot.Property(PropertyName_d);
                    if (jsonProperty != null) {
                        var dChildAny = jsonProperty.Value;

                        if ((dChildAny.Type == Newtonsoft.Json.Linq.JTokenType.Object)
                            && (dChildAny is Newtonsoft.Json.Linq.JObject dChildObject)) {
                            var dResultsAny = dChildObject.Property(PropertyName_results);
                            if (dResultsAny != null) {
                                var dResultsValue = dResultsAny.Value;
                                if (dResultsValue.Type == Newtonsoft.Json.Linq.JTokenType.Array) {
                                    var result = new List<IEntity>();
                                    ParseArray((Newtonsoft.Json.Linq.JArray)dResultsValue, result.Add);
                                    return result;
                                } else if (dResultsValue.Type == Newtonsoft.Json.Linq.JTokenType.Object) {
                                    var result = ParseObject((Newtonsoft.Json.Linq.JObject)dResultsValue);
                                    return result;
                                } else {
                                    throw new NotImplementedException("d results expected array or object");
                                }
                            } else {
                                throw new NotImplementedException("d results expected");
                            }
                        } else {
                            throw new NotImplementedException("d as Object expected");
                        }
                    } else {
                        throw new NotImplementedException("d expected");
                    }
                } else {
                    throw new NotImplementedException(jsonRoot.Type.ToString());
                }
            } else {
                throw new NotImplementedException(jsonResponce.GetType().FullName);
            }
        }

        public void ParseArray(JArray jArray, Action<IEntity> addToList) {
            foreach (var jToken in jArray.Children()) {
                if (jToken is JObject jObject) {
                    var entity = ParseObject(jObject);
                    addToList?.Invoke(entity);
                }
            }
        }

        public IEntity ParseObject(Newtonsoft.Json.Linq.JObject jObject) {
            var metaData = jObject.Property(PropertyName__metadata);
            if (metaData != null && metaData.Value is JObject jObjectMetadata) {
                /*
                 *  {"d":{"results":[{
                 *  "__metadata":{
                 *      "id":"https://m365x235962.sharepoint.com/sites/pwa/_api/ProjectData/%5Ben-us%5D/Projects(guid'c54ff8c6-4e51-e711-80d4-00155d38270c')",
                 *      "uri":"https://m365x235962.sharepoint.com/sites/pwa/_api/ProjectData/%5Ben-us%5D/Projects(guid'c54ff8c6-4e51-e711-80d4-00155d38270c')",
                 *      "type":"ReportingData.Project"}
                 */
                var id = (string)(jObjectMetadata.Property(PropertyName_id)?.Value);
                var uri = (string)(jObjectMetadata.Property(PropertyName_uri)?.Value);
                var type = (string)(jObjectMetadata.Property(PropertyName_type)?.Value);
                IEntity entity = this.CreateEntityByExternalTypeName(type);
                var entityMetaData = entity.MetaData;
                if (entity == null) { throw new OfaSchlupfer.Model.ResolveNameNotFoundException(type); }
                foreach (var jToken in jObject.Children()) {
                    if (jToken is JProperty jProperty) {
                        var propertyName = jProperty.Name;
                        if (string.Equals(propertyName, PropertyName__metadata, StringComparison.Ordinal)) {
                            continue;
                        }
                        var metaProperty = entityMetaData.GetProperty(propertyName);
                        if (metaProperty is null) {
                            var deferred_uri = jProperty.Value.SelectToken("__deferred.uri");
                            if (deferred_uri != null && deferred_uri.Type == JTokenType.String) {
                                // navigation url...
                            } else {
                                throw new OfaSchlupfer.Model.ResolveNameNotFoundException($"{type} - {propertyName}");
                            }
                        } else {
                            object propertyValue = null;
                            propertyValue = jProperty.ToObject(metaProperty.PropertyType);
                            metaProperty.GetAccessor(entity).Value = propertyValue;
                        }
                    }
                }
                return entity;
            } else {
                throw new NotImplementedException("ODataDeserializtion - ParseObject metaData is null");
            }
        }

        public void ParseAny(Newtonsoft.Json.Linq.JObject jsonAny) {
            if (jsonAny.Type == Newtonsoft.Json.Linq.JTokenType.Object) {
                // throw new NotImplementedException(jsonAny.ToString());
            } else {
                throw new NotImplementedException(jsonAny.Type.ToString());
            }
        }

        public IEntity CreateEntityByExternalTypeName(string externalTypeName) => this.oDataClient.CreateEntityByExternalTypeName(externalTypeName);
    }
}