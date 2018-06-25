using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : Collectable
{
    public AudioClip liveCollectSound;
    protected override void OnRabitHit(HeroRabit rabit)
    {
        print(LevelController.current.getLives());
        if (LevelController.current.soundOn)
            AudioSource.PlayClipAtPoint(liveCollectSound, transform.position);

        if (LevelController.current.getLives()<3)
        LevelController.current.editLives(1);
        print(LevelController.current.getLives());
        this.CollectedHide();
    }
}
