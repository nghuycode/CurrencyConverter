using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : Controller<GameplayApp>
{
    private void Awake() {
        ScreenOrientationDetect.Instance.OnLandscape += OnLandscape;
        ScreenOrientationDetect.Instance.OnPortrait += OnPortrait;
    }
    public void OnPortrait() {
        CountryPoolController = CountryPoolController_Portrait;
    }
    public void OnLandscape() {
        CountryPoolController = CountryPoolController_Landscape;
    }
    #region Portrait
    public CountryPoolController CountryPoolController_Portrait;
    #endregion 
    #region Landscape
    public CountryPoolController CountryPoolController_Landscape;
    #endregion
    public CountryPoolController CountryPoolController;
}
