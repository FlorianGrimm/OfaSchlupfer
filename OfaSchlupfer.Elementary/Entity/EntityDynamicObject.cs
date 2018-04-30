namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;

    public class EntityDynamicObject
        : System.Dynamic.DynamicObject
        , IFreezable
        , IEntity
        , IEntityFlexible {
        [JsonIgnore]
        private int _IsFrozen;

        private IMetaEntityFlexible _MetaData;

        public EntityDynamicObject(IMetaEntityFlexible metaData) {
            this._MetaData = metaData;
        }

        IMetaEntity IEntity.MetaData => this._MetaData;

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            //binder.Name
            //binder.ReturnType
            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value) {
            //binder.Name
            //binder.ReturnType
            //binder.FallbackSetMember
            return base.TrySetMember(binder, value);
        }

        public override IEnumerable<string> GetDynamicMemberNames() {
            return base.GetDynamicMemberNames();
        }

        object IEntityFlexible.GetObjectValue(int index) {
            throw new NotImplementedException();
        }
        void IEntityFlexible.SetObjectValue(int index, object value) {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        bool IFreezable.IsFrozen() => (this._IsFrozen == 1);

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        bool IFreezable.Freeze() => (System.Threading.Interlocked.CompareExchange(ref this._IsFrozen, 1, 0) == 0);


        //public IMetaEntity MetaData {
        //    get {
        //        throw new NotImplementedException();
        //    }
        //}

        //public bool Freeze() {
        //    throw new NotImplementedException();
        //}

        //public object GetObjectValue(int index) {
        //    throw new NotImplementedException();
        //}

        //public bool IsFrozen() {
        //    throw new NotImplementedException();
        //}

        //public void SetObjectValue(int index, object value) {
        //    throw new NotImplementedException();
        //}
        }
}
