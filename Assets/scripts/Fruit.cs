using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable
{
    public AudioClip fruitCollectSound;
    protected override void OnRabitHit(HeroRabit rabit)
    {
        if (LevelController.current.soundOn)
            AudioSource.PlayClipAtPoint(fruitCollectSound, transform.position);
        this.CollectedHide();
        LevelController.current.addFruits(1);
        //print(LevelController.current.fruitsLabel.text);
    }
}
