using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyConverter : MonoBehaviour
{
    public static CurrencyConverter Instance;
    private void Awake() {
        Instance = this;
    }

    public float ConvertCurrency(float curMoneyA, float multiNumA, float multiNumB) {
        return curMoneyA * (multiNumA / multiNumB);
    }
}
