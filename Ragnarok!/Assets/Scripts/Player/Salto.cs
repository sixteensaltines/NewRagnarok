using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public Inputs En_Inputs;
    public float FuerzaDeSalto;
    public Transform T_Pies;
    public LayerMask LayerPiso;
    public bool Suelo;
    public bool CoolDownJump = true;

    private float Radio = 0.34f;

    
    Rigidbody2D R_player;
    void Start()
    {
        R_player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Physics2D.OverlapCircle(T_Pies.position, Radio, LayerPiso))
        {
            Suelo = true;
        }
        else
        {
            Suelo = false;
        }        
        if (En_Inputs.B_Jump && Suelo && CoolDownJump)
        {
            R_player.velocity = Vector2.up * FuerzaDeSalto;
            CoolDownJump = false;
            En_Inputs.B_Jump = false;
            Invoke("CoolDownInvoke", 1f);
        }


        if (R_player.velocity.y <= -0.1f)
        {
            R_player.gravityScale = 2.5f;
        }
        else
        {
            R_player.gravityScale = 1;
        }

        
        if (!Suelo)
        {
            En_Inputs.BlockButtons = true;
        }
        else
        {
            En_Inputs.BlockButtons = false;
        }

    }
    public void CoolDownInvoke()
    {
        CoolDownJump = true;
    }
}
