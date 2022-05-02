using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;
using System.Text;
using System.IO;

public class Graphe: MonoBehaviour
{
    public Evolution evolution;
    private RectTransform graphcontainer; //Pour la transformation du rectangle de graphcontainer

    //Sprite: objet 2D pour afficher l'élément graphique du point
    [SerializeField] private Sprite dotsprite; //SerializeField permet de forcer à modifier la donnée privée.

    public static string[] lignes;
    private int nbvaleurs;
    public float[] valeurs;

	void Start ()
	{
		string fileName = "ScoresGraphe.txt";
		lignes = File.ReadAllLines(fileName);

		Debug.Log("Génération initiale: score: " + lignes[0] + " " + ", Génération finale: score: " + lignes[21]);

        nbvaleurs=22;
        valeurs=new float[nbvaleurs];
        for(int i=0; i<nbvaleurs; i++)
        {
            valeurs[i]=float.Parse(lignes[i]);
        }
        AfficherGraphe(valeurs);
	}

    private void Awake()
    {
        graphcontainer=transform.Find("graphcontainer").GetComponent<RectTransform>();
    }

    private void Dot(Vector2 position)
    {
        GameObject dot=new GameObject("Dot", typeof(Image));
        dot.transform.SetParent(graphcontainer, false);
        dot.GetComponent<Image>().sprite=dotsprite;
        RectTransform recttransform=dot.GetComponent<RectTransform>();
        recttransform.anchoredPosition=position;
        recttransform.sizeDelta=new Vector2(25,25);
        recttransform.anchorMin=new Vector2(0,0);
        recttransform.anchorMax=new Vector2(0,0);
    }

    private void AfficherGraphe(float[] valeurs)
    {
       float hauteur=graphcontainer.sizeDelta.y;
       float yMinimum=100f;
       float ecart=50f;
       for(int i=0; i<nbvaleurs; i++)
       {
           float xPosition=i*ecart;
           float yPosition= (valeurs[i]/yMinimum)*hauteur;
           Dot(new Vector2(xPosition, yPosition));
       }
    }
}