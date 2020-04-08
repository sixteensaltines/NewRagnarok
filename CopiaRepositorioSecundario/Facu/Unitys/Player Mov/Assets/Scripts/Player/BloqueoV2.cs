using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BloqueoV2 : MonoBehaviour
{
    public Inputs En_Inputs;

    //Escudo de frente
    private bool ActivarContador_Frente;
    public float Contador_Frente;
    public float TiempoDefault_Frente;


    [HideInInspector]
    public bool ActivarEscudo_Frente;

    #region VARIABLES_DE_ESCUDO_ATRAS(DESACTIVADO)
    /*EscudoAtras

    private bool primerToque = true;
    private bool esperaSuelte;
    private bool esperaSegundoToque;

    private bool ActivarContador_Atras;
    public float Contador_Atras;
    public float TiempoDefault_Atras;

    [HideInInspector]
    public bool ActivarEscudo_Atras;*/
    #endregion 

    private void Update()
    {
        DondeEstaElEscudo();
        ControladorContador_Frente();

        #region CONTADOR_ESCUDO_ATRAS(DESACTIVADO)
        //ControladorContador_Atras();
        #endregion

    }
    void DondeEstaElEscudo()
    {
        #region ACTIVADOR_ESCUDO_ATRAS(DESACTIVADO)

        //Activar Escudo Atras
        /*if (En_Inputs.BD_Block && primerToque && En_Inputs.PlayMode)
        {
            Contador_Atras = TiempoDefault_Atras;
            ActivarContador_Atras = true;
            primerToque = false;
            esperaSuelte = true;
        }
        if (En_Inputs.BU_Block && esperaSuelte)
        {
            esperaSuelte = false;
            esperaSegundoToque = true;
        }
        if (En_Inputs.BH_Block && Contador_Atras > 0 && esperaSegundoToque)
        {
            ActivarEscudo_Atras = true;
            ActivarContador_Atras = false;

            //AccionesLayerAtras
        }

        //Reinicio despues de activar BlockBack
        if (ActivarEscudo_Atras && !En_Inputs.BH_Block)
        {
            primerToque = true;
            esperaSegundoToque = false;
            ActivarEscudo_Atras = false;
        }*/
        #endregion

        //Activar Escudo Frente
        if (En_Inputs.BH_Block /*&& !ActivarEscudo_Atras*/)
        {
            ActivarContador_Frente = true;
        }
        if(!En_Inputs.BH_Block /*&& !ActivarEscudo_Atras*/)
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
    #region CONTADOR_ESCUDO_ATRAS(DESACTIVADO)
    /*void ControladorContador_Atras()
    {
        if (ActivarContador_Atras)
        {
            Contador_Atras -= Time.deltaTime;
        }
        if (Contador_Atras <= 0)
        {
            primerToque = true;
            esperaSegundoToque = false;

            ActivarContador_Atras = false;
        }
    }*/
    #endregion
}


