using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADN
{
    private float tailleAileG; //0
    private float tailleAileD; //1
    private float tailleQueue; //2
    private float poids;       //3

    //on travaille avec des ratios par rapport à notre créature de base
    //le constructeur par défaut à des genes qui ne modifie pas notre ccreature

    public ADN()
    {
        tailleAileD = 1;
        tailleAileG = 1;
        tailleQueue = 1; 
        poids = 1;
    }

    //constructeurs avec pramètres pour modifier nos créatures
    public void setGenes(float tAg, float tAd, float tQ, float p){
        tailleAileD = tAd;
        tailleAileG = tAg;
        tailleQueue = tQ;
        poids = p;
    }

    public float getAileD(){
        return tailleAileD;
    }
    public float getAileG(){
        return tailleAileG;
    }
    public float getQueue(){
        return tailleQueue;
    }

    public float getPoids(){
        return poids;
    }

    public void setAileD(float t){
        tailleAileD = t;
    }

    public void setAileG(float t){
        tailleAileG = t;
    }
    public void setQueue(float t){
        tailleQueue = t;
    }
    public void setPoids(float t){
        poids = t;
    }
}
