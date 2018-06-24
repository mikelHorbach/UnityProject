using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour {

    void openDr1()
    {
        StartCoroutine(openDoor1());
    }

    IEnumerator openDoor1()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Level1");
    }

    void openDr2()
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
        if(this.transform.CompareTag("door2"))
        {
            openDr2();
        }
    }

    
}
