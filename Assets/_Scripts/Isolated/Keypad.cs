using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    GameplayApp app;

    [SerializeField]
    private char keyValue;

    private void Awake()
    {
        app = GameObject.Find("Application").GetComponent<GameplayApp>();
    }
    public void OnPressed()
    {
        app.view.TextView.OnTextChanged(keyValue);
    }
}
