using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    Vector3 target;

    //////////////////  CREATURE  /////////////////////

    public Aile aileGauche;
    public Aile aileDroite;
    public Queue queueGameObject;
    public Corps corps;
    
    private ADN genes = new ADN();

    void Start()
    {
        modifCreature();
    }

//////////////////// GETTEURS & SETTEURS ////////////////////
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
        return genes.getPoids();
    }

    public float getAileg() 
    {
        return genes.getAileG();
    }

    public float setAiled() 
    {
        return genes.getAileD();
    }

    public float getQueue() 
    {
        return genes.getQueue();
    }

    public void setGenes(float _ailed, float _aileg, float _queue, float _poids) 
    {
        setAiled(_ailed);
        setAileg(_aileg);
        setPoids(_poids);
        setQueue(_queue);
        modifCreature();
    }


//////////////////// INITIALISATION ////////////////////

/*
    initialisation des composants de la créature avec des gènes par défaut
*/


/*
    Créature dont les gènes sont ceux passés en paramètre.
    Modifie les gènes d'une créature.
    => varier les morphologies des créatures
*/
    private void modifCreature() 
    {
        aileDroite.setSize(genes.getAileD());
        aileGauche.setSize(genes.getAileG());
        queueGameObject.setSize(genes.getQueue());
        corps.setPoids(genes.getPoids());
    }

    public void generateRandomGenes()
    {
        float tailleAileGauche = Random.Range(0f, 2f);
        float tailleAileDroite = Random.Range(0f, 2f);
        float tailleQueue = Random.Range(0f, 2f);
        float poids = Random.Range(0f, 2f);
        setGenes(tailleAileGauche, tailleAileDroite, tailleQueue, poids);
    }

    public void appliquerForce(Vector3 force)
    {
        transform.localPosition += 0.01f * force;
    }
    bool estArrive() 
    {
        //if(m_Test.position == target) return true;

        return false;
    }
}
