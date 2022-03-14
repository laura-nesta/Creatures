using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aile : MonoBehaviour
{
    public float Vitesse;
    public int rotationScale;
    public int valRotation;
    // Start is called before the first frame update
    void Start()
    {
        valRotation = 0;
        Vitesse = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if((valRotation >= 46 && rotationScale > 0) || 
         (valRotation <= -46 && rotationScale < 0))
                rotationScale = -rotationScale;

        //batements ailes
        if(Input.GetKey("space")){
            transform.Rotate(rotationScale,0,0);
            valRotation += rotationScale;
        }
    }
} 