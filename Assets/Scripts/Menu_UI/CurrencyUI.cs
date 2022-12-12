using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CurrencyUI : MonoBehaviour
{
    private int _totalMoneyAnimated;
    private int _fps = 30;
    private Coroutine increaseCoroutine;

    [SerializeField] TMP_Text totalMoneyText;
    [SerializeField] TMP_Text additionText;

    private float _additionOriginalPosY;

    private void Start()
    {
        _additionOriginalPosY = additionText.transform.position.y;
    }

    public void OnAddMoney(int amount, bool isExpense)
    {
        if(isExpense)
            additionText.text = "- " + amount.ToString();
        else
            additionText.text = "+ " + amount.ToString();

        additionText.DOKill();
        additionText.transform.DOMoveY(_additionOriginalPosY + 30, 0.3f);
        additionText.GetComponent<CanvasGroup>().DOFade(0, 0.3f).OnComplete(() => { ResetAddition(); });

        //I want an async method when 2 enemies die at the same time
        if (increaseCoroutine != null)
            StopCoroutine(increaseCoroutine);

        increaseCoroutine = StartCoroutine(ChangeMoneyAsync(amount, isExpense));
    }

    private void ResetAddition()
    {
        additionText.text = "";
        additionText.transform.DOMoveY(_additionOriginalPosY, 0);
        additionText.GetComponent<CanvasGroup>().DOFade(1, 0);
    }

    IEnumerator ChangeMoneyAsync(int amount, bool isExpense)
    {
        int targetValue;
        int stepAmount = Mathf.CeilToInt(amount / (_fps * 0.3f));

        if (isExpense)
        {
            targetValue = _totalMoneyAnimated - amount;

            while (_totalMoneyAnimated > targetValue)
            {
                _totalMoneyAnimated -= stepAmount;
                if (_totalMoneyAnimated < targetValue)
                    _totalMoneyAnimated = targetValue;

                totalMoneyText.text = _totalMoneyAnimated.ToString();

                yield return new WaitForSeconds(1f / _fps);
            }
        }
        else
        {
            targetValue = _totalMoneyAnimated + amount;

            while (_totalMoneyAnimated < targetValue)
            {
                _totalMoneyAnimated += stepAmount;
                if (_totalMoneyAnimated > targetValue)
                    _totalMoneyAnimated = targetValue;

                totalMoneyText.text = _totalMoneyAnimated.ToString();

                yield return new WaitForSeconds(1f / _fps);
            }
        }
    }
}
