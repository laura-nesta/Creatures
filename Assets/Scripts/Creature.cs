/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
  //public float Vitesse;
  //public Aile [] Ailes = new Aile[2];

  public static GameObject creature;
  public int note = 20;

  private ADN genes;
  private int nb_genes;
  nb_genes =  genes.getNbGene();



  public GameObject aile /*= creature.transform.Find("Ailes").gameObject;
    public GameObject ailed //= creature.transform.Find("Ailes/aile_droite").gameObject;
    public GameObject aileg //= creature.transform.Find("Ailes/aile_gauche").gameObject;

  public GameObject corps //= creature.transform.Find("Corps").gameObject;
  
  public GameObject queue //= creature.transform.Find("Queue").gameObject;


  public void setGene(ADN g){
    genes = g;
  }

  public ADN getGene(){
    return genes;
  }

  /*
  public void genereADN(){
      genes.SetAileD(rand.NextDouble() * 2);
    }
    //

  public void tabToGene(int tab[nb_genes]){
      genes.SetAileG(tab[0]);
      genes.SetAileD(tab[1]);
      genes.SetQueue(tab[2]);
      genes.SetPoids(tab[3]);
      if(tab[4] == 0)
        genes.SetSync(false);
      else
        genes.SetSync(true);
  }

  public int[] geneToTab(){
    int tab[nb_genes];
    tab[0] = getAileG();
    tab[1] = getAileD();
    tab[2] = getQueue();
    tab[3] = getpoids();
    if(SetSync)
      tab[4] = 1;
    else
      tab[4] = 0;
    return tab;
  }

  public void modifCrea(){
    ailed.transform.localScale = new Vector3(ailed.transform.localScale.x*1, ailed.transform.localScale.y*1,ailed.transform.localScale.z*genes.getAileD());    
  }

  /*geneRand.SetAileD(rand.NextDouble() * 2);
        geneRand.SetAileG(rand.NextDouble() * 2);
        geneRand.SetQueue(rand.NextDouble() * 2);
        geneRand.SetPoids(rand.NextDouble() * 2);
        if(rand.Next(2) == 0){
            geneRand.SetSync(false);
        }
        else geneRand.SetSync(true);
  //
    // Start is called before the first frame update
  async void Start()
  {   
     ailed.transform.localScale = new Vector3(ailed.transform.localScale.x*1, ailed.transform.localScale.y*1,ailed.transform.localScale.z*genes.getAileD());
  }

  // Update is called once per frame
  void Update()
  {

      
  }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public int nbAiles = 2;
    public int nbQueues = 1;
    Vector3 target;

//////////////////  CREATURE  /////////////////////
    AileDeFou [] tabAiles;
    Queue [] tabQueue;
    Oiseau corps;
    GameObject m_Creature;
    Rigidbody r_Creature;
    
    ADN genes;
    float aileg, ailed, queue, poids;

    Vector3 [] v_aile;

    public float timer = 0f;
    public float waitTime = 5f;

    void Awake() {
        tabAiles = new AileDeFou[nbAiles];
        tabQueue = new Queue[nbQueues];
        
        genes = gameObject.AddComponent<ADN>();
        r_Creature = GetComponent<Rigidbody>();

        tabAiles = GetComponentsInChildren<AileDeFou>();
        tabQueue = GetComponentsInChildren<Queue>();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        // INITIALISATION DES COMPOSANTS DE LA CREATURE (avec les gènes)
       
        aileg = genes.getAileG();
        ailed = genes.getAileD();
        queue = genes.getQueue();
        poids = genes.getPoids();

        r_Creature.mass = poids;

        foreach(AileDeFou adf in tabAiles){            
            if(adf.isAile_G){
                adf.getAile().transform.localScale *= aileg;
            }
            else{
                adf.getAile().transform.localScale *= ailed;
            }
        }
        
        foreach(Queue q in tabQueue){            
          
            q.transform.localScale *= queue;
            
        }
       
    }

    void Update() {
        Debug.Log(tabAiles[0].getAile().transform.localScale);
    }


    bool estArrive() {
        //if(m_Test.position == target) return true;

        return false;
    }
}