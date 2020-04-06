using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Vida : MonoBehaviour
{
    public float PlayerHP= 20;
    public Text HPText;

    private void Awake()
    {
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
    }
    void Update()
    {
        HPText.text = "Health: "+ PlayerHP.ToString();
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
