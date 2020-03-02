using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RüstungsInventarScript : MonoBehaviour
{
    bool RüstunginventarAktiv;
    public GameObject Rüstungsinventar;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RüstunginventarAktiv = !RüstunginventarAktiv;
        }

        if (RüstunginventarAktiv)
        {
            Rüstungsinventar.SetActive(true);
        }
        else
        {
            Rüstungsinventar.SetActive(false);
        }

    }
}
