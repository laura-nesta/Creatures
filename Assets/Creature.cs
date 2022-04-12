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
    Rigidbody r_Creature;
    
    ADN genes;
    float aileg, ailed, queue, poids;

    public float timer = 0f;
    public float waitTime = 5f;

    void Awake() 
    {
        tabAiles = new AileDeFou[nbAiles];
        tabQueue = new Queue[nbQueues];
        
        genes = gameObject.AddComponent<ADN>();
        r_Creature = GetComponent<Rigidbody>();

        tabAiles = GetComponentsInChildren<AileDeFou>();
        tabQueue = GetComponentsInChildren<Queue>();
    }


    void Start()
    {
        ModifCreature(12,1,1,1);
    }

    public void setPoids(float _poids) 
    {
        genes.setPoids(_poids);
    }

    public void setAileg(float _aileg) 
    {
        genes.setAileG(_aileg);
    }

    public void setAiled(float _ailed)
    {
        genes.setAileD(_ailed);
    }

    public void setQueue(float _queue) 
    {
         genes.setQueue(_queue);
    }

    public float getPoids() 
    {
        return poids = genes.getPoids();
    }

    public float getAileg() 
    {
        return aileg;
    }

    public float setAiled() 
    {
        return ailed;
    }

    public float getQueue() 
    {
        return queue;
    }

    public void setGenes(float _ailed, float _aileg, float _queue, float _poids) 
    {
        setAiled(_ailed);
        setAileg(_aileg);
        setPoids(_poids);
        setQueue(_queue);
    }

    void InitCreature() 
    {
        // INITIALISATION DES COMPOSANTS DE LA CREATURE (avec les gènes)
        
        aileg = genes.getAileG();
        ailed = genes.getAileD();
        queue = genes.getQueue();
        poids = genes.getPoids();

        r_Creature.mass = poids;
        foreach(AileDeFou adf in tabAiles){            
            if(adf.isAile_G){
                adf.getAile().transform.localScale *= 1;
            }
            else{
                adf.getAile().transform.localScale *= ailed;
            }
        }
        
        foreach(Queue q in tabQueue){            
            q.transform.localScale *= queue;
        }
    }

    void ModifCreature(float _ailed, float _aileg, float _queue, float _poids) 
    {
        setGenes(_aileg, _ailed, _queue, _poids);

        r_Creature.mass = _poids;
        foreach(AileDeFou adf in tabAiles){            
            if(adf.isAile_G){
                adf.getAile().transform.localScale *= _aileg;
            }
            else{
                adf.getAile().transform.localScale *= _ailed;
            }
        }
        
        foreach(Queue q in tabQueue){            
            q.transform.localScale *= _queue;
        }
    }


    bool estArrive() 
    {
        //if(m_Test.position == target) return true;

        return false;
    }
}
