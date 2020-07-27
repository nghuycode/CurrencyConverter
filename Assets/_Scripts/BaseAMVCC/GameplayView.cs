using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayView : View<GameplayApp>
{
    private void Awake() {
        ScreenOrientationDetect.Instance.OnLandscape += OnLandscape;
        ScreenOrientationDetect.Instance.OnPortrait += OnPortrait;
    }
    public void OnPortrait() {
        if (TextView)
        {
            TextView_Portrait.CountryModel.Copy(TextView.CountryModel);
            TextViewBase_Portrait.CountryModel.Copy(TextViewBase.CountryModel);
            TextViewTarget_Portrait.CountryModel.Copy(TextViewTarget.CountryModel);
        }
        TextView = TextView_Portrait;
        TextViewBase = TextViewBase_Portrait;
        TextViewTarget = TextViewTarget_Portrait;
    }
    public void OnLandscape() {
        if (TextView) 
        {
            TextView_Landscape.CountryModel.Copy(TextView.CountryModel);
            TextViewBase_Landscape.CountryModel.Copy(TextViewBase.CountryModel);
            TextViewTarget_Landscape.CountryModel.Copy(TextViewTarget.CountryModel);
        }
        TextView = TextView_Landscape;
        TextViewBase = TextViewBase_Landscape;
        TextViewTarget = TextViewTarget_Landscape;
    }
    public TextView TextView;
    public TextView TextViewBase, TextViewTarget;
    #region Portrait
    public TextView TextView_Portrait;
    public TextView TextViewBase_Portrait, TextViewTarget_Portrait;
    #endregion  
    #region Landscape
    public TextView TextView_Landscape;
    public TextView TextViewBase_Landscape, TextViewTarget_Landscape;
    #endregion
}
