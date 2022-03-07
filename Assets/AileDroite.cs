using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileDroite : MonoBehaviour
{
    public GameObject maCreature;
    public float Vitesse = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    int rotationScale = -1;
     int valRotaion = 0;
    // Update is called once per frame
    void Update()
    {
        if((valRotaion >= 46 && rotationScale > 0) || 
         (valRotaion <= -46 && rotationScale < 0))
                rotationScale = -rotationScale;
        //batement aile
        if(Input.GetKey("space")){
            transform.Rotate(rotationScale,0,0);
            valRotaion += rotationScale;
            if(rotationScale < 0){
               maCreature.transform.Translate(0,0.50f,0); 
               
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(rotationScale,0,0);
            valRotaion += rotationScale;
            if(rotationScale < 0){
                maCreature.transform.Translate(0,0,0.25f);
                maCreature.transform.Translate(0,0.25f,0);
                maCreature.transform.Rotate(0.1f,0,0);
            }
        }
    }
} 