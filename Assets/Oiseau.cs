using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oiseau : MonoBehaviour
{
    public float taille;
    public float masse;

    public float vitesse; // d/t
    void Awake() {
        masse = 100f;
    }

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Renderer>().material.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
