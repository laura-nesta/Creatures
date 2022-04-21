using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aile : MonoBehaviour
{
    Rigidbody r_Aile;
    public bool isAile_G;

    float angle = 0.0f;
    Vector3 v;

    Vector3 m_StartPos;

    float coefPortance = 1.0f;
    Vector3 portance, trainee, traction;

    // Start is called before the first frame update
    void Start()
    {
        m_StartPos = transform.position;

        r_Aile = GetComponent<Rigidbody>();
            r_Aile.drag = 1.2f;
        
        portance = new Vector3(0.0f, coefPortance, 0.0f);
        trainee  = new Vector3(-1.0f,0.0f,0.0f);
        traction = new Vector3(2.0f,0.0f,0.0f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAile_G) {
            v = new Vector3(Mathf.Sin(angle), 0, 0);
            angle += 0.1f;
        }
        else {
            v = new Vector3(-Mathf.Sin(angle), 0, 0);
            angle += 0.1f;
        }
            
            r_Aile.AddTorque(v, ForceMode.VelocityChange);
            r_Aile.AddForce(portance, ForceMode.Impulse);

            r_Aile.AddForce(trainee, ForceMode.Impulse);
            r_Aile.AddForce(traction, ForceMode.Acceleration);
    }

    public Rigidbody getAile() {
        return r_Aile;
    }
}
