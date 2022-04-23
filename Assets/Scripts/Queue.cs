using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public Creature parentCreature;

    float angle = 0.0f;
    float v;
    float size = 1;
    bool descending = false;

    float defaultScale = 1.0f;
    float horizontalSpeed = 10;
    float verticalSpeed = 3;
    float minAngle = -30f;
    float maxAngle = 30;

    void FixedUpdate()
    { 
        v = 1 + Mathf.Sin(angle);
        if (v > 1.9f)
        {
            descending = true;
        }
        if (v < 0.1f)
        {
            descending = false;
        }

        angle += 0.1f;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minAngle, maxAngle, v / 2));

        parentCreature.appliquerForce(new Vector3(-horizontalSpeed * size, descending ? verticalSpeed * size : 0, 0));
    }

    public void setSize(float _size)
    {
        size = _size;
        transform.localScale = new Vector3(defaultScale * size, transform.localScale.y, transform.localScale.z);
    }
}
