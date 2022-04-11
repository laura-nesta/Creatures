using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADN : MonoBehaviour
{
    private float tailleAileG; //0
    private float tailleAileD; //1
    private float tailleQueue; //2
    private float poids;       //3
    private bool synchro;      //4   //ou int 0;1
    private int nb_gene = 5;

    //on travaille avec des ratios par rapport à notre créature de base
    //le constructeur par défaut à des genes qui ne modifie pas notre ccreature
    public ADN(){
        tailleAileD = 1;
        tailleAileG = 1;
        tailleQueue = 1;
        poids = 1;
        synchro = false;
    }

    //constructeurs avec pramètres pour modifier nos créatures
    public ADN(float tAg, float tAd, float tQ, float p, bool s){
        tailleAileD = tAd;
        tailleAileG = tAg;
        tailleQueue = tQ;
        poids = p;
        synchro = s;
    }

    public void setGenes(float tAg, float tAd, float tQ, float p, bool s){
        tailleAileD = tAd;
        tailleAileG = tAg;
        tailleQueue = tQ;
        poids = p;
        synchro = s;
    }

    public float getAileD(){
        return tailleAileD;
    }
    public float getAileG(){
        return tailleAileD;
    }
    public float getQueue(){
        return tailleQueue;
    }

    public float getpoids(){
        return poids;
    }

    public bool getSync(){
        return synchro;
    }

    public void SetAileD(float t){
        tailleAileD = t;
    }

    public void SetAileG(float t){
        tailleAileG = t;
    }
    public void SetQueue(float t){
        tailleQueue = t;
    }
    public void SetPoids(float t){
        poids = t;
    }
    public void SetSync(bool t){
        synchro = t;
    }

    public int getNbGene(){
        return nb_gene;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
