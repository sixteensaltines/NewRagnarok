using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public Inputs En_Inputs;

    public Transform T_Centro;
    public Transform T_RayoMedio;
    public Transform T_RayoArriba;
    public Transform T_RayoAtras;

    private Vector2 V_Centro;

    private Vector2 Rayito;
    public float CasteoRayo;

    public RaycastHit2D hit;

    //Escudo de frente

    public float CuentaAtrasDefault_Frente;
    public float CuentaAtras_Frente;

    public bool ActivarContador_Frente;

    public bool ActivarEscudo_Frente;

    //EscudoAtras

    public bool PrimerToque = true;
    public bool EsperaSegundoToque;
    public bool SegundoToque;


    private bool ActivarContador_Atras;

    public bool ActivarBloquear_Atras;
    private bool CancelaEscudo_Atras;

    public float CuentaAtras_Atras;
    public float CuentaAtrasDefault_Atras;


    private void Update()
    {
        V_Centro = new Vector2(T_Centro.position.x, T_Centro.position.y);

        DondeEstaElEscudo();
    }
    void DondeEstaElEscudo()
    {
        if (En_Inputs.BH_Block)
        {
            ActivarContador_Frente = true;



            if (SegundoToque)
            {
                ActivarContador_Atras = false;

                if (!CancelaEscudo_Atras)
                {
                    ActivarBloquear_Atras = true;

                    Rayito = new Vector2(T_RayoAtras.position.x, T_RayoAtras.position.y);

                    Picking();
                    DibujarRayo();
                }
            }

            ContadorEscudo_Frente_Atras();

            if (ActivarEscudo_Frente && !ActivarBloquear_Atras)
            {
                if (En_Inputs.BH_Block && En_Inputs.B_GuardMid)
                {
                    Rayito = new Vector2(T_RayoMedio.position.x, T_RayoMedio.position.y);
                }
                if (En_Inputs.BH_Block && En_Inputs.B_GuardUp)
                {
                    Rayito = new Vector2(T_RayoArriba.position.x, T_RayoArriba.position.y);
                }
                Picking();
                DibujarRayo();
            }
        }
        else
        {
            CuentaAtras_Frente = CuentaAtrasDefault_Frente;
            ActivarContador_Frente = false;
            ActivarEscudo_Frente = false;

        }
        if (En_Inputs.BD_Block)
        {
            if (PrimerToque && En_Inputs.BD_PlayMode)
            {
                EsperaSegundoToque = true;
                ActivarContador_Atras = true;
                CancelaEscudo_Atras = false;
                PrimerToque = false;
                CuentaAtras_Atras = CuentaAtrasDefault_Atras;
            }
        }
        if (En_Inputs.BU_Block)
        {
            if (EsperaSegundoToque)
            {
                SegundoToque = true;
                EsperaSegundoToque = false;
            }
            if (En_Inputs.BU_Block && ActivarBloquear_Atras)
            {
                PrimerToque = true;
                SegundoToque = false;
                EsperaSegundoToque = false;
                ActivarBloquear_Atras = false;
                CancelaEscudo_Atras = true;
            }

        }
    }
    void ContadorEscudo_Frente_Atras()
    {
        //Escudo Frente

        if (ActivarContador_Frente)
        {
            CuentaAtras_Frente -= Time.deltaTime;
        }
        if (CuentaAtras_Frente <= 0)
        {
            ActivarEscudo_Frente = true;
        }

        //Escudo atras

        if (ActivarContador_Atras)
        {
            CuentaAtras_Atras -= Time.deltaTime;
        }
        if (CuentaAtras_Atras <= 0)
        {
            CancelaEscudo_Atras = true;
            ActivarContador_Atras = false;

            PrimerToque = true;
            SegundoToque = false;
            EsperaSegundoToque = false;
            ActivarBloquear_Atras = false;
        }
    }
    void Picking()
    {
        hit = Physics2D.Linecast(V_Centro, Rayito, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                //AccionAGolpeEnemigo
            }
            else
            {
                //AccionAGolpeEnemigo
            }
        }
    }
    void DibujarRayo()
    {
        if (hit.collider != null)
        {
            Debug.DrawLine(T_Centro.position, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(V_Centro, Rayito, Color.blue);
        }
    }


}
