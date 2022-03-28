using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
A FAIRE:
    - faire les getteurs et les setteurs ? 
    - bien coder la fonction BattementAile() => pb avec la fréquence de battement des ailes
    - réfléchir aux autres fonctionnalités possibles
*/

public class Ailes : MonoBehaviour
{
    public const float RHO_AIR = 1.20f;
    public float compteur = 0; // compte les battements d'une aile 
    public float frequence;
    public float vitesse = 0.5f;
    public float masse;
    public int amplitude;
    public float longueur; 
    public float largeur;
    public float epaisseur;
    public float surface;
    public float angle;
    public Vector3 extremite;

    public float allongement;
    //L'allongement d'une aile est égal au quotient de l'envergure par la corde moyenne. 
    //Pour une aile de forme quelconque, l'allongement est égal au carré de l'envergure divisé par la surface portante :
    //FORMULE = λ = b²/S

   // public Random alea = new Random(); // Coeficient de portance. Pour vol de croisiere: 0.3 < Cz < 0.7
    public float Cz = 0.5f;
    public float portance;
    // composante de la force subie par un corps en mvt dans un fluide qui s'exerce perpendiculairement à la direction du mvt 
    
    public Rigidbody aile;

    void Awake()
    {
        frequence = 0.2f;
        amplitude = 2;
        masse = 10f;

        angle = 0;

        longueur = gameObject.transform.localScale.x;
        largeur = gameObject.transform.localScale.z;
        epaisseur = gameObject.transform.localScale.y;

        extremite = transform.forward;

        surface = getSurface(gameObject.transform.localScale.x, gameObject.transform.localScale.z);
        allongement = longueur * longueur / surface;

        portance = 0.5f * RHO_AIR * vitesse*vitesse * surface * Cz;
        aile = GetComponent<Rigidbody>();
            aile.mass = 2;
            aile.drag = RHO_AIR; 
            aile.isKinematic = true;

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
       //BattementAileGauche();
       Debug.Log(compteur);
    }

    public float getSurface(float x, float y) {
        return x*y;
    }
   
    public void BattementAileGauche() {
        transform.Rotate(-Mathf.Sin(angle) * amplitude, 0, 0);
        angle +=0.1f;

        //aile.AddForce(transform.up * portance);
        //aile.AddForce(transform.right * portance);
    }

    public void BattementAileDroite() {
        transform.Rotate(Mathf.Sin(angle) * amplitude, 0, 0);
		angle +=0.1f;
        //aile.AddForce(transform.up * portance);
        //aile.AddForce(transform.right * portance);
    }
	    
    public void RotationAileInter() {
        transform.Rotate(0,0, Mathf.Sin(angle) * amplitude);
		angle +=0.1f;
    }

    public void RotationAileExter() {
        transform.Rotate(0,0, -Mathf.Sin(angle) * amplitude);
		angle +=0.1f;
    }

    public bool estEnTrainDeBattre() {
        if(angle != 0) return true;
        return false;
    }

    public void ArreterBattements() {
       transform.Rotate(Mathf.Sin(angle) * amplitude, 0, 0);
       transform.Rotate(-Mathf.Sin(angle) * amplitude, 0, 0);
    }

    void Descelerer() {
        
    }

     
}

   