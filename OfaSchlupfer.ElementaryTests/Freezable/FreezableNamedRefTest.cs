//namespace OfaSchlupfer.Freezable {
//    using System;
//    using System.Collections.Generic;
//    using System.Text;
//    using OfaSchlupfer.Freezable;
//    using Xunit;

//    public class FreezableNamedRefTest {
//        class M : FreezableObject {
//            private string _Name;
//            public readonly FreezableOwnedKeyedCollection<M, string, S> S;

//            public string Name {
//                get => this._Name;
//                set {
//                    this._Name = value;
//                }
//            }

//            public M() {
//                this.S = new FreezableOwnedKeyedCollection<M, string, S>(
//                    this,
//                    (item) => item.Name,
//                    StringComparer.Ordinal,
//                    (m, s) => s.Owner = m
//                    );
//            }
//        }
//        class S : FreezableObject {

//            public FreezableNamedRef<S, string, S> SNext { get; }
//            private M _Owner;
            
//            public S() {
//                this.SNext = new FreezableNamedRef<S, string, S>(this, (s) => s.Name, (s, n) => s.Owner?.S?.GetValueOrDefault(n));
//            }

//            //
//            public string Name { get; set; }

//            public M Owner {
//                get => this._Owner;
//                set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.S);
//            }
//        }

//        public FreezableNamedRefTest() {
//        }

//        [Fact]
//        public void FreezeableNamedRef_1_Text() {
//            var m = new M();
//            m.Name = "m";

//            var s = new S();
//            s.Name = "s";
//            s.Owner = m;
//            Assert.Equal("s", s.Name);
//            Assert.Equal("m", s.Owner.Name);
//            Assert.Same(m, s.Owner);

//            var t = new S();
//            t.Name = "t";
//            t.Owner = m;
//            Assert.Equal("t", t.Name);
//            Assert.Equal("m", t.Owner.Name);
//            Assert.Same(m, t.Owner);


//            s.SNext.Ref = t;
//            Assert.Equal("t", s.SNext.Name);
//            t.SNext.Name = "s";
//            Assert.Equal("s", t.SNext.Ref?.Name);
//        }

//        [Fact]
//        public void FreezableNamedRefConverter_Test() {
//            var converter = new FreezableNamedRefConverter<S, string, S>();
//            var s = new S();
//            Assert.True(converter.CanConvert(s.SNext.GetType()));
//        }
//    }
//}
