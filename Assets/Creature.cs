using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public const int nbAiles = 2;
    public const int nbQueues = 1;
    Vector3 target;

//////////////////  CREATURE  /////////////////////
    public AileDeFou [] tabAiles;
    public Queue [] tabQueue;
    public Oiseau corps;
    GameObject m_Creature;
    Rigidbody r_Creature;

    public ADN genes;
    float aileg, ailed, queue;

    public float timer = 0f;
    public float waitTime = 5f;


    // Start is called before the first frame update
    void Start()
    {
        tabAiles = new AileDeFou[nbAiles];
        tabQueue = new Queue[nbQueues];
        genes = m_Creature.AddComponent<ADN>();
        r_Creature = GetComponent<Rigidbody>();
        //corps = new Oiseau();
        //genes = new ADN();
        
        // INITIALISATION DES COMPOSANTS DE LA CREATURE (avec les gènes)
       
    }

    void Update() {
        //r_Creature.mass = genes.getPoids();
        aileg = genes.getAileG();
        ailed = genes.getAileD();
        queue = genes.getQueue();
        for(int i=0; i<nbAiles; i++){
            if(tabAiles[i].isAile_G){
                tabAiles[i].getAile().transform.localScale = new Vector3(aileg, aileg, aileg);
            }
            else{
                tabAiles[i].getAile().transform.localScale = new Vector3(ailed, ailed, ailed);
            }
        }

        for(int i=0; i<nbQueues; i++){
            tabQueue[i].transform.localScale = new Vector3(queue, queue, queue);
        }
    }


    bool estArrive() {
        //if(m_Test.position == target) return true;

        return false;
    }
}
