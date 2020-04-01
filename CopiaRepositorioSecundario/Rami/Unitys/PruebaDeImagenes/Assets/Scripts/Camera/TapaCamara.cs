using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapaCamara : MonoBehaviour
{
    private SpriteRenderer sprite;

    //public GameObject LoadingObj;
    [Range(0, 1)]
    public float Transparencia = 20000;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(-35.5f, 3.9f, 0f);

    }
    void Update()
    {
        Transparencia -= Time.deltaTime / 10f;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Transparencia);
    }
}
