using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiNationView : View<GameplayApp>
{
    public GameObject Content;
    public GameObject prefabCountryDisplay, BaseCountry;
    public GameObject TextViewBase;
    public List<TextView> listTextView;
    [SerializeField]
    private Vector3 offsetBetweenCountries;

    public void SwitchToMulti() {
        CountryModel src = app.view.TextViewBase.CountryModel;
        TextViewBase.GetComponent<TextView>().CountryModel.Copy(src);
        TextViewBase.GetComponent<TextView>().UpdateTextView();
    }
    public void AddNewTextViewToContent(CountryModel src) {
        //Instantiate new TextView -> add to listTextView and set parent to content
        GameObject NewCountry = Instantiate(prefabCountryDisplay);
        NewCountry.transform.SetParent(Content.transform);
        listTextView.Add(NewCountry.GetComponent<TextView>());

        int ID = NewCountry.transform.GetSiblingIndex();
        NewCountry.GetComponent<RectTransform>().localPosition = GetPositionOfCountry(ID);
        NewCountry.GetComponent<TextView>().CountryModel.Copy(src);
        NewCountry.GetComponent<TextView>().UpdateTextView();
    }
    public void OnListTextViewUpdated(List<CountryModel> listCountryModel) {
        //Need to optimize
        for (int i = 0; i < listCountryModel.Count; ++i) {
            listTextView[i].CountryModel.Copy(listCountryModel[i]);
            listTextView[i].ConvertCurrency();
            listTextView[i].UpdateTextView();
        }
    }

    private Vector3 GetPositionOfCountry(int ID) {
        return TextViewBase.GetComponent<RectTransform>().localPosition + offsetBetweenCountries * ID;
    }
}
