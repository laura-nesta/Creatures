using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    public float Vitesse = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive!");
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        //transform.Position(-400, 252.5, 0);
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
    }
}
