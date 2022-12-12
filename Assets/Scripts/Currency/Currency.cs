using UnityEngine;

public class Currency : Singleton<Currency>
{
    private int _totalMoney;

    [SerializeField] CurrencyUI currencyUI;

    public void AddMoney(int amount)
    {
        _totalMoney += amount;

        SaveData.Instance.profile.currency += amount;
        currencyUI.OnAddMoney(amount, false);
    }

    public void Buy(int expense)
    {
        _totalMoney -= expense;

        SaveData.Instance.profile.currency -= expense;
        currencyUI.OnAddMoney(expense, true);
    }

    public int GetMoney()
    {
        return _totalMoney;
    }
}
