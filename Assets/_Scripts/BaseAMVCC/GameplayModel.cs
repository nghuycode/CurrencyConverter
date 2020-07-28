using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayModel : Model<GameplayApp>
{
    private void Awake() {
        ScreenOrientationDetect.Instance.OnLandscape += OnLandscape;
        ScreenOrientationDetect.Instance.OnPortrait += OnPortrait;
    }
    public void OnPortrait() {
        GameplayUI_Portrait.SetActive(true);
        GameplayUI_Landscape.SetActive(false);
        if (CountryPoolModel)
            CountryPoolModel_Portrait.CurrentCountryIndex = CountryPoolModel.CurrentCountryIndex;
        CountryPoolModel = CountryPoolModel_Portrait;
    }
    public void OnLandscape() {
        GameplayUI_Portrait.SetActive(false);
        GameplayUI_Landscape.SetActive(true);
        if (CountryPoolModel)
            CountryPoolModel_Landscape.CurrentCountryIndex = CountryPoolModel.CurrentCountryIndex;
        CountryPoolModel = CountryPoolModel_Landscape;
    }
    public CountryPoolModel CountryPoolModel;
    public MultiNationModel MultiNationModel;
    #region Portrait
    public GameObject GameplayUI_Portrait;
    public CountryPoolModel CountryPoolModel_Portrait;
    #endregion
    #region Landscape
    public GameObject GameplayUI_Landscape;
    public CountryPoolModel CountryPoolModel_Landscape;
    #endregion
}
