using System;
using Bmc;

namespace Bmc.Lexigraph
{
    public interface IInstruction
    {
        bool MutatesState { get; }
        bool InteractsWithUser { get; }
        bool WillComplete { get; } //false means it MAY never complete
        void Emit(IGenerator codeEmittor);
    }
}

