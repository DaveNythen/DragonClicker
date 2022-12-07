using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Currency : Singleton<Currency>
{
    private int _totalMoneyAnimated;
    private int _totalMoney;
    private float _additionAnimationTime = 0.3f;
    private float _totalAnimationTime = 0.3f;
    private int _fps = 30;
    private Coroutine increaseCoroutine;
    private float _additionOriginalPosY;

    [SerializeField] TMP_Text totalMoneyText;
    [SerializeField] TMP_Text additionText;

    private void Start()
    {
        _additionOriginalPosY = additionText.transform.position.y;
    }

    public void AddMoney(int amount)
    {
        //I want an async method when 2 enemies die at the same time
        StartCoroutine(AddMoneyAsync(amount));
    }

    IEnumerator AddMoneyAsync(int amount)
    {
        _totalMoney += amount;
        additionText.text = "+ " + amount.ToString();

        additionText.DOKill();
        additionText.transform.DOMoveY(_additionOriginalPosY + 30, _additionAnimationTime);
        additionText.GetComponent<CanvasGroup>().DOFade(0, _additionAnimationTime).OnComplete(() => { ResetAddition(); });

        if (increaseCoroutine != null)
        {
            StopCoroutine(increaseCoroutine);
            if (_totalMoney != _totalMoneyAnimated)
                _totalMoneyAnimated = _totalMoney;
        }

        increaseCoroutine = StartCoroutine(IncreaseTotalMoney(amount));

        yield return null;
    }

    IEnumerator IncreaseTotalMoney(int amount)
    {
        int targetValue = _totalMoneyAnimated + amount;
        int stepAmount = Mathf.CeilToInt(amount / (_fps * _totalAnimationTime));

        while (_totalMoneyAnimated < targetValue)
        {
            _totalMoneyAnimated += stepAmount;
            if (_totalMoneyAnimated > targetValue)
                _totalMoneyAnimated = targetValue;

            totalMoneyText.text = _totalMoneyAnimated.ToString();

            yield return new WaitForSeconds(1f / _fps);
        }
    }

    private void ResetAddition()
    {
        additionText.text = "";
        additionText.transform.DOMoveY(_additionOriginalPosY, 0);
        additionText.GetComponent<CanvasGroup>().DOFade(1, 0);
    }
}
