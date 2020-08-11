using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryView : MonoBehaviour
{
    public GameObject HistoryBarPrefab;
    public void GenerateHistoryBar(string[] bases, string[] targets, string[] timedates)
    {
        for (int i = 0; i < bases.Length; ++i)
        {
            GameObject GO = Instantiate(HistoryBarPrefab) as GameObject;
            GO.transform.SetParent(this.transform);
            GO.GetComponent<HistoryBar>().UpdateView(bases[i], targets[i], timedates[i]);
        }
    }
}
