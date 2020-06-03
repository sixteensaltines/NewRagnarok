using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueoV2 : MonoBehaviour
{
    public Inputs En_Inputs;

    private bool ActivarContador_Frente;
    public float Contador_Frente;
    public float TiempoDefault_Frente;

    [HideInInspector]
    public bool ActivarEscudo_Frente;

    private void Update()
    {
        DondeEstaElEscudo();
        ControladorContador_Frente();
    }
    void DondeEstaElEscudo()
    {
        if (En_Inputs.BH_Block)
        {
            ActivarContador_Frente = true;
        }
        if(!En_Inputs.BH_Block)
        {
            ActivarContador_Frente = false;
            Contador_Frente = TiempoDefault_Frente;
            ActivarEscudo_Frente = false;
        }
    }
    void ControladorContador_Frente()
    {
        if (ActivarContador_Frente)
        {
            Contador_Frente -= Time.deltaTime;
        }
        if (Contador_Frente <= 0)
        {
            ActivarEscudo_Frente = true;
        }
    }
}


