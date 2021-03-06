﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPlayer : MonoBehaviour
{

    public Animator anim;
    public BloqueoV2 En_BloqueoV2;
    public ModoDeJuego En_ModoDeJuego;
    public Inputs En_Inputs;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (En_Inputs.BH_Right || En_Inputs.BH_Left)
        {
            anim.SetBool("WalkExpLegs",true);
            anim.SetBool("WalkExpTorso", true);
        }
        else
        {
            anim.SetBool("WalkExpLegs", false);
            anim.SetBool("WalkExpTorso", false);
        }
        if (En_ModoDeJuego.PlayMode)
        {
            anim.SetBool("GuardMode", true);
        }
        else
        {
            anim.SetBool("GuardMode", false);
        }
        if (En_BloqueoV2.ActivarAnimacionEscudo)
        {
            anim.SetBool("EscudoFrente", true);
        }
        else
        {
            anim.SetBool("EscudoFrente", false);
        }
        if (En_Inputs.BD_Attack)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

}
