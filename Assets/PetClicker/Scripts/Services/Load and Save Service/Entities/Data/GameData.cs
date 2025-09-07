using System.Collections.Generic;

public class GameData : BaseData
{
    // Значение по дефолту:

    // Currencies
    public int AmountOfMoney = 0;

    // Clicker
    public int ClicksCount = 0;
    public int ClickerIncomePerClick = 1;

    // AutoClicker
    public int AutoClickerIncomePerSecond = 0;

    // Upgrades
    // 2 словаря где апгрейды хранятся по енаму, так как если мы будем хранить в одном словаре по SO как в модели апгрейд шопа, то если мы поменяем ссылку на СО сохранение слетит, а так не слетит так как мы можем спокойно поменять ссылку на СО, ведь сохранение по енаму происходит
    public Dictionary<AutoClickerUpgrades, int> AutoClickerUpgradesPurchasedCount = new Dictionary<AutoClickerUpgrades, int>();

    public Dictionary<ClickerUpgrades, int> ClickerUpgradesPurchasedCount = new Dictionary<ClickerUpgrades, int>();
}
