using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryController : Controller<GameplayApp>
{
    public float ConvertCurrency(float srcCurMoney, float srcCurrencyMulti) 
    {
        return CurrencyConverter.Instance.ConvertCurrency(srcCurMoney, srcCurrencyMulti, app.model.CountryModel.CurrencyMultiplier);
    }
}
