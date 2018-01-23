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
            Assert.AreEqual("a", SqlName.Parse("a", ObjectLevel.Column).GetQFullName(null, 0));
            Assert.AreEqual("a.b", SqlName.Parse("a.b", ObjectLevel.Column).GetQFullName(null, 0));
            Assert.AreEqual("a.b.c", SqlName.Parse("a.b.c", ObjectLevel.Column).GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName(null, 0));
            Assert.AreEqual("a.b.c.d.e", SqlName.Parse("a.b.c.d.e", ObjectLevel.Column).GetQFullName(null, 0));

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

            Assert.AreEqual(ObjectLevel.Column, SqlName.Parse("a.b.c.d.e", ObjectLevel.Column).ObjectLevel);
            Assert.AreEqual(ObjectLevel.Object, SqlName.Parse("a.b.c.d.e", ObjectLevel.Column).Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Schema, SqlName.Parse("a.b.c.d.e", ObjectLevel.Column).Parent.Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Database, SqlName.Parse("a.b.c.d.e", ObjectLevel.Column).Parent.Parent.Parent.ObjectLevel);
            Assert.AreEqual(ObjectLevel.Server, SqlName.Parse("a.b.c.d.e", ObjectLevel.Column).Parent.Parent.Parent.Parent.ObjectLevel);
        }

        [TestMethod()]
        public void SqlName_IsRootTest() {
            Assert.IsTrue(SqlName.Root.IsRoot);
            Assert.IsTrue(SqlName.Root.Parent.IsRoot);
            Assert.IsTrue(SqlName.Parse("a", ObjectLevel.Column).Parent.IsRoot);
            Assert.IsFalse(SqlName.Parse("a", ObjectLevel.Column).IsRoot);
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
            Assert.IsTrue(SqlName.Parse("a.b", ObjectLevel.Column).Equals(SqlName.Parse("a.b", ObjectLevel.Column)));
            Assert.IsFalse(SqlName.Parse("a", ObjectLevel.Column).Equals(SqlName.Parse("b", ObjectLevel.Column)));
            Assert.IsFalse(SqlName.Parse("a.b", ObjectLevel.Column).Equals(SqlName.Parse("b", ObjectLevel.Column)));
            Assert.IsFalse(SqlName.Parse("a", ObjectLevel.Column).Equals(null));
        }

        [TestMethod()]
        public void SqlName_EqualsTest1() {
            Assert.IsTrue(SqlName.Parse("a.b.c.d", ObjectLevel.Unknown).Equals(SqlName.Parse("a.b.c.d", ObjectLevel.Unknown)));
        }

        [TestMethod()]
        public void SqlName_GetHashCodeTest() {
            Assert.AreEqual(SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetHashCode(), SqlName.Parse("A.B.C.D", ObjectLevel.Column).GetHashCode());
            Assert.AreNotEqual(SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetHashCode(), SqlName.Parse("A.B.C.DE", ObjectLevel.Column).GetHashCode());
        }

        [TestMethod()]
        public void SqlName_GetQNameTest() {
            Assert.AreEqual("d", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQName(null));
            Assert.AreEqual("c", SqlName.Parse("a.b.c", ObjectLevel.Column).GetQName(null));
            Assert.AreEqual("b", SqlName.Parse("a.b", ObjectLevel.Column).GetQName(null));
            Assert.AreEqual("a", SqlName.Parse("a", ObjectLevel.Column).GetQName(null));

            Assert.AreEqual("[d]", SqlName.Parse("[d]", ObjectLevel.Column).GetQName("["));
            Assert.AreEqual("[c]", SqlName.Parse("[c]", ObjectLevel.Column).GetQName("["));
            Assert.AreEqual("[b]", SqlName.Parse("[b]", ObjectLevel.Column).GetQName("["));
            Assert.AreEqual("[a]", SqlName.Parse("[a]", ObjectLevel.Column).GetQName("["));

        }

        [TestMethod()]
        public void SqlName_GetQFullNameTest() {
            Assert.AreEqual("d", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName(null, 1));
            Assert.AreEqual("c", SqlName.Parse("a.b.c", ObjectLevel.Column).GetQFullName(null, 1));
            Assert.AreEqual("b", SqlName.Parse("a.b", ObjectLevel.Column).GetQFullName(null, 1));
            Assert.AreEqual("a", SqlName.Parse("a", ObjectLevel.Column).GetQFullName(null, 1));

            Assert.AreEqual("d", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName(null, 1));
            Assert.AreEqual("c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName(null, 2));
            Assert.AreEqual("b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName(null, 3));
            Assert.AreEqual("a.b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName(null, 4));

            Assert.AreEqual("[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName("[", 1));
            Assert.AreEqual("[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName("[", 2));
            Assert.AreEqual("[b].[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName("[", 3));
            Assert.AreEqual("[a].[b].[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Column).GetQFullName("[", 4));
        }
    }
}