using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryView : View<GameplayApp>
{
    public Image UI_Flag;
    public Text UI_CurrencyName;

    public void OnUpdateCountry() {
        var CountryModel = this.GetComponent<CountryModel>();

        UI_Flag.sprite = CountryModel.Flag;
        UI_CurrencyName.text = CountryModel.CurrencyName;
    }

    public void OnFlagClick() {
        CountryModel CountryModel = this.GetComponent<CountryModel>();
        app.view.TextView.OnFlagFromPoolClick(CountryModel);
    }
}
