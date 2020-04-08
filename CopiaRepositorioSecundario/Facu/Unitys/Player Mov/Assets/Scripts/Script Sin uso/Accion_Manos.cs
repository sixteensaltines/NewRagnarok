using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accion_Manos : MonoBehaviour
{
    public BloqueoV2 En_BloqueoV2;
    public AtaqueV2 En_AtaqueV2;
    public Inputs En_Inputs;

    public Transform T_ManosFrente;
    public Transform T_ManosAtras;

    #region LECTURA_DE_MANOS_VARIABLES(DESACTIVADO)
    /*public LayerMask Enemigo;

    public float _Damage;*/
    #endregion

    public float RangoManos;

    private void Update()
    {
        Lectura();
    }

    void Lectura()
    {
        if (En_BloqueoV2.ActivarEscudo_Frente/* || En_BloqueoV2.ActivarEscudo_Atras */|| En_Inputs.BD_Attack)
        {
            #region LECTURA_DE_LAYES_EN_MANOS_(DESACTIVADO)
            /*Collider2D[] LecturaEnemigo = Physics2D.OverlapCircleAll(t_ManosPosition.position, RangoManos, Enemigo);
            Lee todo lo que este dentro del rango (TODAS LAS CAPAS) 
            for (int i = 0; i < LecturaEnemigo.Length; i++)
            {

                la funcion "Take damage" la estaba usando para probar si funcionaba, la dejo porque puede servir
                LecturaEnemigo[i].GetComponent<Enemigo>().TakeDamage(_Damage);
            }*/
            #endregion
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (En_BloqueoV2.ActivarEscudo_Frente)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(T_ManosFrente.position, RangoManos);

        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(T_ManosFrente.position, RangoManos);
        }

        #region DIBUJAR_MANO_ATRAS(DESACTIVADO)
        /*if (En_BloqueoV2.ActivarEscudo_Atras)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(T_ManosAtras.position, RangoManos);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(T_ManosAtras.position, RangoManos);
        }*/
        #endregion

        if (En_Inputs.BD_Attack)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(T_ManosFrente.position, RangoManos);
        }
    }
}
