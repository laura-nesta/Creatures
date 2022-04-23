using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corps : MonoBehaviour
{
    public Creature parentCreature;

    float poids;
    const float gravity = 9.8f;

    void FixedUpdate()
    {
        parentCreature.appliquerForce(new Vector3(0, -poids * gravity, 0));
    }

    public void setPoids(float _poids)
    {
        poids = _poids;
    }
}
