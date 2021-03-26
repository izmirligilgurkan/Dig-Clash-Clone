using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WinTrigger : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.GetComponent<CameraFollow>().WinCamera();
            var allies= GameObject.FindGameObjectsWithTag("Ally");
            foreach (var ally in allies)
            {
                ally.GetComponent<AllyAI>().win = true;
                ally.GetComponent<NavMeshAgent>().SetDestination(new Vector3(transform.position.x, 0, transform.position.z + 10));
            }
            
        }
        
    }
}
