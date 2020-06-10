using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoDeJuego : MonoBehaviour
{
    public Inputs En_Inputs;
    public Movimiento En_Movimiento;
    public Desplazamiento En_Desplazamiento;

    public bool PlayMode;

    public float VelMovimientoExp;
    public float VelMovimientoGuard;

    public float FuerzaDesplazamientoExp;
    public float FuerzaDesplazamientoGuard;

    public float TiempoDesplazamientoExp;
    public float TiempoDesplazamientoGuard;

    private void Start()
    {
        En_Inputs.BlockJump = false;
        En_Movimiento.Speed = VelMovimientoExp;
        En_Desplazamiento.FuerzaDesplazamiento = FuerzaDesplazamientoExp;
        En_Desplazamiento.ContadorDefaultDesplazamiento = TiempoDesplazamientoExp;
    }
    void Update()
    {
        LecturaMODO();
        CambiaDeLadoSkin();
    }
    void LecturaMODO()
    {
        if (PlayMode)
        {
            En_Inputs.BlockJump = true;
            En_Inputs.BlockAttack = false;
            En_Movimiento.Speed = VelMovimientoGuard;
            En_Desplazamiento.FuerzaDesplazamiento = FuerzaDesplazamientoGuard;
            En_Desplazamiento.ContadorDefaultDesplazamiento = TiempoDesplazamientoGuard;
        }
        else
        {
            En_Inputs.BlockJump = false;
            En_Inputs.BlockAttack = true;
            En_Movimiento.Speed = VelMovimientoExp;
            En_Desplazamiento.FuerzaDesplazamiento = FuerzaDesplazamientoExp;
            En_Desplazamiento.ContadorDefaultDesplazamiento = TiempoDesplazamientoExp;
        }
    }
    void CambiaDeLadoSkin()
    {
        if (En_Inputs.BH_Right)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (En_Inputs.BH_Left)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
