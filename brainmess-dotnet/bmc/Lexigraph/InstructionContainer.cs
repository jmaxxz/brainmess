using System;
using System.Collections.Generic;
using System.Linq;

namespace Bmc.Lexigraph
{
    public class InstructionContainer: IInstruction
    {
        public bool MutatesState { get { return _instructions.Any(x=>x.MutatesState); } }
        public bool InteractsWithUser { get { return _instructions.Any(x=>x.InteractsWithUser); } }
        public bool WillComplete { get { return _instructions.All(x=>x.WillComplete); } }


        private IEnumerable<IInstruction> _instructions;
        public InstructionContainer (IEnumerable<IInstruction> instructions)
        {
            _instructions = instructions;
        }

        public void Emit(IGenerator codeEmittor)
        {
            foreach(var i in _instructions)
            {
                i.Emit(codeEmittor);
            }
        }
    }
}

