using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPiernas : MonoBehaviour
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
            Anim.SetBool("WalkLegs", true);
        }
        else
        {
            Anim.SetBool("WalkLegs", false);
        }
        if (En_Inputs.PlayMode)
        {
            Anim.SetBool("IsModeGuard", true);
        }
        else 
        {
            Anim.SetBool("IsModeGuard", false);
        }
    }
}
