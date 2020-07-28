using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryButton : MonoBehaviour
{
    public CountryModel CountryModel;
    public MultiNationView MultiNationView;
    public void UpdateButtonView() {
        //this.GetComponent<Image>().sprite = CountryModel.Flag;
    }
    public void OnPicked() {
        Debug.Log(CountryModel.CurrencyName);
        MultiNationView.AddNewTextViewToContent(CountryModel);
    }
}
