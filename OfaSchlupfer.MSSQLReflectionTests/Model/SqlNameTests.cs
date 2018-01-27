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
            Assert.AreEqual("a", SqlName.Parse("a", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.AreEqual("a.b", SqlName.Parse("a.b", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.AreEqual("a.b.c", SqlName.Parse("a.b.c", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d.e", SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).GetQFullName(null, 0));

            Assert.AreEqual(ObjectLevel.Server, SqlName.Parse("a", ObjectLevel.Server).ObjectLevel);

            Assert.AreEqual(ObjectLevel.Database, SqlName.Parse("a.b", ObjectLevel.Database).ObjectLevel);
            Assert.AreEqual(ObjectLevel.Server, SqlName.Parse("a.b", ObjectLevel.Database).Parent.ObjectLevel);

            Assert.AreEqual(ObjectLevel.Schema, SqlName.Parse("a.b.c", ObjectLevel.Schema).ObjectLevel);
            Assert.AreEqual(ObjectLevel.Database, SqlName.Parse("a.b.c", ObjectLevel.Schema).Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Server, SqlName.Parse("a.b.c", ObjectLevel.Schema).Parent.Parent.ObjectLevel);

            Assert.AreEqual(ObjectLevel.Object, SqlName.Parse("a.b.c.d", ObjectLevel.Object).ObjectLevel);
            Assert.AreEqual(ObjectLevel.Schema, SqlName.Parse("a.b.c.d", ObjectLevel.Object).Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Database, SqlName.Parse("a.b.c.d", ObjectLevel.Object).Parent.Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Server, SqlName.Parse("a.b.c.d", ObjectLevel.Object).Parent.Parent.Parent.ObjectLevel);

            Assert.AreEqual(ObjectLevel.Child, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).ObjectLevel);
            Assert.AreEqual(ObjectLevel.Object, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Schema, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Database, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.Parent.Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Server, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.Parent.Parent.Parent.ObjectLevel);
        }

        [TestMethod()]
        public void SqlName_IsRootTest() {
            Assert.IsTrue(SqlName.Root.IsRoot);
            Assert.IsTrue(SqlName.Root.Parent.IsRoot);
            Assert.IsTrue(SqlName.Parse("a", ObjectLevel.Child).Parent.IsRoot);
            Assert.IsFalse(SqlName.Parse("a", ObjectLevel.Child).IsRoot);
        }

        [TestMethod()]
        public void SqlName_ChildTest() {
            Assert.AreEqual("a.b.c", SqlName.Root.Child("a").Child("b").Child("c").GetQFullName(null, 0));
        }

        [TestMethod()]
        public void SqlName_ChildWellkownTest() {
            var a = SqlName.Root.ChildWellkown("a");
            Assert.AreEqual("a.b.c", a.ChildWellkown("b").ChildWellkown("c").GetQFullName(null, 0));
            Assert.IsTrue(ReferenceEquals(a.ChildWellkown("b").ChildWellkown("c"), a.ChildWellkown("b").ChildWellkown("c")));
            Assert.IsFalse(ReferenceEquals(a.ChildWellkown("b").Child("c"), a.ChildWellkown("b").ChildWellkown("c")));
        }

        [TestMethod()]
        public void SqlName_EqualsTest() {
            Assert.IsTrue(SqlName.Parse("a.b", ObjectLevel.Child).Equals(SqlName.Parse("a.b", ObjectLevel.Child)));
            Assert.IsFalse(SqlName.Parse("a", ObjectLevel.Child).Equals(SqlName.Parse("b", ObjectLevel.Child)));
            Assert.IsFalse(SqlName.Parse("a.b", ObjectLevel.Child).Equals(SqlName.Parse("b", ObjectLevel.Child)));
            Assert.IsFalse(SqlName.Parse("a", ObjectLevel.Child).Equals(null));
        }

        [TestMethod()]
        public void SqlName_EqualsTest1() {
            Assert.IsTrue(SqlName.Parse("a.b.c.d", ObjectLevel.Unknown).Equals(SqlName.Parse("a.b.c.d", ObjectLevel.Unknown)));
        }

        [TestMethod()]
        public void SqlName_GetHashCodeTest() {
            Assert.AreEqual(SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetHashCode(), SqlName.Parse("A.B.C.D", ObjectLevel.Child).GetHashCode());
            Assert.AreNotEqual(SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetHashCode(), SqlName.Parse("A.B.C.DE", ObjectLevel.Child).GetHashCode());
        }

        [TestMethod()]
        public void SqlName_GetQNameTest() {
            Assert.AreEqual("d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQName(null));
            Assert.AreEqual("c", SqlName.Parse("a.b.c", ObjectLevel.Child).GetQName(null));
            Assert.AreEqual("b", SqlName.Parse("a.b", ObjectLevel.Child).GetQName(null));
            Assert.AreEqual("a", SqlName.Parse("a", ObjectLevel.Child).GetQName(null));

            Assert.AreEqual("[d]", SqlName.Parse("[d]", ObjectLevel.Child).GetQName("["));
            Assert.AreEqual("[c]", SqlName.Parse("[c]", ObjectLevel.Child).GetQName("["));
            Assert.AreEqual("[b]", SqlName.Parse("[b]", ObjectLevel.Child).GetQName("["));
            Assert.AreEqual("[a]", SqlName.Parse("[a]", ObjectLevel.Child).GetQName("["));

        }

        [TestMethod()]
        public void SqlName_GetQFullNameTest() {
            Assert.AreEqual("d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.AreEqual("c", SqlName.Parse("a.b.c", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.AreEqual("b", SqlName.Parse("a.b", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.AreEqual("a", SqlName.Parse("a", ObjectLevel.Child).GetQFullName(null, 1));

            Assert.AreEqual("d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.AreEqual("c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 2));
            Assert.AreEqual("b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 3));
            Assert.AreEqual("a.b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 4));

            Assert.AreEqual("[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 1));
            Assert.AreEqual("[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 2));
            Assert.AreEqual("[b].[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 3));
            Assert.AreEqual("[a].[b].[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 4));
        }
    }
}