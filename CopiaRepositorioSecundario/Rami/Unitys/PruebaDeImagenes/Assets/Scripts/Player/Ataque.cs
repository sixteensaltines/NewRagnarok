using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public LayerMask WhatIsEnemies;
    public Inputs En_Inputs;
    public Transform T_AttackPosition;

    public float SetCooldown = 1.5f;
    [SerializeField] private float cooldownTimer;
    public float AttackRange;
    public float Damage;


    void Update()
    {
        StartAttack();
    }
    private void StartAttack()
    {
        if (cooldownTimer <= 0 && En_Inputs.BD_Attack == true && En_Inputs.BD_PlayMode == false)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(T_AttackPosition.position, AttackRange, WhatIsEnemies);
            //este for aplica una instancia de daño a todo lo que golpee
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                //la funcion "Take damage" la estaba usando para probar si funcionaba, la dejo porque puede servir
                enemiesToDamage[i].GetComponent<Enemigo>().TakeDamage(Damage);
            }
            En_Inputs.BD_Attack = false;
            cooldownTimer = SetCooldown;
        }
        else
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            En_Inputs.BD_Attack = false;
        }
    }
    //esto dibuja un gizmos en el editor cuando se estan cambiando las opciones del ataque para ver el rango
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(T_AttackPosition.position, AttackRange);
    }

}
