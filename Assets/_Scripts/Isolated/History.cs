using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class History : MonoBehaviour
{
    public static History Instance;
    public GameplayApp app;
    public JSONObject newHistory;
    public JSONArray Base, Target, TimeDate;

    public string[] bases, targets, timedates;
    private void Awake()
    {
        Instance = this;

        //Init the JSON
        newHistory = new JSONObject();
        TimeDate = new JSONArray();
        Base = new JSONArray();
        Target = new JSONArray();
    }
    public void SaveBaseTarget()
    {
        //Time
        DateTime now = DateTime.Now;
        TimeDate.Add(DateTime.Now.ToString("dd/MM/yyyy   HH:mm"));

        //Get Base and Target currency name
        string baseName = app.view.TextViewBase.CountryModel.CurrencyName;
        string targetName = app.view.TextViewTarget.CountryModel.CurrencyName;

        Base.Add(baseName);
        Target.Add(targetName);  
    }
    public void SaveToFile()
    {
        newHistory.Add("TimeDate", TimeDate);
        newHistory.Add("Base", Base);
        newHistory.Add("Target", Target);
        string path = Application.persistentDataPath + "/history.json";
        File.WriteAllText(path, newHistory.ToString());
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/history.json";
        string jsonFile = File.ReadAllText(path);
        JSONObject jsonObject = (JSONObject)JSON.Parse(jsonFile);

        int count = jsonObject["Base"].Count;
        bases = new string[count];
        targets = new string[count]; 
        timedates = new string[count];

        for (int i = 0; i < count; ++i)
        {
            bases[i] = jsonObject["Base"][i].Value;
            targets[i] = jsonObject["Target"][i].Value;
            timedates[i] = jsonObject["TimeDate"][i].Value;
        }
        app.view.HistoryView.GenerateHistoryBar(bases, targets, timedates);
    }
}
