public interface ISaveableMVPLayer // мб переименовать в ISaveableMVPModel ? ведь по идее только она может сохраняться и загружаться
{
    public void SaveLayer(BaseData baseData);

    public void LoadLayer(BaseData baseData);
}
