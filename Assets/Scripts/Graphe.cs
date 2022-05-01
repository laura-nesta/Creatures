using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graphe: MonoBehaviour
{
    public Evolution evolution;
    private RectTransform graphcontainer;
    [SerializeField] private Sprite dotsprite;

    private void Awake()
    {
        graphcontainer=transform.Find("graphcontainer").GetComponent<RectTransform>();

        float[] valeurs;
        valeurs=new float[100];
        for(int i=0; i<100; i++)
        {
            valeurs[i]=evolution.gettabScore(i);
        }
        AfficherGraphe(valeurs);
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
       float xSize=50f;
       for(int i=0; i<100; i++)
       {
           float xPosition=i*xSize+xSize;
           float yPosition= (valeurs[i]/yMinimum)*hauteur;
           Dot(new Vector2(xPosition, yPosition));
       }
    }
}