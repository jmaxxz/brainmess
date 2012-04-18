using System;
using Bmc.Lexigraph;
using NUnit.Framework;

namespace bmcTests
{
    [TestFixture]
    public class WriteOutCurrentValueTests
    {
        [Test]
        public void WriteOut_Works()
        {
            var instruction = new WriteOutCurrentValue();
            var m = new MockGenerator();
            instruction.Emit(m);
            Assert.AreEqual(1, m.Writes);
        }

        [Test]
        public void Has_No_State_Mutation()
        {
            var instruction = new WriteOutCurrentValue();
            Assert.IsFalse(instruction.MutatesState);
        }

        [Test]
        public void Has_UserInteraction()
        {
            var instruction = new WriteOutCurrentValue();
            Assert.IsTrue(instruction.InteractsWithUser);
        }
    }
}

