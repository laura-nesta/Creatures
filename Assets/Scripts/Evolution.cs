using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Evolution : MonoBehaviour
{
    public Generation generation;
    int numero_generation=1;
    Dictionary<ADN, float> scoreByGene = new Dictionary<ADN, float>();
    float max_time = 20;
    float current_time = 0;
    float percentage = 0.4f;
    float success = 60f;
    
    public Text GenerationText;
    

    private void Start()
    {
        generation.launch();
        scoreByGene.Clear();
        GenerationText.text="Generation: 0";
    }

    private void Update()
    {
        if (generation.isPlaying)
        {
            current_time += Time.deltaTime;
            if (generation.creatures.All(c => !c.isAlive || c.isArrived) || current_time > max_time)
            {
                GenerationText.text="Generation: " + numero_generation;            
                getScoresAndLaunchAgain();
            }
        }
    }

    private void getScoresAndLaunchAgain()
    {
        for (int i = 0; i < Generation.nb_creatures; i++)
        {
            scoreByGene.Add(generation.creatures[i].getGene(), generation.creatures[i].getFinalScore());
        }
        generation.reset();

        float mean = scoreByGene.Values.Average();
        Debug.Log(mean);
        if (mean > success)
        {
            string result = string.Format("Résultats :\nTaille aile gauche : {0}\nTaille aile droite : {1}\nTaille queue : {2}\nPoids : {3}",
                scoreByGene.Keys.Select(g => g.getAileG()).Average(),
                scoreByGene.Keys.Select(g => g.getAileD()).Average(),
                scoreByGene.Keys.Select(g => g.getQueue()).Average(),
                scoreByGene.Keys.Select(g => g.getPoids()).Average());
            Debug.Log(result);
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
        numero_generation++;
    }
}
