using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : Orc {
    public float runSpeed = 2.5f;

    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override float attackDirection()
    {
        Vector3 position = this.transform.position;
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;

        if (speed != runSpeed) speed = runSpeed;

        if (GetComponent<BoxCollider2D>().IsTouching(HeroRabit.lastRabit.GetComponent<BoxCollider2D>()))
        {
            return 0;
        }
        if (position.x < rabit_pos.x)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    protected override void checkAttack()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(HeroRabit.lastRabit.GetComponent<BoxCollider2D>()))
        {
            if (!animator.GetBool("isAttack")) animator.SetTrigger("isAttack");
            if (HeroRabit.lastRabit.transform.position.y > transform.position.y+0.4)
            {
                animator.SetBool("isDie", true);
                
                return;
            }
            else HeroRabit.lastRabit.GetComponent<Animator>().SetBool("death", true);
        }

    }

   

    protected override bool isDieAnimation()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("orc1_die");
    }
}
