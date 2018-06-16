using UnityEngine;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController current;
    Vector3 startingPosition;
    int coins;
   // int lives;
    void Awake()
    {
        current = this;
    }

    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }
    public void onRabitDeath(HeroRabit rabit)
    {
        //При смерті кролика повертаємо на початкову позицію
        rabit.transform.position = this.startingPosition;
        rabit.doSmall();
        rabit.transform.rotation = new UnityEngine.Quaternion(0,0,0,0);

    }

    public void addCoins(int c)
    {
        coins += c;
        if (c < 0) coins = 0;
    }
}