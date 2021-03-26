using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InvisDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Corner"))
        {
            other.gameObject.SetActive(false);
        }
    }
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Corner"))
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }
}
