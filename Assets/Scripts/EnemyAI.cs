using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    private GameObject ally = null;
    private NavMeshAgent agent;

    private GameObject deathParticlePrefab;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        deathParticlePrefab = Resources.Load("DeathParticle", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ally != null)
        {
            agent.SetDestination(new Vector3(ally.transform.position.x, 0, ally.transform.position.z));
            if ((transform.position-ally.transform.position).magnitude<=1f)
            {
                StartCoroutine(DestroyAlly());
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ally"))
        {
            //ally = other.gameObject;


        }
        if (other.gameObject.CompareTag("Player"))
        {
            var allies= GameObject.FindGameObjectsWithTag("Ally");
            List<GameObject> allyList = allies.OrderBy(gameObject => (gameObject.transform.position-transform.position).magnitude).ToList();
            if (allyList.Count > 0)
            {
                ally = allyList[0];
            }
            else
            {
                ally = other.gameObject;
            }
        }

        
    }

    IEnumerator DestroyAlly()
    {
        Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        ally.SetActive(false);
        yield return new WaitForSeconds(0f);
        gameObject.SetActive(false);
        
    }

    
}
