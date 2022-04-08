using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int nbAiles = 2;
    Vector3 m_StartPos, m_StartForce;

    Vector3 target;
    Vector3 m_NewForce;
    Rigidbody m_Test;
    public Aile [] a = new Aile[2];
    Vector3 portance, trainee, traction;
    float coefPortance = 1f;
    float coefTrainee = 1f;
    float coefTraction = 1f;

    // Start is called before the first frame update
    async void Start()
    {
        m_Test = GetComponent<Rigidbody>();
        
        m_NewForce = new Vector3(0.0f, 1.0f, 0.0f);

        portance = new Vector3(0.0f, 0.1f, 0.0f);
        trainee  = new Vector3(0.0f,0.0f, -0.1f);
        traction = new Vector3(0.0f,0.0f, 0.2f);

        m_StartPos = transform.position;
        m_StartForce = m_Test.transform.position;

        m_Test.drag = 1.20f;
        /*m_Test.AddForce(trainee, ForceMode.Impulse);
        m_Test.AddForce(traction, ForceMode.Acceleration); */
        
        for(int i=0; i<nbAiles; i++) m_Test.mass += a[i].m_Aile.mass ;

        target = new Vector3(0, 1, 5);
        
    }

    public float timer = 0f;
    public float waitTime = 5f;

    void Update() {

            a[0].tt();
            a[1].tt2();
            timer += Time.deltaTime;

    }
    // Update is called once per frame
    void FixedUpdate()
    { 
        
    }


    bool estArrive() {
        if(m_Test.position == target) return true;

        return false;
    }
}
