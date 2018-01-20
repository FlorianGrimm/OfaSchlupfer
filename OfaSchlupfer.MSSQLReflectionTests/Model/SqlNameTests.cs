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
            Assert.AreEqual("a.b", SqlName.Parse("a.b").GetQFullName(null));
            Assert.AreEqual("a.b.c", SqlName.Parse("a.b.c").GetQFullName(null));
            Assert.AreEqual("a.b.c.d", SqlName.Parse("a.b.c.d").GetQFullName(null));
            Assert.AreEqual("a.b.c.d.e", SqlName.Parse("a.b.c.d.e").GetQFullName(null));
            Assert.AreEqual("a.b.c.d.e.f", SqlName.Parse("a.b.c.d.e.f").GetQFullName(null));
            Assert.AreEqual("a.b.c.d.e.f.g", SqlName.Parse("a.b.c.d.e.f.g").GetQFullName(null));
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
            Assert.AreEqual("a.b.c", SqlName.Root.Child("a").Child("b").Child("c").GetQFullName(null));
        }

        [TestMethod()]
        public void SqlName_ChildWellkownTest() {
            Assert.AreEqual("a.b.c", SqlName.Root.ChildWellkown("a").ChildWellkown("b").ChildWellkown("c").GetQFullName(null));
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
        }

        [TestMethod()]
        public void SqlName_GetHashCodeTest() {
        }

        [TestMethod()]
        public void SqlName_ToStringTest() {
        }

        [TestMethod()]
        public void SqlName_GetQNameTest() {
        }

        [TestMethod()]
        public void SqlName_GetQFullNameTest() {
        }
    }
}