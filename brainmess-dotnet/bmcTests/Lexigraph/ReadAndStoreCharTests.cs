using System;
using Bmc.Lexigraph;
using NUnit.Framework;

namespace bmcTests
{
    [TestFixture]
    public class ReadAndStoreCharTests
    {
        [Test]
        public void ReadAndStore_Works()
        {
            var instruction = new ReadAndStoreChar();
            var m = new MockGenerator();
            instruction.Emit(m);
            Assert.AreEqual(1, m.Reads);
        }

        [Test]
        public void Has_UserInteraction()
        {
            var instruction = new ReadAndStoreChar();
            Assert.IsTrue(instruction.InteractsWithUser);
        }

        [Test]
        public void Has_StateMutation()
        {
            var instruction = new ReadAndStoreChar();
            Assert.IsTrue(instruction.MutatesState);
        }
    }
}

