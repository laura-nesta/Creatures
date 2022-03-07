using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileGauche : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
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
            transform.Rotate(rotationScale,0,0);
            valRotaion += rotationScale;
            //transform.Rotate(-rotationScale,0,0);
            //print(gameObject.transform.localRotation.x);
            //print(gameObject.transform.localRotation.x);
        }
    }
}