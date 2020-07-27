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
        TextView = TextView_Portrait;
        TextViewBase = TextViewBase_Portrait;
        TextViewTarget = TextViewTarget_Portrait;
    }
    public void OnLandscape() {
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
