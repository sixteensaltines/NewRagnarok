using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Inputs En_Inputs;

    public float Speed;
    public float velocity;

    private void FixedUpdate()
    {
        if (En_Inputs.BH_Right)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + velocity, transform.position.y), Speed * Time.deltaTime);
        }
        if (En_Inputs.BH_Left)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - velocity, transform.position.y), Speed * Time.deltaTime);
        }
    }
}
