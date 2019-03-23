
using System;

#if SIGNALING_USE_UNIRX
using UniRx;
#endif

namespace FreakshowStudio.Signaling.Runtime
{
    public abstract class SignalBase
    {
    }

    public abstract class Signal : SignalBase
    {
        private event Action Callback;
        #if SIGNALING_USE_UNIRX
        private readonly Subject<object> _subject =
            new Subject<object>();
        #endif

        public void AddListener(Action handler)
        {
            Callback += handler;
        }

        public void RemoveListener(Action handler)
        {
            Callback -= handler;
        }

        public void Dispatch()
        {
            Callback?.Invoke();

            #if SIGNALING_USE_UNIRX
            _subject.OnNext(null);
            #endif
        }

        #if SIGNALING_USE_UNIRX
        public IObservable<object> AsObservable() => _subject;
        #endif
    }

    public abstract class Signal<T>: SignalBase
    {
        private event Action<T> Callback;

        #if SIGNALING_USE_UNIRX
        private readonly Subject<T> _subject =
            new Subject<T>();
        #endif

        public void AddListener(Action<T> handler)
        {
            Callback += handler;
        }

        public void RemoveListener(Action<T> handler)
        {
            Callback -= handler;
        }

        public void Dispatch(T arg1)
        {
            Callback?.Invoke(arg1);

            #if SIGNALING_USE_UNIRX
            _subject.OnNext(arg1);
            #endif
        }

        #if SIGNALING_USE_UNIRX
        public IObservable<T> AsObservable() => _subject;
        #endif
    }

    public abstract class Signal<T1, T2>: SignalBase
    {
        private event Action<T1, T2> Callback;

        #if SIGNALING_USE_UNIRX
        private readonly Subject<(T1, T2)> _subject =
            new Subject<(T1, T2)>();
        #endif

        public void AddListener(Action<T1, T2> handler)
        {
            Callback += handler;
        }

        public void RemoveListener(Action<T1, T2> handler)
        {
            Callback -= handler;
        }

        public void Dispatch(T1 arg1, T2 arg2)
        {
            Callback?.Invoke(arg1, arg2);

            #if SIGNALING_USE_UNIRX
            _subject.OnNext((arg1, arg2));
            #endif
        }

        #if SIGNALING_USE_UNIRX
        public IObservable<(T1, T2)> AsObservable => _subject;
        #endif
    }

    public abstract class Signal<T1, T2, T3>: SignalBase
    {
        private event Action<T1, T2, T3> Callback;

        #if SIGNALING_USE_UNIRX
        private readonly Subject<(T1, T2, T3)> _subject =
            new Subject<(T1, T2, T3)>();
        #endif

        public void AddListener(Action<T1, T2, T3> handler)
        {
            Callback += handler;
        }

        public void RemoveListener(Action<T1, T2, T3> handler)
        {
            Callback -= handler;
        }

        public void Dispatch(T1 arg1, T2 arg2, T3 arg3)
        {
            Callback?.Invoke(arg1, arg2, arg3);
            #if SIGNALING_USE_UNIRX
            _subject.OnNext((arg1, arg2, arg3));
            #endif
        }

        #if SIGNALING_USE_UNIRX
        public IObservable<(T1, T2, T3)> AsObservable => _subject;
        #endif
    }
}
