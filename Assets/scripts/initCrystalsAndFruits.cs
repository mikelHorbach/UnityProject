using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initCrystalsAndFruits : MonoBehaviour {

    public GameObject crystal;
    public GameObject fruit;

    public Sprite crystalSprite;
    public Sprite fruitSprite;
    

    void Awake () {

        string sss = transform.CompareTag("door1")? "stats1" : "stats2";

        string str = PlayerPrefs.GetString(sss, null);
        LevelStat stats = JsonUtility.FromJson<LevelStat>(str);
        if (stats==null)
        {
            stats = new LevelStat();
        }
        if (stats.hasAllFruits)
        {
            fruit.GetComponent<SpriteRenderer>().sprite = fruitSprite;
        }
        if (stats.hasCrystals)
        {
            crystal.GetComponent<SpriteRenderer>().sprite = crystalSprite;
        }


    }

}
