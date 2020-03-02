using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildschweinSpawner : MonoBehaviour
{
    public GameObject Wildschwein;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject.Instantiate(Wildschwein, new Vector3(Random.Range(240, 380), 575, Random.Range(800, 900)), Quaternion.identity);
        }

    }


    void Update()
    {
        
    }
}
