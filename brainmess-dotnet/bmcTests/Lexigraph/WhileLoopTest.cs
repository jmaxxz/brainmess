using System;
using Bmc.Lexigraph;
using NUnit.Framework;

namespace bmcTests
{
    [TestFixture]
    public class WhileLoopTest
    {
        [Test]
        public void While_Dec_Dec()
        {
            var instruction = new WhileLoop(new InstructionContainer(new []
            {
                new IncrementCurrentValue(-1), new IncrementCurrentValue(-1)
            }));
            var m = new MockGenerator();
            instruction.Emit(m);
            Assert.AreEqual(2, m.ValueDecrements);
            Assert.AreEqual(1, m.LoopBegins);
            Assert.AreEqual(1, m.LoopEnds);
        }

        [Test]
        public void Loop_InheritsMutation_And_User_Interaction()
        {
            var instruction = new WhileLoop(new InstructionContainer(new []
            {
                new IncrementCurrentValue(-1), new IncrementCurrentValue(-1)
            }));

            Assert.IsFalse(instruction.InteractsWithUser);
            Assert.IsTrue(instruction.MutatesState);
        }
    }
}

