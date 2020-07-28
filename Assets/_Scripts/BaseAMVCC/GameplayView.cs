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
            TextView_Portrait.Copy(TextView);
            TextViewBase_Portrait.Copy(TextViewBase);
            TextViewTarget_Portrait.Copy(TextViewTarget);
        }
        TextView = TextView_Portrait;
        TextViewBase = TextViewBase_Portrait;
        TextViewTarget = TextViewTarget_Portrait;

        TextView.UpdateTextView();
        TextViewBase.UpdateTextView();
        TextViewTarget.UpdateTextView();
    }
    public void OnLandscape() {
        if (TextView) 
        {
            TextView_Landscape.Copy(TextView);
            TextViewBase_Landscape.Copy(TextViewBase);
            TextViewTarget_Landscape.Copy(TextViewTarget);
        }
        TextView = TextView_Landscape;
        TextViewBase = TextViewBase_Landscape;
        TextViewTarget = TextViewTarget_Landscape;

        TextView.UpdateTextView();
        TextViewBase.UpdateTextView();
        TextViewTarget.UpdateTextView();
    }
    public TextView TextView;
    public TextView TextViewBase, TextViewTarget;
    public MultiNationView MultiNationView;
    #region Portrait
    public TextView TextView_Portrait;
    public TextView TextViewBase_Portrait, TextViewTarget_Portrait;
    #endregion  
    #region Landscape
    public TextView TextView_Landscape;
    public TextView TextViewBase_Landscape, TextViewTarget_Landscape;
    #endregion
}
