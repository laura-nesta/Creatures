using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aile : MonoBehaviour
{
    public float Vitesse; //rapide, lent
    public int rotationScale;
    public int valRotation;
    public int poids;
    public int taille;
    public int amplitude;
    public int frequence;
    public int turbulence;
    public int portance; 
    // composante de la force subie par un corps en mvt dans un fluide qui s'exerce perpendiculairement à la direction du mvt
    public int allongement; //élevé ou pas
    public int cambrure;
    public int largeur;
    public int battements; // continus ou non
    public int emargination; //pour la pression de l'air
    public int typeVol; //plané lent
    public int manoeuvrabilite;
    

    // Start is called before the first frame update
    void Start()
    {
        valRotation = 0;
        Vitesse = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if((valRotation >= 46 && rotationScale > 0) || 
         (valRotation <= -46 && rotationScale < 0))
                rotationScale = -rotationScale;

        //batements ailes
        if(Input.GetKey("space")){
            transform.Rotate(rotationScale,0,0);
            valRotation += rotationScale;
        }
    }
} 