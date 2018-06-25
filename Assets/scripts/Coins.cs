using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable
{
    public AudioClip coinCollectSound;
    protected override void OnRabitHit(HeroRabit rabit)
    {
       if( LevelController.current.soundOn)
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
        LevelController.current.addCoins(1);
        this.CollectedHide();
    }
}