using System;
using Bmc.Lexigraph;
using NUnit.Framework;

namespace bmcTests
{
    [TestFixture]
    public class InstructionContainerTests
    {
        [Test]
        public void InstructionContainer_IncVal_DecVal()
        {
            var instruction = new InstructionContainer(new []
                        {
                            new IncrementCurrentValue(1), new IncrementCurrentValue(-1)
                        });
            var m = new MockGenerator();
            instruction.Emit(m);
            Assert.AreEqual(1, m.ValueDecrements);
            Assert.AreEqual(1, m.ValueIncrements);
        }

        [Test]
        public void Container_Mutates_No_Interaction()
        {
            var instruction = new InstructionContainer(new []
            {
                new IncrementCurrentValue(-1), new IncrementCurrentValue(-1)
            });

            Assert.IsFalse(instruction.InteractsWithUser);
            Assert.IsTrue(instruction.MutatesState);
        }

        [Test]
        public void Container_Does_Not_Mutates_Does_Interact()
        {
            var instruction = new InstructionContainer(new []
            {
                new WriteOutCurrentValue(), new WriteOutCurrentValue()
            });

            Assert.IsFalse(instruction.MutatesState);
            Assert.IsTrue(instruction.InteractsWithUser);
        }

        [Test]
        public void Container_Does_Mutates_Does_Interact()
        {
            var instruction = new InstructionContainer(new IInstruction[]
            {
                new WriteOutCurrentValue(), new IncrementCurrentValue(1)
            });

            Assert.IsTrue(instruction.MutatesState);
            Assert.IsTrue(instruction.InteractsWithUser);
        }

        [Test]
        public void EmptyContainer()
        {
            var instruction = new InstructionContainer(new IInstruction[]
            {
            });

            Assert.IsFalse(instruction.InteractsWithUser);
            Assert.IsFalse(instruction.MutatesState);
        }
    }
}

