using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aile : MonoBehaviour
{
    public Creature parentCreature;
    public bool isAile_G;

    float angle = 0.0f;
    float v;
    float size = 1;
    bool descending = false;

    float defaultScale = 1.5f;
    float horizontalSpeed = 3;
    float verticalSpeed = 3;
    float minAngle = -30f;
    float maxAngle = 30f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAile_G) {
            v = 1 + Mathf.Sin(angle);
            angle += 0.1f;
            if (v > 1.9f)
            {
                descending = false;
            }
            if (v < 0.1f)
            {
                descending = true;
            }
        }
        else {
            v = 1 - Mathf.Sin(angle);
            angle += 0.1f;
            if (v > 1.9f)
            {
                descending = true;
            }
            if (v < 0.1f)
            {
                descending = false;
            }
        }

        transform.localEulerAngles = new Vector3(Mathf.Lerp(minAngle, maxAngle, v / 2), 0, 0);

        if (isAile_G)
        {
            parentCreature.appliquerForce(new Vector3(0, descending ? verticalSpeed * size : 0, horizontalSpeed * size));
        }
        else
        {
            parentCreature.appliquerForce(new Vector3(0, descending ? verticalSpeed * size : 0, -horizontalSpeed * size));
        }
    }

    public void setSize(float _size)
    {
        size = _size;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, defaultScale * size);
    }
}
