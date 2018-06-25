using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable
{
    public AudioClip bombCollectSound;
    
    protected override void OnRabitHit(HeroRabit rabit)
    {
        if (LevelController.current.soundOn)
            AudioSource.PlayClipAtPoint(bombCollectSound, transform.position);
        rabit.doSmall();
        this.CollectedHide();
    }
}
