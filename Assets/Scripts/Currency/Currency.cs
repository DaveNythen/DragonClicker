using UnityEngine;

public class Currency : Singleton<Currency>
{
    [SerializeField] CurrencyUI currencyUI;

    public void AddMoney(int amount)
    {
        SaveData.Instance.profile.currency += amount;
        currencyUI.OnEarnMoney(amount);
    }

    public void Buy(int expense)
    {
        SaveData.Instance.profile.currency -= expense;
        currencyUI.OnExpendMoney(expense);
    }
}
