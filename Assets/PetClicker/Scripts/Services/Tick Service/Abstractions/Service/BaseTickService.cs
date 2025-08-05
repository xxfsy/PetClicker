using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseTickService : MonoBehaviour
{
    protected readonly Dictionary<ITickable, float> tickablesCooldownTimers = new();

    private const float _timerToCooldownTickDefaultValue = 0f;

    public virtual void Register(ITickable tickable)
    {
        if (tickable != null && !tickablesCooldownTimers.ContainsKey(tickable))
            tickablesCooldownTimers.Add(tickable, _timerToCooldownTickDefaultValue);
    }

    public virtual void Unregister(ITickable tickable)
    {
        tickablesCooldownTimers.Remove(tickable);
    }

    protected virtual void TickAll(float timeFromLastTick)
    {
         List<ITickable> tickables = tickablesCooldownTimers.Keys.ToList<ITickable>();

        foreach (ITickable tickable in tickables)
        {
            if (tickable == null)
                continue;

            float timerToCooldownTick = tickablesCooldownTimers[tickable];

            timerToCooldownTick += timeFromLastTick;

            if (timerToCooldownTick >= tickable.TickCooldownInSeconds)
            {
                timerToCooldownTick = 0;
                tickable.Tick();
            }

            tickablesCooldownTimers[tickable] = timerToCooldownTick;
        }
    }
}
