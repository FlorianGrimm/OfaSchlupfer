namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class ModelRepository {
        private string _Name;
        public string SqlSchemaName;
        public string Type;
        public IRepositoryType RepositoryType;
        public ModelSchema ModelSchema;
        public IRepository Repository;

        public ModelRepository() {
        }

        public string Name {
            get {
                return this._Name;
            }
            set {
                this._Name = value;
                this.ModelSchema._Name = value;
            }
        }

        public IRepository GetRepository() {
            if (this.Repository != null) { return this.Repository; }
            if (this.RepositoryType == null) {
                // TODO: this.Type
            }
            throw new NotImplementedException();
        }
    }
}
