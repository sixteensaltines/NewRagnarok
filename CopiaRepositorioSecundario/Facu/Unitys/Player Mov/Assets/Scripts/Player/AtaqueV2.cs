using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueV2 : MonoBehaviour
{
    public Inputs En_Inputs;

    private float rafaga;
    public float RafagaDefault;
    public float TiempoEntreGolpes;
    private bool activarContador;

    public bool PuedeGolpear = true;

    private float tiempoCombo;
    public float TiempoComboDefault;
    public float TiempoReinicioCombo;

    [HideInInspector]
    public bool ActivarAtaque;
    private void Start()
    {
        rafaga = RafagaDefault;
        tiempoCombo = TiempoComboDefault;
    }
    private void Update()
    {
        LecturaGolpes();
        ControlCombo();
    }
    void LecturaGolpes()
    {
        if (En_Inputs.BD_Attack && rafaga>=1 && PuedeGolpear)
        {
            tiempoCombo = TiempoComboDefault;
            En_Inputs.BlockAtack = true;
            En_Inputs.BD_Attack = false;
            Invoke("In_TiempoEntreGolpes", TiempoEntreGolpes);
            rafaga--;
        }
    }
    void ControlCombo()
    {
        if (rafaga <= 2 && rafaga > 1)
        {
            activarContador = true;
        }
        if (activarContador)
        {
            tiempoCombo -= Time.deltaTime;
        }
        if (rafaga < 1)
        {
            activarContador = false;
            if (tiempoCombo > 0)
            {

                Invoke("In_ReiniciarCombo", TiempoReinicioCombo);
            }
        }
        if (tiempoCombo < 0)
        {
            En_Inputs.BlockAtack = true;
            En_Inputs.BD_Attack = false;
            activarContador = false;
            PuedeGolpear = false;
            Invoke("In_ReiniciarCombo", TiempoReinicioCombo);
        }
    }
    public void In_TiempoEntreGolpes()
    {
        En_Inputs.BlockAtack = false;
    }
    void In_ReiniciarCombo()
    {
        tiempoCombo = TiempoComboDefault;
        PuedeGolpear = true;
        En_Inputs.BlockAtack = false;
        En_Inputs.BD_Attack = false;
        rafaga = RafagaDefault;
    }
}
