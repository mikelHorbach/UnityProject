using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController current;
    Vector3 startingPosition;
    int coins = 0;
    int lives = 3;
    int fruits = 0;
    int crystal = 0;
    public Text coinsLabel;
    public Text fruitsLabel;
    public RawImage live1;
    public RawImage live2;
    public RawImage live3;
    public RawImage emptyLive;

    public RawImage crystal1;
    public RawImage crystal2;
    public RawImage crystal3;

    public RawImage crystalRed;
    public RawImage crystalBlue;
    public RawImage crystalGreen;
    public GameObject loseCanvas;
    

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
        showCoins(coins);
       // coinsLabel.text = coins.ToString();
    }

    public void showCoins ( int c)
    {
        string s = c.ToString();
        while (s.Length < 4) s = "0"+s;
        coinsLabel.text = s;
    }

    public void editLives(int l)
    {
        lives += l;
        showLives(lives);
        if (lives == 0)
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void showLives(int c)
    {
        if (c == 3) live3.texture = live1.texture;
        else if (c == 2) { 
        live3.texture = emptyLive.texture;
        live2.texture = live1.texture;
        }
        else if (c == 1)
        {
            live2.texture = emptyLive.texture;
        }
        else if (c == 0) live1.texture = emptyLive.texture;
    }

    public void setLives(int c)
    {
        lives = c;
    }

    public int getLives()
    {
        return lives;
    }

    public void addFruits(int f)
    {
        fruits += f;
        showFruits(fruits);
    }
    public void showFruits(int f)
    {
        string s = fruitsLabel.text;
        fruitsLabel.text = f + s.Substring(s.IndexOf("/"));
    }

    public void showCrystal(int c , string tag)
    {
        if (c == 0 && tag.Equals("redCrystal"))
            crystal1.texture = crystalRed.texture;
        else if (c == 0 && tag.Equals("greenCrystal"))
            crystal1.texture = crystalGreen.texture;
        else if (c == 0 && tag.Equals("blueCrystal"))
            crystal1.texture = crystalBlue.texture;

        else if (c == 1 && tag.Equals("redCrystal"))
            crystal2.texture = crystalRed.texture;
        else if (c == 1 && tag.Equals("greenCrystal"))
            crystal2.texture = crystalGreen.texture;
        else if (c == 1 && tag.Equals("blueCrystal"))
            crystal2.texture = crystalBlue.texture;

        else if (c == 2 && tag.Equals("redCrystal"))
            crystal3.texture = crystalRed.texture;
        else if (c == 2 && tag.Equals("greenCrystal"))
            crystal3.texture = crystalGreen.texture;
        else if (c == 2 && tag.Equals("blueCrystal"))
            crystal3.texture = crystalBlue.texture;
    }
    public int getCrystal()
    {
        return crystal;
    }
    public void addCrystal()
    {
        crystal++;
    }

    
}