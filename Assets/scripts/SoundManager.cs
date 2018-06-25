using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                  
    public AudioSource musicSource;                 
    public static SoundManager instance = null;                          

    void Awake()
    {
        efxSource.volume = 0.2f;
        if (instance == null)
            
            instance = this;
        
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;
        //Play the clip.
        efxSource.Play();
    }

    // used to stop playing music
    public void musicOn()
    {
        efxSource.volume = 0.2f;
        print(efxSource.volume);
    }

    public void musicOf()
    {
        efxSource.volume = 0;
        print(efxSource.volume);
    }

}