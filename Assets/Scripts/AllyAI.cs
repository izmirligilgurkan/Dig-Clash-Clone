using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class AllyAI : MonoBehaviour
{

    private GameObject player = null;

    private NavMeshAgent agent;

    public bool win = false;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null && !win)
        {
            agent.SetDestination(new Vector3(player.transform.position.x, 0, player.transform.position.z)-  
                                 (player.transform.position-transform.position).normalized*2f);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            GetComponent<MeshRenderer>().material.DOColor(Color.green, 0.1f);
            gameObject.tag = "Ally";
        }

        
    }
}
