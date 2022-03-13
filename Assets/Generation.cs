using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    private int nb_creatures = 10;
    public GameObject[] maCreature;
    public GameObject selector;
    //int[] array1 = new int[5];
    // Start is called before the first frame update
    async void Start()
    {
        /*
        maCreature[0].GetComponent<Renderer>().material.color = Color.blue;
        maCreature[1].GetComponent<Renderer>().material.color = Color.yellow;
        maCreature[0].transform.Translate(2,0,0);
        maCreature[1].transform.Translate(-2,0,0);*/
        maCreature = new GameObject[nb_creatures];
        for(int i = 0 ; i < nb_creatures; i++){
            GameObject go = Instantiate(selector, new Vector3((float)283.5, (float)255.7, (float)i*50-200), Quaternion.identity) as GameObject;
            //go.transform.localScale = Vector3.one;
            go.transform.localScale = new Vector3(-10,10,10);
            //maCreature[i].transform.localScale += new Vector3(10,10,10);
            maCreature[i] = go;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}