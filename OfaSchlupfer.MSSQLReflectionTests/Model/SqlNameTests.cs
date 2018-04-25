using Xunit;
using OfaSchlupfer.MSSQLReflection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfaSchlupfer.MSSQLReflection.Model {
    
    public class SqlNameTests {
        [Fact]
        public void SqlName_ParseTest() {
            Assert.Equal("a", SqlName.Parse("a", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.Equal("a.b", SqlName.Parse("a.b", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.Equal("a.b.c", SqlName.Parse("a.b.c", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.Equal("a.b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 0));
            Assert.Equal("a.b.c.d.e", SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).GetQFullName(null, 0));

            Assert.Equal(ObjectLevel.Server, SqlName.Parse("a", ObjectLevel.Server).ObjectLevel);

            Assert.Equal(ObjectLevel.Database, SqlName.Parse("a.b", ObjectLevel.Database).ObjectLevel);
            Assert.Equal(ObjectLevel.Server, SqlName.Parse("a.b", ObjectLevel.Database).Parent.ObjectLevel);

            Assert.Equal(ObjectLevel.Schema, SqlName.Parse("a.b.c", ObjectLevel.Schema).ObjectLevel);
            Assert.Equal(ObjectLevel.Database, SqlName.Parse("a.b.c", ObjectLevel.Schema).Parent.ObjectLevel);
            Assert.Equal(ObjectLevel.Server, SqlName.Parse("a.b.c", ObjectLevel.Schema).Parent.Parent.ObjectLevel);

            Assert.Equal(ObjectLevel.Object, SqlName.Parse("a.b.c.d", ObjectLevel.Object).ObjectLevel);
            Assert.Equal(ObjectLevel.Schema, SqlName.Parse("a.b.c.d", ObjectLevel.Object).Parent.ObjectLevel);
            Assert.Equal(ObjectLevel.Database, SqlName.Parse("a.b.c.d", ObjectLevel.Object).Parent.Parent.ObjectLevel);
            Assert.Equal(ObjectLevel.Server, SqlName.Parse("a.b.c.d", ObjectLevel.Object).Parent.Parent.Parent.ObjectLevel);

            Assert.Equal(ObjectLevel.Child, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).ObjectLevel);
            Assert.Equal(ObjectLevel.Object, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.ObjectLevel);
            Assert.Equal(ObjectLevel.Schema, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.Parent.ObjectLevel);
            Assert.Equal(ObjectLevel.Database, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.Parent.Parent.ObjectLevel);
            Assert.Equal(ObjectLevel.Server, SqlName.Parse("a.b.c.d.e", ObjectLevel.Child).Parent.Parent.Parent.Parent.ObjectLevel);
        }

        [Fact]
        public void SqlName_IsRootTest() {
            Assert.True(SqlName.Parse("a", ObjectLevel.Child).Parent.IsRoot);
            Assert.False(SqlName.Parse("a", ObjectLevel.Child).IsRoot);
        }

        [Fact]
        public void SqlName_ChildTest() {
            Assert.Equal("a.b.c", new SqlName(null, "a", ObjectLevel.Schema).Child("b").Child("c").GetQFullName(null, 0));
        }

        [Fact]
        public void SqlName_ChildWellkownTest() {
            var a = new SqlName(null, "a", ObjectLevel.Database);
            Assert.Equal("a.b.c", a.ChildWellkown("b").ChildWellkown("c").GetQFullName(null, 0));
            Assert.True(ReferenceEquals(a.ChildWellkown("b").ChildWellkown("c"), a.ChildWellkown("b").ChildWellkown("c")));
            Assert.False(ReferenceEquals(a.ChildWellkown("b").Child("c"), a.ChildWellkown("b").ChildWellkown("c")));
        }

        [Fact]
        public void SqlName_EqualsTest() {
            Assert.True(SqlName.Parse("a.b", ObjectLevel.Child).Equals(SqlName.Parse("a.b", ObjectLevel.Child)));
            Assert.False(SqlName.Parse("a", ObjectLevel.Child).Equals(SqlName.Parse("b", ObjectLevel.Child)));
            Assert.False(SqlName.Parse("a.b", ObjectLevel.Child).Equals(SqlName.Parse("b", ObjectLevel.Child)));
            Assert.False(SqlName.Parse("a", ObjectLevel.Child).Equals(null));
        }

        [Fact]
        public void SqlName_EqualsTest1() {
            Assert.True(SqlName.Parse("a.b.c.d", ObjectLevel.Unknown).Equals(SqlName.Parse("a.b.c.d", ObjectLevel.Unknown)));
        }

        [Fact]
        public void SqlName_GetHashCodeTest() {
            Assert.Equal(SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetHashCode(), SqlName.Parse("A.B.C.D", ObjectLevel.Child).GetHashCode());
            Assert.NotEqual(SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetHashCode(), SqlName.Parse("A.B.C.DE", ObjectLevel.Child).GetHashCode());
        }

        [Fact]
        public void SqlName_GetQNameTest() {
            Assert.Equal("d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQName(null));
            Assert.Equal("c", SqlName.Parse("a.b.c", ObjectLevel.Child).GetQName(null));
            Assert.Equal("b", SqlName.Parse("a.b", ObjectLevel.Child).GetQName(null));
            Assert.Equal("a", SqlName.Parse("a", ObjectLevel.Child).GetQName(null));

            Assert.Equal("[d]", SqlName.Parse("[d]", ObjectLevel.Child).GetQName("["));
            Assert.Equal("[c]", SqlName.Parse("[c]", ObjectLevel.Child).GetQName("["));
            Assert.Equal("[b]", SqlName.Parse("[b]", ObjectLevel.Child).GetQName("["));
            Assert.Equal("[a]", SqlName.Parse("[a]", ObjectLevel.Child).GetQName("["));

        }

        [Fact]
        public void SqlName_GetQFullNameTest() {
            Assert.Equal("d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.Equal("c", SqlName.Parse("a.b.c", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.Equal("b", SqlName.Parse("a.b", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.Equal("a", SqlName.Parse("a", ObjectLevel.Child).GetQFullName(null, 1));

            Assert.Equal("d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 1));
            Assert.Equal("c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 2));
            Assert.Equal("b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 3));
            Assert.Equal("a.b.c.d", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName(null, 4));

            Assert.Equal("[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 1));
            Assert.Equal("[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 2));
            Assert.Equal("[b].[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 3));
            Assert.Equal("[a].[b].[c].[d]", SqlName.Parse("a.b.c.d", ObjectLevel.Child).GetQFullName("[", 4));
        }
    }
}