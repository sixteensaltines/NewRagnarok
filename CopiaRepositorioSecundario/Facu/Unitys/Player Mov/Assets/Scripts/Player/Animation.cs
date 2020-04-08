using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Inputs En_Inputs;
    public AtaqueV2 En_AtaqueV2;

    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (En_Inputs.BH_Block)
        {
            Anim.SetBool("OpenShield", true);
        }
        else
        {
            Anim.SetBool("OpenShield", false);
        }
        if (En_Inputs.BD_Attack)
        {
            Anim.SetBool("Attack", true);
        }
        else
        {
            Anim.SetBool("Attack", false);
        }
    }
}
