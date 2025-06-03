using System;

public abstract class SharedModel
{
    public abstract event Action<string> ViewsNotify;
}
