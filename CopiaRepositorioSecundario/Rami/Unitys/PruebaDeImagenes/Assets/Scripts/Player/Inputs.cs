using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public bool BH_Right;
    public bool BH_Left;

    public bool PlayMode;

    public bool BH_Jump;
    public bool BD_Jump;

    public bool BH_Block;
    public bool BD_Block;
    public bool BU_Block;

    public bool BD_Attack;
    public bool BlockAtack;

    public bool BH_Dash;

    //Bloqueo de botones
    public bool BlockButtons = false;
    public bool BD_BlockJump = false;
    public bool QuitForces = false;

    void Update()
    {
        if (!BlockButtons)
        {
            Axis();
            Block();
            Dash();

            if (!BD_BlockJump)
            {
                Jump();
            }

            if (!BlockAtack)
            {
                Attack();
            }

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
    void Jump()
    {
        BD_Jump = Input.GetButtonDown("Jump");
        BH_Jump = Input.GetButton("Jump");
    }
    void Dash()
    {
        BH_Dash = Input.GetButton("Dash");
    }
    void Attack()
    {
        BD_Attack = Input.GetButtonDown("Attack");
    }
    void Block()
    {
        BH_Block = Input.GetButton("Block");
        BD_Block = Input.GetButtonDown("Block");
        BU_Block = Input.GetButtonUp("Block");
    }
}




