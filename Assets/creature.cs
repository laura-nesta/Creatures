using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    public float Vitesse_Marche = 100.0f;
    public float Acceleration = 5.0f;
    public float Vitesse_Vol = 70.0f;
    //Animation animations;
    // Start is called before the first frame update
    void Start()
    {
        //animations= gameObject.GetComponent<Animation>();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.forward*Time.deltaTime*Vitesse_Marche);
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.back*Time.deltaTime*Vitesse_Marche);
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left*Time.deltaTime*Vitesse_Marche);
        }

        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right*Time.deltaTime*Vitesse_Marche);
        }
        /*
        if(Input.GetKeyDown(KeyCode.Space)){
            transform.Translate(Vector3.left*Time.deltaTime*Vitesse);
        }*/
        if (Input.GetKey("space"))
        {
            transform.Translate(Vector3.up*Time.deltaTime*Vitesse_Vol);
        }
        //appeusenteure (deso je sais pas l'ecrire x) )
       // transform.Translate(0,-0.1f,0);

    }
}
