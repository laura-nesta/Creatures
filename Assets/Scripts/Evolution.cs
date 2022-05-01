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
    float max_time = 20;    // temps maximum de simulation pour une génération
    float current_time = 0;
    float percentage = 0.6f;  //pourcentage de créatures retenues pour la génération suivante
    float success = 80f; //objectif de moyenne de la note d'une génération
    float mean;
    public Text numGeneration;
    private float[] tabScore = new float[100];

    public float gettabScore(int indice)
    {
        return tabScore[indice];
    }

    private void Start()
    {
        videFichierScore();
        generation.launch();
        scoreByGene.Clear();
        createScoreByGene();
    }

    void OnGUI()
    {

        GUI.Box(new Rect(10, 10, 260, 160), "Génération " + numero_generation);
        GUI.Box(new Rect(20, 40, 230, 30), "Taille moyenne aile gauche: " + scoreByGene.Keys.Select(g => g.getAileG()).Average());
        GUI.Box(new Rect(20, 70, 230, 30), "Taille moyenne aile droite: " + scoreByGene.Keys.Select(g => g.getAileD()).Average());
        GUI.Box(new Rect(20, 100, 230, 30), "Taille moyenne queue: " + scoreByGene.Keys.Select(g => g.getQueue()).Average());
        GUI.Box(new Rect(20, 130, 230, 30), "poids moyen: " + scoreByGene.Keys.Select(g => g.getPoids()).Average());

        GUI.Box(new Rect(10, 650, 230, 30), "temps: " + current_time);

        GUI.Box(new Rect(1000, 10, 200, 30 + numero_generation * 30), "Score");
        for (int i = 2; i <= numero_generation; i++)
        {
            GUI.Box(new Rect(1010, 40 + (i - 2) * 30, 180, 30), "Score " + (i - 1) + ": " + tabScore[i - 1]);
        }

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
        if(numero_generation != 1)
            createScoreByGene();
        generation.reset();

        mean = scoreByGene.Values.Average();
        
        Debug.Log(mean);
        tabScore[numero_generation] = mean;
        if (mean > success)
        {
            string result = string.Format("Résultats :\nTaille aile gauche : {0}\nTaille aile droite : {1}\nTaille queue : {2}\nPoids : {3}",
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
