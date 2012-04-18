using System;
using System.Linq;
using System.Collections.Generic;

namespace Bmc.Lexigraph
{
    public class WhileLoop : IInstruction
    {
        public bool MutatesState { get { return _instructions.MutatesState; } }
        public bool InteractsWithUser { get { return _instructions.InteractsWithUser; } }
        public bool WillComplete { get { return false; } }

        private InstructionContainer _instructions;
        public WhileLoop (InstructionContainer instructions)
        {
            _instructions = instructions;
        }

        public void Emit(IGenerator codeEmittor)
        {
            codeEmittor.BeginLoop();
            _instructions.Emit(codeEmittor);
            codeEmittor.EndLoop();
        }
    }
}

