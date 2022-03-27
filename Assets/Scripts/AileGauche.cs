using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileGauche : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            transform.Rotate(2,0,0);
            //transform.Rotate(-2,0,0);

        }
    }
}
