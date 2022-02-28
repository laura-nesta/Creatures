using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    public float Vitesse = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.forward*Time.deltaTime*Vitesse);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.back*Time.deltaTime*Vitesse);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left*Time.deltaTime*Vitesse);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right*Time.deltaTime*Vitesse);
        }
        /*
        if(Input.GetKeyDown(KeyCode.Space)){
            transform.Translate(Vector3.left*Time.deltaTime*Vitesse);
        }*/
        if (Input.GetKey("space"))
        {
            transform.Translate(0,0.50f,0);
        }
        //appeusenteure (deso je sais pas l'ecrire x) )
       // transform.Translate(0,-0.1f,0);
    }
}
