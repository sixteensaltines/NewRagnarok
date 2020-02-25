using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{   
    public float B_AxisHorizontal;

    //Por donde ira la guardia del block y el hit
    public bool B_GuardUp;
    public bool B_GuardMid;

    //Modos de juego//True: Guard//False: Exploration
    public bool B_PlayMode;

    public bool B_Jump;
    public bool B_Hit;
    public bool B_Block;
    public bool B_Dash;

    //Bloqueo de botones basico
    public bool BlockButtons = false;

    private void Start()
    {
        B_GuardMid = true;
    }
    void Update()
    {
        if (!BlockButtons)
        {
            Axis();
            ModePlay();
            Guard();
            Block();
            Jump();           
            Hit();
            Dash();
        }
        if (BlockButtons)
        {
            B_AxisHorizontal = 0.0f;
        }
    }
    public void Axis()
    {
        B_AxisHorizontal = Input.GetAxis("Horizontal");
    }
    public void ModePlay()
    {
        if (Input.GetButtonDown("ModePlay"))
        {
            if (B_PlayMode)
            {
                //TODO: Creo que hay un error en esto. 
                B_PlayMode = false;
                //Por defecto al volver a Guard, la guardia esta en mid
                B_GuardUp = false;
                B_GuardMid = true;
            }
            else
            {
                B_PlayMode = true;
            }
        }
    }
    public void Guard()
    {
        if (Input.GetButtonDown("GuardUp"))
        {
            B_GuardMid = false;
            B_GuardUp = true;
        }
        if (Input.GetButtonDown("GuardMid"))
        {
            B_GuardUp = false;
            B_GuardMid = true;
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            B_Jump = true;
        }
    }

    public void Dash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            B_Dash = true;
        }
    }
    
    public void Hit()
    {
        if (Input.GetButtonDown("Hit"))
        {
            B_Hit = true;
        }
    }
    public void Block()
    {
        if (Input.GetButton("Block"))
        {
            B_Block = true;
        }
        else
        {
            B_Block = false;
        }
    }
}




