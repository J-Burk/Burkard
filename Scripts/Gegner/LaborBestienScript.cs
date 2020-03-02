using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaborBestienScript : MonoBehaviour
{
    Animator animator;
    public int leben;
    public bool die;
    public bool walk;
    public bool hit;
    bool BewegungFrei;

    GameObject player;

    void Start()
    {
        leben = 10000;

        animator = gameObject.GetComponent<Animator>();
        walk = false;
        die = false;
        hit = false;

        BewegungFrei = true;

        player = GameObject.FindWithTag("Player");

    }


    void Update()
    {
        animator.SetBool("die", die);
        animator.SetBool("walk", walk);
        animator.SetBool("hit", hit);

        Distanzpruefer();
        //Invoke("Distanzpruefer", 2);


        if (leben <= 0)
        {
            Invoke("Sterben", 5);
            die = true;
        }

    }

    void Distanzpruefer()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 10 && Vector3.Distance(player.transform.position, transform.position) > 5 && !die)
        {
            NavMeshAgent Agent = GetComponent<NavMeshAgent>();
            Agent.SetDestination(player.transform.position);
            walk = true;
        }
        else
        {
            walk = false;
        }

        if (Vector3.Distance(player.transform.position, transform.position) <= 5 && BewegungFrei && !die)
        {
            Schlag();
        }
        else
        {
            hit = false;
        }

    }

    void BerechneSchaden(int schaden)
    {
        leben -= schaden;
    }

    void Sterben()
    {
        Destroy(gameObject);
    }

    void Schlag()
    {
        hit = true;
        if (BewegungFrei)
        {
            player.GetComponent<LebensScript>().leben -= 10;
            BewegungFrei = false;
            Invoke("Ruecksetz", 3);
        }
    }

    void Ruecksetz()
    {
        BewegungFrei = true;
    }

}
