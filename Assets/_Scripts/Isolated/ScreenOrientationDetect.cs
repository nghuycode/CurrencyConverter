using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationDetect : MonoBehaviour
{
    public static ScreenOrientationDetect Instance;
    [SerializeField]
    private ScreenOrientation CurOrientation;
    private void Awake() {
        Instance = this;
        CurOrientation = ScreenOrientation.Unknown;
    }
    private void LateUpdate() {
        if (Screen.orientation == ScreenOrientation.Portrait && CurOrientation != ScreenOrientation.Portrait) 
        {
            CurOrientation = ScreenOrientation.Portrait;
            PortraitOrientation();
        }
        else if (Screen.orientation == ScreenOrientation.Landscape && CurOrientation != ScreenOrientation.Landscape) 
        {
            CurOrientation = ScreenOrientation.Landscape;
            LandscapeOrientation();
        }
    }
    public event Action OnPortrait;
    public void PortraitOrientation() {
        Debug.Log("Portrait");
        if (OnPortrait != null) 
            OnPortrait();
    }
    public event Action OnLandscape;
    public void LandscapeOrientation() {
        Debug.Log("Landscape");
        if (OnLandscape != null)
            OnLandscape();
    }
}
