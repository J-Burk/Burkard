using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayOptionen()
    {
        SceneManager.LoadScene(2);
    }

    public void PlaySpiel()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayQuit()
    {
        Application.Quit();
    }
}
