using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable
{
    private float speed = 2.5f;
    public GameObject prefabCarrot;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(destroyLater());
    }

    public void launch(float direction)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, 0);
        if (direction < 0) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;

    }

    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    protected override void OnRabitHit(HeroRabit rabit)
    {
        rabit.doSmall();
        LevelController.current.editLives(-1);
        this.CollectedHide();
    }
}
