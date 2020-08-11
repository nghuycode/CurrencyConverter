using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyConverter : MonoBehaviour
{
    public static CurrencyConverter Instance;
    private float lastMultiNumA, lastMultiNumB;
    private void Awake() {
        Instance = this;
    }

    public float ConvertCurrency(float curMoneyA, float multiNumA, float multiNumB) {
        if (lastMultiNumA != multiNumA || lastMultiNumB != multiNumB)
        {
            History.Instance.SaveBaseTarget();
        }
        lastMultiNumA = multiNumA;
        lastMultiNumB = multiNumB;
        return curMoneyA * (multiNumB / multiNumA);
    }
}
