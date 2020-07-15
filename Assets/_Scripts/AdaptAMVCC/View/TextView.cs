using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCalc;

public class TextView : View<GameplayApp>
{
    public CountryModel CountryModel;
    public CountryController CountryController;
    public InputField TextHolder;
    public Image Flag;
    public Text CurrencyName;
    public void OnTextChanged(char key) {
        processKey(key);
    }
    public void OnFlagFromPoolClick(CountryModel srcModel) {
        CountryModel.CurrencyName = srcModel.CurrencyName;
        CountryModel.Flag = srcModel.Flag;
        CountryModel.CurrencyMultiplier = srcModel.CurrencyMultiplier;
        CountryModel.CurMoney = srcModel.CurMoney; 

        Flag.sprite = CountryModel.Flag;
        CurrencyName.text = CountryModel.CurrencyName;
    }
    public void ConvertCurrency() {
        if (this.gameObject.name == "TextViewTarget") {
            CountryModel Base = app.view.TextViewBase.CountryModel;
            CountryController.ConvertCurrency(Base.CurMoney, Base.CurrencyMultiplier);
            TextHolder.text = CountryModel.CurMoney.ToString();
        }
    }
    public void OnFlagClick() {
        app.view.TextView = this;
    }

    #region  PROCESS THE KEY
    private void processKey(char key) {
        switch(key) {
            case 'T':
                if (TextHolder.text.Length > 0) {
                    TextHolder.text = TextHolder.text.Remove(TextHolder.text.Length - 1, 1);
                }
                break;
            case '=':
                TextHolder.text = getAnswer(TextHolder.text);
                CountryModel.CurMoney = int.Parse(TextHolder.text);
                break;
            default:
                TextHolder.text += key;
                CountryModel.CurMoney = int.Parse(TextHolder.text);
                break;
        }
    }
    #endregion

    #region NCal plugins
    private object startCalculate(string expression) {
        Expression ex = new Expression(expression);
        return ex.Evaluate();
    }
    private string getAnswer(string expression) {
        return startCalculate(expression).ToString();
    }
    #endregion
    #region MONO BEHAVIOUR 
    private void Update() {
        ConvertCurrency();
    }
    #endregion
}
