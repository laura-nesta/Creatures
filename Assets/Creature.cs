using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
A FAIRE:
    - faire les getteurs et les setteurs ? 
    - coder les fonctions vides
    - réfléchir aux autres fonctionnalités possibles
*/

public class Creature : MonoBehaviour
{


    public float waitTime = 10.0f;
    public float timer = 0.0f;
    public float visualTime = 0.0f;
    public float scrollBar = 1.0f;

    public const float RHO_AIR = 1.20f;
    public bool vol = true;
    public int nbAiles = 2;
    public Ailes [] Ailes = new Ailes[2];
    public Queue Q;
    public Oiseau O;

    public Rigidbody Oiseau;
    public float speed;

/////////////////////////// FORCES ///////////////////////////////////////////
  
    public float trainee;
    public float Cx = 0.5f;
    public float vitesse = 0.5f;

///////////////////////////////////////////////////////////////////////////////////
    

    // Start is called before the first frame update

    void Start()
    {
        Ailes[0].GetComponent<Renderer>().material.color = Color.green;
        Ailes[1].GetComponent<Renderer>().material.color = Color.yellow;
        
        trainee = 0.5f * RHO_AIR * vitesse*vitesse * 20 * Cx;
        Oiseau = GetComponent<Rigidbody>();
            Oiseau.mass = 2;
            Oiseau.drag = RHO_AIR; 
            Oiseau.velocity = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Voler();
    }

    bool estEnTrain(Ailes A) {
        return A.estEnTrainDeBattre();
    }
    void BattementAileHB() {

        Voler();
        Debug.Log(timer);
    }

    void TournerAGauche() {
    
    }

    void TournerADroite() {
        if(estEnTrain(Ailes[1]) && !estEnTrain(Ailes[0])) {
            Oiseau.AddForce(-transform.forward * 55);
        }
    }

    void Decoler() {
        Oiseau.AddForce(transform.up * 55);
        Oiseau.AddForce(-transform.right * 55);
    }

    void Detruire() {
        Destroy(gameObject);
    }

    void Minuterie() {

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            Detruire();
        }
    }
    

    void Min() {
        timer += Time.deltaTime;
        
        if(timer > waitTime) {
            Debug.Log("onnnnnnn");
            timer = 0;
        }
    }

    void Voler() {
       
        BattementAileHB();
          
    }
    

}
