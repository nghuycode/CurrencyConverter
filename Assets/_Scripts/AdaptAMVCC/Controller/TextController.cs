using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : Controller<GameplayApp>
{
    public void ChangeText(char key) {
        app.view.TextView.OnTextChanged(key);
    }
}
