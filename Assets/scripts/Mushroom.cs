using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable
{
    public AudioClip mushroomCollectSound;
    protected override void OnRabitHit(HeroRabit rabit)
    {
        if (LevelController.current.soundOn)
            AudioSource.PlayClipAtPoint(mushroomCollectSound, transform.position);
        if (!rabit.IsBig_rabbit)
        {
            rabit.doBig();
        }
        this.CollectedHide();
    }
}
