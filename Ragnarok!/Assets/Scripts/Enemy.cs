using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Health;
    public Text caca;
    private void Awake()
    {
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
    }
    void Update()
    {
        caca.text = "health: " + Health.ToString();
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        Debug.Log("Daño = "+ Damage);
    }
   
}
