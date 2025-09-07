using System;
using System.Collections.Generic;

public abstract class BaseEventBus 
{
    protected Dictionary<string, List<object>> eventsAndSubscribedMethods = new Dictionary<string, List<object>>();

    public abstract void Subscribe<T>(Action<T> method) where T : BaseSignal; // мб переименовать в callback потом, сейчас просто для понимания сделал method

    public abstract void Unsubscribe<T>(Action<T> method) where T : BaseSignal;

    public abstract void Invoke<T>(T signal) where T : BaseSignal;
}
