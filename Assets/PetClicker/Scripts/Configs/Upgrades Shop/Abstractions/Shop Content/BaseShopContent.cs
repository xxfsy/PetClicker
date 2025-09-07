using System.Collections.Generic;
using UnityEngine;

//  Я перенес сюда список айтемов шоп контента, ведь у каждого шоп контента должен быть список айтемов, а уже например конкретные реализации добавляют напрмер логиу OnValidate и т.д.
public abstract class BaseShopContent : ScriptableObject 
{
    [SerializeField] private List<BaseUpgradeItem> _autoClickerAndClickerUpgradeItems;

    public IEnumerable<BaseUpgradeItem> AutoClickerAndClickerUpgradeItems => _autoClickerAndClickerUpgradeItems;
}
