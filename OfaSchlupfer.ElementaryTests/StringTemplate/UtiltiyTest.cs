namespace OfaSchlupfer.StringTemplate {
using System;
using System.Collections.Generic;
using System.Text;

    using Xunit;

    public class UtiltiyTest {
        [Fact]
        public void GnaTest() {
            Assert.Equal("a b", (new Utility()).Gna());
        }
    }
}
