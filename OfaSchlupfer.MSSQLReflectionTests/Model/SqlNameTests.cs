using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfaSchlupfer.MSSQLReflection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfaSchlupfer.MSSQLReflection.Model {
    [TestClass()]
    public class SqlNameTests {
        [TestMethod()]
        public void SqlName_ParseTest() {
            Assert.AreEqual("a", SqlName.Parse("a").ToString());
            Assert.AreEqual("a.b", SqlName.Parse("a.b").GetQFullName(null, 0));
            Assert.AreEqual("a.b.c", SqlName.Parse("a.b.c").GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d", SqlName.Parse("a.b.c.d").GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d.e", SqlName.Parse("a.b.c.d.e").GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d.e.f", SqlName.Parse("a.b.c.d.e.f").GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d.e.f.g", SqlName.Parse("a.b.c.d.e.f.g").GetQFullName(null, 0));
        }

        [TestMethod()]
        public void SqlName_IsRootTest() {
            Assert.IsTrue(SqlName.Root.IsRoot);
            Assert.IsTrue(SqlName.Root.Parent.IsRoot);
            Assert.IsTrue(SqlName.Parse("a").Parent.IsRoot);
            Assert.IsFalse(SqlName.Parse("a").IsRoot);
        }

        [TestMethod()]
        public void SqlName_ChildTest() {
            Assert.AreEqual("a.b.c", SqlName.Root.Child("a").Child("b").Child("c").GetQFullName(null, 0));
        }

        [TestMethod()]
        public void SqlName_ChildWellkownTest() {
            Assert.AreEqual("a.b.c", SqlName.Root.ChildWellkown("a").ChildWellkown("b").ChildWellkown("c").GetQFullName(null, 0));
            Assert.IsTrue(ReferenceEquals(SqlName.Root.ChildWellkown("a").ChildWellkown("b").ChildWellkown("c"), SqlName.Root.ChildWellkown("a").ChildWellkown("b").ChildWellkown("c")));
            Assert.IsFalse(ReferenceEquals(SqlName.Root.ChildWellkown("a").ChildWellkown("b").Child("c"), SqlName.Root.ChildWellkown("a").ChildWellkown("b").ChildWellkown("c")));
        }

        [TestMethod()]
        public void SqlName_EqualsTest() {
            Assert.IsTrue(SqlName.Parse("a.b").Equals(SqlName.Parse("a.b")));
            Assert.IsFalse(SqlName.Parse("a").Equals(SqlName.Parse("b")));
            Assert.IsFalse(SqlName.Parse("a.b").Equals(SqlName.Parse("b")));
            Assert.IsFalse(SqlName.Parse("a").Equals(null));
        }

        [TestMethod()]
        public void SqlName_EqualsTest1() {
            Assert.IsTrue(SqlName.Parse("a.b.c.d").Equals(SqlName.Parse("a.b.c.d")));
        }

        [TestMethod()]
        public void SqlName_GetHashCodeTest() {
            Assert.AreEqual(SqlName.Parse("a.b.c.d").GetHashCode(), SqlName.Parse("A.B.C.D").GetHashCode());
            Assert.AreNotEqual(SqlName.Parse("a.b.c.d").GetHashCode(), SqlName.Parse("A.B.C.DE").GetHashCode());
        }

        [TestMethod()]
        public void SqlName_GetQNameTest() {
            Assert.AreEqual("d", SqlName.Parse("a.b.c.d").GetQName(null));
            Assert.AreEqual("c", SqlName.Parse("a.b.c").GetQName(null));
            Assert.AreEqual("b", SqlName.Parse("a.b").GetQName(null));
            Assert.AreEqual("a", SqlName.Parse("a").GetQName(null));

            Assert.AreEqual("[d]", SqlName.Parse("[d]").GetQName("["));
            Assert.AreEqual("[c]", SqlName.Parse("[c]").GetQName("["));
            Assert.AreEqual("[b]", SqlName.Parse("[b]").GetQName("["));
            Assert.AreEqual("[a]", SqlName.Parse("[a]").GetQName("["));

        }

        [TestMethod()]
        public void SqlName_GetQFullNameTest() {
            Assert.AreEqual("d", SqlName.Parse("a.b.c.d").GetQFullName(null, 1));
            Assert.AreEqual("c", SqlName.Parse("a.b.c").GetQFullName(null, 1));
            Assert.AreEqual("b", SqlName.Parse("a.b").GetQFullName(null, 1));
            Assert.AreEqual("a", SqlName.Parse("a").GetQFullName(null, 1));

            Assert.AreEqual("d", SqlName.Parse("a.b.c.d").GetQFullName(null, 1));
            Assert.AreEqual("c.d", SqlName.Parse("a.b.c.d").GetQFullName(null, 2));
            Assert.AreEqual("b.c.d", SqlName.Parse("a.b.c.d").GetQFullName(null, 3));
            Assert.AreEqual("a.b.c.d", SqlName.Parse("a.b.c.d").GetQFullName(null, 4));

            Assert.AreEqual("[d]", SqlName.Parse("a.b.c.d").GetQFullName("[", 1));
            Assert.AreEqual("[c].[d]", SqlName.Parse("a.b.c.d").GetQFullName("[", 2));
            Assert.AreEqual("[b].[c].[d]", SqlName.Parse("a.b.c.d").GetQFullName("[", 3));
            Assert.AreEqual("[a].[b].[c].[d]", SqlName.Parse("a.b.c.d").GetQFullName("[", 4));
        }
    }
}