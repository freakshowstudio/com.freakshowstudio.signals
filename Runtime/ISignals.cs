
using System;


namespace FreakshowStudio.Signaling.Runtime
{
    public interface ISignals
    {
        SignalBase Get(Type signalType);
        TSignal Get<TSignal>() where TSignal : SignalBase, new();
    }
}
