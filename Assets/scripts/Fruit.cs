using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable
{

    protected override void OnRabitHit(HeroRabit rabit)
    {
        this.CollectedHide();
        LevelController.current.addFruits(1);
        //print(LevelController.current.fruitsLabel.text);
    }
}
