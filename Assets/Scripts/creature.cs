using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
 /* public float Vitesse;
  public Aile [] Ailes = new Aile[2];*/

  public static GameObject creature;
  public int note = 20;

  private ADN genes;
  private int nb_genes;
  nb_genes =  genes.getNbGene;



  public GameObject aile /*= creature.transform.Find("Ailes").gameObject*/;
    public GameObject ailed /*= creature.transform.Find("Ailes/aile_droite").gameObject*/;
    public GameObject aileg /*= creature.transform.Find("Ailes/aile_gauche").gameObject*/;

  public GameObject corps /*= creature.transform.Find("Corps").gameObject*/;
  
  public GameObject queue /*= creature.transform.Find("Queue").gameObject*/;


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
    */

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


  /*geneRand.SetAileD(rand.NextDouble() * 2);
        geneRand.SetAileG(rand.NextDouble() * 2);
        geneRand.SetQueue(rand.NextDouble() * 2);
        geneRand.SetPoids(rand.NextDouble() * 2);
        if(rand.Next(2) == 0){
            geneRand.SetSync(false);
        }
        else geneRand.SetSync(true);
  */    
    // Start is called before the first frame update
  async void Start()
  {   
     ailed.transform.localScale = new Vector3(ailed.transform.localScale.x*1, ailed.transform.localScale.y*1,ailed.transform.localScale.z*genes.getAileD());
  }

  // Update is called once per frame
  void Update()
  {

      
  }
}
