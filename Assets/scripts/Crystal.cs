using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable
{
    public AudioClip crystalCollectSound;
    protected override void OnRabitHit(HeroRabit rabit)
    {

        if (LevelController.current.soundOn)
            AudioSource.PlayClipAtPoint(crystalCollectSound, transform.position);
        string tag = this.gameObject.tag;   
        LevelController.current.showCrystal(LevelController.current.getCrystal(), tag);
        LevelController.current.addCrystal();
        CollectedHide();
    }
}
