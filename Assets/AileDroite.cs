using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileDroite : MonoBehaviour
{
    public float Vitesse = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            transform.Rotate(2,0,0);
        }
    }
}
