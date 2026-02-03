using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<Type, Action<object>> _handlers = new();

    public static void Subscribe<T>(Action<T> handler)
    {
        var type = typeof(T);
        _handlers[type] = _handlers.TryGetValue(type, out var existing)
            ? existing + (e => handler((T)e))
            : (e => handler((T)e));
    }

    public static void Raise<T>(T evt)
    {
        if (_handlers.TryGetValue(typeof(T), out var handler))
            handler(evt);
    }
}
