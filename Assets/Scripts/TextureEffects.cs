using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureEffects : MonoBehaviour
{
    public Material water;

    public Material waterCorner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        water.mainTextureOffset += Vector2.one * (Time.deltaTime * 0.1f);
        waterCorner.mainTextureOffset += Vector2.one * (Time.deltaTime * 0.1f);
    }
}
