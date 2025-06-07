using System;

public abstract class BaseSharedModel
{
    public abstract event Action<string> ViewsNotify;
}
