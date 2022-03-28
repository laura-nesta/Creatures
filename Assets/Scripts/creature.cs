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

  public GameObject aile /*= creature.transform.Find("Ailes").gameObject*/;
    public GameObject ailed /*= creature.transform.Find("Ailes/aile_droite").gameObject*/;
    public GameObject aileg /*= creature.transform.Find("Ailes/aile_gauche").gameObject*/;

  public GameObject corps /*= creature.transform.Find("Corps").gameObject*/;
  
  public GameObject queue /*= creature.transform.Find("Queue").gameObject*/;


  // Start is called before the first frame update
  async void Start()
  {   
     ailed.transform.localScale = new Vector3(ailed.transform.localScale.x*1, ailed.transform.localScale.y*1,ailed.transform.localScale.z*genes.tailleAileD);
  }

  // Update is called once per frame
  void Update()
  {

      
  }
}
