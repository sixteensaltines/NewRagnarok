using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public Inputs En_Inputs;
    public Transform T_Pies;
    public LayerMask LayerPiso;
    public bool Suelo;
    public bool CoolDownJump = true;

    public float FuerzaDeSaltoActual;
    public float FuerzaDeSaltoMinima;
    public float FuerzaDeSaltoMaxima;
    public float TiempoDeCargaMaximo = 0.25f;

    private float Radio = 0.34f;

    private float VelocidadDeCarga;


    Rigidbody2D R_player;
    void Start()
    {
        R_player = GetComponent<Rigidbody2D>();

        VelocidadDeCarga = (FuerzaDeSaltoMaxima - FuerzaDeSaltoMinima) / TiempoDeCargaMaximo;
        FuerzaDeSaltoActual = FuerzaDeSaltoMinima;
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

        
        if (En_Inputs.B_JumpHold && Suelo && CoolDownJump)
        {
            FuerzaDeSaltoActual += VelocidadDeCarga * Time.deltaTime;
        }
        if(En_Inputs.B_JumpUp && Suelo && CoolDownJump)
        {
            EjecucionDeSaltoMantenido();
        }
        if(FuerzaDeSaltoActual >= FuerzaDeSaltoMaxima && Suelo && CoolDownJump)
        {
            FuerzaDeSaltoActual = FuerzaDeSaltoMaxima;
            EjecucionDeSaltoMantenido();
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
            En_Inputs.B_JumpHold = false;
        }
        else
        {
            En_Inputs.BlockButtons = false;
        }
    }

    public void EjecucionDeSaltoMantenido()
    {
        R_player.velocity = Vector2.up * FuerzaDeSaltoActual;
        CoolDownJump = false;
        En_Inputs.B_Jump = false;
        Invoke("CoolDownInvoke", 1f);
    }
    public void CoolDownInvoke()
    {
        CoolDownJump = true;
        FuerzaDeSaltoActual = FuerzaDeSaltoMinima;
    }
}
