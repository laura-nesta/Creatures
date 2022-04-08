using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public int nbAiles = 2;
    Vector3 target;

    AileDeFou [] Ail;
    Rigidbody m_Test;

    public float timer = 0f;
    public float waitTime = 5f;


    // Start is called before the first frame update
    void Start()
    {
        m_Test = GetComponent<Rigidbody>();
            m_Test.drag = 1.20f;
    
        target = new Vector3(0, 1, 5);
    }

 
    void Update() {


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
