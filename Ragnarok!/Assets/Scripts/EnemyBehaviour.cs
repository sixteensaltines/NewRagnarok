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

    private RaycastHit2D hit;
    private RaycastHit2D hit2;
    [SerializeField] private Transform target;
    [SerializeField] private float distance;
    [SerializeField] private bool attackMode;
    [SerializeField] private bool inRange;
    [SerializeField] private bool cooling;
    [SerializeField] private float intTimer;
    private void Awake()
    {
        intTimer = timer;
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
        else if (attackDistance>= distance && cooling == false)
        {
            Attack();
            Block();
        }
    }
    void Move()
    {
        Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    void Block()
    {
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
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
