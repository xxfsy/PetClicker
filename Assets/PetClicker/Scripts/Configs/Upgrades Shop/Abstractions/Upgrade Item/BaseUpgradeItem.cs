using UnityEngine;

public abstract class BaseUpgradeItem : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public float UpgradeValue { get; private set; }
}
