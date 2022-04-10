using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public int nbAiles = 2;
    public int nbQueues = 1;
    Vector3 target;

//////////////////  CREATURE  /////////////////////
    public AileDeFou [] tabAiles;
    public Queue [] tabQueue;
    public Oiseau corps;
    GameObject m_Creature;
    Rigidbody r_Creature;

    public ADN genes;
    float aileg, ailed, queue, poids;

    public float timer = 0f;
    public float waitTime = 5f;


    // Start is called before the first frame update
    void Start()
    {
        tabAiles = new AileDeFou[nbAiles];
        tabQueue = new Queue[nbQueues];
        //genes = m_Creature.AddComponent<ADN>();
        genes = new ADN(); 
        
        r_Creature = GetComponent<Rigidbody>();
    
        // INITIALISATION DES COMPOSANTS DE LA CREATURE (avec les gènes)
       
        aileg = genes.getAileG();
        ailed = genes.getAileD();
        queue = genes.getQueue();
        poids = genes.getPoids();

        r_Creature.mass = poids;
/*
        for(int i=0; i<nbAiles; i++){
            if(tabAiles[i].isAile_G){
                tabAiles[i].getAile().transform.localScale *= aileg;
            }
            else{
                tabAiles[i].getAile().transform.localScale *= ailed;
            }
        }

        for(int i=0; i<nbQueues; i++){
            tabQueue[i].transform.localScale *= queue;
        } */
    }

    void Update() {
        Debug.Log(ailed);
    }


    bool estArrive() {
        //if(m_Test.position == target) return true;

        return false;
    }
}
