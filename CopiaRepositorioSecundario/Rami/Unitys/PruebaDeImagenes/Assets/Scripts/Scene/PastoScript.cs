using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastoScript : MonoBehaviour
{    
    public Inputs En_Inputs;
    public Transform T_Pies;
    public LayerMask LayerGrass;
    public Animator Anim;

    public bool TocandoPasto;

    private float radio = 0.50f;
    
    private void Update()
    {
        DetectaPasto();
        ContactoPasto();
        MoverPasto();      
    }


    void DetectaPasto()
    {
        TocandoPasto = Physics2D.OverlapCircle(T_Pies.position, radio, LayerGrass);
    }
    void ContactoPasto()
    {
        if (TocandoPasto)
        {
            Anim.SetBool("Contact", true);
        }
        else
        {
            Anim.SetBool("Contact", false);
        }
    }
    void MoverPasto()
    {
        if (En_Inputs.BH_Left && TocandoPasto)
        {
            Anim.SetBool("LeftMov", true);
            Anim.SetBool("RightMov", false);
        }
        if (En_Inputs.BH_Right && TocandoPasto)
        {
            Anim.SetBool("LeftMov", false);
            Anim.SetBool("RightMov", true);
        }
        if (!En_Inputs.BH_Left && !En_Inputs.BH_Right)
        {
            Anim.SetBool("LeftMov", false);
            Anim.SetBool("RightMov", false);
        }
    }
}
