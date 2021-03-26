using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{
    public GameObject holePrefab;

    public Camera camera;
    public NavMeshAgent agent;
    public ParticleSystem destroyParticle;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        #if UNITY_EDITOR

        #region UnityEditorControls
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hitNav;
            Ray rayNav = camera.ScreenPointToRay(Input.mousePosition);
            int layerMaskNav = 1 << 8;
            if (Physics.Raycast(rayNav, out hitNav, Mathf.Infinity, layerMaskNav))
            {
                agent.SetDestination(hitNav.point);
                

            }
            int layerMask1 = 1 << 7;
            RaycastHit hit1;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit1, Mathf.Infinity, layerMask1))
            {
                
                if (hit1.collider.gameObject.CompareTag("Water"))
                {
                    //Destroy water and create borders
                    
                    int layerMask = 1 << 8;
            

                    RaycastHit hit;
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        var hole = Instantiate(holePrefab, hit.point, Quaternion.identity);
                        var particleEffect = Instantiate(destroyParticle, hit.point, Quaternion.Euler(-90, 0, 0));

                    }
                }

            }
            
        }
        

        #endregion
        
        #endif
        
        #if UNITY_IPHONE

        #region iOSControls
        if (Input.GetButton("Fire1") && Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            
            
            RaycastHit hitNav;
            Ray rayNav = camera.ScreenPointToRay(touch.position);
            int layerMaskNav = 1 << 8;
            if (Physics.Raycast(rayNav, out hitNav, Mathf.Infinity, layerMaskNav))
            {
                agent.SetDestination(hitNav.point);
                

            }
            int layerMask1 = 1 << 7;
            RaycastHit hit1;
            if (Physics.Raycast(camera.ScreenPointToRay(touch.position), out hit1, Mathf.Infinity, layerMask1))
            {
                
                if (hit1.collider.gameObject.CompareTag("Water"))
                {
                    //Destroy water and create borders
                    
                    int layerMask = 1 << 8;
            

                    RaycastHit hit;
                    Ray ray = camera.ScreenPointToRay(touch.position);
                    
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        var hole = Instantiate(holePrefab, hit.point, Quaternion.identity);
                        var particleEffect = Instantiate(destroyParticle, hit.point, Quaternion.Euler(-90, 0, 0));

                    }
                }

            }
            
        }
        

        #endregion
        
        #endif
        
    }
}
