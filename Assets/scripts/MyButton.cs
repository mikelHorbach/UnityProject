using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyButton : MonoBehaviour
{
    public UnityEvent signalOnClick = new UnityEvent();
    public void _onClick()
    {
        this.signalOnClick.Invoke();
    }
    public void loadChooseLevel(int level)
    {
        SceneManager.LoadScene("ChooseLevelScene");
    }
}
