public interface ITickable
{
    public float TickCooldownInSeconds { get; } // перезарядка ответа на тик (например автосохранение)

    public void SetTickCooldown(float tickCooldownInSeconds);

    public void Tick(float timeFromLastTick);
}
