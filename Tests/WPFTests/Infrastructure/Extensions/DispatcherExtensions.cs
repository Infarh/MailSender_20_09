using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Windows.Threading
{
    static class DispatcherExtensions
    {
        public static DispatcherAwaiter GetAwaiter(this Dispatcher dispatcher)
        {
            return new DispatcherAwaiter(dispatcher);
        }

        public readonly struct DispatcherAwaiter : INotifyCompletion
        {
            private readonly DispatcherPriority _Priority;
            [NotNull] private readonly Dispatcher _Dispatcher;

            public bool IsCompleted => _Dispatcher.CheckAccess();

            public DispatcherAwaiter([NotNull] Dispatcher dispatcher)
            {
                _Dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
                _Priority = DispatcherPriority.Normal;
            }

            public DispatcherAwaiter([NotNull] Dispatcher dispatcher, DispatcherPriority Priority)
            {
                _Dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
                _Priority = Priority;
            }

            public void OnCompleted(Action continuation)
            {
                if (_Priority == DispatcherPriority.Normal)
                    _Dispatcher.Invoke(continuation);
                else
                    _Dispatcher.Invoke(continuation, _Priority);
            }

            public void GetResult() { }
        }
    }
}
