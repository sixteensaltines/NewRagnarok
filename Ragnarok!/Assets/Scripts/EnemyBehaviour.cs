using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    //esto es l ode ataque y  queda asi hasta tener animaciones y probar nuevo metodo
    public Transform AttackPosition;
    public Transform AttackPosition2;
    public float AttackRange = 10.0f;
    public LayerMask PlayerLayer;
    public float Damage = 10.0f;
    [SerializeField]private float TimeBtwAttack = 0f;
    public float StartTimeBtwAttack = 2.0f;
    //
    
    private RaycastHit2D hit;
    private RaycastHit2D hit2;
    [SerializeField] private Transform target;
    [SerializeField] private float distance;
    [SerializeField] private bool attackMode;
    [SerializeField] private bool inRange;
    [SerializeField] private bool cooling;
    [SerializeField] private float intTimer;
    private Animator animator;
    private void Awake()
    {
        intTimer = timer;
        /* esto llama al animador pegado al enemigo
        animator = GetComponent<Animator>();*/
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
        }
    }
    void Update()
    {
        if(inRange == true)
        { 
            hit = Physics2D.Raycast(rayCast.position, Vector2.left , rayCastLength, raycastMask);
            hit2= Physics2D.Raycast(rayCast.position, Vector2.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }
        if(hit.collider != null || hit2.collider !=null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null || hit2.collider ==null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            // Acá se agrega la animacion "idle" si hay una o un punto para parar todas las animaciones ya que el enemigo esta estatico
            StopAttack();
        }
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance>= distance && cooling == false && TimeBtwAttack<=0)
        {
            Attack();
        }
        if (TimeBtwAttack >= 0)
        {
            TimeBtwAttack -= Time.deltaTime;
        }
        
        if (cooling)
        {
            //Detener la animacion de ATAQUE 
        }
    }
    void Move()
    {
        //Se puede agregar un IF para checkear que no se este reproduciendo la animacion de ataque antes de que se empieze a mover
        //Reproducir animacion de MOVIMIENTO
        Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        Collider2D[] caca = Physics2D.OverlapCircleAll(AttackPosition2.position, AttackRange, PlayerLayer);
        for (int i = 0; i < caca.Length; i++)
        {  
            caca[i].GetComponent<Vida>().TakeDamage(Damage);
        }
        Collider2D[] LecturaEnemigo = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange, PlayerLayer);
        for (int i = 0; i < LecturaEnemigo.Length; i++)
        { 
            LecturaEnemigo[i].GetComponent<Vida>().TakeDamage(Damage);
        }
        TimeBtwAttack = StartTimeBtwAttack;
        // timer = intTimer;
        attackMode = true;
        //Reproducir la animacion de ATAQUE
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        //Detener la animacion de ataque
    }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
            Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
            Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.green);
        }
    }
}
