using System;
using Bmc.Lexigraph;
using NUnit.Framework;

namespace bmcTests
{
    [TestFixture]
    public class IncrementCurrentValueTests
    {
        [Test]
        public void Inc_Value_By_One ()
        {
            var instruction = new IncrementCurrentValue(1);
            var m = new MockGenerator();
            instruction.Emit(m);
            Assert.AreEqual(1, m.ValueIncrements);
        }

        [Test]
        public void Dec_Value_By_One ()
        {
            var instruction = new IncrementCurrentValue(-1);
            var m = new MockGenerator();
            instruction.Emit(m);
            Assert.AreEqual(1, m.ValueDecrements);
        }

        [Test]
        public void Nop ()
        {
            var instruction = new IncrementCurrentValue(0);
            Assert.IsFalse(instruction.MutatesState);
        }

        [Test]
        public void Has_No_UserInteraction()
        {
            var instruction = new IncrementCurrentValue(1);
            Assert.IsFalse(instruction.InteractsWithUser);
        }
    }
}

