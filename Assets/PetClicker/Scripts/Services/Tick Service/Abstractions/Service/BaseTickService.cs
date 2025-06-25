using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTickService : MonoBehaviour
{
    protected readonly List<ITickable> tickables = new();

    public virtual void Register(ITickable tickable)
    {
        if (tickable != null && !tickables.Contains(tickable))
            tickables.Add(tickable);
    }

    public virtual void Unregister(ITickable tickable)
    {
        tickables.Remove(tickable);
    }

    protected virtual void TickAll(float timeFromLastTick)
    {
        foreach (ITickable tickable in tickables)
            tickable?.Tick(timeFromLastTick);
    }
}
