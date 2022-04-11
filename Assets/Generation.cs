using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
 
public class Generation : MonoBehaviour
{
    public int populationTaille = 10;

    public GameObject m_creature;

    public float populationEsperance=6.0f;

    public List<GameObject> population;

    public int mutationRate; // Chance of a mutation occuring, 0 - 100%
 
    private int currentGeneration = 1;

    private float timeleft;
 
    // Start is called before the first frame update
    void Start()
    {
        // Initialise une population aleatoire
        Initialisation();
        
        //Pour chaque espérance de vie d'une population, coupler une nouvelle génération, répéter toujours
        InvokeRepeating("Couplage Population", populationEsperance, populationEsperance);

        //On modifie timeleft pour le compteur
        timeleft=populationEsperance;
    }
 
    // Update is called once per frame
    void Update()
    {
        timeleft-=Time.deltaTime; //compteur
    }
 
    /**
     * Initialises the population
     */
    private void Initialisation()
    {
        for (int i = 0; i < populationTaille; i++)
        {
            
            Vector3 pos = new Vector2(Random.Range(-200, 0), 256, Random.Range(-400, 400));
 
            // Instantiate a new creature
            GameObject creature = Instantiate(Bird, pos, Quaternion.identity);

            float randtaille=Random.Range(1.0f,3.0f);
            
            ADN creatureDNA = creature.GetComponent<DNA>();
            creatureDNA.tailleAileG=randtaille;
            creatureDNA.tailleAileD=randtaille;
            creatureDNA.tailleQueue=randtaille;
            creatureDNA.poids=Random.Range(1.0f,4.0f);
            creatureDNA.synchro=true;


            population.Add(m_creature);
        }
    }
    
    private void BreedPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();
 
        //List<GameObject> sortedList = population.OrderByDescending(o => o.GetComponent<ADN>().).ToList();
 
        population.Clear();

        //A développer

    }

    private GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 position = new Vector3(Random.Range(-200, 0), 256, Random.Range(-400, 400));
 
        // Créer une nouvelle créature et avoir une référence à son ADN
        GameObject progeniture = Instantiate(m_creature, pos, Quaternion.identity);
        ADN progenitureADN = progeniture.GetComponent<ADN>();
 
        // ADN des parents
        ADN adn1 = parent1.GetComponent<ADN>();
        ADN adn2 = parent2.GetComponent<ADN>();

        //Obtenir un mélange de l'ADN des parents la plupart du temps, en fonction du risque de mutation
        if (mutationRate <= Random.Range(0, 100))
        {
            // choisir une plage entre 0 et 4, si elle est inférieure à 2, choisissez l'ADN du parent1, sinon choisissez le parent 2
            progenitureADN.tailleAileG = Random.Range(1, 4) < 2 ? adn1.tailleAileG : adn2.tailleAileG;
            progenitureADN.tailleQueue = Random.Range(1, 4) < 2 ? adn1.tailleAileD: adn2.tailleAileD;
            progenitureADN.tailleAileD = Random.Range(1, 4) < 2 ? adn1.tailleQueue : adn2.tailleQueue;
            progenitureADN.poids = Random.Range(1, 4) < 2 ? adn1.poids : adn2.poids ;
        }

        //A completer

        return progeniture;
    }
}