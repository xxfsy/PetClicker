using System.Collections.Generic;
using UnityEngine;

// TODO: подумать как отрефакторить, сравнить с мвп связками, подумать что добавить в этот абстрактный класс. Допустим я перенес сюда список айтемов шоп контента, ведь у каждого шоп контента должен быть список айтемов, а уже например конкретные реализации добавляют напрмер логиу OnValidate и т.д.
public abstract class BaseShopContent : ScriptableObject 
{
    // наверное надо создать один список всех улучшений и спомощью этого списка и будет настраиваться их расположение в магазине улучшений. (? спросить у чата)
    [SerializeField] private List<BaseUpgradeItem> _autoClickerAndClickerUpgradeItems;

    public IEnumerable<BaseUpgradeItem> AutoClickerAndClickerUpgradeItems => _autoClickerAndClickerUpgradeItems;
}
