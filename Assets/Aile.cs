using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aile : MonoBehaviour
{
    public const float RHO_AIR = 1.20;
    public int rotationScale;
    public int valRotation;
    public float vitesse;

    public int amplitude;
    public int frequence;

    public float longueur; 
    public float largeur;
    public float epaisseur;
    public int poids;
    public float surface;

    public float allongement;
    //L'allongement d'une aile est égal au quotient de l'envergure par la corde moyenne. 
    //Pour une aile de forme quelconque, l'allongement est égal au carré de l'envergure divisé par la surface portante :
    //FORMULE = λ = b²/S

    public float Cz; // Coeficient de portance. Pour vol de croisiere: 0.3 < Cz < 0.7
    public float portance;
    // composante de la force subie par un corps en mvt dans un fluide qui s'exerce perpendiculairement à la direction du mvt 
    
    public Vector3 extremite;


    // Start is called before the first frame update
    async void Start()
    {
        valRotation = 0;
        vitesse = 100.0f;

        longueur = gameObject.transform.localScale.x;
        largeur = gameObject.transform.localScale.z;
        epaisseur = gameObject.transform.localScale.y;

        extremite = new Vector3(gameObject.transform.position.x - longueur / 2, 0, gameObject.transform.position.z);

        surface = Surface(gameObject.transform.localScale.x, gameObject.transform.localScale.z);

        allongement = longueur * longueur / surface;

        portance = 0.5 * RHO_AIR * vitesse*vitesse * surface * Cz;
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

    
    public float Surface(float x, float y) {
        return x*y;
    }

} 