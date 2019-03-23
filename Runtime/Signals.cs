
using System;
using System.Collections.Generic;


namespace FreakshowStudio.Signaling.Runtime
{
    public class Signals : ISignals
    {
        private readonly Dictionary<Type, SignalBase> _signals =
            new Dictionary<Type, SignalBase>();

        public SignalBase Get(Type signalType)
        {
            if(_signals.TryGetValue(signalType, out var signal))
            {
                return signal;
            }

            signal = (SignalBase)Activator.CreateInstance(signalType);
            _signals.Add(signalType, signal);
            return signal;
        }

        public TSignal Get<TSignal>()
            where TSignal : SignalBase, new() =>
            (TSignal)Get(typeof(TSignal));
    }
}
