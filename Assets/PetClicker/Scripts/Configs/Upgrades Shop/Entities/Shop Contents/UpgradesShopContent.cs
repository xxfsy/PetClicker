using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesShopContent", menuName = "ScriptableObject/UpgradesShop/Contents/UpgradesShopContent")]
public class UpgradesShopContent : BaseShopContent
{
    //[SerializeField] private List<BaseUpgradeItem> _autoClickerUpgradeItems;
    //[SerializeField] private List<BaseUpgradeItem> _clickerUpgradeItems;

    //public IEnumerable<BaseUpgradeItem> AutoClickerUpgradeItems => _autoClickerUpgradeItems;
    //public IEnumerable<BaseUpgradeItem> ClickerUpgradeItems => _clickerUpgradeItems;

    private void OnValidate() // TODO: написать проверку чтобы нельзя было айтемы с одинаковым айдишником (enum) кидать в коллекцию
    {
        
    }
}
