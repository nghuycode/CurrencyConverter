using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryPick : MonoBehaviour
{
    public List<CountryModel> Countries;
    public List<bool> IsLocked;

    [SerializeField]
    private GameObject GOCountries, prefabCountryButton, Content, baseCountry;
    [SerializeField]
    private Vector3 alphaPos, offsetButton;
    /*
    private void Awake() {
        Countries.Add(GOCountries.transform.GetChild(0).GetComponent<CountryModel>());
        IsLocked.Add(false);

        for (int i = 1; i < GOCountries.transform.childCount; ++i) {
            Countries.Add(GOCountries.transform.GetChild(i).GetComponent<CountryModel>());
            IsLocked.Add(false);
            GameObject NewCountryButton = Instantiate(prefabCountryButton);
            NewCountryButton.transform.SetParent(Content.transform);
            
            NewCountryButton.GetComponent<RectTransform>().localPosition = GetButtonPosition(i);
            NewCountryButton.GetComponent<CountryButton>().CountryModel.Copy(Countries[i]);
            NewCountryButton.GetComponent<CountryButton>().UpdateButtonView();
        }
    }*/
    private Vector3 GetButtonPosition(int ID) {
        return baseCountry.transform.localPosition + offsetButton * ID;
    }
}
