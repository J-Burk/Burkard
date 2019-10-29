using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject Item;
    public string Type;
    public Sprite Icon;
    public Sprite IconLeer;
    public int ID;
    public bool leer;
    public Transform SlotPosition;

    GameObject Waffenslot;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        BenutzeItem();
    }

    void Start()
    {
        SlotPosition = transform.GetChild(0);
        SlotPosition.GetComponent<Image>().sprite = IconLeer;
        Waffenslot = GameObject.FindWithTag("Waffenslot");
    }


    void Update()
    {

    }

    public void UpdateSlot()
    {
        SlotPosition.GetComponent<Image>().sprite = Icon;
    }

    public void BenutzeItem()
    {
        if (Type == "Schwert")
        {
            Debug.Log("Benutze Waffe Schwert");
            ItemScript itemScript = GetComponent<ItemScript>();
            Item.GetComponent<ItemScript>().SchwertNutzen(gameObject);
            
            // Waffenwechsel
            //if (itemScript.angelegterStab)
            //{
            //    leer = true;
            //    SlotPosition.GetComponent<Image>().sprite = IconLeer;
            //    Item = null;
            //    GetComponent<InventarScript>().AddItem(itemScript.Stab, itemScript.ID, itemScript.Type, itemScript.Icon);
            //}
            //else
            //{
            //    leer = true;
            //    SlotPosition.GetComponent<Image>().sprite = IconLeer;
            //    Item = null;

            //}
        }

        if (Type == "Stab")
        {
            Debug.Log("Benutze Waffe Stab");
            Item.GetComponent<ItemScript>().StabNutzen(gameObject);
            //leer = true;
            //SlotPosition.GetComponent<Image>().sprite = IconLeer;
            //Item = null;
        }

        if (Type == "Pilz")
        {
            Debug.Log("Benutze Pilz");
            Item.GetComponent<ItemScript>().PilzNutzen(gameObject);
            leer = true;
            SlotPosition.GetComponent<Image>().sprite = IconLeer;
            Item = null;
        }

        if (Type == "Fleisch")
        {
            Debug.Log("Benutze Fleisch");
            Item.GetComponent<ItemScript>().FleischNutzen(gameObject);
            leer = true;
            SlotPosition.GetComponent<Image>().sprite = IconLeer;
            Item = null;
        }

        if (Type == "Trank")
        {
            Debug.Log("Benutze Trank");
            Item.GetComponent<ItemScript>().TrankNutzen(gameObject);
            leer = true;
            SlotPosition.GetComponent<Image>().sprite = IconLeer;
            Item = null;
        }

        if (Type == "Ulttrank")
        {
            Debug.Log("Benutze Ulttrank");
            Item.GetComponent<ItemScript>().UlttrankNutzen(gameObject);
        }

        //if (Type == "Item")
        //{
        //    Debug.Log("Item frei geben ....");
        //    Item.GetComponent<ItemScript>().ItemWegwerfen();
        //    leer = true;
        //    SlotPosition.GetComponent<Image>().sprite = IconLeer;
        //    Item = null;
        //}

    }
}
