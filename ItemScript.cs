using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int ID;
    public string Type;
    public Sprite Icon;
    public bool Abgeholt;

    public bool AktWaffe;
    public GameObject AktSlot;

    GameObject player;
    public GameObject angelegtesSchwert;
    public GameObject angelegterStab;
    public GameObject Schwert;
    public GameObject Stab;

    public bool Ulttrankrdy;

    GameObject Waffenslot;


    void Start()
    {
        Type = gameObject.tag;
        AktWaffe = false;

        player = GameObject.FindWithTag("Player");
        Waffenslot = GameObject.FindWithTag("Waffenslot");

        Ulttrankrdy = true;
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    AktWaffe = false;
        //}
        //if (AktWaffe == false && Abgeholt)
        //{
        //    gameObject.transform.parent = AktSlot.transform;
        //    gameObject.SetActive(false);
        //}
    }

    public void SchwertNutzen(GameObject aktSlot)
    {
        angelegtesSchwert.SetActive(true);
        angelegterStab.SetActive(false);
        player.GetComponent<SkillScript>().Schwert = true;
        player.GetComponent<SkillScript>().Stab = false;
    }

    public void StabNutzen(GameObject aktSlot)
    {
        angelegterStab.SetActive(true);
        angelegtesSchwert.SetActive(false);
        player.GetComponent<SkillScript>().Schwert = false;
        player.GetComponent<SkillScript>().Stab = true;
    }



    public void PilzNutzen(GameObject aktSlot)
    {
        gameObject.transform.parent = null;
        gameObject.SetActive(true);
        Destroy(gameObject);
        if ((player.GetComponent<LebensScript>().hunger + 25) <= player.GetComponent<LebensScript>().maxHunger)
        {
            player.GetComponent<LebensScript>().hunger += 25;
        }
        else
        {
           player.GetComponent<LebensScript>().hunger = player.GetComponent<LebensScript>().maxHunger;
           if (player.GetComponent<LebensScript>().leben + 10 <= player.GetComponent<LebensScript>().maxLeben)
            {
                player.GetComponent<LebensScript>().leben += 10;
            }
            else
            {
                player.GetComponent<LebensScript>().leben = player.GetComponent<LebensScript>().maxLeben;

            }
        }

    }

    public void FleischNutzen(GameObject aktSlot)
    {
        gameObject.transform.parent = null;
        gameObject.SetActive(true);
        Destroy(gameObject);
        if ((player.GetComponent<LebensScript>().hunger + 50) <= player.GetComponent<LebensScript>().maxHunger)
        {
            player.GetComponent<LebensScript>().hunger += 50;
        }
        else
        {
            player.GetComponent<LebensScript>().hunger = player.GetComponent<LebensScript>().maxHunger;
            if (player.GetComponent<LebensScript>().leben + 20 <= player.GetComponent<LebensScript>().maxLeben)
            {
                player.GetComponent<LebensScript>().leben += 20;
            }
            else
            {
                player.GetComponent<LebensScript>().leben = player.GetComponent<LebensScript>().maxLeben;

            }
        }
    }

    public void TrankNutzen(GameObject aktSlot)
    {
        gameObject.transform.parent = null;
        gameObject.SetActive(true);
        Destroy(gameObject);
        if (player.GetComponent<LebensScript>().leben + 500 <= player.GetComponent<LebensScript>().maxLeben)
        {
            player.GetComponent<LebensScript>().leben += 500;
        }
        else
        {
            player.GetComponent<LebensScript>().leben = player.GetComponent<LebensScript>().maxLeben;

        }
    }

    public void UlttrankNutzen(GameObject aktSlot)
    {
        if (Ulttrankrdy)
        {
            if (player.GetComponent<LebensScript>().leben + 500 <= player.GetComponent<LebensScript>().maxLeben)
            {
                player.GetComponent<LebensScript>().leben += 500;
            }
            else
            {
                player.GetComponent<LebensScript>().leben = player.GetComponent<LebensScript>().maxLeben;

            }
            Ulttrankrdy = false;
            Invoke("Ulttrankreset", 10);
        }
    }

    public void Ulttrankreset()
    {
        Debug.Log("Ulttrank wird zurück gesetzt");
        Ulttrankrdy = true;
    }

}
