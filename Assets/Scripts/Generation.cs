using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    //private int nb_crea = 10;
   // public float[nb_crea] note = {10f};


    private int nb_creatures = 10;
    public GameObject[] maCreature;
    public GameObject selector;
    //int[] array1 = new int[5];


    // Start is called before the first frame update
    void Start()
    {
        /*
        maCreature[1].GetComponent<Renderer>().material.color = Color.yellow;
        maCreature[0].transform.Translate(2,0,0);
        maCreature[1].transform.Translate(-2,0,0);*/
        //maCreature[0].GetComponent<Renderer>().material.color = Color.blue;
        maCreature = new GameObject[nb_creatures];
        for(int i = 0 ; i < nb_creatures; i++){
            GameObject go = Instantiate(selector, new Vector3((float)-10, (float)25, (float)i*5-20), Quaternion.identity) as GameObject;

            //GameObject queue1 = GameObject[0].Find("queue");
            //queue1.transform.localScale = Vector3.one;
            //maCreature[i].transform.localScale += new Vector3(10,10,10);
            //go.Find("creature/corps").transform.localScale = new Vector3(i,1,1);
            maCreature[i] = go;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}