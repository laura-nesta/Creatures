using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queue : MonoBehaviour
{
    public GameObject maCreature;
    int rotationScale = 1;
    int valRotaion = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((valRotaion >= 35 && rotationScale > 0) || 
         (valRotaion <= -35 && rotationScale < 0))
                rotationScale = -rotationScale;
        if(Input.GetKey("space")){
            transform.Rotate(0,0,rotationScale);
            valRotaion += rotationScale;
            if(rotationScale > 0){
               maCreature.transform.Translate(0,0.25f,0); 
               
            }
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Rotate(0,0,(float)0.5*rotationScale);
            valRotaion += rotationScale;
            if(rotationScale > 0){
                 maCreature.transform.Translate(0,0,0.25f);
                 maCreature.transform.Translate(-0.5f,0,0);
                 maCreature.transform.Rotate(0,0,-0.01f);
            }
        }
    }
}
