using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryController : Controller<GameplayApp>
{
    public float GetCurMoney() {
        CountryModel CountryModel = this.GetComponent<CountryModel>();
        return CountryModel.CurMoney;
    }
    public float GetCurrencyMultiplier() {
        CountryModel CountryModel = this.GetComponent<CountryModel>();
        return CountryModel.CurrencyMultiplier;
    }
    public void ConvertCurrency(float srcCurMoney, float srcCurrencyMulti) 
    {
        CountryModel CountryModel = this.GetComponent<CountryModel>();
        CountryModel.CurMoney = CurrencyConverter.Instance.ConvertCurrency(srcCurMoney, srcCurrencyMulti, CountryModel.CurrencyMultiplier);
    }
    public void UpdateCountry(CountryModel src) {
        CountryModel CountryModel = this.GetComponent<CountryModel>();
        CountryView CountryView = this.GetComponent<CountryView>();

        CountryModel.CurrencyName = src.CurrencyName;
        CountryModel.Flag = src.Flag;
        CountryModel.CurrencyMultiplier = src.CurrencyMultiplier;
        CountryModel.CurMoney = src.CurMoney;

        //Debug.Log(this.name + ":UpdateCountry:" + CountryModel.CurrencyName);
        CountryView.OnUpdateCountry();
    }
}
