using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RompeExplosion : MonoBehaviour
{
    private float TiempoEspera = 2.0f;

    private void Update()
    {
        Invoke("Romper", TiempoEspera);
    }

    void Romper()
    {
        GameObject.Destroy(gameObject);

    }
}
