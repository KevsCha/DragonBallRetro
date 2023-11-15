using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransition : MonoBehaviour
{
    [SerializeField] private Vector2 vel;
    private Vector2 Offset;
    private Material material;
    private void Awake() 
    {
        material = GetComponent<SpriteRenderer>().material;    
    }
    void Update()
    {
        Offset = vel * Time.deltaTime;
        material.mainTextureOffset += Offset;
    }
}
