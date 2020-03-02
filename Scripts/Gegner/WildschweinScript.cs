using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildschweinScript : MonoBehaviour
{
    public int leben;
    public GameObject Fleisch;
    Vector3 position;

    void Start()
    {
        leben = 10;
        position = gameObject.transform.position;
    }


    void Update()
    {
        if (leben <= 0)
        {
            Destroy(gameObject);
            GameObject.Instantiate(Fleisch, position, Random.rotation);
        }

    }

    void BerechneSchaden(int schaden)
    {
        leben -= schaden;
    }


}
