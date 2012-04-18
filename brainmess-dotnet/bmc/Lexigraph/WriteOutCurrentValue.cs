using System;

namespace Bmc.Lexigraph
{
    public class WriteOutCurrentValue : IInstruction
    {
        public bool MutatesState { get { return false; } }
        public bool InteractsWithUser { get { return true; } }
        public bool WillComplete { get { return true; } }

        
        public WriteOutCurrentValue ()
        {
        }
        public void Emit(IGenerator codeEmittor)
        {
            codeEmittor.WriteCurrent();
        }
    }
}

