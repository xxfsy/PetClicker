public abstract class BaseSaveableModel : BaseModel 
{
    public abstract void SaveLayer(BaseData baseData);

    public abstract void LoadLayer(BaseData baseData);
}
