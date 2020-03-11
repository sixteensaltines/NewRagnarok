using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{   
    
    public Inputs En_Inputs;
    [SerializeField] private float _cooldownTimer;  //Tiempo hasta que se pueda atacar denuevo
    public Transform T_AttackPosition;
    public LayerMask _WhatIsEnemy;          //En esta capa se asignan los enemigos
    public float _AttackCd = 1.5f;          //Intervalo entre ataques
    public float _AttackRange;              //Rango del ataque
    public float _Damage;                   //Daño del Ataque

    void Update()
    {
        if (En_Inputs.B_PlayMode == false)
        {
            StartAttack();
        }
        //Pone el Timer en 0 si se cambia a modo guardia
        else
        {
            _cooldownTimer = 0;
        }
    }
    private void StartAttack()
    {
        if (_cooldownTimer <= 0 && En_Inputs.B_Attack==true&& En_Inputs.B_PlayMode ==false)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(T_AttackPosition.position, _AttackRange, _WhatIsEnemy);
            //este for aplica una instancia de daño a todo lo que golpee
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
            //la funcion "Take damage" la estaba usando para probar si funcionaba, la dejo porque puede servir
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(_Damage);
            }
            En_Inputs.B_Attack = false;
            _cooldownTimer = _AttackCd;
        }
        if (_cooldownTimer>0) 
        {
            _cooldownTimer -= Time.deltaTime;
            En_Inputs.B_Attack = false;
        }
    }
    //esto dibuja un gizmos en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(T_AttackPosition.position,_AttackRange);
    }

}
