using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Inputs En_Inputs;

    public bool DashIzquierda;
    public bool DashDerecha;
    public float FuerzaDash;

    Rigidbody2D R_Player;
    void Start()
    {
        R_Player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {        
        if(En_Inputs.B_AxisHorizontal <= -0.1)
        {            
            DashDerecha = false;
            DashIzquierda = true;
        }
        if (En_Inputs.B_AxisHorizontal >= 0.1)
        {
            DashDerecha = true;
            DashIzquierda = false;
        }
        if(!En_Inputs.B_PlayMode)
        {
            FuerzaDash = 7f;
        }
        else
        {
            FuerzaDash = 6f;
        }
        if(En_Inputs.B_AxisHorizontal == 0 && En_Inputs.B_Dash)
        {
            En_Inputs.B_Dash = false;
        }



        if (En_Inputs.B_Dash && DashDerecha)
        {
            R_Player.velocity = Vector2.right * FuerzaDash;
            En_Inputs.B_Dash = false;
            Invoke("ParaElDash", 0.75f);

        }
        if (En_Inputs.B_Dash && DashIzquierda)
        {
            R_Player.velocity = Vector2.left * FuerzaDash;
            En_Inputs.B_Dash = false;
            En_Inputs.BlockButtons = true;

            Invoke("ParaElDash", 0.75f);
            Invoke("DevuelveInputs", 0.75f);
        }
    }
    public void ParaElDash()
    {
        R_Player.velocity = Vector2.zero;
    }
    public void DevuelveInputs()
    {
        En_Inputs.BlockButtons = false;
    }
}