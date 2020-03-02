using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SteuerungsScript : MonoBehaviour
{
    public void PlaySpiel()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayQuit()
    {
        Application.Quit();
    }
}
