using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfaSchlupfer.SQLReflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfaSchlupfer.SQLReflection {
    [TestClass()]
    public class UtilityTests {
        [TestMethod()]
        public void Utility_TransportTest() {
            var u = new Utility();
            var f = u.Parse(@"SELECT * FROM sys.all_columns;");
            Assert.IsNotNull(f, "Parse");
            var act = u.Transport(f);
            Assert.IsNotNull(act, "Transport");
        }

        [TestMethod()]
        public void Utility_Transport_b_Test() {
            var u = new Utility();
            var t = System.IO.File.ReadAllText(@"C:\git\ConsoleApp1\OfaSchlupfer.SQLReflectionTests\test1.txt");
            var f = u.Parse(t);
            Assert.IsNotNull(f, "Parse");
            var act = u.Transport(f);
            Assert.IsNotNull(act, "Transport");
        }
    }
}