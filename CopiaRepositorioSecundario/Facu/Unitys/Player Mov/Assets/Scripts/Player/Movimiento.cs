using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    #region Public Inputs En_Inputs
    [Tooltip("Enlase con el script de Inputs")]
    public Inputs En_Inputs;
    #endregion

    #region public float Speed
    [Tooltip("Velocidad a la que se mueve el player en eje Horizontal")]
    public float Speed;
    #endregion

    private void FixedUpdate()
    {
        if (En_Inputs.BH_Right)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 0.8f, transform.position.y), Speed * Time.deltaTime);
        }
        if (En_Inputs.BH_Left)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 0.8f, transform.position.y), Speed * Time.deltaTime);
        }
    }
}
