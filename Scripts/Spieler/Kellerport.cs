using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kellerport : MonoBehaviour
{
    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            player.GetComponent<CharacterController>().enabled = false;

            player.transform.position = GameObject.FindWithTag("Eingang").transform.position;

            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
