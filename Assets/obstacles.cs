using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    private int nb_obstacles = 5;
    public GameObject[] obstacle;
    public GameObject selector;

    // Start is called before the first frame update
    void Start()
    {
        obstacle = new GameObject[nb_obstacles];
        for(int i = 0 ; i < nb_obstacles; i++){
            GameObject go = Instantiate(selector, new Vector3(Random.Range(-200, 200), 10, Random.Range(-400,0)), Quaternion.identity) as GameObject;
            //go.transform.localScale = new Vector3(-10,10,10);
            obstacle[i] = go;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}