using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public bool BH_Right;
    public bool BH_Left;


    //Por donde ira la guardia del block y el hit
    public bool B_GuardUp;        
    public bool B_GuardMid;

    //Modos de juego//True: Guard//False: Exploration
    public bool BD_PlayMode;

    public bool BH_Jump;
    public bool BD_Jump;
    //FUE REEMPLAZADO POR UN GETKEYUP(KEYCODE.SPACE) en el script de SALTO
    //public bool BU_Jump; 

    public bool BH_Block;
    public bool BD_Block;
    public bool BU_Block;

    public bool BD_Attack;

    public bool BH_Dash;

    //Bloqueo de botones
    public bool BlockButtons = false;
    public bool BD_BlockJump = false;
    public bool QuitForces = false;

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

            if (BD_PlayMode)
            {
                Guard();
            }

            Block();

            if (!BD_BlockJump)
            {
                Jump();
            }

            Hit();

            Dash();

        }
        if (BlockButtons && QuitForces) 
        {
            BH_Left = false;
            BH_Right = false;
            BH_Dash = false;
        }
    }
    void Axis()
    {
        BH_Left = Input.GetButton("Left");
        BH_Right = Input.GetButton("Right");
    }
    void ModePlay()
    {
        if (Input.GetButtonDown("ModePlay"))
        {
            if (BD_PlayMode)
            {
                BD_PlayMode = false;

                //Por defecto al volver a Guard, la guardia esta en mid
                B_GuardUp = false;
                B_GuardMid = true;
            }
            else
            {
                BD_PlayMode = true;
                B_GuardUp = false;
                B_GuardMid = true;
            }
        }
    }
    void Guard()
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
    void Jump()
    {
        BD_Jump = Input.GetButtonDown("Jump");
        BH_Jump = Input.GetButton("Jump");
    }

    void Dash()
    {
        BH_Dash = Input.GetButton("Dash");
    }
    
    void Hit()
    {
        if (Input.GetButtonDown("Attack"))
        {
            BD_Attack = true;
        }
    }
    void Block()
    {
        BH_Block = Input.GetButton("Block");
        BD_Block = Input.GetButtonDown("Block");
        BU_Block = Input.GetButtonUp("Block");
    }
}




