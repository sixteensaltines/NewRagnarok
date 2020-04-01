using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{


    private GameObject Go;
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Ground"));
        {*/ 
            GameObject.Destroy(gameObject); 
        //}
    }
    void Update()
    {
        
    }
}