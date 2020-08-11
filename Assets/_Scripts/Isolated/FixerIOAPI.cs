using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System;
using System.IO;

public class FixerIOAPI : MonoBehaviour
{
    public static FixerIOAPI Instance;
    public GameObject Countries;
    public string Date;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(GetCurrencyRateAPI());
    }
    public event Action OnAPIUpdated;
    public void APIUpdated()
    {
        if (OnAPIUpdated != null)
        {
            OnAPIUpdated();
        }
    }
    private IEnumerator GetCurrencyRateAPI()
    {
        string URL = "http://data.fixer.io/api/latest?access_key=e778a88bc21fdd653d79b82ca9895f4e";
        UnityWebRequest currencyRateRequest = UnityWebRequest.Get(URL);

        yield return currencyRateRequest.SendWebRequest();
        
        if (currencyRateRequest.error != null)
        {
            Debug.Log("Load currency rate failed! Load latest currency rate instead");
            LoadCurrencyRateOffline();
            yield break;
        }
        string path = Application.persistentDataPath + "/currencyrate.json";
        File.WriteAllText(path, currencyRateRequest.downloadHandler.text);
        JSONNode currencyRateJSON = JSON.Parse(currencyRateRequest.downloadHandler.text);
        JSONNode rate = currencyRateJSON["rates"];

        for (int i = 0; i < Countries.transform.childCount; ++i)
        {
            if (Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName == currencyRateJSON["base"])
                Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyMultiplier = 1;
            Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyMultiplier = rate[Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName];
        }
        APIUpdated();
    }
    private void LoadCurrencyRateOffline()
    {
        string path = Application.persistentDataPath + "/currencyrate.json";
        string jsonFile = File.ReadAllText(path);
        JSONNode currencyRateJSON = JSON.Parse(jsonFile);
        JSONNode rate = currencyRateJSON["rates"];

        for (int i = 0; i < Countries.transform.childCount; ++i)
        {
            if (Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName == currencyRateJSON["base"])
                Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyMultiplier = 1;
            Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyMultiplier = rate[Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName];
        }
    }
}
