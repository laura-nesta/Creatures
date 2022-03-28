using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADN : MonoBehaviour
{
    public float tailleAileG;
    public float tailleAileD;
    private float tailleQueue;
    private float poids;
    private bool synchro; //ou int 0;1

    //on travaille avec des ratios par rapport à notre créature de base
    //le constructeur par défaut à des genes qui ne modifie pas notre ccreature
    ADN(){
        tailleAileD = 1;
        tailleAileG = 1;
        tailleQueue = 1;
        poids = 1;
        synchro = false;
    }

    //constructeurs avec pramètres pour modifier nos créatures
    ADN(float tAg, float tAd, float tQ, float p, bool s){
        tailleAileD = tAd;
        tailleAileG = tAg;
        tailleQueue = tQ;
        poids = p;
        synchro = s;
    }

    void setGenes(float tAg, float tAd, float tQ, float p, bool s){
        tailleAileD = tAd;
        tailleAileG = tAg;
        tailleQueue = tQ;
        poids = p;
        synchro = s;
    }

    float getAileD(){
        return tailleAileD;
    }
    float getAileG(){
        return tailleAileD;
    }
    float getQueue(){
        return tailleQueue;
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
