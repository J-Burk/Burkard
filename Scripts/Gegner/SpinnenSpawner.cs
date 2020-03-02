using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnenSpawner : MonoBehaviour
{
    public GameObject Spinne;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject.Instantiate(Spinne, new Vector3(Random.Range(280, 380), 578, Random.Range(380, 480)), Quaternion.identity);
        }

    }


    void Update()
    {
    

    }
}
