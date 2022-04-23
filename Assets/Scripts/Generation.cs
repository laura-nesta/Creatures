using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public const int nb_creatures = 100;
    public Creature[] creatures;
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
}
