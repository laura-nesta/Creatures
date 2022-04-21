using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADN: MonoBehaviour
{
    private float tailleAileG; //0
    private float tailleAileD; //1
    private float tailleQueue; //2
    private float poids;       //3
    private bool synchro;      //4   //ou int 0;1
    private int nb_genes = 20;
    private float Red, Green, Blue; //Pour couleurs des oiseaux
    public GameObject[] Genes;
    public GameObject selector;
    //public List<GameObject> Genes= new List<GameObject>();
    //private float Val_mutation=0.01f;

    public ADN(int nb_genes) //Constructeur par défaut
    {
        this.nb_genes=nb_genes;
        Genes=new GameObject[this.nb_genes];
        for(int i=0; i<this.nb_genes; i++)
        {
            Vector3 position=new Vector3(Random.Range(1,10), Random.Range(1,2), Random.Range(-10,10));
            GameObject creaturego = Instantiate(selector, position, Quaternion.identity) as GameObject;
            Genes[i]=creaturego;
        }

    }
    //on travaille avec des ratios par rapport à notre créature de base
    //le constructeur par défaut à des genes qui ne modifie pas notre ccreature

    public ADN(ADN parent1, ADN parent2, float Val_mutation) //Constructeur avec 2 parents ADN
    {
        Val_mutation=0.01f;

        for(int i=0; i<parent1.getNbGene; i++)
        {
            float Mutation_chance=Random.Range(0.0f,1.0f);
            if(Val_mutation<=Mutation_chance)
            {
                Vector3 position=new Vector3(Random.Range(1,10), Random.Range(1,2), Random.Range(-10,10));
                GameObject progeniture = Instantiate(selector, position, Quaternion.identity) as GameObject;
                Genes[i]=progeniture;
            }
            else
            {
                int Chance_parents=Random.Range(0,1);
                if(Chance_parents==0)
                {
                    Genes[i]=parent1.Genes[i];
                }
                else if(Chance_parents==1)
                {
                    Genes[i]=parent2.Genes[i];
                }
            }
        }

    }

    void Awake()
    {
        tailleAileD = 1;
        tailleAileG = 1;
        tailleQueue = 1; 
        poids = 1;
        synchro = false;
    }

    //constructeurs avec pramètres pour modifier nos créatures
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

    public float getPoids(){
        return poids;
    }

    public bool getSync(){
        return synchro;
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
    public void setSync(bool t){
        synchro = t;
    }

    public int getNbGene(){
        return nb_genes;
    }

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
