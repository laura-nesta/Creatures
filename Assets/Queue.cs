using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
A FAIRE:
    - faire les getteurs et les setteurs ? 
    - coder les fonctions vides
    - réfléchir aux autres fonctionnalités possibles

*/

public class Queue : MonoBehaviour
{
    //public GameObject maCreature;
    int rotationScale;
    int valRotation;
    
    // Start is called before the first frame update
    void Awake()
    {
        rotationScale = 1;
        valRotation = 0;
    }

    void Start() {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void Bouger() {
        if((valRotation >= 35 && rotationScale > 0) || 
         (valRotation <= -35 && rotationScale < 0))
                rotationScale = -rotationScale;

        transform.Rotate(0,0,rotationScale);
        valRotation += rotationScale;
    }

}
