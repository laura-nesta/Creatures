using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float Vitesse=100.0f;

    void Start()
    {
        gameObject.GetComponent<Renderer>.material.color=Color.purple;
    }
}

void Update()
{
    if(Input.GetKey("r"))
    {
        transform.Translate(Random.Range(220,-220),0,Random.Range(-400,400));
    }
}