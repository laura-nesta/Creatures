using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tete : MonoBehaviour
{
    public Creature parentCreature;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GoalArea")
            parentCreature.isArrived = true;
        else if (other.gameObject.name != "Tete")
            parentCreature.isAlive = false;
    }
}
