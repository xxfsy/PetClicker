using System;
using System.Collections.Generic;

public class EventBus : BaseEventBus
{
    public override void Subscribe<T>(Action<T> method)
    {
        string key = typeof(T).Name;

        if (eventsAndSubscribedMethods.ContainsKey(key))
        {
            eventsAndSubscribedMethods[key].Add(method);
        }
        else
        {
            eventsAndSubscribedMethods.Add(key, new List<Object>() { method } );
        }
    }

    public override void Unsubscribe<T>(Action<T> method)
    {
        string key = typeof(T).Name;

        if (eventsAndSubscribedMethods.ContainsKey(key))
        {
            eventsAndSubscribedMethods[key].Remove(method);
        }
        else
        {
            throw new ArgumentException("Trying to unsubscribe for not existing key! { 0}", key);
        }
    }

    public override void Invoke<T>(T signal)
    {
        string key = typeof(T).Name;

        if (eventsAndSubscribedMethods.ContainsKey(key))
        {
            foreach(object subscriber in eventsAndSubscribedMethods[key])
            {
                Action<T> subscribedMethod = subscriber as Action<T>;
                subscribedMethod?.Invoke(signal);
            }
        }
    }
}
