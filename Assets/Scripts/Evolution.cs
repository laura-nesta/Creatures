using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using UnityEngine.UI;
using System.IO;
using System.Text;

public class Evolution : MonoBehaviour
{
    public Generation generation;
    int numero_generation = 1;
    Dictionary<ADN, float> scoreByGene = new Dictionary<ADN, float>();
    float max_time = 20;    // temps maximum de simulation pour une g�n�ration
    float current_time = 0;
    float percentage = 0.6f;  //pourcentage de cr�atures retenues pour la g�n�ration suivante
    float success = 40f; //objectif de moyenne de la note d'une g�n�ration
    float mean;
    public Text numGeneration;

    private void Start()
    {
        videFichierScore();
        generation.launch();
        scoreByGene.Clear();
    }

    private void Update()
    {
        if (generation.isPlaying)
        {
            current_time += Time.deltaTime;
            if (generation.creatures.All(c => !c.isAlive || c.isArrived) || current_time > max_time)
            {
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

        mean = scoreByGene.Values.Average();
        Debug.Log(mean);
        if (mean > success)
        {
            string result = string.Format("R�sultats :\nTaille aile gauche : {0}\nTaille aile droite : {1}\nTaille queue : {2}\nPoids : {3}",
                scoreByGene.Keys.Select(g => g.getAileG()).Average(),
                scoreByGene.Keys.Select(g => g.getAileD()).Average(),
                scoreByGene.Keys.Select(g => g.getQueue()).Average(),
                scoreByGene.Keys.Select(g => g.getPoids()).Average());
            Debug.Log(result);
            finDeSimulation(scoreByGene.Keys.Select(g => g.getAileG()).Average(),
                scoreByGene.Keys.Select(g => g.getAileD()).Average(),
                scoreByGene.Keys.Select(g => g.getQueue()).Average(),
                scoreByGene.Keys.Select(g => g.getPoids()).Average());
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
        sauverScore();
    }

    private void finDeSimulation(float ag, float ad, float q, float p)
    {
        //ADN selectedGenes = new ADN(ag, ad, q, p);
        generation.FinDeSimulation(ad, ag, q, p);
    }

    void sauverScore()
    {
        File.AppendAllText("Scores.txt", mean.ToString()+"\n");
    }

    void videFichierScore()
    {
        StreamWriter sw = new StreamWriter("Scores.txt");
        sw.Flush();
        sw.Close();
    }
}
