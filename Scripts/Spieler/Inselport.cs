using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inselport : MonoBehaviour
{
    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            player.GetComponent<CharacterController>().enabled = false;

            player.transform.position = GameObject.FindWithTag("Ausgang").transform.position;

            player.GetComponent<CharacterController>().enabled = true;

            //Debug.Log(GameObject.FindWithTag("Ausgang").transform.position);
            //Debug.Log(player.transform.position);
        }
    }
}
