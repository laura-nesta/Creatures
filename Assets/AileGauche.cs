using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileGauche : MonoBehaviour
{
    public GameObject maCreature;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    int rotationScale = 1;
    int valRotaion = 0;
    // Update is called once per frame
    void Update()
    {
        //battement aile 
        if((valRotaion >= 46 && rotationScale > 0) || 
         (valRotaion <= -46 && rotationScale < 0))
                rotationScale = -rotationScale;
        if(Input.GetKey("space")){
            transform.Rotate(rotationScale,0,0);
            valRotaion += rotationScale;
            if(rotationScale > 0){
               maCreature.transform.Translate(0,0.50f,0); 
               
            }
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(rotationScale,0,0);
            valRotaion += rotationScale;
            if(rotationScale > 0){
                 maCreature.transform.Translate(0,0,-0.25f);
                 maCreature.transform.Translate(0,0.25f,0);
                 maCreature.transform.Rotate(-0.1f,0,0);
            }
        }
    
    }
}
