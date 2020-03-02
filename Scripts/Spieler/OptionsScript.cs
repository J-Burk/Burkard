using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    bool OptionenAktiv;
    public GameObject Optionen;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OptionenAktiv = !OptionenAktiv;
        }

        if (OptionenAktiv)
        {
            Optionen.SetActive(true);
        }
        else
        {
            Optionen.SetActive(false);
        }

    }

}
