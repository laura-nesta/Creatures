using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    //////////////////  CREATURE  /////////////////////

    public Aile aileGauche;
    public Aile aileDroite;
    public Queue queueGameObject;
    public Corps corps;
    
    private ADN genes = new ADN();

    public bool isAlive = true;
    public bool isArrived = false;
    float timeScore = 30f;

    float variation = 0.4f; //pourcentage de variation sur les gênes parents

    void Start()
    {
        modifCreature();
    }

    private void Update()
    {
        if (isAlive && !isArrived) timeScore -= Time.deltaTime * 0.5f;
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

    public ADN getGene()
    {
        return genes;
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

    public float getFinalScore()
    {
        return timeScore + (isArrived ? 50f : 0f) + 20f * Mathf.Min(genes.getAileD(), genes.getAileG()) / Mathf.Max(genes.getAileD(), genes.getAileG());
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
    public void modifCreature() 
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

    public void generateGenes(ADN[] genes)
    {
        float tailleAileGauche = Mathf.Clamp(genes[Random.Range(0, genes.Length)].getAileG() * Random.Range(1f - variation, 1f + variation), 0f, 2f);
        float tailleAileDroite = Mathf.Clamp(genes[Random.Range(0, genes.Length)].getAileD() * Random.Range(1f - variation, 1f + variation), 0f, 2f);
        float tailleQueue = Mathf.Clamp(genes[Random.Range(0, genes.Length)].getQueue() * Random.Range(1f - variation, 1f + variation), 0f, 2f);
        float poids = Mathf.Clamp(genes[Random.Range(0, genes.Length)].getPoids() * Random.Range(1f - variation, 1f + variation), 0f, 2f);
        setGenes(tailleAileGauche, tailleAileDroite, tailleQueue, poids);
    }

    public void appliquerForce(Vector3 force)
    {
        if (isAlive)
            transform.localPosition += 0.01f * force;
    }

}
