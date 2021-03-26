using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 camDist;

    private bool follow = true;
    // Start is called before the first frame update
    void Start()
    {
        camDist = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position - camDist, 1f*Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position,
                new Vector3(transform.position.x, transform.position.y, player.transform.position.z + camDist.z), 1f*Time.deltaTime);
            transform.LookAt(player.transform);
        }
        
    }

    public void WinCamera()
    {
        follow = false;
        
    }
}
