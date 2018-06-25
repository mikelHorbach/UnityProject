using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour {
    public GameObject settingsPanel;
    public GameObject winPanel;
    public Sprite offmusic;
    public Sprite onMusic;
    public Sprite offsound;
    public Sprite onSound;
    public Button sound;
    public Button music;
    //private AudioClip buttonSound = LevelController.current.buttonSound;

    public void openDr1()
    {
        StartCoroutine(openDoor1());
    }

    IEnumerator openDoor1()
    {
        yield return new WaitForSeconds(1.0f);
         SceneManager.LoadScene("Level1");
    }

    public void openDr2()
    {
        StartCoroutine(openDoor2());
    }

    IEnumerator openDoor2()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Level2");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.transform.CompareTag("door1"))
        {
            openDr1(); 
        }
        if(this.transform.CompareTag("door2") && !this.transform.Find("lock").gameObject.active )
        {
            openDr2();
        }
        if (this.transform.CompareTag("end1"))
        {
            loadWinPanel();
        }
    }


    public void openSettings()
    {
       // AudioSource.PlayClipAtPoint(buttonSound, transform.position);
        settingsPanel.SetActive(true);
        Time.timeScale =0;
    }

    public void closeSettings()
    {
        AudioSource.PlayClipAtPoint(LevelController.current.buttonSound, transform.position);
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void loadCHooseLvlScene()
    {
        StartCoroutine(loadChoose());
    }

    IEnumerator loadChoose()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("ChooseLevelScene");
    }

    public void loadMenu()
    {
        AudioSource.PlayClipAtPoint(LevelController.current.buttonSound, transform.position);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void loadWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void offSound()
    {
        LevelController.current.soundOn = !LevelController.current.soundOn;
        if (LevelController.current.soundOn) sound.GetComponent<Image>().sprite = onSound;
        else sound.GetComponent<Image>().sprite = offsound;
    }

    public void offMusic()
    {
        LevelController.current.musicOn = !LevelController.current.musicOn;
        if (LevelController.current.musicOn) music.GetComponent<Image>().sprite = onMusic;
        else music.GetComponent<Image>().sprite = offmusic;
    }

    
}
