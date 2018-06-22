using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOrc : Orc {
    public GameObject prefabCarrot;
    public float break_time = 1.5f;
    float timeCurrrent;
    // Use this for initialization
    new void Start () {
        base.Start();
        timeCurrrent = break_time;
    }
	
	// Update is called once per frame
	new void FixedUpdate () {
        base.FixedUpdate();
	}

    protected override float attackDirection()
    {
        return 0;
    }

    void launchCarrot(float direction)
    {
        //Створюємо копію Prefab
        GameObject obj = GameObject.Instantiate(this.prefabCarrot);
        //Розміщуємо в просторі
        obj.transform.position = this.transform.position + new Vector3(0, this.GetComponent<BoxCollider2D>().size.y / 2.1f - 0.2f, 0);
      //  obj.layer = 110;
        //Запускаємо в рух
        Carrot carrot = obj.GetComponent<Carrot>();
        carrot.launch(direction);
    }

    protected override bool isDieAnimation()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("orc2_die");
    }

    protected override void checkAttack()
    {
        Vector3 position = this.transform.position;
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        if (GetComponent<BoxCollider2D>().IsTouching(HeroRabit.lastRabit.GetComponent<BoxCollider2D>()))
        {
            if (HeroRabit.lastRabit.transform.position.y > transform.position.y)
            {
                animator.SetBool("isDie", true);
                return;
            }
        }
        if (mode == Mode.Attack)
        {
            if (rabit_pos.x > position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                if (timeCurrrent > 0)
                {
                    timeCurrrent -= Time.deltaTime;
                    return;
                }
                animator.SetTrigger("isAttack");
                this.launchCarrot(1);
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                if (timeCurrrent > 0)
                {
                    timeCurrrent -= Time.deltaTime;
                    return;
                }
                animator.SetTrigger("isAttack");
                this.launchCarrot(-1);
            }
            timeCurrrent = break_time;
        }
    }

    
}
