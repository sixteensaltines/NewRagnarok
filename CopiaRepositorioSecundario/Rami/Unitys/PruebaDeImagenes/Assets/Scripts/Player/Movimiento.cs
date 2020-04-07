using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    
    public Inputs En_Inputs;

    public float Speed;
    private float fixedSpeed;
    public float velocity;

    public void Update()
    {
        fixedSpeed = Speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (En_Inputs.BH_Right)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + velocity, transform.position.y), fixedSpeed);
        }
        if (En_Inputs.BH_Left)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - velocity, transform.position.y), fixedSpeed);
        }
    }

    //QBO

    
    /*private Rigidbody2D rb;
    public Inputs En_Inputs;
    public Vector2 v_Movement;
    public float Speed = 10.0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        v_Movement = new Vector2(En_Inputs.B_AxisHorizontal, 0);
    }
    private void FixedUpdate()
    {   //Movimiento
        moveCharacter(v_Movement);
    }

    //Movimiento
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * Speed * Time.deltaTime));
    }*/



    //FACU

    /*  //Enlaces
    public Inputs En_Inputs;

    private Rigidbody2D rb;

    private Vector2 v_DirectionMov;
    public float _SpeedMov = 10.0f;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        DirectionMov();
    }
    private void FixedUpdate()
    {
        CharacterMov(v_DirectionMov);
    }
    void DirectionMov()
    {
        if (En_Inputs.B_Right)
        {
            v_DirectionMov = new Vector2(1, 0);
        }
        if (En_Inputs.B_Left)
        {
            v_DirectionMov = new Vector2(-1, 0);
        }
        if (!En_Inputs.B_Left && !En_Inputs.B_Right)
        {
            v_DirectionMov = new Vector2(0, 0);
        }
    }
    void CharacterMov(Vector2 direction)
    {
            rb.MovePosition((Vector2)transform.position + (v_DirectionMov * _SpeedMov * Time.deltaTime));
    }*/
}
