using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMode : MonoBehaviour
{
    public GameObject ParticleExit;
    public GameObject PrefaBala;

    public Transform canion;

    public bool dispara; 
    public float velocidadBala = 1.0f;

    private bool PuedeDisparar = true;
    public float TiempoCadencia = 1.0f;
    void Start()
    {
        //GO = GetComponent<GameObject>();
    }


    void Update()
    {
        bool dispara = Input.GetButtonDown("Fire");
        if (dispara && PuedeDisparar)
        {
            Instantiate(ParticleExit, transform.position,transform.rotation);

            var bala = GameObject.Instantiate(PrefaBala, canion.position, canion.rotation);

            var rb = bala.GetComponent<Rigidbody>();

            rb.velocity = canion.transform.forward * velocidadBala;

            PuedeDisparar = false;

            Invoke("TiempoDisparo", TiempoCadencia);
            //Destroy(GameObject);
        }
    }

    void TiempoDisparo()
    {
        PuedeDisparar = true;
    }
}
