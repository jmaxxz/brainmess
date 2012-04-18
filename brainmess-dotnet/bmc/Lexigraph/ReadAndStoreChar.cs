using System;

namespace Bmc.Lexigraph
{
    public class ReadAndStoreChar : IInstruction
    {
        public bool MutatesState { get { return true; } }
        public bool InteractsWithUser { get { return true; } }
        public bool WillComplete { get { return false; } }

        public ReadAndStoreChar ()
        {
        }

        public void Emit(IGenerator codeEmittor)
        {
            codeEmittor.ReadAndStoreInput();
        }
    }
}

