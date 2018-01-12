using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfaSchlupfer.Elementary.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfaSchlupfer.Elementary.Immutable {
    [TestClass()]
    public class BuildTargetBaseTests {
        public class BTBTest : BuildTargetBase, IEquatable<BTBTest> {
            private string _Name;
            public BTBTest() {
            }

            public BTBTest(BTBTest src) {
                this.Name = src.Name;
            }
            public string Name { get { return this._Name; } set { this.ThrowIfFozen(); this._Name = value; } }

            public static bool operator ==(BTBTest a, BTBTest b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

            public static bool operator !=(BTBTest a, BTBTest b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

            public override bool Equals(object obj) {
                return base.Equals(obj as BTBTest);
            }

            public bool Equals(BTBTest other) {
                if ((object)other == null) { return false; }
                if (ReferenceEquals(this, other)) { return true; }
                return (string.Equals(this.Name, other.Name, StringComparison.OrdinalIgnoreCase))
                    ;
            }

            public override int GetHashCode() => this.Name.GetHashCode();

            public override string ToString() => this.Name.ToString();

            /// <summary>
            /// Get the builder for mutate.
            /// </summary>
            /// <param name="clone">always clone.</param>
            /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
            /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
            /// <returns>a builder</returns>
            public Builder GetBuilder(bool clone, Action<BTBTest> setUnFrozen, Action<BTBTest> setFrozen)
                => new Builder(this, clone, setUnFrozen, setFrozen);

            /// <summary>
            /// Builder
            /// </summary>
            public class Builder : BuilderBase<BTBTest> {
                internal Builder(BTBTest target, bool clone, Action<BTBTest> setUnFrozen, Action<BTBTest> setFozen) 
                    : base(target, clone, setUnFrozen, setFozen) {
                }
                public string Name { get { return this._Target._Name; } set { if (this._Target._Name == value) { return; } this.EnsureUnfrozen()._Name = value; } }
            }
        }
        public class FreezeReceiverTest : IFreezeReceiver {
            public bool Result;
            public IBuildTarget Frozen;
            public IBuildTarget Previous;
            public IBuildTarget Next;

            public bool HandleFreeze(IBuildTarget frozen) {
                this.Frozen = frozen;
                return this.Result;
            }

            public bool HandleUnFreeze(IBuildTarget previous, IBuildTarget next) {
                this.Previous = previous;
                this.Next = next;
                return this.Result;
            }
        }

        [TestMethod()]
        public void BuildTargetBase_AddFreezeReceiverTest() {
            var a = new BTBTest() { Name = "a" };
            var afr = new FreezeReceiverTest();

            a.AddFreezeReceiver(afr);
            a.Freeze();
            Assert.IsTrue(a.IsFrozen);
            Assert.AreEqual("a", a.Name);
            Assert.AreEqual(a, afr.Frozen);
            afr.Frozen = null;

            var b = (BTBTest)a.UnFreeze(false);
            Assert.IsFalse(b.IsFrozen);
            b.Name = "b";
            Assert.IsTrue(ReferenceEquals(a, afr.Previous));
            Assert.IsTrue(ReferenceEquals(b, afr.Next));
            Assert.AreEqual("a", a.Name);
            Assert.AreEqual("b", b.Name);
            afr.Next = null;

            var c = (BTBTest)b.UnFreeze(false);
            var cfr = new FreezeReceiverTest();
            c.AddFreezeReceiver(cfr);
            Assert.IsTrue(ReferenceEquals(b, c));
            Assert.IsNull(afr.Next);
            afr.Next = null;

            
            var d = (BTBTest)c.UnFreeze(true);
            Assert.IsFalse(ReferenceEquals(b, d));
            Assert.IsTrue(ReferenceEquals(d, cfr.Next));
            cfr.Next = null;

            // remove FreezeReceiver
            cfr.Result = true;
            d.AddFreezeReceiver(cfr);
            d.Freeze();
            Assert.IsTrue(d.IsFrozen);
            Assert.AreEqual(d, cfr.Frozen);
            cfr.Frozen = null;
            cfr.Next = null;
            var e = (BTBTest)d.UnFreeze(false);
            Assert.IsFalse(ReferenceEquals(d, e));
            Assert.IsNull(cfr.Next);
        }

        [TestMethod()]
        public void BuildTargetBase_ThrowIfFozenTest() {
            var a = new BTBTest() { Name = "a" };
            var fr = new FreezeReceiverTest();
            a.AddFreezeReceiver(fr);
            a.Freeze();
            Assert.IsTrue(a.IsFrozen);
            Assert.ThrowsException<InvalidOperationException>(() => { a.Name = "b"; });
        }
    }
}