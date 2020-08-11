using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryBar : MonoBehaviour
{
    public GameObject Countries;

    //Model 
    public string baseCurrencyName, targetCurrencyName;

    //View
    public Image baseFlag, targetFlag;
    public Text timeDateText;

    //Controller
    private void Awake()
    {
        Countries = GameObject.Find("Countries");
    }
    public void UpdateView(string nameBase, string nameTarget, string timeDate)
    {
        baseCurrencyName = nameBase;
        targetCurrencyName = nameTarget;

        //Flag
        baseFlag.sprite = FindFlagWithCurrencyName(baseCurrencyName);
        targetFlag.sprite = FindFlagWithCurrencyName(targetCurrencyName);

        //TimeDate
        timeDateText.text = timeDate;
    }
    private Sprite FindFlagWithCurrencyName(string currencyName)
    {
        for (int i = 0; i < Countries.transform.childCount; ++i)
        {
            if (currencyName == Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName)
                return Countries.transform.GetChild(i).GetComponent<CountryModel>().Flag;
        }
        return null;
    }
}
