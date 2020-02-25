using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public Inputs En_Inputs;

    public float FuerzaDash;
    public bool SeEstaMoviendo = false;
    Rigidbody2D R_Player;

    void Start()
    {
        R_Player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (En_Inputs.B_Dash)
        {
            SeEstaMoviendo = true;
            R_Player.velocity = Vector2.right * FuerzaDash;
            En_Inputs.B_Dash = false;         
            Invoke("CheckMov", 0.75f);

        }

    }
    public void CheckMov()
    {
        SeEstaMoviendo = false;
        R_Player.velocity = Vector2.zero;
    }
}
