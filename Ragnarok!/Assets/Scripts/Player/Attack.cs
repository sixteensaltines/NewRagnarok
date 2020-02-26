using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float _timebetweenattacks;

    public float _StartTimeBetweenAttack;
    public float _AttackRange;
    public int _Damage;

    public Transform T_AttackPosition;
    public LayerMask whatIsEnemies;
    

    void Update(){
        if (_timebetweenattacks<=0)
        {     
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(T_AttackPosition.position,_AttackRange, whatIsEnemies);
                //este for aplica una instancia de daño a todo lo que golpee
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                 //la funcion "Take damage" la estaba usando para probar si funcionaba, la dejo porque puede servir
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(_Damage);
                

                }
                
            }
            _timebetweenattacks = _StartTimeBetweenAttack;

        }
        else { _timebetweenattacks -= Time.deltaTime; }
        
    }

    //esto dibuja un gizmos en el editor cuando se estan cambiando las opciones del ataque para ver el rango
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(T_AttackPosition.position,_AttackRange);
    }

}
