using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

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
    private IEnumerator GetCurrencyRateAPI()
    {
        string URL = "http://data.fixer.io/api/latest?access_key=e778a88bc21fdd653d79b82ca9895f4e";
        UnityWebRequest currencyRateRequest = UnityWebRequest.Get(URL);

        yield return currencyRateRequest.SendWebRequest();
        
        if (currencyRateRequest.isNetworkError || currencyRateRequest.isHttpError)
        {
            Debug.Log("Load currency rate failed! Load latest currency rate instead");
            yield break;
        }
        JSONNode currencyRateJSON = JSON.Parse(currencyRateRequest.downloadHandler.text);
        JSONNode rate = currencyRateJSON["rates"];
        Debug.Log(rate.Count);
        for (int i = 0; i < Countries.transform.childCount; ++i)
        {
            if (Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName == currencyRateJSON["base"])
                Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyMultiplier = 1;
            Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyMultiplier = rate[Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName];
            Debug.Log(Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyName + ":" + Countries.transform.GetChild(i).GetComponent<CountryModel>().CurrencyMultiplier);
        }
    }
}
