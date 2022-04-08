using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{

    Rigidbody r_Queue;
    float angle = 0.0f;
    Vector3 v;

    Vector3 m_StartPos, m_StartForce;

    float coefPortance = 0.5f;
    Vector3 portance, trainee, traction;

    // Start is called before the first frame update
    void Start()
    {
        r_Queue = GetComponent<Rigidbody>();
            r_Queue.drag = 1.2f;
        
        portance = new Vector3(0.0f, 0.1f, 0.0f);
        trainee  = new Vector3(-0.1f,0.0f, 0.0f);
        traction = new Vector3(0.2f,0.0f, 0.0f);
        
    }

    void FixedUpdate()
    {
            v = new Vector3( Mathf.Sin(angle),0, 0);
            angle += 0.1f;
            r_Queue.AddTorque(v, ForceMode.VelocityChange);
            r_Queue.AddForce(portance, ForceMode.Impulse);

            r_Queue.AddForce(trainee, ForceMode.Impulse);
            r_Queue.AddForce(traction, ForceMode.Acceleration);
    }
}
