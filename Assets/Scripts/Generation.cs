using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public const int nb_creatures = 100;
    public Creature[] creatures;
    public Creature finalCreature;
    public GameObject creaturePrefab;
    public bool isPlaying = false;

    public void launch(ADN[] genes = null)
    {
        isPlaying = true;
        creatures = new Creature[nb_creatures];
        if (genes == null)
        {
            for (int i = 0; i < nb_creatures; i++)
            {
                Creature creature = Instantiate(creaturePrefab, new Vector3(0, 50, 0), Quaternion.identity).GetComponent<Creature>();
                creature.transform.eulerAngles = new Vector3(0, 180, 0);
                creature.generateRandomGenes();
                creatures[i] = creature;
            }
        }
        else
        {
            for (int i = 0; i < nb_creatures; i++)
            {
                Creature creature = Instantiate(creaturePrefab, new Vector3(0, 50, 0), Quaternion.identity).GetComponent<Creature>();
                creature.transform.eulerAngles = new Vector3(0, 180, 0);
                creature.generateGenes(genes);
                creatures[i] = creature;
            }
        }
    }

    public void reset()
    {
        for (int i = 0; i < nb_creatures; i++)
        {
            Destroy(creatures[i].gameObject);
        }
        creatures = new Creature[nb_creatures];
        isPlaying = false;
    }

    public void FinDeSimulation(float ad, float ag, float q, float p)
    {
        Creature creature = Instantiate(creaturePrefab, new Vector3(20, 60, 30), Quaternion.identity).GetComponent<Creature>();
        creature.transform.eulerAngles = new Vector3(0, 180, 0);
        creature.setGenes(ad, ag, q, p);
        creature.modifCreature();
        creature.isAlive = false;

    }


    /*
    public void finDeSimulation(float ag, float ad, float q, float p)
    {
        finalCreature = new Creature();
        finalCreature.setGenes(ad, ag, q, p);
        finalCreature = Instantiate(creaturePrefab, new Vector3(0, 50, 0), Quaternion.identity).GetComponent<Creature>();
        finalCreature.modifCreature();
        finalCreature.isAlive = false;
    }*/
}
