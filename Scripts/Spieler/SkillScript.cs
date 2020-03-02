using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillScript : MonoBehaviour
{
    Sprite Icon;
    GameObject MagieSlot;
    GameObject KriegerSlot;
    public bool Schwert;
    public bool Stab;
    GameObject player;

    public float entfernung;
    public float maxEntfernung;
    RaycastHit hit;
    public int schaden;
    GameObject Camera;
    private AudioSource AudioSource;
    public float hunger;

    [SerializeField] private AudioClip Stabattack;           
    [SerializeField] private AudioClip Schwertattack;
    [SerializeField] private AudioClip heal;
    [SerializeField] private AudioClip use;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        MagieSlot = GameObject.FindWithTag("Magieslot");
        KriegerSlot = GameObject.FindWithTag("Kriegerslot");
        Camera = GameObject.FindWithTag("MainCamera");
        Stab = false;
        Schwert = false;
        MagieSlot.SetActive(false);
        KriegerSlot.SetActive(false);

        AudioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        hunger = GetComponent<LebensScript>().hunger;


        if (Stab)
        {
            maxEntfernung = 7f;
            MagieSlot.SetActive(true);
            KriegerSlot.SetActive(false);
        }
        else if (Schwert)
        {
            maxEntfernung = 5f;
            MagieSlot.SetActive(false);
            KriegerSlot.SetActive(true);
        }
        else
        {
            maxEntfernung = 3f;
            MagieSlot.SetActive(false);
            KriegerSlot.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Autohit();
        }

        if (Schwert)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && (hunger >= 10))
            {
                KleinerHeal();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && (hunger >= 20))
            {
                GroserHeal();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) && (hunger >= 10))
            {
                Schwerthieb();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) && (hunger >= 10))
            {
                Kraftschlag();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) && (hunger >= 10))
            {
                Siebenwege();
            }
        }


        if (Stab)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && (hunger >= 10))
            {
                KleinerHeal();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && (hunger >= 20))
            {
                GroserHeal();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) && (hunger >= 10))
            {
                Feuerball();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) && (hunger >= 10))
            {
                Wasserball();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) && (hunger >= 10))
            {
                Eruption();
            }
        }
    }

    // Allgemeine Attacken
    void Autohit()
    {
        schaden = 20;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            entfernung = hit.distance;
            if (entfernung < maxEntfernung)
            {
                hit.transform.SendMessage("BerechneSchaden", schaden);
                AudioSource.clip = use;
                AudioSource.Play();

            }
        }

    }


    void KleinerHeal()
    {
        player.GetComponent<LebensScript>().leben += 50;
        player.GetComponent<LebensScript>().hunger -= 10;
        AudioSource.clip = heal;
        AudioSource.Play();
    }

    void GroserHeal()
    {
        player.GetComponent<LebensScript>().leben += 200;
        player.GetComponent<LebensScript>().hunger -= 20;
        AudioSource.clip = heal;
        AudioSource.Play();
    }

    // Schwertskills
    void Schwerthieb()
    {
        schaden = 30;
        player.GetComponent<LebensScript>().hunger -= 30;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            entfernung = hit.distance;
            if (entfernung < maxEntfernung)
            {
                hit.transform.SendMessage("BerechneSchaden", schaden);
                AudioSource.clip = Schwertattack;
                AudioSource.Play();
            }
        }
    }


    void Kraftschlag()
    {
        schaden = 50;
        player.GetComponent<LebensScript>().hunger -= 10;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            entfernung = hit.distance;
            if (entfernung < maxEntfernung)
            {
                hit.transform.SendMessage("BerechneSchaden", schaden);
                AudioSource.clip = Schwertattack;
                AudioSource.Play();
            }
        }

    }

    void Siebenwege()
    {
        schaden = 100;
        player.GetComponent<LebensScript>().hunger -= 10;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            entfernung = hit.distance;
            if (entfernung < maxEntfernung)
            {
                hit.transform.SendMessage("BerechneSchaden", schaden);
                AudioSource.clip = Schwertattack;
                AudioSource.Play();
            }
        }

    }

    // Magieattacken
    void Feuerball()
    {
        schaden = 30;
        player.GetComponent<LebensScript>().hunger -= 10;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            entfernung = hit.distance;
            if (entfernung < maxEntfernung)
            {
                hit.transform.SendMessage("BerechneSchaden", schaden);
                AudioSource.clip = Stabattack;
                AudioSource.Play();
            }
        }

    }

    void Wasserball()
    {
        schaden = 30;
        player.GetComponent<LebensScript>().hunger -= 10;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            entfernung = hit.distance;
            if (entfernung < maxEntfernung)
            {
                hit.transform.SendMessage("BerechneSchaden", schaden);
                AudioSource.clip = Stabattack;
                AudioSource.Play();
                hunger -= 10;
            }
        }

    }

    void Eruption()
    {
        schaden = 100;
        player.GetComponent<LebensScript>().hunger -= 30;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            entfernung = hit.distance;
            if (entfernung < maxEntfernung)
            {
                hit.transform.SendMessage("BerechneSchaden", schaden);
                AudioSource.clip = Stabattack;
                AudioSource.Play();
                hunger -= 10;
            }
        }

    }

}
