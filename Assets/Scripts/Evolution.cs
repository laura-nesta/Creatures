using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Evolution : MonoBehaviour
{
    public Generation generation;
    int numero_generation;
    Dictionary<ADN, float> scoreByGene = new Dictionary<ADN, float>();
    float max_time = 20;
    float current_time = 0;
    float percentage = 0.4f;
    float success = 80f;

    private void Start()
    {
        generation.launch();
        scoreByGene.Clear();
        createScoreByGene();
    }

    void OnGUI()
    {
        
        GUI.Box(new Rect(10,10,260,160), "Génération " + numero_generation);
        GUI.Box(new Rect(20,40,230,30), "Taille moyenne aile gauche: " + scoreByGene.Keys.Select(g => g.getAileG()).Average());
        GUI.Box(new Rect(20,70,230,30), "Taille moyenne aile droite: " + scoreByGene.Keys.Select(g => g.getAileD()).Average());
        GUI.Box(new Rect(20,100,230,30), "Taille moyenne queue: " + scoreByGene.Keys.Select(g => g.getQueue()).Average());
        GUI.Box(new Rect(20,130,230,30), "poids moyen: " + scoreByGene.Keys.Select(g => g.getPoids()).Average());

       // GUI.Box(new Rect(20,130,230,30), "temps moyen: " + generation.creatures[0].getTime());
    }


    
    private void Update()
    {
        if (generation.isPlaying)
        {
            current_time += Time.deltaTime;
            if (generation.creatures.All(c => !c.isAlive || c.isArrived) || current_time > max_time)
            {
                getScoresAndLaunchAgain();
                numero_generation ++;
            }
        }
    }

    public void createScoreByGene()
    {
        for (int i = 0; i < Generation.nb_creatures; i++)
        {
            scoreByGene.Add(generation.creatures[i].getGene(), generation.creatures[i].getFinalScore());
        }
    }

    private void getScoresAndLaunchAgain()
    {
        /*
        for (int i = 0; i < Generation.nb_creatures; i++)
        {
            scoreByGene.Add(generation.creatures[i].getGene(), generation.creatures[i].getFinalScore());
        }*/
        //createScoreByGene();
        generation.reset();

        float mean = scoreByGene.Values.Average();
        Debug.Log(mean);
        if (mean > success)
        {
            string result = string.Format("R�sultats :\nTaille aile gauche : {0}\nTaille aile droite : {1}\nTaille queue : {2}\nPoids : {3}",
                scoreByGene.Keys.Select(g => g.getAileG()).Average(),
                scoreByGene.Keys.Select(g => g.getAileD()).Average(),
                scoreByGene.Keys.Select(g => g.getQueue()).Average(),
                scoreByGene.Keys.Select(g => g.getPoids()).Average());
            Debug.Log(result);
            FinDeSimulation();
            
        }
        else
        {
            ADN[] orderedGenes = scoreByGene.OrderByDescending(gbs => gbs.Value).Select(gbs => gbs.Key).ToArray();
            int numberOfSelectedGenes = (int)(Generation.nb_creatures * percentage);
            ADN[] selectedGenes = new ADN[numberOfSelectedGenes];
            for (int i = 0; i < numberOfSelectedGenes; i++)
            {
                selectedGenes[i] = orderedGenes[i];
            }
            generation.launch(selectedGenes);
        }
        current_time = 0;
    }

    private void FinDeSimulation() {
        ADN[] orderedGenes = scoreByGene.OrderByDescending(gbs => gbs.Value).Select(gbs => gbs.Key).ToArray();
        int numberOfSelectedGenes = (int)(Generation.nb_creatures * percentage);
        ADN[] selectedGenes = new ADN[numberOfSelectedGenes];
        for (int i = 0; i < numberOfSelectedGenes; i++)
        {
            selectedGenes[i] = orderedGenes[i];
        }
        generation.FinDeSimulation(selectedGenes);
    }

}


