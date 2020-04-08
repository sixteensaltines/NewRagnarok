using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueV2 : MonoBehaviour
{
    public Inputs En_Inputs;

    public float RafagaDefault;     
    private float rafaga;

    public float TiempoMinEntreGolpes;
    private bool activarContador;

    public bool PuedeGolpear = true;

    public float TiempoMaxComboDefault;
    private float tiempoMaxCombo;

    public float TiempoReinicioCombo;

    [HideInInspector]
    public bool ActivarAtaque;

    private void Start()
    {
        rafaga = RafagaDefault;
        tiempoMaxCombo = TiempoMaxComboDefault;
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
            tiempoMaxCombo = TiempoMaxComboDefault;
            En_Inputs.BlockAtack = true;
            En_Inputs.BD_Attack = false;
            Invoke("In_TiempoEntreGolpes", TiempoMinEntreGolpes);
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
            tiempoMaxCombo -= Time.deltaTime;
        }
        if (rafaga < 1)
        {
            activarContador = false;
            if (tiempoMaxCombo > 0)
            {

                Invoke("In_ReiniciarCombo", TiempoReinicioCombo);
            }
        }
        if (tiempoMaxCombo < 0)
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
        tiempoMaxCombo = TiempoMaxComboDefault;
        PuedeGolpear = true;
        En_Inputs.BlockAtack = false;
        En_Inputs.BD_Attack = false;
        rafaga = RafagaDefault;
    }
}
