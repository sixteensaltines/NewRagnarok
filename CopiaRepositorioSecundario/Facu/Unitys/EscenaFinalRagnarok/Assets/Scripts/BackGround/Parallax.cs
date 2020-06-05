using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    
    public GameObject Camara;
    public float EfectoParallax; 
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void FixedUpdate()
    {
        float temp = (Camara.transform.position.x * (1 - EfectoParallax));
        float dist = (Camara.transform.position.x * EfectoParallax);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else 
        if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
