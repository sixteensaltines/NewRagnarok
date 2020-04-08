using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desplazamiento : MonoBehaviour
{
    public Inputs En_Inputs;

    //Se Controla desde el modo de juego.
    [HideInInspector]
    public float FuerzaDesplazamiento;
    [HideInInspector]
    public float ContadorDesplazamiento;
    [HideInInspector]
    public float ContadorDefaultDesplazamiento;

    private bool Derecha;
    private bool izquierda;

    public float CadenciaDash;
    private bool puedeDesplazarse = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ContadorDesplazamiento = ContadorDefaultDesplazamiento;
    }
    private void Update()
    {
        LecturaInputs();
    }

    private void FixedUpdate()
    {
        if (izquierda || Derecha)
        {
            EjecutoDesplazamiento();
        }
    }
    //Update
    void LecturaInputs()
    {
        if (puedeDesplazarse)
        {
            if (En_Inputs.BH_Dash && En_Inputs.BH_Right)
            {
                izquierda = false;
                Derecha = true;
                En_Inputs.BlockButtons = true;
            }
            if (En_Inputs.BH_Dash && En_Inputs.BH_Left)
            {
                Derecha = false;
                izquierda = true;
                En_Inputs.BlockButtons = true;
            }
        }

    }
    //FixedUpdate
    private void EjecutoDesplazamiento()
    {
        if (ContadorDesplazamiento <= 0)
        {
            izquierda = false;
            Derecha = false;
            En_Inputs.BlockButtons = false;
            En_Inputs.QuitForces = false;
            puedeDesplazarse = false;
            ContadorDesplazamiento = ContadorDefaultDesplazamiento;
            Invoke("In_CadenciaDash", CadenciaDash);

            rb.velocity = Vector2.zero;
        }
        else
        {
            ContadorDesplazamiento -= Time.deltaTime;
            if (izquierda)
            {
                rb.velocity = Vector2.left * FuerzaDesplazamiento;
            }
            if (Derecha)
            {
                rb.velocity = Vector2.right * FuerzaDesplazamiento;
            }
        }
    }
    //Invokes
    private void In_CadenciaDash()
    {
        puedeDesplazarse = true;
    }
}
