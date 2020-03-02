using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Image Lebensbalken;
    public Text Lebenspunkte;

    public Image Hungerbalken;
    public Text Hungerpunkte;

    float maxLeben;
    float maxHunger;

    GameObject player;

    float leben;
    float hunger;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        maxLeben = player.GetComponent<LebensScript>().maxLeben;
        maxHunger = player.GetComponent<LebensScript>().maxHunger;
        leben = player.GetComponent<LebensScript>().leben;
        hunger = player.GetComponent<LebensScript>().hunger; 
        UpdateHUD();


    }

    void UpdateHUD()
    {
        Lebensbalken.fillAmount = leben / maxLeben;
        Lebenspunkte.text = leben.ToString();

        Hungerbalken.fillAmount = hunger / maxHunger;
        Hungerpunkte.text = hunger.ToString();

    }
}
