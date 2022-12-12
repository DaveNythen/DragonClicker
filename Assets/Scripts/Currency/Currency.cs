using UnityEngine;

public class Currency : Singleton<Currency>
{
    private int _totalMoney;

    [SerializeField] CurrencyUI currencyUI;

    public void AddMoney(int amount)
    {
        _totalMoney += amount;

        currencyUI.OnAddMoney(amount);
    }

    public int GetMoney()
    {
        return _totalMoney;
    }
}
