using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
  public float Vitesse=100.0f;
  //public Aile [] Ailes = new Aile[2];
  public int taille;
  public int poids;
  
  // Start is called before the first frame update
  void Start()
  {   
      //Vitesse = 100.0f;

      gameObject.GetComponent<Renderer>().material.color = Color.red;
      //Ailes[0].GetComponent<Renderer>().material.color = Color.green;
      //Ailes[1].GetComponent<Renderer>().material.color = Color.yellow;
      
      //Ailes[0].rotationScale = 1;
      //Ailes[1].rotationScale = -1;

  }

  // Update is called once per frame
  void Update()
  {

      
  }
}
