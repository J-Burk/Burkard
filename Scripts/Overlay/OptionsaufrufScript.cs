using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsaufrufScript : MonoBehaviour
{
    public void PlayOptionen()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayQuit()
    {
        Application.Quit();
    }
}
