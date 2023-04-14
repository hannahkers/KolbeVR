using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{

    public void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log(Input.inputString);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;

    }

}
