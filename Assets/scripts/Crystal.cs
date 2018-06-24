using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable
{
    protected override void OnRabitHit(HeroRabit rabit)
    {
        string tag = this.gameObject.tag;   
        LevelController.current.showCrystal(LevelController.current.getCrystal(), tag);
        LevelController.current.addCrystal();
        CollectedHide();
    }
}
