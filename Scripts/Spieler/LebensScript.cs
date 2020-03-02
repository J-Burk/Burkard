using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LebensScript : MonoBehaviour
{
    public int maxLeben = 1000;
    public int maxHunger = 100;
    public int leben;
    public int hunger;

    bool hungern;

    void Start()
    {
        maxLeben = 1000;
        maxHunger = 100;
        leben = 50;
        hunger = 100;
        hungern = true;
    }


    void Update()
    {
        Verhungern();
        if (leben <= 0)
        {
            GetComponent<CharacterController>().transform.position = GameObject.FindWithTag("Respawn").transform.position;
            leben = maxLeben;
        }
    }

    void Verhungern()
    {
        if (hungern && hunger > 0)
        {
            hunger--;
            hungern = false;
            Invoke("Hungern", 3);
        }
        if (hungern && hunger <= 0 )
        {
            leben = leben - 100;
            hungern = false;
            Invoke("Hungern", 1);
        }
    }

    void Hungern()
    {
        hungern = true;
    }

}
