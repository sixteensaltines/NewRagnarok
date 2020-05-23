using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionDoble : MonoBehaviour
{

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            anim.SetBool("Arriba", true);
        }
        else
        {
            anim.SetBool("Arriba", false);
        }
        if (Input.GetKey(KeyCode.N))
        {
            anim.SetBool("Abajo", true);
        }
        else
        {
            anim.SetBool("Abajo", false);
        }

    }
}
