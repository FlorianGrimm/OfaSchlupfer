namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Text;

    using Xunit;
    public class EntityDynamicObjectTest {
        class Gna : System.Dynamic.DynamicObject {
            public int PropA { get; set; }
            public int PropB { get => this.PropA; set => this.PropA = value; }

            public override bool TrySetMember(SetMemberBinder binder, object value) {
                throw new NotSupportedException();
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                // return base.TryGetMember(binder, out result);
                result = 43;
                return true;
            }
        }

        [Fact]
        public void Understand_DynamicObject_Test() {
            var gna = new Gna();            
            gna.PropA = 42;
            Assert.Equal(42, gna.PropA);
            Assert.Equal(42, gna.PropB);
            Assert.Equal(43, ((dynamic)gna).PropC);            
            // => Pre definded Properties
        }
    }
}
