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
    public Button Flag;
    public Text CurrencyName;
    public void OnTextChanged(char key) {
        processKey(key);
    }
    public void OnFlagFromPoolClick(CountryModel srcModel) {
        CountryModel.CurrencyName = srcModel.CurrencyName;
        CountryModel.Flag = srcModel.Flag;
        CountryModel.CurrencyMultiplier = srcModel.CurrencyMultiplier;
        CountryModel.CurMoney = srcModel.CurMoney; 

        Flag.image.sprite = CountryModel.Flag;
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
        InputField TextHolderBase = app.view.TextViewBase.TextHolder; 
        switch(key) {
            case 'T':
                if (TextHolderBase.text.Length > 0) {
                    TextHolderBase.text = TextHolderBase.text.Remove(TextHolderBase.text.Length - 1, 1);
                }
                break;
            case '=':
                TextHolderBase.text = getAnswer(TextHolderBase.text);
                break;
            default:
                TextHolderBase.text += key;
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
    private void Start() {
        
    }
    private void Update() {
        if (TextHolder.text != "" && this.gameObject.name == "TextViewBase" && isNumeric(TextHolder.text))
            CountryModel.CurMoney = int.Parse(TextHolder.text);
        if (CountryModel.CurrencyName != "")
            ConvertCurrency();
    }
    bool isNumeric(string s) {
        int num;
        return int.TryParse(s, out num);
    }
    #endregion
}
