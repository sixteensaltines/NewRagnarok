using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTorsoAnim : MonoBehaviour
{
    public Inputs En_Inputs;
    public BloqueoV2 En_BloqueoV2;

    public Animator anim;

    private bool guardOn;
    private bool ExpOn;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        WhatModeIs();
        IsBlock();
        IsAttack();
    }
    void WhatModeIs()
    {
        if (En_Inputs.PlayMode && !guardOn)
        {
            guardOn = true;
            ExpOn = false;
            anim.SetBool("ExpToGuard", true);
            Invoke("In_SetOffAnimations", 0.1f);
        }
        if (!En_Inputs.PlayMode && !ExpOn)
        {
            guardOn = false;
            ExpOn = true;
            anim.SetBool("GuardToExp", true);
            Invoke("In_SetOffAnimations", 0.1f);
        }
    }
    void IsBlock()
    {
        if (En_BloqueoV2.ActivarEscudo_Frente)
        {
            anim.SetBool("ShieldOn", true);
        }
        else
        {
            anim.SetBool("ShieldOn", false);
        }
    }
    void IsAttack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetBool("AttackOn", true);
            Invoke("In_SetOffAnimations", 0.2f);
        }
    }
    void In_SetOffAnimations()
    {
        anim.SetBool("AttackOn", false);
        anim.SetBool("GuardToExp", false);
        anim.SetBool("ExpToGuard", false);
    }

}
