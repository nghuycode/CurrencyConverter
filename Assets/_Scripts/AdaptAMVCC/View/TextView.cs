using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCalc;

public class TextView : View<GameplayApp>
{
    public InputField TextHolder;
    public void OnTextChanged(char key) {
        processKey(key);
    }

    #region  PROCESS THE KEY
    private void processKey(char key) {
        switch(key) {
            case 'T':
                if (TextHolder.text.Length > 0) {
                    TextHolder.text = TextHolder.text.Remove(TextHolder.text.Length - 1, 1);
                }
                break;
            case '=':
            TextHolder.text = getAnswer(TextHolder.text);
                break;
            default:
                TextHolder.text += key;
                break;
        }
    }
    #endregion

    #region NCal plugins
    private object startCalculate(string expression) {
        Expression ex = new Expression(expression);
        return ex.Evaluate();
    }
    private string getAnswer(string expression) {
        return startCalculate(expression).ToString();
    }
    #endregion
}
