using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desplazamiento : MonoBehaviour
{
    public Inputs En_Inputs;

    //Se Controla desde el modo de juego.
    [HideInInspector]
    public float FuerzaDesplazamiento;
    public float ContadorDesplazamiento;
    public float ContadorDefaultDesplazamiento;

    private bool right;
    private bool left;

    public float CadenciaDash;
    private bool puedeDashear = true;

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
        if (left || right)
        {
            EjecutoDesplazamiento();
        }

    }
    //Update
    void LecturaInputs()
    {
        if (puedeDashear)
        {
            if (En_Inputs.BH_Dash && En_Inputs.BH_Right)
            {
                left = false;
                right = true;
                En_Inputs.BlockButtons = true;
            }
            if (En_Inputs.BH_Dash && En_Inputs.BH_Left)
            {
                right = false;
                left = true;
                En_Inputs.BlockButtons = true;
            }
        }

    }
    //FixedUpdate
    private void EjecutoDesplazamiento()
    {
        if (ContadorDesplazamiento <= 0)
        {
            left = false;
            right = false;
            En_Inputs.BlockButtons = false;
            En_Inputs.QuitForces = false;
            puedeDashear = false;
            ContadorDesplazamiento = ContadorDefaultDesplazamiento;
            Invoke("In_CadenciaDash", CadenciaDash);

            rb.velocity = Vector2.zero;
        }
        else
        {
            ContadorDesplazamiento -= Time.deltaTime;
            if (left)
            {
                rb.velocity = Vector2.left * FuerzaDesplazamiento;
            }
            if (right)
            {
                rb.velocity = Vector2.right * FuerzaDesplazamiento;
            }
        }
    }
    //Invokes
    private void In_CadenciaDash()
    {
        puedeDashear = true;
    }
}
