using System.Collections.Generic;

public abstract class BaseController<T> where T : IControllable
{
    // TODO: finish this class 

    protected readonly List<T> components = new(); // нужно ли подумать еще?????? мб сделать абстрактным свойством хз подумать еще короче. нужно как-то сделать абстрактную коллекцию и сделать ее закрытой

    public abstract void InitAll();
}
