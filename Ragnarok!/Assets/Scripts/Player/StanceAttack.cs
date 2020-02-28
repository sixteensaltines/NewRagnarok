using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceAttack : MonoBehaviour
{
    public Inputs En_Inputs;
    [SerializeField] private float _cooldownTimer;  //Contador hasta poder atacar denuevo
    
    public Transform T_AttackPositionUp;     
    public LayerMask _EnemiesUp;            //En esta capa se asignan los enemigos
    public float _AttackCdUp;               //Intervalo entre ataque
    public float _AttackRangeUp;            //Rango del ataque
    public float _DamageUp;                 //Daño del ataque
    
    public Transform T_AttackPositionMid;
    public LayerMask _EnemiesMid;        
    public float _AttackCdMid;            
    public float _AttackRangeMid;        
    public float _DamageMid;             
    void Update()
    {
        if (En_Inputs.B_PlayMode == true)
        {
            AttackUp();
            AttackMid();
        }
        else { _cooldownTimer = 0; }
    }

    void AttackUp()
    {
        if (En_Inputs.B_PlayMode == true && En_Inputs.B_GuardUp == true && En_Inputs.B_Attack&&_cooldownTimer<=0)
        {
            Collider2D[] AttackUp = Physics2D.OverlapCircleAll(T_AttackPositionUp.position, _AttackRangeUp, _EnemiesMid);
            for (int i = 0; i < AttackUp.Length; i++)
            {
                AttackUp[i].GetComponent<Enemy>().TakeDamage(_DamageUp);
            }

            En_Inputs.B_Attack = false;
            _cooldownTimer = _AttackCdUp;
        }
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            En_Inputs.B_Attack = false;
        }
        
    }
    void AttackMid()
    {
        if (En_Inputs.B_PlayMode == true && En_Inputs.B_GuardMid == true && En_Inputs.B_Attack && _cooldownTimer <= 0)
        {
            Collider2D[] AttackMid = Physics2D.OverlapCircleAll(T_AttackPositionMid.position, _AttackRangeMid, _EnemiesMid);
            for (int h = 0; h < AttackMid.Length; h++)
            {
                AttackMid[h].GetComponent<Enemy>().TakeDamage(_DamageMid);
            }

            En_Inputs.B_Attack = false;
            _cooldownTimer = _AttackCdMid;
        }
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            En_Inputs.B_Attack = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(T_AttackPositionUp.position, _AttackRangeUp);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(T_AttackPositionMid.position, _AttackRangeMid);
    }
}
