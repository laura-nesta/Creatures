using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public int nbAiles = 2;
    public int nbQueues = 1;
    Vector3 target;

//////////////////  CREATURE  /////////////////////
    AileDeFou [] tabAiles;
    Queue [] tabQueue;
    Oiseau corps;
    GameObject m_Creature;
    Rigidbody r_Creature;
    
    ADN genes;
    float aileg, ailed, queue, poids;

    Vector3 [] v_aile;

    public float timer = 0f;
    public float waitTime = 5f;

    void Awake() {
        tabAiles = new AileDeFou[nbAiles];
        tabQueue = new Queue[nbQueues];
        
        genes = gameObject.AddComponent<ADN>();
        r_Creature = GetComponent<Rigidbody>();

        tabAiles = GetComponentsInChildren<AileDeFou>();
        tabQueue = GetComponentsInChildren<Queue>();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        // INITIALISATION DES COMPOSANTS DE LA CREATURE (avec les gènes)
       
        aileg = genes.getAileG();
        ailed = genes.getAileD();
        queue = genes.getQueue();
        poids = genes.getPoids();

        r_Creature.mass = poids;

        foreach(AileDeFou adf in tabAiles){            
            if(adf.isAile_G){
                adf.getAile().transform.localScale *= aileg;
            }
            else{
                adf.getAile().transform.localScale *= ailed;
            }
        }
        
        foreach(Queue q in tabQueue){            
          
            q.transform.localScale *= queue;
            
        }
       
    }

    void Update() {
        Debug.Log(tabAiles[0].getAile().transform.localScale);
    }


    bool estArrive() {
        //if(m_Test.position == target) return true;

        return false;
    }
}
