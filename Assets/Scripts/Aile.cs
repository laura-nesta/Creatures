using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aile : MonoBehaviour
{
    public int rotationScale;
    public int valRotation;

    public float Vitesse; //rapide, lent
    public int poids;
    public int taille; 
    public int largeur; // large, étroite 
    public int envergure;

    public int amplitude;
    public int frequence;

    public int turbulence;
    /*
    La turbulence désigne l'état de l'écoulement d'un fluide, liquide ou gaz, dans lequel la vitesse présente en tout point un caractère tourbillonnaire 
    [formule à ajouter]
    */
    public int portance; 
    // composante de la force subie par un corps en mvt dans un fluide qui s'exerce perpendiculairement à la direction du mvt 
    // [chercher formule]
    public int allongement; //élevé ou pas
    /*
    L'allongement d'une aile (noté λ {\displaystyle \lambda } \lambda (lambda), est égal au quotient de l'envergure par la corde moyenne. 
    Pour une aile rectangulaire sans flèche, il est donc égal au quotient de l'envergure par la corde.
    Pour une aile de forme quelconque, l'allongement est égal au carré de l'envergure divisé par la surface portante :
    FORMULE = λ = b²/S
    */

    public int manoeuvrabilite; //plus ou moin forte
    public int habilete; // adresse 
    public int cambrure;

    public bool échancrure;
    public bool interstices;
    
    
    public int battements; //continu ou non
    public int emargination; //pour la pression de l'air
    public int typeVol; //plané, lent... => enum?
    
    

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