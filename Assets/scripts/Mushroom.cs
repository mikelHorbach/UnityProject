﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable
{
    protected override void OnRabitHit(HeroRabit rabit)
    {
        if(!rabit.IsBig_rabbit)
        {
            rabit.doBig();
        }
        this.CollectedHide();
    }
}
