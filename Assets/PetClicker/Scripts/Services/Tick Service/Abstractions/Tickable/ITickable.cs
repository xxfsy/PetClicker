public interface ITickable
{
    public float TickCooldownInSeconds { get; } // перезарядка ответа на тик (например автосохранение)

    public void Tick(float timeFromLastTick);
}
