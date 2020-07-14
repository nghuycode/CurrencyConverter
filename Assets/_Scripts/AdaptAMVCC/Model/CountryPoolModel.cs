using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryPoolModel : Model<GameplayApp>
{
    public GameObject Countries;
    public List<CountryModel> CountriesModel;
    public int CurrentCountryIndex;
    
    private void Awake() {
        for (int i = 0; i < Countries.transform.childCount; i++) 
            CountriesModel.Add(Countries.transform.GetChild(i).GetComponent<CountryModel>());
    }
}
