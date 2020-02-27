using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LayerMask _WhatIsEnemies;
    public Inputs En_Inputs;
    public Transform T_AttackPosition;


    public float _SetCooldown = 1.5f;
    [SerializeField] private float _cooldownTimer;
    public float _AttackRange;
    public float _Damage;

    
    void Update()
    { 
        StartAttack();
    }
    private void StartAttack()
    {
        if (_cooldownTimer <= 0 && En_Inputs.B_Attack==true)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(T_AttackPosition.position, _AttackRange, _WhatIsEnemies);
            //este for aplica una instancia de daño a todo lo que golpee
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
            //la funcion "Take damage" la estaba usando para probar si funcionaba, la dejo porque puede servir
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(_Damage);
            }
            En_Inputs.B_Attack = false;
            _cooldownTimer = _SetCooldown;
        }
        else 
        {
            if (_cooldownTimer>0) 
            {
                _cooldownTimer -= Time.deltaTime;
            }
            En_Inputs.B_Attack = false;
        }
    }
    //esto dibuja un gizmos en el editor cuando se estan cambiando las opciones del ataque para ver el rango
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(T_AttackPosition.position,_AttackRange);
    }

}
