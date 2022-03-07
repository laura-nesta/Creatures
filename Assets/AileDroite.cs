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

    int rotationScale = 2;
     int valRotaion = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            if(valRotaion == 46 || 
                valRotaion == -46)
                rotationScale = -rotationScale;
            transform.Rotate(-rotationScale,0,0);
            valRotaion += rotationScale;
            //transform.Rotate(rotationScale,0,0);
            //print(transform.localRotation.x);
        }
    }
} 