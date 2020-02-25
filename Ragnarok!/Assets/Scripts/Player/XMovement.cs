using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMovement : MonoBehaviour
{
    public float _Speed = 10.0f;
    public Rigidbody2D _Rb;
    public Inputs En_Inputs;
    public Vector2 v_Movement;
    void Start()
    {
        _Rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        v_Movement = new Vector2(En_Inputs.B_AxisHorizontal, 0);
    }

    private void FixedUpdate()
    {
        moveCharacter(v_Movement);
        { }
    }

    void moveCharacter(Vector2 direction)
    {
        _Rb.MovePosition((Vector2)transform.position + (direction * _Speed * Time.deltaTime));
    }
}
