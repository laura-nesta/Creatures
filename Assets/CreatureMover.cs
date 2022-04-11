using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover: MonoBehaviour
{
    public float Max_Vitesse = 100.0f; //Vitesse maximale pour un oiseau
    public float Acceleration = 2.0f;
    
    //private Rigidbody m_rigidbody;
    private Vector3 mouvement;
    private float TimeDirectionChange;

    //Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        //m_rigidbody=GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void Update()
    {
        //Va modifier la direction de l'oiseau pour chaque frame
        TimeDirectionChange -= Time.deltaTime;
        if(TimeDirectionChange<=0)
        {
            mouvement = new Vector3(Random.Range(-450,-250), Random.Range(256,356), Random.Range(-400,400));
        }

        TimeDirectionChange += Acceleration;
    }
    
    //Si un oiseau rentre en collision avec l'obstacle, il change de direction
    void OnCollision3D(Collision collision)
    {
        mouvement = -mouvement;
    }

    void FixedUpdate()
    {
        //Appliquer une force à ce Rigidbody en direction du GameObject
        //m_rigidbody.AddForce(mouvement*Max_Vitesse);
    }
}