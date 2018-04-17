namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class ODataResponce {
        public Stream ResponceContentStream;
        public string ResponceContentString;

        public ODataResponce() {
        }

        public void SetResponceContentStream(Stream responceContent) {
            this.ResponceContentStream = responceContent;
        }

        public void SetResponceContentString(string responceContent) {
            this.ResponceContentString = responceContent;
        }

#warning later
        //public void Parse(ODataServiceClient oDataClient, ODataQueryRequest oDataRequest) {
        //    var d = new ODataDeserializtion(this, oDataRequest, oDataClient.EdmxModel);
        //    var responceContentString = this.ResponceContentString;
        //    d.Deserialize(responceContentString);
        //}
    }
}