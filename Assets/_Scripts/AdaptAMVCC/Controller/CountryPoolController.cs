using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryPoolController : Controller<GameplayApp>

{
    Animator anim;
    public CountryController CountryL, CountryM, CountryR;
    private void Start() {
        anim = this.GetComponent<Animator>();
        InputHandler.Instance.OnSwipeUp += SwipeUp;
        InputHandler.Instance.OnSwipeDown += SwipeDown;
        InputHandler.Instance.OnSwipeLeft += SwipeLeft;
        InputHandler.Instance.OnSwipeRight += SwipeRight;
        UpdateCountryPool();
    }
    public void UpdateCountryPool() {
        Debug.Log("UpdateCountryPool");
        var currentIndex = app.model.CountryPoolModel.CurrentCountryIndex;
        var countriesModel = app.model.CountryPoolModel.CountriesModel;

        CountryL.UpdateCountry(countriesModel[currentIndex - 1]);
        CountryM.UpdateCountry(countriesModel[currentIndex]);
        CountryR.UpdateCountry(countriesModel[currentIndex + 1]);
    }
    public void SwipeUp() {
        anim.SetTrigger("CountryPoolUnhide");
    }
    public void SwipeDown() {
        anim.SetTrigger("CountryPoolHide");
    }
    public void SwipeRight() {
        CountryPoolModel countryPoolModel = app.model.CountryPoolModel;
        if (countryPoolModel.CurrentCountryIndex > 1) {
            countryPoolModel.CurrentCountryIndex--;
            UpdateCountryPool();
        }
    }
    public void SwipeLeft() {
        CountryPoolModel countryPoolModel = app.model.CountryPoolModel;
        if (countryPoolModel.CurrentCountryIndex < countryPoolModel.CountriesModel.Count - 2) {
            countryPoolModel.CurrentCountryIndex++;
            UpdateCountryPool();
        }
    }
}
