using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryModel : Model<GameplayApp>
{
    public Sprite Flag;
    public string CurrencyName;
    public string CurrencyFullName;
    public float CurrencyMultiplier;
    public float CurMoney;

    public void Copy(CountryModel src) {
        Flag = src.Flag;
        CurrencyName = src.CurrencyName;
        CurrencyFullName = src.CurrencyFullName;
        CurrencyMultiplier = src.CurrencyMultiplier;
        CurMoney = src.CurMoney;
    }
}
