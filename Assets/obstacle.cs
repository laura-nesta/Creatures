using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class obstacle : MonoBehaviour
{
    public float Vitesse=100.0f;
    public float Grow=10;
    public float Pas=50;
    public const float GROW_MAX=500;
    public const float GROW_MIN=10;
    public float Move_x=10;
    public float Move_z=10;
    /*public Vector3Int minposition=(-220,0,-400);
    public Vector3Int maxposition=(220,0,400);*/
    

    void Start()
    {
       gameObject.GetComponent<Renderer>().material.color=Color.black;
       /*transform.Translate(Random.Range(0, 50), 
                                            Random.Range(0, 0),
                                            Random.Range(0,50));*/
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if(Grow<=GROW_MAX)
            {
            //gets the local scale of an object
            Vector3 local = transform.localScale;

            //sets the local scale of an object
            transform.localScale = new Vector3(70,Grow,70);

            //gets the world scale of the object but is read only
            Vector3 world = transform.lossyScale;

            //transform.Translate(0,Grow,0);
                Grow+=Pas;
            }
        }

        if(Grow>=GROW_MAX)
        {

            //gets the local scale of an object
            Vector3 local = transform.localScale;

            //sets the local scale of an object
            transform.localScale = new Vector3(70,0,70);

            //gets the world scale of the object but is read only
            Vector3 world = transform.lossyScale;

            Grow=GROW_MIN;
        }   
    }
}