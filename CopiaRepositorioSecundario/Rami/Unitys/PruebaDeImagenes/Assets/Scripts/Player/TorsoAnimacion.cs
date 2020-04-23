using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoAnimacion : MonoBehaviour
{
    public Inputs En_Inputs;
    public Animator Anim;

    public void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void Update()
    {
        if (En_Inputs.BH_Right || En_Inputs.BH_Left)
        {
            Anim.SetBool("WalkTorso", true);
        }
        else
        {
            Anim.SetBool("WalkTorso", false);
        }
    }
}
