using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject Cam;
    public float ParallaxEfect;

    private void Start()
    {
        startpos = transform.position.x;

        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    private void FixedUpdate()
    {
        float temp = (Cam.transform.position.x * (1 - ParallaxEfect));
        float dist = (Cam.transform.position.x * ParallaxEfect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
