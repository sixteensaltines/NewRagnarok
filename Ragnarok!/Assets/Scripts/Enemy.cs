using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        Debug.Log("Daño = "+ Damage);
    }
   
}
