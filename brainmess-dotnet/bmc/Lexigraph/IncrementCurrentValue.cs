using System;

namespace Bmc.Lexigraph
{
    public class IncrementCurrentValue: IInstruction
    {
        public bool MutatesState { get { return _x !=0; } }
        public bool InteractsWithUser { get { return false; } }
        public bool WillComplete { get { return true; } }


        private int _x;
        public IncrementCurrentValue (int x)
        {
            _x=x;
        }

        public void Emit(IGenerator codeEmittor)
        {
            codeEmittor.AddValue(_x);
        }
    }
}

