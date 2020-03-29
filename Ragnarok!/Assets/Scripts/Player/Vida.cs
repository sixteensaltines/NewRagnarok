using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float PlayerHP= 20;

    void Update()
    {
        if (PlayerHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float Damage)
    {
        PlayerHP -= Damage;
        Debug.Log("Daño = " + Damage);
    }
}
