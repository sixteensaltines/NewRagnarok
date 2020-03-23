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

    public LayerMask Enemigo;

    //public float _Damage;

    public float RangoManos;

    private void Update()
    {
        Lectura();
    }

    void Lectura()
    {
        if (En_BloqueoV2.ActivarEscudo_Frente || En_BloqueoV2.ActivarEscudo_Atras || En_Inputs.BD_Attack)
        {
            /*Collider2D[] LecturaEnemigo = Physics2D.OverlapCircleAll(t_ManosPosition.position, RangoManos, Enemigo);
            Lee todo lo que este dentro del rango (TODAS LAS CAPAS) 
            for (int i = 0; i < LecturaEnemigo.Length; i++)
            {

                la funcion "Take damage" la estaba usando para probar si funcionaba, la dejo porque puede servir
                LecturaEnemigo[i].GetComponent<Enemigo>().TakeDamage(_Damage);
            }*/
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
        if (En_BloqueoV2.ActivarEscudo_Atras)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(T_ManosAtras.position, RangoManos);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(T_ManosAtras.position, RangoManos);
        }
        if (En_Inputs.BD_Attack)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(T_ManosFrente.position, RangoManos);
        }
    }
}
