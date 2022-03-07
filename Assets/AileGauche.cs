using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileGauche : MonoBehaviour
{
    public GameObject maCreature;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    int rotationScale = 1;
    int valRotaion = 0;
    int Vitesse = 10;
    // Update is called once per frame
    void Update()
    {
        //battement aile 
        if(Input.GetKey("space")){
            if(valRotaion == 46 || valRotaion == -46)
                rotationScale = -rotationScale;
            transform.Rotate(rotationScale,0,0);
            valRotaion += rotationScale;
            if(rotationScale > 0){
               maCreature.transform.Translate(0,0.50f,0); 
               
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                maCreature.transform.Translate(Vector3.right*Time.deltaTime*Vitesse);
                
            }
        }
    }
}