using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoDeJuego : MonoBehaviour
{
    public Inputs En_Inputs;

    public float VelMovimientoExp;
    public float VelMovimientoGuard;

    public float FuerzaDesplazamientoExp;
    public float FuerzaDesplazamientoGuard;

    public float TiempoDesplazamientoExp;
    public float TiempoDesplazamientoGuard;

    public Movimiento En_Movimiento;
    public Desplazamiento En_Desplazamiento;

    private bool puedeCambiarLadoSkin;

    private void Start()
    {
        En_Inputs.BD_BlockJump = false;
        puedeCambiarLadoSkin = true;
        En_Movimiento.Speed = VelMovimientoExp;
        En_Desplazamiento.FuerzaDesplazamiento = FuerzaDesplazamientoExp;
        En_Desplazamiento.ContadorDefaultDesplazamiento = TiempoDesplazamientoExp;
    }
    void Update()
    {
        if (En_Inputs.BD_PlayMode)
        {
            LecturaMODO();
        }

        if (puedeCambiarLadoSkin)
        {
            CambiaDeLadoSkin();
        }
    }
    void LecturaMODO()
    {
        if (En_Inputs.PlayMode)
        {
            En_Inputs.BD_BlockJump = true;
            puedeCambiarLadoSkin = false;
            En_Movimiento.Speed = VelMovimientoGuard;
            En_Desplazamiento.FuerzaDesplazamiento = FuerzaDesplazamientoGuard;
            En_Desplazamiento.ContadorDefaultDesplazamiento = TiempoDesplazamientoGuard;
        }
        else
        {
            En_Inputs.BD_BlockJump = false;
            puedeCambiarLadoSkin = true;
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
