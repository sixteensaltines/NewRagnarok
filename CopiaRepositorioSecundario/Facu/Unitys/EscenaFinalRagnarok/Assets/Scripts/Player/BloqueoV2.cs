using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueoV2 : MonoBehaviour
{
    public Inputs En_Inputs;

    [HideInInspector]
    public bool ActivarAnimacionEscudo;

    public bool EscudoActivo;

    private void Update()
    {
        DondeEstaElEscudo();
    }
    void DondeEstaElEscudo()
    {
        if (En_Inputs.BH_Block)
        {
            ActivarAnimacionEscudo= true;
        }
        else
        {
            ActivarAnimacionEscudo = false;
            EscudoActivo = false;
        }
    }
    //Lo activa la animacion
    void ActivarEscudo()
    {
        if (ActivarAnimacionEscudo)
        {
            EscudoActivo = true;
        }
    }
}


