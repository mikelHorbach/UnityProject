using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelStat
{
    public bool hasCrystals = false;
    public bool hasAllFruits = false;
    public bool levelPassed = false;
    public List<int> collectedFruits = new List<int>();

    //Збереження
    /*string str = JsonUtility.ToJson(this.stats);
    PlayerPrefs.SetString("stats", str);
    //Читання
string str = PlayerPrefs.GetString("stats", null);
this.stats = JsonUtility.FromJson<LevelStat>(str);
if(!this.stats) {
    this.stats = new LevelStat();
}

    */
}

