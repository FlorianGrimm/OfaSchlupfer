using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfaSchlupfer.MSSQLReflection.Model;

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.MSSQLReflection.Model;

    [TestClass()]
    public class SqlScopeTests {
        [TestMethod()]
        public void SqlScope_ResolveTest() {
            var sut = new SqlScope(null);
            var a = sut.CreateChildScope();
            sut.Add(SqlName.Parse("a", ObjectLevel.Unknown), "42");
            Assert.AreEqual("42", a.ResolveObject(SqlName.Parse("a", ObjectLevel.Local), null));

        }

        [TestMethod()]
        public void SqlScope_AddTest() {
            var sut = new SqlScope(null);
            sut.Add(SqlName.Parse("a", ObjectLevel.Unknown), "42");
            Assert.AreEqual("42", sut.ResolveObject(SqlName.Parse("a", ObjectLevel.Unknown), null));
        }

        [TestMethod()]
        public void SqlScope_GetTest() {
            var sut = new SqlScope();
            sut.Add(SqlName.Parse("a", ObjectLevel.Unknown), "42");
            Assert.AreEqual("42", sut.ResolveObject(SqlName.Parse("a", ObjectLevel.Unknown), null));
        }

        [TestMethod()]
        public void SqlScope_AddChildScopeTest() {
            var sut = new SqlScope();
            var a = sut.CreateChildScope();
            var b = a.CreateChildScope();
            var c = b.CreateChildScope();
            var d = b.CreateChildScope();
            a.Add(SqlName.Parse("a", ObjectLevel.Local), "1");
            b.Add(SqlName.Parse("b", ObjectLevel.Local), "2");
            c.Add(SqlName.Parse("c", ObjectLevel.Local), "3");
            d.Add(SqlName.Parse("d", ObjectLevel.Local), "4");
            Assert.AreEqual("1", a.ResolveObject(SqlName.Parse("a", ObjectLevel.Local), null));
            Assert.IsNull(a.ResolveObject(SqlName.Parse("b", ObjectLevel.Local), null));
            Assert.IsNull(a.ResolveObject(SqlName.Parse("c", ObjectLevel.Local), null));
            Assert.IsNull(a.ResolveObject(SqlName.Parse("d", ObjectLevel.Local), null));

            Assert.AreEqual("1", b.ResolveObject(SqlName.Parse("a", ObjectLevel.Local), null));
            Assert.AreEqual("2", b.ResolveObject(SqlName.Parse("b", ObjectLevel.Local), null));
            Assert.IsNull(b.ResolveObject(SqlName.Parse("c", ObjectLevel.Local), null));
            Assert.IsNull(b.ResolveObject(SqlName.Parse("d", ObjectLevel.Local), null));

            Assert.AreEqual("1", c.ResolveObject(SqlName.Parse("a", ObjectLevel.Local), null));
            Assert.AreEqual("2", c.ResolveObject(SqlName.Parse("b", ObjectLevel.Local), null));
            Assert.AreEqual("3", c.ResolveObject(SqlName.Parse("c", ObjectLevel.Local), null));
            Assert.IsNull(c.ResolveObject(SqlName.Parse("d", ObjectLevel.Local), null));

            Assert.AreEqual("1", d.ResolveObject(SqlName.Parse("a", ObjectLevel.Local), null));
            Assert.AreEqual("2", d.ResolveObject(SqlName.Parse("b", ObjectLevel.Local), null));
            Assert.IsNull(d.ResolveObject(SqlName.Parse("c", ObjectLevel.Local), null));
            Assert.AreEqual("4", d.ResolveObject(SqlName.Parse("d", ObjectLevel.Local), null));
        }
    }
}