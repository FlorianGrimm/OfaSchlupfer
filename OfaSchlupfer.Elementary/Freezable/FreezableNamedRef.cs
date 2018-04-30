//namespace OfaSchlupfer.Freezable {
//    using System;
//    using Newtonsoft.Json;

//    [JsonObject())]
//    public struct FreezableNamedRef<TThis, TKey, TValue>
//        where TThis : class, IFreezeable
//        where TKey : class
//        where TValue : class {
//        private readonly TThis _This;
//        private readonly Func<TValue, TKey> _GetName;
//        private readonly Func<TThis, TKey, TValue> _Resolve;
//        private TKey _Name;
//        private TValue _Value;

//        public FreezableNamedRef(
//            TThis @this,
//            Func<TValue, TKey> getName,
//            Func<TThis, TKey, TValue> resolve
//            ) {
//            this._This = @this;
//            this._GetName = getName;
//            this._Resolve = resolve;
//            this._Name = default(TKey);
//            this._Value = default(TValue);
//        }

//        [JsonProperty]
//        public TKey Name {
//            get {
//                if (this._Value is null) {
//                    return this._Name;
//                } else {
//                    return this._Name = this._GetName(this._Value);
//                }
//            }
//            set {
//                this._This.ThrowIfFrozen();
//                this._Name = value;
//                if (value is null) {
//                    this._Value = null;
//                } else {
//                    this._Value = this._Resolve(this._This, value);
//                }
//            }
//        }

//        [JsonIgnore]
//        public TValue Ref {
//            get {
//                if (!(this._Name is null) && (this._Value is null)) {
//                    return this._Value = this._Resolve(this._This, this._Name);
//                } else {
//                    return this._Value;
//                }
//            }
//            set {
//                this._This.ThrowIfFrozen();
//                this._Value = value;
//                if (value is null) {
//                    this._Name = default(TKey);
//                } else {
//                    this._Name = this._GetName(value);
//                }
//            }
//        }
//    }

//    public class FreezableNamedRefConverter<TThis, TKey, TValue> : JsonConverter<FreezableNamedRef<TThis, TKey, TValue>>
//        where TThis : class, IFreezeable
//        where TKey : class
//        where TValue : class {
//        public FreezableNamedRefConverter() {
//        }
//        public override bool CanRead => true;
//        public override bool CanWrite => true;

//        public override FreezableNamedRef<TThis, TKey, TValue> ReadJson(JsonReader reader, Type objectType, FreezableNamedRef<TThis, TKey, TValue> existingValue, bool hasExistingValue, JsonSerializer serializer) {
//            return existingValue;
//        }

//        public override void WriteJson(JsonWriter writer, FreezableNamedRef<TThis, TKey, TValue> value, JsonSerializer serializer) {
//            writer.WriteValue(value.Name);
//        }


//    }

//    //public class FreezableNamedRefConverter<TThis, TKey, TValue> : JsonConverter<>
//    //    where TThis : class, IFreezeable
//    //    where TKey : class
//    //    where TValue : class {
//    //    public FreezableNamedRefConverter() {
//    //    }
//    //    public override bool CanRead => true;
//    //    public override bool CanWrite => true;
//    //    public override bool CanConvert(Type objectType) {
//    //        //if (objectType.IsConstructedGenericType) {
//    //        //    var genericTypeDefinition = objectType.GetGenericTypeDefinition();
//    //        //    if (!(genericTypeDefinition is null)) {
//    //        //        return typeof(FreezableNamedRef<,,>).Equals(genericTypeDefinition);
//    //        //    }
//    //        //}
//    //        return typeof(FreezableNamedRef<TThis, TKey, TValue>).Equals(objectType);
//    //    }

//    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
//    //        throw new NotImplementedException();
//    //    }

//    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
//    //        (FreezableNamedRef<TThis, TKey, TValue>)value 
//    //        writer.WriteValue(value);
//    //    }
//    //}
//#if weichei
//    bingt nix
//    public static class FreezableNamedRefExtension {
//        public static FreezableNamedRef<TThis, TKey, TValue> FreezableNamedRef<TThis, TKey, TValue>(
//               this TThis @this,
//               Func<TValue, TKey> getName,
//               Func<TThis, TKey, TValue> resolve)
//                   where TThis : class, IFreezeable
//                   where TKey : class
//                   where TValue : class
//               => new FreezableNamedRef<TThis, TKey, TValue>(@this, getName, resolve);
//    }
//#endif
//}
