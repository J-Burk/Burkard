using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventarScript : MonoBehaviour
{
    public bool InventarAktiv;
    public GameObject Inventar;

    public GameObject SlotContainer;
    int anzSlots;
    GameObject[] slot;

    void Start()
    {
        //Anzahl Slots auslesen
        anzSlots = SlotContainer.transform.childCount;

        // Array Slot initialisieren
        slot = new GameObject[anzSlots];



        for (int i = 0; i < anzSlots; i++)
        {
            // Array mit Slots füllen;
            slot[i] = SlotContainer.transform.GetChild(i).gameObject;

            //Wenn die Slots leer sind, Zustand "true" zuweisen
            if (slot[i].GetComponent<SlotScript>().Item == null)
            {
                slot[i].GetComponent<SlotScript>().leer = true;
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventarAktiv = !InventarAktiv;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (InventarAktiv)
        {
            Inventar.SetActive(true);

        }
        else
        {
            Inventar.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }

    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Schwert" || col.tag == "Stab" || col.tag == "Ulttrank" || col.tag == "Trank" || col.tag == "Pilz" || col.tag == "Fleisch")
        {
            GameObject abgeholteItem = col.gameObject;
            if (abgeholteItem.tag == "Waffe")
            {
                abgeholteItem.GetComponent<BoxCollider>().isTrigger = false;
            }

            ItemScript itemScript = abgeholteItem.GetComponent<ItemScript>();
            AddItem(abgeholteItem, itemScript.ID, itemScript.Type, itemScript.Icon);
        }
    }

    public void AddItem(GameObject abgeholteItem, int IDItem, string TypeItem, Sprite IconItem)
    {
        for (int i = 0; i < anzSlots; i++)
        {
            if (slot[i].GetComponent<SlotScript>().leer)
            {
                abgeholteItem.GetComponent<ItemScript>().Abgeholt = true;

                // Werte dem aktuellen Slot zuweisen
                slot[i].GetComponent<SlotScript>().Item = abgeholteItem;
                slot[i].GetComponent<SlotScript>().Type = TypeItem;
                slot[i].GetComponent<SlotScript>().ID = IDItem;
                slot[i].GetComponent<SlotScript>().Icon = IconItem;

                // Abgeholte Gameobjekt in aktuelle Slot verschieben (Parenting)
                abgeholteItem.transform.parent = slot[i].transform;
                abgeholteItem.SetActive(false);

                slot[i].GetComponent<SlotScript>().UpdateSlot();
                slot[i].GetComponent<SlotScript>().leer = false;
                return;
            }
        }
    }
}
