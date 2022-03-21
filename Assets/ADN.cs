using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADN : MonoBehaviour
{
    int[] gene;
    float fitness;
    float mutationRate = 0.01f;
    //private System.Random random;
    float random = Random.Range(0,10);
    bool fisrtGen = true;

    public gene(int n){

    }

    public init(){

    }

    public void fitnessCal(){

    }

    public void crossOver(){

    }

    public void mutation(){

    }

    // Start is called before the first frame update
    void Start()
    {
        init();
        
        if(fisrtGen == false){
            fitnessCal();
            crossOver();
            mutation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
