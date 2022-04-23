using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    private const int nb_creatures = 100;
    public Creature[] creatures;
    public GameObject creaturePrefab;

    // Start is called before the first frame update
    void Start()
    {
        creatures = new Creature[nb_creatures];
        for(int i = 0 ; i < nb_creatures; i++){
            Creature creature = Instantiate(creaturePrefab, new Vector3(0, 30, 0), Quaternion.identity).GetComponent<Creature>();
            creature.transform.eulerAngles = new Vector3(0, 180, 0);
            creature.generateRandomGenes();
            creatures[i] = creature;
        }
    }
}
