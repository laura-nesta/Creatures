using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oiseau : MonoBehaviour
{

    Rigidbody r_Body;


    Vector3 m_StartPos, m_StartForce;

    float coefPortance = 0.5f;
    float vitesse = 20.0f;
    Vector3 portance, trainee, traction;

    // Start is called before the first frame update
    void Start()
    {
        r_Body = GetComponent<Rigidbody>();
            r_Body.drag = 1.2f;
        
        //portance = new Vector3(0.0f, coefPortance, 0.0f);
        trainee  = new Vector3(-0.1f,0.0f,0.0f);
        traction = new Vector3(vitesse,0.0f,0.0f);
        
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        //r_Body.AddForce(portance, ForceMode.Impulse);

        r_Body.AddForce(trainee, ForceMode.Impulse);
        r_Body.AddForce(traction, ForceMode.Acceleration);
    }
}
