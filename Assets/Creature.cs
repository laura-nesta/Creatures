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

    public GameObject  m_tabAiles;
    public GameObject m_tabQueues;
    GameObject m_Corps;
    GameObject m_Creature;
    Rigidbody r_Creature;

    public ADN genes;
    float aileg, ailed, queue, poids;

    Vector3 [] v_aile;
    Vector3 tmp_aile;

    public float timer = 0f;
    public float waitTime = 5f;

    void Awake() {
        tabAiles = new AileDeFou[nbAiles];
        tabQueue = new Queue[nbQueues];
        v_aile = new Vector3[nbAiles];
        tmp_aile = new Vector3();
    
        
        //m_tabAiles = new GameObject;
        //m_tabQueues = new GameObject[nbQueues];
        genes = new ADN(); 
        
        r_Creature = GetComponent<Rigidbody>();

        for(int i=0; i<nbAiles; i++) {
            tabAiles[i] = m_tabAiles.GetComponent<AileDeFou>();
        }

        for(int i=0; i<nbQueues; i++) {
            tabQueue[i] = m_tabQueues.GetComponent<Queue>();
        }
        
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

        for(int i=0; i<nbAiles; i++){
            v_aile[i] = tabAiles[i].getAile().transform.localScale;
            tmp_aile = v_aile[i];
            
            if(tabAiles[i].isAile_G){
                v_aile[i] *= aileg;
            }
            else{
                v_aile[i] *= ailed;
            }
        }
        
        for(int i=0; i<nbQueues; i++){
            tabQueue[i].transform.localScale *= queue;
        } 
    }

    void Update() {
        Debug.Log("here we gooooo");
    }


    bool estArrive() {
        //if(m_Test.position == target) return true;

        return false;
    }
}
