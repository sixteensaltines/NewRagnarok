using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadMovimiento;
    public float velocidadRotacion;



    float h;
    float v;

    private Rigidbody rb;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");


    }
    private void FixedUpdate()
    {
        if (v > 0.1f || v < -0.1f)
        {
            rb.velocity = v * transform.forward *
                velocidadMovimiento;
        }
        if (h > 0.1f || h < -0.1f)
        {
            rb.angularVelocity = h * Vector3.up *
                velocidadRotacion;
        }
    }
}
